using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SampleDisplayActionSheet.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SampleDisplayActionSheet.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        public Command ShowNormalDisplayAction { get; set; }
        public Command ShowCustomDisplayAction { get; set; }
        private string _selectedText;
        public string SelectedText
        {
            get => _selectedText;
            set => SetProperty(ref _selectedText, value);
        }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            ShowNormalDisplayAction = new Command(ExecuteShowNormalDisplayAction);
            ShowCustomDisplayAction = new Command(ExecuteShowCustomDisplayAction);
        }

        private async void ExecuteShowCustomDisplayAction(object obj)
        {
            var result = await CustomDisplayAlert.ShowDialogAsync("Meta products", "Choose one Meta product", "Facebook", "Whatsapp", "Instagram");
            if (result != null)
                SelectedText = $"Custom select : {result}";
        }

        private async void ExecuteShowNormalDisplayAction(object obj)
        {
            var result = await Application.Current.MainPage.DisplayActionSheet("Choose one Meta product", "Cancel", null, "Facebook", "Whatsapp", "Instagram");
            if (result != null)
                SelectedText = $"Normal select : {result}";
        }
    }
}
