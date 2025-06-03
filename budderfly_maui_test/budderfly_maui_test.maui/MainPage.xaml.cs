using Budderfly_MAUI_Test.ViewModels;

namespace Budderfly_MAUI_Test
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            BindingContext = mainViewModel;
        }
    }

}
