using System;
using System.Collections.Generic;
using System.Linq;
using CarouselView.FormsPlugin.Abstractions;
using Spelling2.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spelling2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Spelling2Page : ContentPage
    {
        private readonly IAudioPlayerService _audioPlayerService;
        private string currentWord;

        public Spelling2Page()
        {
            InitializeComponent();

            var faveToolbarItem = new ToolbarItem()
            {
                Text = "Favorite",
                Icon ="fav.png"
            };
            faveToolbarItem.Clicked += FaveToolbarItemOnClicked;
            ToolbarItems.Add(faveToolbarItem);

            _audioPlayerService = DependencyService.Get<IAudioPlayerService>();

            var fontFamily = Device.RuntimePlatform == Device.Android
                ? "RobotoMono-Regular.ttf#Roboto Mono"
                : "Roboto Mono";

            OutputLabel.FontFamily = fontFamily;
            InputEntry.FontFamily = fontFamily;

            var outputTapGestureRecognizer = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };
            outputTapGestureRecognizer.Tapped += OutputTapped;
            OutputLabel.GestureRecognizers.Add(outputTapGestureRecognizer);


            var lettersViewTappedRecognizer = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };
            lettersViewTappedRecognizer.Tapped += LettersView_Tapped;
            LettersView.GestureRecognizers.Add(lettersViewTappedRecognizer);
        }

        private void FaveToolbarItemOnClicked(object sender, EventArgs eventArgs)
        {
            if (!string.IsNullOrEmpty(currentWord))
            {
                (App.Current as App).HomePage.FavPage.AddFavorite(currentWord);
            }
        }

        private void OutputTapped(object sender, EventArgs e)
        {
            InputEntry.IsVisible = true;
            SpellButton.IsVisible = true;

            OutputLabel.IsVisible = false;
            LettersView.IsVisible = false;

            InputEntry.Focus();

            LettersView.Position = 0;
        }

        private void PlaySound_Clicked(object sender, EventArgs e)
        {
            var letter = currentWord.Substring(LettersView.Position, 1).ToUpper();
            _audioPlayerService.Play(letter + ".mp3");
        }

        public void SpellButton_Clicked(object sender, EventArgs e)
        {
            currentWord = InputEntry.Text;
            if(!String.IsNullOrEmpty(currentWord))
            {
                SetWord();
            }
            else
            {
                InputEntry.Focus();
            }
        }

        void SpellingEntry_Completed(object sender, System.EventArgs e)
        {
            currentWord = InputEntry.Text;
            SetWord();
        }

        private void SetWord()
        {
            if (!string.IsNullOrEmpty(currentWord))
            {
                InputEntry.IsVisible = false;
                SpellButton.IsVisible = false;
                var i = 0;
                var letters = currentWord.ToCharArray()
                    .Select(c =>
                    {
                        var a = Letter.Letters.FirstOrDefault(s => s.Char == c.ToString().ToUpper());

                        return new Letter
                        {
                            Char = a.Char,
                            Icao2008 = a.Icao2008,
                            Icao = a.Icao,
                            WikipediaIpa = a.WikipediaIpa
                        };
                    });
                LettersView.ItemsSource = letters;

                HighlightLetter(0);
                LettersView.Position = 0;
                OutputLabel.IsVisible = true;
                LettersView.IsVisible = true;
            }
        }

        private void HighlightLetter(int letterIndex)
        {
            if (letterIndex < currentWord.Length)
            {
                var first = currentWord.Substring(0, letterIndex);
                var hightlighted = currentWord.Substring(letterIndex, 1);
                var second = currentWord.Substring(letterIndex + 1);
                var fs = new FormattedString();
                fs.Spans.Add(new Span { Text = first });
                fs.Spans.Add(new Span { Text = hightlighted, ForegroundColor = Color.Red });
                fs.Spans.Add(new Span { Text = second });
                OutputLabel.FormattedText = fs;
            }
        }

        private void LettersView_ItemSelected(object sender, PositionSelectedEventArgs e)
        {
            HighlightLetter(LettersView.Position);
        }

        private void LettersView_Tapped(object sender, EventArgs e)
        {
            var currentPosition = LettersView.Position;
            if (currentPosition + 1 < currentWord?.Length) LettersView.Position = currentPosition + 1;
        }

        public void SetWord(string selected)
        {
            currentWord = selected;
            SetWord();
        }
    }
}