using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.Globalization;
using Dajbych.Demo6.Models;

namespace Dajbych.Demo6.Converters {
    [ValueConversion(typeof(Machine), typeof(Uri))]
    public class MachineToUriConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value != null) {
                var machine = value as Machine;
                if (machine != null) {
                    return new Uri(machine.Url);
                } else {
                    throw new ArgumentException("Type Machine expected.");
                }
            } else {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new Exception("One way only.");
        }

    }
}
