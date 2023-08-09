using System;
using PhoneNumbers;
using System.Windows.Input;
using PropertyChanged;
using Maui_Flower_App.MVVM.Models;

namespace Maui_Flower_App.MVVM.ViewModels.ClientsRegarding
{
    [AddINotifyPropertyChangedInterface]
    public class AddClientViewModel
    {
        #region Properties

        public Client Client { get; set; }

        #endregion

        public AddClientViewModel()
        {
            Client = new Client();
        }

        #region Commands

        public ICommand Parse => new Command(ParsePhoneNumber);
        public ICommand Save => new Command(CreateClient);

        #endregion

        #region Commands Methods

        public void ParsePhoneNumber()
        {
            PhoneNumber parsedNumber;
            var parsed = PhoneNumbers.PhoneNumber.TryParse(Client.PhoneNumber, CountryInfo.Ukraine ,out parsedNumber);

            Client.PhoneNumber = parsed ? parsedNumber.ToString("E.123") : "incorrect format";
        }

        public void CreateClient()
        {
            if(Client.PhoneNumber == "incorrect format")
                App.Current.MainPage.DisplayAlert("Error", "Incorrect phone number format", "Ok");


        }

        #endregion
    }
}
