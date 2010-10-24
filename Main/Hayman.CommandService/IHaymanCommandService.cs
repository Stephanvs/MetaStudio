using System;
using System.ServiceModel;
using Hayman.Commands;

namespace Hayman.CommandService
{
	[ServiceContract]
	public interface IHaymanCommandService
	{
		[OperationContract]
		void CreateModel(CreateMetaModel command);

		[OperationContract]
		void CreateMetaitem(AddMetaitem command);

		[OperationContract]
		void AddAssociationToMetaitem(CreateMetaAssociation command);
	}
}