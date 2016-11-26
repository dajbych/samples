using System.Globalization;
using System.Linq;
using System.Text;

namespace MsFest2016 {
    public class Descriptor {

        public const int FeaturesCount = 6;

        protected readonly string value;

        public Descriptor(string value) {
            this.value = value;
        }

        public string Value {
            get {
                return value;
            }
        }

        public double CoutOfAts {
            get {
                return (from ch in value where ch == '@' select ch).Count();
            }
        }

        public double CoutOfDiacriticChars {
            get {
                return (
                    from ch in value.Normalize(NormalizationForm.FormD)
                    let unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(ch)
                    where unicodeCategory == UnicodeCategory.NonSpacingMark
                    select ch
                ).Count();
            }
        }

        public double CoutOfDots {
            get {
                return (from ch in value where ch == '.' select ch).Count();
            }
        }

        public double CoutOfExclamationMarks {
            get {
                return (from ch in value where ch == '!' select ch).Count();
            }
        }

        public double CoutOfQuotationMarks {
            get {
                return (from ch in value where ch == '"' select ch).Count();
            }
        }

        public double CoutOfQuestionMarks {
            get {
                return (from ch in value where ch == '?' select ch).Count();
            }
        }

        public double[] ToInputVector() {
            return new[] { CoutOfAts, CoutOfDiacriticChars, CoutOfDots, CoutOfExclamationMarks, CoutOfQuestionMarks, CoutOfQuotationMarks };
        }

        public override string ToString() {
            return value;
        }

    }
}