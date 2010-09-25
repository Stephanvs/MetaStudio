using System;
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.Practices.Composite.Regions;
using Hayman.Client.Infrastructure.Core;

namespace Hayman.Client.Infrastructure.RegionAdapters
{
    public class DesktopRegionAdapter : RegionAdapterBase<IDesktop>
    {
        public DesktopRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, IDesktop regionTarget)
        {
            //region.Views.CollectionChanged += (sender, e) =>
            //{
            //    if (e.Action == NotifyCollectionChangedAction.Add)
            //    {
            //        foreach (var item in e.NewItems)
            //        {
            //            if (item is Desktop)
            //            {
            //                regionTarget.Tabs.Add((RibbonTabItem)item);
            //            }
            //        }
            //    }
            //};
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}
