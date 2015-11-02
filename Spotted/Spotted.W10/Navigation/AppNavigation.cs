using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AppStudio.Uwp.Navigation;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;

namespace Spotted.Navigation
{
    public class AppNavigation
    {
        private NavigationNode _active;

        static AppNavigation()
        {

        }

        public NavigationNode Active
        {
            get
            {
                return _active;
            }
            set
            {
                if (_active != null)
                {
                    _active.IsSelected = false;
                }
                _active = value;
                if (_active != null)
                {
                    _active.IsSelected = true;
                }
            }
        }


        public ObservableCollection<NavigationNode> Nodes { get; private set; }

        public void LoadNavigation()
        {
            Nodes = new ObservableCollection<NavigationNode>();
		    var resourceLoader = new ResourceLoader();
            Nodes.Add(new ItemNavigationNode
            {
                Title = @"Spotted",
                Label = "Home",
                FontIcon = "\ue10f",
                IsSelected = true,
                NavigationInfo = NavigationInfo.FromPage("HomePage")
            });

            Nodes.Add(new ItemNavigationNode
            {
                Label = "Home",
                FontIcon = "\ue185",
                NavigationInfo = NavigationInfo.FromPage("HomeListPage")
            });
            Nodes.Add(new GroupNavigationNode
            {
                Label = "Regiões",
                Visibility = Visibility.Visible,
                FontIcon = "\ue10c",
                Nodes = new ObservableCollection<NavigationNode>()
                {
                    new ItemNavigationNode
                    {
                        Label = "Generic Layout",
                        FontIcon = "\ue1d3",
                        NavigationInfo = NavigationInfo.FromPage("GenericLayoutListPage")
                    },
                    new ItemNavigationNode
                    {
                        Label = "Photo Layout",
                        FontIcon = "\ue1d3",
                        NavigationInfo = NavigationInfo.FromPage("PhotoLayoutListPage")
                    },
                    new ItemNavigationNode
                    {
                        Label = "Text Layout",
                        FontIcon = "\ue12a",
                        NavigationInfo = NavigationInfo.FromPage("TextLayoutListPage")
                    },
                }
            });
            Nodes.Add(new ItemNavigationNode
            {
                Label = resourceLoader.GetString("NavigationPaneAbout"),
                FontIcon = "\ue11b",
                NavigationInfo = NavigationInfo.FromPage("AboutPage")
            });
            Nodes.Add(new ItemNavigationNode
            {
                Label = resourceLoader.GetString("NavigationPanePrivacy"),
                FontIcon = "\ue1f7",
                NavigationInfo = new NavigationInfo()
                {
                    NavigationType = NavigationType.DeepLink,
                    TargetUri = new Uri("http://appstudio.windows.com/home/appprivacyterms", UriKind.Absolute)
                }
            });
        }

        public NavigationNode FindPage(Type pageType)
        {
            return GetAllItemNodes(Nodes).FirstOrDefault(n => n.NavigationInfo.NavigationType == NavigationType.Page && n.NavigationInfo.TargetPage == pageType.Name);
        }

        private IEnumerable<ItemNavigationNode> GetAllItemNodes(IEnumerable<NavigationNode> nodes)
        {
            foreach (var node in nodes)
            {
                if (node is ItemNavigationNode)
                {
                    yield return node as ItemNavigationNode;
                }
                else if(node is GroupNavigationNode)
                {
                    var gNode = node as GroupNavigationNode;

                    foreach (var innerNode in GetAllItemNodes(gNode.Nodes))
                    {
                        yield return innerNode;
                    }
                }
            }
        }
    }
}
