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
            BuildLocalizedApplicationBar();
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (NavigationContext.QueryString.ContainsKey("bookmarkUrl"))
            {
                string url = NavigationContext.QueryString["bookmarkUrl"];
                SiteUrl.Text = url;

                OpenSite(url);
            }
        }

        // Sample code for building a localized ApplicationBar
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarBackButtonText;
            ApplicationBar.Buttons.Add(appBarButton);

            appBarButton.Click += appBarButton_Click;

            //// Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemBookmark);
            ApplicationBar.MenuItems.Add(appBarMenuItem);

            appBarMenuItem.Click += appBarMenuItem_Click;

        }

        void appBarMenuItem_Click(object sender, EventArgs e)
        {
            if (WebBrowserWindow.Source == null)
            {
                MessageBox.Show("Please load site first");
                return;
            }

            var title = "Unknown";
            try
            {
               title = WebBrowserWindow.InvokeScript("eval", "document.title").ToString();
            }
            catch{}

            var uri = WebBrowserWindow.Source.ToString();
            
            Bookmarks.Add(title, uri);
        }

        /// <summary>
        /// TODO comments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void appBarButton_Click(object sender, EventArgs e)
        {
            if (WebBrowserWindow.CanGoBack)
            {

                WebBrowserWindow.GoBack();
            }
        }

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