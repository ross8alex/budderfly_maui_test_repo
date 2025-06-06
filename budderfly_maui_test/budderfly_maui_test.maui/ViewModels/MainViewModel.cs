﻿using Budderfly_MAUI_Test.Models;
using Budderfly_MAUI_Test.Repositories;
using Budderfly_MAUI_Test.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budderfly_MAUI_Test.ViewModels
{
    [QueryProperty(nameof(RowsAdded), nameof(RowsAdded))]
    public class MainViewModel : BaseViewModel
    {
        private EnergySavingTipDAL EnergySavingTipDAL;

        private ObservableCollection<EnergySavingTip> energySavingTips { get; set; }
        private string rowsAdded { get; set; }

        public Command AddNewTipClicked { get; }

        public ObservableCollection<EnergySavingTip> EnergySavingTips
        {
            get
            {
                return energySavingTips;
            }
            set
            {
                energySavingTips = value;
                OnPropertyChanged(nameof(EnergySavingTips));
            }
        }

        public string RowsAdded
        {
            get
            {
                return rowsAdded;
            }
            set
            {
                rowsAdded = value;
                //If we return to this page with a new id, add this new item to the list
                if (!string.IsNullOrEmpty(rowsAdded) && rowsAdded != 0.ToString())
                    RefreshTips();
                OnPropertyChanged(nameof(RowsAdded));
            }
        }

        public MainViewModel(EnergySavingTipDAL energySavingTipDAL)
        {
            EnergySavingTipDAL = energySavingTipDAL;

            AddNewTipClicked = new Command(AddNewTip);

            CreateTipsIfNone();
            RefreshTips();
        }

        public async void CreateTipsIfNone()
        {
            //If nothing exists in the database, get defaults from json file
            if(EnergySavingTipDAL.GetTipsCount() == 0)
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("energy_saving_tips.json");
                using var reader = new StreamReader(stream);

                //Deserialize json into list of tips
                List<EnergySavingTip> tips = JsonConvert.DeserializeObject<List<EnergySavingTip>>(reader.ReadToEnd());

                //Save all deserialized tips
                EnergySavingTipDAL.InsertAllEnergySavingTips(tips);
            }
        }

        public void RefreshTips()
        {
            EnergySavingTips = new ObservableCollection<EnergySavingTip>(EnergySavingTipDAL.GetEnergySavingTips());
        }

        public async void AddNewTip()
        {
            await Shell.Current.GoToAsync(nameof(EnergySavingTipEntryPage));
        }
    }
}
