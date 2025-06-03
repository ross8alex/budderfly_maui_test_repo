using Budderfly_MAUI_Test.Models;
using Budderfly_MAUI_Test.Repositories;
using Budderfly_MAUI_Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budderfly_MAUI_Test.ViewModels
{
    public class EnergySavingTipEntryViewModel : BaseViewModel
    {
        private EnergySavingTipDAL EnergySavingTipDAL;
        private ImageService ImageService;

        private string title { get; set; }
        private string description { get; set; }
        private bool isValid { get; set; }
        private bool includeRandomImage { get; set; }

        public Command ContinueClicked { get; }
        public Command ToggleIncludeImageClicked { get; }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                IsValid = CheckValidation(Title, Description);
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                IsValid = CheckValidation(Title, Description);
                OnPropertyChanged(nameof(Description));
            }
        }

        public bool IsValid
        {
            get
            {
                return isValid;
            }
            set
            {
                isValid = value;
                OnPropertyChanged(nameof(IsValid));
            }
        }

        public bool IncludeRandomImage
        {
            get
            {
                return includeRandomImage;
            }
            set
            {
                if(includeRandomImage != value)
                    Preferences.Set(nameof(IncludeRandomImage), value);
                
                includeRandomImage = value;
                OnPropertyChanged(nameof(IncludeRandomImage));
            }
        }

        public EnergySavingTipEntryViewModel(EnergySavingTipDAL energySavingTipDAL, ImageService imageService)
        {
            EnergySavingTipDAL = energySavingTipDAL;
            ImageService = imageService;

            //Get user preference for including random image or not from Preferences
            IncludeRandomImage = Preferences.Get(nameof(IncludeRandomImage), true);

            ContinueClicked = new Command(Continue);
            ToggleIncludeImageClicked = new Command(ToggleIncludeImage);
        }

        public EnergySavingTipEntryViewModel()
        {

        }

        public async void Continue()
        {
            //Dummy check in case the Enabled flag on the button doesn't work
            if(!IsValid)
            {
                await Shell.Current.DisplayAlert("Validation Error", "Please complete the title and description to continue.", "Ok");
                return;
            }

            //Save new energy tip
            int RowsAdded = EnergySavingTipDAL.SaveOrUpdateEnergySavingTip(
                new EnergySavingTip() { 
                    EnergyTipTitle = Title, 
                    EnergyTipDescription = Description, 
                    HasImage = IncludeRandomImage, 
                    EnergyTipImage = IncludeRandomImage ? ImageService.GetRandomImage() : string.Empty
                });

            //If no rows were added, notify the user
            if(RowsAdded == 0)
                await Shell.Current.DisplayAlert("Saving Error", "There was an issue saving, please check the entered values and try again.", "Ok");

            //Go back to main page and refresh list with new id
            await Shell.Current.GoToAsync($"..?{nameof(RowsAdded)}={RowsAdded}");

            //Reset for next time
            Title = string.Empty;
            Description = string.Empty;
        }

        public void ToggleIncludeImage()
        {
            IncludeRandomImage = !IncludeRandomImage;
        }

        public bool CheckValidation(string title, string description)
        {
            //Check for continue button enabled state
            return !string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(description);
        }
    }
}
