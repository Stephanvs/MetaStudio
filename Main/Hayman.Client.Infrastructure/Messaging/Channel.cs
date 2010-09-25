using System;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Events;

namespace Hayman.Client.Infrastructure.Messaging
{
	public static class Channel<TMessage, TPayload> where TMessage : CompositePresentationEvent<TPayload>
	{
		private static IEventAggregator eventAggregate = ServiceLocator.Current.GetInstance<IEventAggregator>();

		public static void Publish(TPayload message)
		{
			eventAggregate.GetEvent<TMessage>().Publish(message);
		}

		public static SubscriptionToken Subscribe(Action<TPayload> action)
		{
			return eventAggregate.GetEvent<TMessage>().Subscribe(action);
		}

		public static SubscriptionToken Subscribe(Action<TPayload> action, bool keepSubscriberReferenceAlive)
		{
			return eventAggregate.GetEvent<TMessage>().Subscribe(action, keepSubscriberReferenceAlive);
		}

		public static SubscriptionToken Subscribe(Action<TPayload> action, bool keepSubscriberReferenceAlive, ThreadOption threadOption)
		{
			return eventAggregate.GetEvent<TMessage>().Subscribe(action, threadOption, keepSubscriberReferenceAlive);
		}

		public static SubscriptionToken Subscribe(Action<TPayload> action, bool keepSubscriberReferenceAlive, ThreadOption threadOption, Predicate<TPayload> filter)
		{
			return eventAggregate.GetEvent<TMessage>().Subscribe(action, threadOption, keepSubscriberReferenceAlive, filter);
		}
	}
}
