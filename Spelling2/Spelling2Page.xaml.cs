using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using System;
using Xamarin.Forms.Xaml;

namespace Spelling2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Spelling2Page : ContentPage
    {
        string currentWord;

        public Spelling2Page()
        {
            InitializeComponent();

            //var fontFamily = Device.RuntimePlatform == Device.Android
            //    ? "RobotoMono-Regular.ttf#Roboto Mono"
            //    : "Roboto Mono";

            //OutputLabel.FontFamily = fontFamily;
            //InputEntry.FontFamily = fontFamily;

            var outputTapGestureRecognizer = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };
            outputTapGestureRecognizer.Tapped += OutputTapped;
            OutputLabel.GestureRecognizers.Add(outputTapGestureRecognizer);

            var outputDoubleTapGestureRecognizer = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 2
            };
            outputDoubleTapGestureRecognizer.Tapped += OutputDoubleTapped;
            OutputLabel.GestureRecognizers.Add(outputDoubleTapGestureRecognizer);


            var lettersViewTappedRecognizer = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };
            lettersViewTappedRecognizer.Tapped += LettersView_Tapped;
            LettersView.GestureRecognizers.Add(lettersViewTappedRecognizer);
        }

        private void OutputDoubleTapped(object sender, EventArgs e)
        {
            InputEntry.IsVisible = true;
            SpellButton.IsVisible = true;

            OutputLabel.IsVisible = false;
            LettersView.IsVisible = false;

            LettersView.Position = 0;

        }

        private void OutputTapped(object sender, EventArgs e)
        {
            
        }

        void SpellButton_Clicked (object sender, System.EventArgs e)
        {
            currentWord = InputEntry.Text;
            if(!String.IsNullOrEmpty(currentWord))
            {

                InputEntry.IsVisible = false;
                SpellButton.IsVisible = false;

                var letters = currentWord.ToCharArray()
                                  .Select(c => Letter.Letters.FirstOrDefault(s => s.Char == c.ToString().ToUpper()));
                LettersView.ItemsSource = letters;

                HighlightLetter(0);
                OutputLabel.IsVisible = true;
                LettersView.IsVisible = true;
            }
            else{
                InputEntry.Focus();
            }

        }

        private void HighlightLetter(int letterIndex){
            if( letterIndex < currentWord.Length)
            {
                var first = currentWord.Substring(0, letterIndex);
                var hightlighted = currentWord.Substring(letterIndex, 1);
                var second = currentWord.Substring(letterIndex + 1);
                var fs = new FormattedString();
                fs.Spans.Add(new Span { Text = first });
                fs.Spans.Add(new Span { Text = hightlighted, ForegroundColor = Color.Red });
                fs.Spans.Add(new Span { Text =second});
                OutputLabel.FormattedText = fs;
            }
            else{
                
            }
        }

        void LettersView_ItemSelected(object sender, CarouselView.FormsPlugin.Abstractions.PositionSelectedEventArgs e)
        {
            HighlightLetter(LettersView.Position);   
        }

        private void LettersView_Tapped(object sender, EventArgs e)
        {
            var currentPosition = LettersView.Position;
            if(currentPosition+1 <currentWord?.Length ){
                LettersView.Position = currentPosition + 1;
            }
        }
    }

    public class Letter 
    {
        public static System.Collections.Generic.List<Letter> Letters = new List<Letter>{
            new Letter { Char = "A", Icao2008 = "Alfa", Icao = "[ˈælfʌ]", WikipediaIpa="/ˈælfɑː/ AL-fah" },
                new Letter { Char = "B", Icao2008 = "Bravo", Icao = "[brɑˈvoʊ]", WikipediaIpa="/ˌbrɑːˈvoʊ/ BRAH-VOH" },
                new Letter { Char = "C", Icao2008 = "Charlie", Icao = "[ˈtʃɑ˞li], [ˈʃɑ˞li]", WikipediaIpa="/ˈtʃɑːrliː/ CHAR-lee or /ˈʃɑːrliː/ SHAR-lee" },
                new Letter { Char = "D", Icao2008 = "Delta", Icao = "[ˈdɛltʌ]", WikipediaIpa="/ˈdɛltɑː/ DEL-tah" },
                new Letter { Char = "E", Icao2008 = "Echo", Icao = "[ˈɛkoʊ]", WikipediaIpa="/ˈɛkoʊ/" },
                new Letter { Char = "F", Icao2008 = "Foxtrot", Icao = "[ˈfɑkstrɑt]", WikipediaIpa="/ˈfɒkstrɒt/ FOKS-trot" },
                new Letter { Char = "G", Icao2008 = "Golf", Icao = "[ˈɡʌl(f)]", WikipediaIpa="/ˈɡɒlf/ GOLF" },
                new Letter { Char = "H", Icao2008 = "Hotel", Icao = "[hoʊˈtɛl]", WikipediaIpa="/hoʊˈtɛl/ hoh-TEL" },
                new Letter { Char = "I", Icao2008 = "India", Icao = "[ˈɪndi.ʌ]", WikipediaIpa="/ˈɪndiːɑː/ IN-dee-ah" },
                new Letter { Char = "J", Icao2008 = "Juliett", Icao = "[ˌdʒuliˈɛt]", WikipediaIpa="/ˈdʒuːliːɛt/ JEW-lee-et or /ˌdʒuːliːˈɛt/ JEW-lee-ET" },
                new Letter { Char = "K", Icao2008 = "Kilo", Icao = "[ˈkiloʊ]", WikipediaIpa="/ˈkiːloʊ/ KEE-loh" },
                new Letter { Char = "L", Icao2008 = "Lima", Icao = "[ˈlimʌ]", WikipediaIpa="/ˈliːmɑː/ LEE-mah" },
                new Letter { Char = "M", Icao2008 = "Mike", Icao = "[ˈmʌɪk]", WikipediaIpa="/ˈmaɪk/ MYK" },
                new Letter { Char = "N", Icao2008 = "November", Icao = "[noʊˈvɛmbɹ̩]", WikipediaIpa="/noʊˈvɛmbər/ noh-VEM-bər[15]" },
                new Letter { Char = "O", Icao2008 = "Oscar", Icao = "[ˈɑskɹ̩]", WikipediaIpa="/ˈɒskɑː/ OS-kah" },
                new Letter { Char = "P", Icao2008 = "Papa", Icao = "[pəˈpɑ]", WikipediaIpa="/pɑːˈpɑː/ pah-PAH" },
                new Letter { Char = "Q", Icao2008 = "Quebec", Icao = "[kɛˈbɛk]", WikipediaIpa="/kɛˈbɛk/ ke-BEK" },
                new Letter { Char = "R", Icao2008 = "Romeo", Icao = "[ˈɹoʊmi.oʊ]", WikipediaIpa="/ˈroʊmiːoʊ/ ROH-mee-oh" },
                new Letter { Char = "S", Icao2008 = "Sierra", Icao = "[siˈɛɾʌ]", WikipediaIpa="/siːˈɛrɑː/ see-ERR-ah" },
                new Letter { Char = "T", Icao2008 = "Tango", Icao = "[ˈtæŋɡoʊ]", WikipediaIpa="/ˈtæŋɡoʊ/ TANG-goh" },
                new Letter { Char = "U", Icao2008 = "Uniform", Icao = "[ˈjunɪ̈fɔ˞m], [ˈunɪ̈fɔ˞m]", WikipediaIpa="/ˈjuːniːfɔːrm/ EW-nee-form or /ˈuːniːfɔːrm/ OO-nee-form" },
                new Letter { Char = "V", Icao2008 = "Victor", Icao = "[ˈvɪktəɹ]", WikipediaIpa="/ˈvɪktɑː/ VIK-tah" },
                new Letter { Char = "W", Icao2008 = "Whiskey", Icao = "[ˈwɪski]", WikipediaIpa="/ˈwɪskiː/ WIS-kee" },
                new Letter { Char = "X", Icao2008 = "X-ray or Xray", Icao = "[ˈɛksɹeɪ]", WikipediaIpa="/ˈɛksreɪ/ EKS-ray or /ˌɛksˈreɪ/ EKS-RAY" },
                new Letter { Char = "Y", Icao2008 = "Yankee", Icao = "[ˈjæŋki]", WikipediaIpa="/ˈjæŋkiː/ YANG-kee" },
                new Letter { Char = "Z", Icao2008 = "Zulu", Icao = "[ˈzulu]", WikipediaIpa="/ˈzuːluː/ ZOO-loo" },
                new Letter { Char = "0", Icao2008 = "Zero", Icao = "nan", WikipediaIpa="/ˈziːroʊ/ ZEE-roh /ˌnɑːˌdɑːˌzeɪˈroʊ/ NAH-DAH-ZAY-ROH" },
                new Letter { Char = "1", Icao2008 = "One", Icao = "nan", WikipediaIpa="/ˈwʌn/ WUN /ˌuːˌnɑːˈwʌn/ OO-NAH-WUN" },
                new Letter { Char = "2", Icao2008 = "Two", Icao = "nan", WikipediaIpa="/ˈtuː/ TOO /ˌbiːˌsoʊˈtuː/ BEE-SOH-TOO" },
                new Letter { Char = "3", Icao2008 = "Three", Icao = "nan", WikipediaIpa="/ˈtriː/ TREE /ˌteɪˌrɑːˈtriː/ TAY-RAH-TREE" },
                new Letter { Char = "4", Icao2008 = "Four", Icao = "nan", WikipediaIpa="/ˈfoʊ.ər/ FOH-ər /ˌkɑːrˌteɪˈfoʊ.ər/ KAR-TAY-FOH-ər" },
                new Letter { Char = "5", Icao2008 = "Five", Icao = "nan", WikipediaIpa="/ˈfaɪf/ FYF[17] /ˌpænˌtɑːˈfaɪv/ PAN-TAH-FYV" },
                new Letter { Char = "6", Icao2008 = "Six", Icao = "nan", WikipediaIpa="/ˈsɪks/ SIKS /ˌsɔːkˌsiːˈsɪks/ SOK-SEE-SIKS" },
                new Letter { Char = "7", Icao2008 = "Seven", Icao = "nan", WikipediaIpa="/ˈsɛvɛn/ SEV-en /ˌseɪˌteɪˈsɛvɛn/ SAY-TAY-SEV-en" },
                new Letter { Char = "8", Icao2008 = "Eight", Icao = "nan", WikipediaIpa="/ˈeɪt/ AYT /ˌɔːkˌtoʊˈeɪt/ OK-TOH-AYT" },
                new Letter { Char = "9", Icao2008 = "Nine", Icao = "nan", WikipediaIpa="/ˈnaɪnər/ NY-nər[18] /ˌnɔːvˌeɪˈnaɪnər/ NOV-AY-NY-nər" },
                new Letter { Char = " ", Icao2008 = "Blank", Icao = "Blank", WikipediaIpa="/ˈnaɪnər/ NY-nər[18] /ˌnɔːvˌeɪˈnaɪnər/ NOV-AY-NY-nər" }
        };

        public string Char { get; private set; }
        public string Icao2008 { get; private set; }
        public string Icao { get; private set; }
        public string WikipediaIpa { get; private set; }
    }
}
