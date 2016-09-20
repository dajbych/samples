using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Dajbych.Demo5.ViewModels;

namespace Dajbych.Demo5.Selectors {
    public class PropertyDataTemplateSelector : DataTemplateSelector {

        public DataTemplate Boeing { get; set; }
        public DataTemplate Airbus { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container) {

            if (item is AirbusViewModel) return Airbus;

            if (item is BoeingViewModel) return Boeing;

            throw new Exception();
        }
    }
}