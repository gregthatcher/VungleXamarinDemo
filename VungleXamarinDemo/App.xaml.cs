using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace VungleXamarinDemo
{
    public partial class App : Application
    {
        public static IVungleInterface Vungle { get; private set; }

        public App(IVungleInterface vungle)
        {
            InitializeComponent();
            Vungle = vungle;

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
