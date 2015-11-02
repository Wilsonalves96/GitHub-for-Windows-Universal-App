//---------------------------------------------------------------------------
//
// <copyright file="TextLayoutListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/2/2015 2:29:42 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.Rss;
using Spotted.Sections;
using Spotted.ViewModels;

namespace Spotted.Views
{
    public sealed partial class TextLayoutListPage : Page
    {
        public TextLayoutListPage()
        {
            this.ViewModel = new ListViewModel<RssDataConfig, RssSchema>(new TextLayoutConfig());
            this.InitializeComponent();
        }

        public ListViewModel<RssDataConfig, RssSchema> ViewModel { get; set; }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();

            base.OnNavigatedTo(e);
        }

    }
}
