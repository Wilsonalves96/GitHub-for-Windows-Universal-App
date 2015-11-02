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
    public class GenericLayoutConfig : SectionConfigBase<DynamicStorageDataConfig, GenericLayout1Schema>
    {
        public override DataProviderBase<DynamicStorageDataConfig, GenericLayout1Schema> DataProvider
        {
            get
            {
                return new DynamicStorageDataProvider<GenericLayout1Schema>();
            }
        }

        public override DynamicStorageDataConfig Config
        {
            get
            {
                return new DynamicStorageDataConfig
                {
                    Url = new Uri("http://ds.winappstudio.com/api/data/collection?dataRowListId=6db1e7d0-5216-4519-8978-d51f1452f9f2&appId=7870994b-3130-4d4e-8075-59c2b37aa075"),
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
                return NavigationInfo.FromPage("GenericLayoutListPage");
            }
        }

        public override ListPageConfig<GenericLayout1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<GenericLayout1Schema>
                {
                    Title = "Generic Layout",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Name.ToSafeString();
                        viewModel.SubTitle = item.Surname.ToSafeString();
                        viewModel.Description = "";
                        viewModel.Image = item.Thumbnail.ToSafeString();
                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("GenericLayoutDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<GenericLayout1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, GenericLayout1Schema>>();
                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Name.ToSafeString();
                    viewModel.Title = item.Surname.ToSafeString();
                    viewModel.Description = item.PersonalSummary.ToSafeString();
                    viewModel.Image = item.Image.ToSafeString();
                    viewModel.Content = null;
                });
                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = "Other data";
                    viewModel.Title = "";
                    viewModel.Description = item.Other.ToSafeString();
                    viewModel.Image = "";
                    viewModel.Content = null;
                });
                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = "Detail";
                    viewModel.Title = item.Phone.ToSafeString();
                    viewModel.Description = item.Mail.ToSafeString();
                    viewModel.Image = "";
                    viewModel.Content = null;
                });

                var actions = new List<ActionConfig<GenericLayout1Schema>>
                {
                    ActionConfig<GenericLayout1Schema>.Mail("Mail", (item) => item.Mail.ToSafeString()),
                    ActionConfig<GenericLayout1Schema>.Phone("Phone", (item) => item.Phone.ToSafeString()),
                };

                return new DetailPageConfig<GenericLayout1Schema>
                {
                    Title = "Generic Layout",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Generic Layout"; }
        }
    }
}
