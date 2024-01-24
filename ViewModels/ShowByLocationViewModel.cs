using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonkeysMVVM.Services;
using MonkeysMVVM.Models;

namespace MonkeysMVVM.ViewModels
{
    internal class ShowByLocationViewModel:ViewModelBase
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                OnPropertyChanged();
            }
        }
        private string location;
        public string Location
        {
            get { return this.location; }
            set
            {
                this.location = value;
                OnPropertyChanged();
            }
        }

        private string imageUrl;
        public string ImageUrl
        {
            get { return this.imageUrl; }
            set
            {
                this.imageUrl = value;
                OnPropertyChanged();
            }
        }
        public string entry;
        public string Entry
        {
            get { return this.entry; }
            set
            {
                this.entry = value;
                OnPropertyChanged();
            }
        }
        public Command GetMonkeyCommand { get; set; }

        public ShowByLocationViewModel()
        {
            GetMonkeyCommand = new Command(GetMonkey);
        }
        private int overAllMonkeys;
        public int OverAllMonkeys
        {
            get { return this.overAllMonkeys; }
            set
            {
                this.overAllMonkeys = value;
                OnPropertyChanged();
            }
        }
        private async void GetMonkey()
        {
            MonkeysService service = new MonkeysService();
            List<Monkey> list = await service.GetMonkeysByLocation(Location);
            OverAllMonkeys = list.Count;
            if (list.Count > 0)
            {
                Name = list[0].Name;
                Location = list[0].Location;
                ImageUrl = list[0].ImageUrl;
            }
            else
            {
                Name = "Not Found!";
                ImageUrl = "";
            }

        }
    }
}
