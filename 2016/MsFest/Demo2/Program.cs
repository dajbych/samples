using Accord.Neuro;
using Accord.Neuro.Learning;
using Accord.Neuro.Networks;
using HtmlAgilityPack;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MsFest2016 {
    public static class Program {

        public static void AddRange<T>(this ConcurrentBag<T> bag, IEnumerable<T> items) {
            foreach (var item in items) {
                bag.Add(item);
            }
        }

        public static void Main(string[] args) {

            // načtení trénovacích dat
            var dataset = new ConcurrentBag<DescriptorWithLabel>();
            Parallel.ForEach(Directory.GetFiles("dataset"), file => {
                var page = new HtmlDocument();
                page.Load(file);
                foreach (var element in page.DocumentNode.Descendants()) {
                    if (element.Name == "a" && (element.Attributes["href"]?.Value ?? string.Empty).StartsWith("mailto:")) {
                        var email = element.Attributes["href"].Value.Substring("mailto:".Length);
                        dataset.Add(new DescriptorWithLabel(email, true));
                    } else if (element.NodeType == HtmlNodeType.Text && element.ParentNode.Name != "script" && element.ParentNode.Name != "style") {
                        foreach (var word in WebUtility.HtmlDecode(element?.InnerText ?? string.Empty).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)) {
                            dataset.Add(new DescriptorWithLabel(word, false));
                        }
                    }
                }               
            });

            var input = (from s in dataset select s.ToInputVector()).ToArray();
            var output = (from s in dataset select s.ToOutputVector()).ToArray();

            // vytvoření sítě
            var network = new DeepBeliefNetwork(Descriptor.FeaturesCount, DescriptorWithLabel.LabelsCount);
            new GaussianWeights(network).Randomize();

            // trénování sítě
            var fineTuneTeacher = new BackPropagationLearning(network);
            for (var i = 1; i <= 10; i++) {
                var error = fineTuneTeacher.RunEpoch(input, output) / dataset.Count;
                Console.WriteLine($" Epocha {i}: {(1 - error) * 100} %");
            }

            // vyčíslení úspěšnosti
            var threshold = 0.33;
            var passed = 0d;
            foreach (var data in dataset) {
                var result = network.Compute(data.ToInputVector());
                if (Math.Abs(result[0] - 1) < threshold && data.IsEmailByRegex || Math.Abs(result[0]) < threshold && !data.IsEmailByRegex) {
                    passed += 1;
                }
            }
            Console.WriteLine($" Úspěšnost {passed / dataset.Count * 100d} %");

            // zkouška
            {
                var test = new Descriptor("@twitter");
                var result = network.Compute(test.ToInputVector());
                Console.WriteLine($" Je \"@twitter\" emailová adresa? {Math.Abs(result[0] - 1) < threshold}");
            }

            Console.ReadKey();
        }

    }
}