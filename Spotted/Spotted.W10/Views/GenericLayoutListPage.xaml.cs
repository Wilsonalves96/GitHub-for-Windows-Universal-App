//---------------------------------------------------------------------------
//
// <copyright file="GenericLayoutListPage.xaml.cs" company="Microsoft">
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
    public sealed partial class GenericLayoutListPage : Page
    {
        public GenericLayoutListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, GenericLayout1Schema>(new GenericLayoutConfig());
            this.InitializeComponent();
        }

        public ListViewModel<DynamicStorageDataConfig, GenericLayout1Schema> ViewModel { get; set; }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();

            base.OnNavigatedTo(e);
        }

    }
}
