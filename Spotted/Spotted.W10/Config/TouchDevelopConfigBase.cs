using AppStudio.DataProviders.TouchDevelop;

namespace Spotted.Config
{
    public abstract class TouchDevelopConfigBase : ConfigBase<TouchDevelopDataConfig, TouchDevelopSchema>
    {
        public abstract string Title { get; }
    }
}
