//---------------------------------------------------------------------------
//
// <copyright file="PhotoLayoutListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/2/2015 2:29:42 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.DynamicStorage;
using Spotted.Sections;
using Spotted.ViewModels;

namespace Spotted.Views
{
    public sealed partial class PhotoLayoutListPage : Page
    {
        public PhotoLayoutListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, PhotoLayout1Schema>(new PhotoLayoutConfig());
            this.InitializeComponent();
        }

        public ListViewModel<DynamicStorageDataConfig, PhotoLayout1Schema> ViewModel { get; set; }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();

            base.OnNavigatedTo(e);
        }

    }
}
