using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spelling2.Helpers;

namespace Spelling2.Services
{
    public class LettersStore
    {
        public List<string> GetFavorites()
        {
            string faves = Settings.Favorites;
            if (String.IsNullOrEmpty(faves))
            {
                return new List<string>();
            }
            try
            {
                return faves.Split(',').ToList();
            }
            catch
            {
                return new List<string>();
            }
        }

        public void SaveFavorites(IEnumerable<string> faves)
        {
            Settings.Favorites = String.Join(",", faves);
        }
    }
}
