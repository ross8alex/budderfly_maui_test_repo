using Budderfly_MAUI_Test.Views;

namespace Budderfly_MAUI_Test
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(EnergySavingTipEntryPage), typeof(EnergySavingTipEntryPage));
        }
    }
}
