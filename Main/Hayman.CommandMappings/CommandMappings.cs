using System;
using Hayman.Commands;
using Ncqrs.Commanding.CommandExecution.Mapping.Fluent;
using Hayman.Domain;
using Ncqrs;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Eventing.Storage;
using Hayman.CommandExecutors;

namespace Hayman
{
    public class CommandMappings
    {
        public static void Initialize()
        {
            NcqrsEnvironment.SetDefault<ICommandService>(InitializeCommandService());

            Map.Command<CreateMetaModel>()
                .ToAggregateRoot<MetaModel>()
                .CreateNew(c => new MetaModel(c.Name));                
            Map.Command<AddMetaitem>()
                .ToAggregateRoot<MetaModel>()
                .WithId(c => c.Id)
                .ToCallOn((c, a) => a.AddMetaitem(c.Id, c.Name));
            Map.Command<AddMetaAssociation>()
                .ToAggregateRoot<MetaModel>()
                .WithId(c => c.Id)
                .ToCallOn((c, a) => a.AddMetaAssociation(c.Id, c.Source, c.Target));
        }

        private static ICommandService InitializeCommandService()
        {
            var service = new Ncqrs.Commanding.ServiceModel.CommandService();

            service.RegisterExecutor<CreateMetaModel>(new CreateMetaModelExecutor());
            service.RegisterExecutor<AddMetaitem>(new AddMetaitemExecutor());
            service.RegisterExecutor<AddMetaAssociation>(new AddMetaAssociationExecutor());

            CommandMappings.Initialize();

            return service;
        }
    }
}