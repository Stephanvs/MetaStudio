using System;
using Microsoft.Practices.Composite.Presentation.Commands;
using Microsoft.Practices.ServiceLocation;
using Hayman.Client.Infrastructure.Events;
using System.Collections.ObjectModel;
using Hayman.Client.Infrastructure.Logging;
using Hayman.Client.Infrastructure.Messaging;
using Hayman.Client.Presentation.Windows.ViewModels;
using Hayman.Client.Infrastructure.Core;

namespace Hayman.Client.MetaModelModule.ViewModels
{
    public class MetaModelViewModel : WorkspaceWindowViewModel
	{
		private ILogger logger = ServiceLocator.Current.GetInstance<ILogger>();
		private ObservableCollection<MessageLoggedEventPayload> entries = new ObservableCollection<MessageLoggedEventPayload>();

		public MetaModelViewModel() : base("Log")
		{
			Clear = new DelegateCommand(o => Entries.Clear());

			foreach (var msg in logger.Events)
			{
				entries.Add(msg);
			}

			Channel<MessageLoggedEvent, MessageLoggedEventPayload>.Subscribe(m => Entries.Add(m));
		}

		public ObservableCollection<MessageLoggedEventPayload> Entries
		{
			get { return entries; }
		}

		public DelegateCommand Clear { get; set; }
    
    }
}
