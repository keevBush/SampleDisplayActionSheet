using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleDisplayActionSheet.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseDialog : CallbackPopup
    {
        public BaseDialog(string title, string description, string[] options)
        {
            InitializeComponent();

            TitleLabel.Text = title;
            DescriptionLabel.Text = description;
            list.ItemsSource = options;
        }

        protected override void OnDisappearingAnimationEnd()
        {
            base.OnDisappearingAnimationEnd();
            SetPopupResult(list.SelectedItem);
        }

        private void list_ChildAdded(object sender, ElementEventArgs e)
        {
            var cell = (e.Element as View);
            cell.SizeChanged += Cell_SizeChanged;
        }

        private void Cell_SizeChanged(object sender, EventArgs e)
        {
            if (list.HeightRequest < 300)
            {
                var cell = (sender as View);
                list.HeightRequest += cell.Height;
            }
        }

        private async void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }
    }
}