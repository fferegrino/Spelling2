using Xamarin.Forms;

namespace Spelling2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            IntializeCodedComponents();

            MainPage = new  NavigationPage(new MainPage());
        }

        public MainPage HomePage => (MainPage as NavigationPage)?.CurrentPage as MainPage;

        private void IntializeCodedComponents()
        {
            var hugeFontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 9;
            var notSoHugeFontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.8;
            var biggerFontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 3;

            Current.Resources.Add("Huge", hugeFontSize);
            Current.Resources.Add("Bigger", biggerFontSize);
            Current.Resources.Add("NotSoHuge", notSoHugeFontSize);
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