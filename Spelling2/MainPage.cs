using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messier16.Forms.Controls;
using Xamarin.Forms;

namespace Spelling2
{
    public class MainPage : PlatformTabbedPage
    {
        public Spelling2Page SpellPage { get; }
        public FavoritesPage FavPage { get; }
        private SettingsPage SettingsPage { get; }

        public MainPage()
        {
            SpellPage = new Spelling2Page() { Icon="spell_tab" };
            FavPage = new FavoritesPage(){ Icon = "fav_tab" };
            //SettingsPage = new SettingsPage();

            Children.Add(SpellPage);
            Children.Add(FavPage);
            //Children.Add(SettingsPage);
        }
    }
}
