using Budderfly_MAUI_Test.ViewModels;

namespace Budderfly_MAUI_Test.Views;

public partial class EnergySavingTipEntryPage : ContentPage
{
	public EnergySavingTipEntryPage(EnergySavingTipEntryViewModel energySavingTipEntryViewModel)
	{
		InitializeComponent();
		BindingContext = energySavingTipEntryViewModel;
	}
}