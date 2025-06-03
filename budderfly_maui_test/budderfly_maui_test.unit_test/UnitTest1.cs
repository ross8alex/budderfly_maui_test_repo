using Budderfly_MAUI_Test.Repositories;
using Budderfly_MAUI_Test.Services;
using Budderfly_MAUI_Test.ViewModels;

namespace budderfly_maui_test.unit_test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("Some title", "Some description")]
        public void CheckValidation(string title, string description)
        {
            EnergySavingTipEntryViewModel energySavingTipEntryViewModel = new EnergySavingTipEntryViewModel();

            Assert.True(energySavingTipEntryViewModel.CheckValidation(title, description));
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("", "Some description")]
        [InlineData(null, "Some description")]
        [InlineData("Some title", "")]
        [InlineData("Some title", null)]
        public void CheckMissingValidation(string title, string description)
        {
            EnergySavingTipEntryViewModel energySavingTipEntryViewModel = new EnergySavingTipEntryViewModel();

            Assert.False(energySavingTipEntryViewModel.CheckValidation(title, description));
        }
    }
}
