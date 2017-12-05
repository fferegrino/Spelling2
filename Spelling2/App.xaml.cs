using System;
using Xamarin.Forms;

namespace Spelling2
{
    public partial class App : Application
    {
        static App ()
        {
            
        }

        public App()
        {
            InitializeComponent();
            IntializeCodedComponents();


            MainPage = new NavigationPage( new Spelling2Page());
        }

        private void IntializeCodedComponents()
        {
            var hugeFontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 9;
            var notSoHugeFontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.8;
            var biggerFontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 3;

            App.Current.Resources.Add("Huge", hugeFontSize);
            App.Current.Resources.Add("Bigger", biggerFontSize);
            App.Current.Resources.Add("NotSoHuge", notSoHugeFontSize);
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
