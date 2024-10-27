using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GermogenovSubscriptions
{
    public class ColumnWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Примерное распределение ширины для каждого столбца
            if (value is double listViewWidth)
            {
                double margin = 0; // Учитываем отступы и прокрутку
                int columnCount = int.Parse(parameter.ToString()); // Количество столбцов
                return (listViewWidth - margin) / columnCount;
            }
            return 100; // Значение по умолчанию, если ширина не определена
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
