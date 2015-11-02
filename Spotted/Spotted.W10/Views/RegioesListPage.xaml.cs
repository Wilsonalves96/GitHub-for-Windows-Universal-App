//---------------------------------------------------------------------------
//
// <copyright file="RegioesListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/2/2015 2:29:42 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.Menu;
using Spotted.Sections;
using Spotted.ViewModels;

namespace Spotted.Views
{
    public sealed partial class RegioesListPage : Page
    {
        public RegioesListPage()
        {
            this.ViewModel = new ListViewModel<LocalStorageDataConfig, MenuSchema>(new RegioesConfig());
            this.InitializeComponent();
        }

        public ListViewModel<LocalStorageDataConfig, MenuSchema> ViewModel { get; set; }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();

            base.OnNavigatedTo(e);
        }

    }
}
