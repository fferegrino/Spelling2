﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Spelling2
{
    public class MainPage : TabbedPage
    {
        public Spelling2Page SpellPage { get; }
        public FavoritesPage FavPage { get; }
        private SettingsPage SettingsPage { get; }

        public MainPage()
        {
            SpellPage = new Spelling2Page();
            FavPage = new FavoritesPage();
            //SettingsPage = new SettingsPage();

            Children.Add(SpellPage);
            Children.Add(FavPage);
            //Children.Add(SettingsPage);
        }
    }
}
