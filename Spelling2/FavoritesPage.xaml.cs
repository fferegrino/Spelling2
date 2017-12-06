using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Spelling2.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spelling2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritesPage : ContentPage
    {
        private ObservableCollection<string> Favorites { get; set; }
        private readonly LettersStore _store;

        public FavoritesPage()
        {
            InitializeComponent();
            _store = new LettersStore();
            Favorites = new ObservableCollection<string>(_store.GetFavorites());
            FavesList.ItemsSource = Favorites;
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            string selected = e.Item as string;
            var homePage = (App.Current as App).HomePage;
            homePage.SpellPage.SetWord(selected);
            homePage.CurrentPage = homePage.Children.First();

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        public void AddFavorite(string fave)
        {
            if (Favorites.Contains(fave)) return;
            Favorites.Add(fave);
            _store.SaveFavorites(Favorites);
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            Favorites.Remove(mi.CommandParameter as string);
            _store.SaveFavorites(Favorites);
        }
    }
}
