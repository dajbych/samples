using Accord.Neuro;
using Accord.Neuro.Learning;
using Accord.Neuro.Networks;
using System;
using System.IO;
using System.Linq;

namespace MsFest2016 {
    public static class Program {
        public static void Main(string[] args) {

            /*
             
             NuGet balíčky:
             - Accord.Neuro
               - Accord
               - Accord.Math
               - Accord.Statistics
             
             */

            // načtení trénovacích dat
            var sampleA = (from email in File.ReadAllLines("emails.txt")
                          select new DescriptorWithLabel(email, true));

            var sampleB = (from line in File.ReadAllLines("RUR.txt")
                          from word in line.Split(new[] { " ", "--" }, StringSplitOptions.RemoveEmptyEntries)
                          select new DescriptorWithLabel(word, false));

            var sample = sampleA.Union(sampleB).ToList().AsReadOnly();
            var input = (from s in sample select s.ToInputVector()).ToArray();
            var output = (from s in sample select s.ToOutputVector()).ToArray();

            // vytvoření sítě
            var network = new DeepBeliefNetwork(Descriptor.FeaturesCount, DescriptorWithLabel.LabelsCount);
            new GaussianWeights(network).Randomize();

            // trénování sítě
            var fineTuneTeacher = new BackPropagationLearning(network);
            for (var i = 1; i <= 10; i++) {
                var error = fineTuneTeacher.RunEpoch(input, output) / sample.Count;
                Console.WriteLine($" Epocha {i}: {(1 - error) * 100} %");
            }

            // vyčíslení úspěšnosti
            var threshold = 0.33;
            var passed = 0d;
            foreach (var data in sample) {
                var result = network.Compute(data.ToInputVector());
                if (Math.Abs(result[0] - 1) < threshold && data.IsEmailByRegex || Math.Abs(result[0]) < threshold && !data.IsEmailByRegex) {
                    passed += 1;
                }
            }
            Console.WriteLine($" Úspěšnost {passed / sample.Count * 100d} %");

            // zkouška
            {
                var test = new Descriptor("@twitter");
                var result = network.Compute(test.ToInputVector());
                Console.WriteLine($" Je \"@twitter\" emailová adresa? {result[0]}");
            }

            Console.ReadKey();
        }

    }
}
