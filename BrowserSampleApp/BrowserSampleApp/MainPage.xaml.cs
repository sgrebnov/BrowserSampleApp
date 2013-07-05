using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BrowserSampleApp.Resources;

namespace BrowserSampleApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void OpenSite(string siteUri)
        {
            // arg checking
            if (string.IsNullOrEmpty(siteUri))
            {
                throw  new ArgumentNullException("siteUri uri can not be null or empty");
            }

            WebBrowserWindow.Navigate(new Uri(siteUri, UriKind.Absolute));
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

        /// <summary>
        /// Implements functionality to open site uri in browser control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonGo_OnClick(object sender, RoutedEventArgs e)
        {
            // arg checcking

            if (string.IsNullOrEmpty(SiteUrl.Text))
            {
                MessageBox.Show("Please type site url");
                return;
            }

            OpenSite(SiteUrl.Text);
        }
    }
}