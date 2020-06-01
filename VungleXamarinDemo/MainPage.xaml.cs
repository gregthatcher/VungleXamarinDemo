using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace VungleXamarinDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            App.Vungle.VungleInitializedEvent += Vungle_VungleInitializedEvent;
            App.Vungle.VungleAdLoadedEvent += Vungle_VungleAdLoadedEvent;
            App.Vungle.VungleDiagnosticEvent += Vungle_VungleDiagnosticEvent;
        }

        private void Initialize_Vungle_Button_Click(object sender, EventArgs e)
        {
            App.Vungle.InitializeVungle(this.txtBoxAppId.Text);
        }

        private void Load_Placement_Button_Click(object sender, EventArgs e)
        {
            App.Vungle.LoadAd(this.txtBoxPlacement.Text);
        }

        private void Play_Placement_Button_Click(object sender, EventArgs e)
        {
            App.Vungle.PlayAd(this.txtBoxPlacement.Text);
        }

        private void Vungle_VungleDiagnosticEvent(string message)
        {
            System.Diagnostics.Trace.WriteLine(message);
        }

        private void Vungle_VungleInitializedEvent(bool initialized, List<string> placements, string errorMessage)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                if (initialized)
                {
                    this.btnLoad.IsEnabled = true;
                    this.btnInitialize.IsEnabled = false;
                }
                else
                {
                    await DisplayAlert("Initialization Error", errorMessage, "Cancel");
                }
            });
        }

        private void Vungle_VungleAdLoadedEvent(string placement, bool loaded)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                if (placement.Equals(txtBoxPlacement.Text))
                { 
                    this.btnPlay.IsEnabled = loaded;
                }
            });
        }

    }
}
