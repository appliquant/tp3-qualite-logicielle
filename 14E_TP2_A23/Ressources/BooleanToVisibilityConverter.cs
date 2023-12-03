using System;
using System.Globalization;
using System.Windows.Data;

namespace _14E_TP2_A23.Ressources
{
    /// <summary>
    /// Convertisseur de booléen en visibilité. Utilisé pour afficher ou non un élément en fonction de la valeur de la propriété
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isBoolean)
            {
                return isBoolean == true ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            }
            else
            {
                return System.Windows.Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
