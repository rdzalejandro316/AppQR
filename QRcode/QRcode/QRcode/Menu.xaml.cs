﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRcode
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.Master = new MenuItems();

            var homeNavigation = new NavigationPage(new MenuContent());
            homeNavigation.SetValue(NavigationPage.BarBackgroundColorProperty, Color.Black);
            homeNavigation.BarBackgroundColor = Color.FromHex("F44336");
            homeNavigation.BackgroundColor = Color.White;


            this.Detail = homeNavigation;
            App.MasterD = this;
        }


    }
}