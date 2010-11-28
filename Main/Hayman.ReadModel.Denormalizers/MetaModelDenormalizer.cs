using System;
using Ncqrs.Eventing.ServiceModel.Bus;
using Hayman.Events;
using Hayman.ReadModel.Sql;
using System.Linq;

namespace Hayman.ReadModel.Denormalizers
{
    public class MetaModelDenormalizer : IEventHandler<MetaModelCreated>, IEventHandler<MetaModelDeleted>, IEventHandler<MetaModelRenamed>
    {
        public void Handle(Events.MetaModelCreated e)
        {
            using (var db = new HaymanReadModelEntities())
            {
                MetaModel metaModel = new MetaModel() { MetaModelId = e.MetaModelId, MetaModelName = e.MetaModelName, Deleted = false };
                db.MetaModels.AddObject(metaModel);
                db.SaveChanges();
            }
        }

        public void Handle(MetaModelDeleted e)
        {
            using (var db = new HaymanReadModelEntities())
            {
                MetaModel metaModel = db.MetaModels.SingleOrDefault(m => m.MetaModelId == e.MetaModelId);
                db.MetaModels.DeleteObject(metaModel);
                db.SaveChanges();
            }
        }

        public void Handle(MetaModelRenamed e)
        {
            using (var db = new HaymanReadModelEntities())
            {
                MetaModel metaModel = db.MetaModels.SingleOrDefault(m => m.MetaModelId == e.MetaModelId);
                metaModel.MetaModelName = e.NewMetaModelName;
                db.SaveChanges();
            }
        }
    }
}
