using System.Text.RegularExpressions;

namespace MsFest2016 {
    public class DescriptorWithLabel : Descriptor {

        public const int LabelsCount = 1;

        public DescriptorWithLabel(string value, bool label) : base(value) {
            Label = label;
        }

        public bool Label { get; }

        internal bool IsEmailByRegex {
            get {
                return Regex.IsMatch(value, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            }
        }

        public double[] ToOutputVector() {
            return new[] { Label ? 1d : 0d };
        }

        public override string ToString() {
            return base.ToString() + " | " + Label.ToString();
        }

    }
}