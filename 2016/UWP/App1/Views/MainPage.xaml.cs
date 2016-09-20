using App1.ViewModels;
using Windows.UI.Xaml.Controls;

namespace App1 {
    public sealed partial class MainPage : Page {

        public MainPage() {
            InitializeComponent();
            list.DataContext = new ViewModel();
        }

    }
}