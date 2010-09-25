using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace Hayman.Client.Infrastructure.ViewModels
{
	/// <summary>
	/// Base class for view models.
	/// </summary>
	/// <remarks>
	/// This class provides basic support for implementing the <see cref="INotifyPropertyChanged"/> interface.
	/// </remarks>
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBase"/> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        protected ViewModelBase(string displayName)
        {
            DisplayName = displayName;
        }

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Raises this object's PropertyChanged event for each of the properties.
        /// </summary>
        /// <param name="propertyNames">The properties that have a new value.</param>
        protected void RaisePropertyChanged(params string[] propertyNames)
        {
            foreach (var name in propertyNames)
            {
                RaisePropertyChanged(name);
            }
        }

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyExpresssion">A Lambda expression representing the property that has a new value.</param>
        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpresssion)
        {
            var propertyName = ExtractPropertyName(propertyExpresssion);
            RaisePropertyChanged(propertyName);
        }

        /// <summary>
        /// Raises this object's PropertyChanged event for each of the properties.
        /// </summary>
        /// <param name="proppertyExpressions">A collection of Lambda expressions representing the properties that have a new value.</param>
        protected void RaisePropertyChanged<T>(params Expression<Func<T>>[] proppertyExpressions)
        {
            foreach (var expression in proppertyExpressions)
                RaisePropertyChanged<T>(expression);
        }

        private string ExtractPropertyName<T>(Expression<Func<T>> propertyExpresssion)
        {
            if (propertyExpresssion == null)
            {
                throw new ArgumentNullException("propertyExpression");
            }

            var memberExpression = propertyExpresssion.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("The expression is not a member access expression.", "propertyExpression");
            }

            var property = memberExpression.Member as PropertyInfo;
            if (property == null)
            {
                throw new ArgumentException("The member access expression does not access a property.", "propertyExpression");
            }

            if (!property.DeclaringType.IsAssignableFrom(GetType()))
            {
                throw new ArgumentException("The referenced property belongs to a different type.", "propertyExpression");
            }

            var getMethod = property.GetGetMethod(true);
            if (getMethod == null)
            {
                // this shouldn't happen - the expression would reject the property before reaching this far
                throw new ArgumentException("The referenced property does not have a get method.", "propertyExpression");
            }

            if (getMethod.IsStatic)
            {
                throw new ArgumentException("The referenced property is a static property.", "propertyExpression");
            }

            return memberExpression.Member.Name;
        }

        public IView View { get; set; }

        private string displayName;

        /// <summary>
        /// Returns the user-friendly name of this object.
        /// Child classes can set this property to a new value,
        /// or override it to determine the value on-demand.
        /// </summary>
        public virtual string DisplayName
        {
            get { return displayName; }
            set
            {
                if (displayName != value)
                {
                    displayName = value;
                    RaisePropertyChanged(() => DisplayName);
                }
            }
        }

#if DEBUG
        /// <summary>
        /// Useful for ensuring that ViewModel objects are properly garbage collected.
        /// </summary>
        ~ViewModelBase()
        {
            string msg = String.Format("{0} ({1}) ({2}) Finalized",
                GetType().Name, DisplayName, GetHashCode());

            System.Diagnostics.Debug.WriteLine(msg);
        }
#endif

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public void Dispose()
        {
            OnDispose();
        }

        /// <summary>
        /// Child classes can override this method to perform 
        /// clean-up logic, such as removing event handlers.
        /// </summary>
        protected virtual void OnDispose()
        {
        }

    }
}
