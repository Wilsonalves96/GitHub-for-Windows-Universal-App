using System;
using System.Collections.Generic;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.DynamicStorage;
using AppStudio.Uwp;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp.Navigation;
using Windows.Storage;
using Spotted.Config;
using Spotted.ViewModels;

namespace Spotted.Sections
{
    public class PhotoLayoutConfig : SectionConfigBase<DynamicStorageDataConfig, PhotoLayout1Schema>
    {
        public override DataProviderBase<DynamicStorageDataConfig, PhotoLayout1Schema> DataProvider
        {
            get
            {
                return new DynamicStorageDataProvider<PhotoLayout1Schema>();
            }
        }

        public override DynamicStorageDataConfig Config
        {
            get
            {
                return new DynamicStorageDataConfig
                {
                    Url = new Uri("http://ds.winappstudio.com/api/data/collection?dataRowListId=ccd467e1-2fd6-4f13-a0fb-6ca261f872ec&appId=7870994b-3130-4d4e-8075-59c2b37aa075"),
                    AppId = "7870994b-3130-4d4e-8075-59c2b37aa075",
                    StoreId = ApplicationData.Current.LocalSettings.Values[LocalSettingNames.StoreId] as string,
                    DeviceType = ApplicationData.Current.LocalSettings.Values[LocalSettingNames.DeviceType] as string
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("PhotoLayoutListPage");
            }
        }

        public override ListPageConfig<PhotoLayout1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<PhotoLayout1Schema>
                {
                    Title = "Photo Layout",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Name.ToSafeString();
                        viewModel.SubTitle = item.Surname.ToSafeString();
                        viewModel.Description = "";
                        viewModel.Image = item.Thumbnail.ToSafeString();
                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("PhotoLayoutDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<PhotoLayout1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, PhotoLayout1Schema>>();
                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Name.ToSafeString();
                    viewModel.Title = item.Surname.ToSafeString();
                    viewModel.Description = item.PersonalSummary.ToSafeString();
                    viewModel.Image = item.Image.ToSafeString();
                    viewModel.Content = null;
                });

                var actions = new List<ActionConfig<PhotoLayout1Schema>>
                {
                };

                return new DetailPageConfig<PhotoLayout1Schema>
                {
                    Title = "Photo Layout",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Photo Layout"; }
        }
    }
}
