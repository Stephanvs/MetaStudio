using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace Hayman.Client.DomainModelVisualizerModule.Converters
{
    public class HalfValueConverter : IMultiValueConverter
    {
       public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)    
       {        
           if (values == null || values.Length < 2)       
           {            
               throw new ArgumentException("HalfValueConverter expects 2 double values to be passed in this order -> totalWidth, width", "values"); 
           }       
 
           double totalWidth = (values[0] != DependencyProperty.UnsetValue ? (double)values[0] : 0.0);
           double width = (values[1] != DependencyProperty.UnsetValue ? (double)values[1] : 0.0);
           
           return (object)((totalWidth - width) / 2);
       } 
        
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)   
        {        
            throw new NotImplementedException();   
        }   
    }
}
