using System;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using DataServicesJSONP;
using Hayman.ReadModel.Sql;
using System.ServiceModel;

namespace Hayman.ReadModelService
{
    [JSONPSupportBehavior]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]   
    public class HaymanReadModelService : DataService<HaymanReadModelEntities>
    {
        // This method is called only once to initialize service-wide policies.        
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
            //This could be "*" and could also be ReadSingle, etc, etc.     
            config.SetServiceOperationAccessRule("GetMetaModels", ServiceOperationRights.AllRead);
            //Set a reasonable paging site    
            config.SetEntitySetPageSize("*", 25);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
            config.UseVerboseErrors = true;
        }

        protected override void OnStartProcessingRequest(ProcessRequestArgs args)
        {
            base.OnStartProcessingRequest(args);
            //Cache for a minute based on querystring     
            HttpCachePolicy c = HttpContext.Current.Response.Cache;
            c.SetCacheability(HttpCacheability.ServerAndPrivate);
            c.SetExpires(HttpContext.Current.Timestamp.AddSeconds(60));
            c.VaryByHeaders["Accept"] = true;
            c.VaryByHeaders["Accept-Charset"] = true;
            c.VaryByHeaders["Accept-Encoding"] = true;
            c.VaryByParams["*"] = true;
        }

        [WebGet]
        public IQueryable<MetaModel> GetMetaModels()
        {
            var metaModels = (from m in CurrentDataSource.MetaModels
                              orderby m.MetaModelId
                              select m);
            return metaModels;
        }
    }
}
