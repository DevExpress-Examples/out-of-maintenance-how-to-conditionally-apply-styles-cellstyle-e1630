using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;

namespace DXGrid_ConditionalFormatting {
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            grid.ItemsSource = Products.GetData();
        }
    }
    public class IntoToColorConverter : MarkupExtension, IValueConverter {

        #region IValueConverter Members

        public object Convert(object value, System.Type targetType,
                    object parameter, System.Globalization.CultureInfo culture) {
            if ((int)value < 20)
                return new LinearGradientBrush(
                        Color.FromArgb(100, 255, 0, 0),
                        Color.FromArgb(0, 255, 0, 0), 0);
            else
                return Brushes.White;
        }

        public object ConvertBack(object value, System.Type targetType, 
                    object parameter, System.Globalization.CultureInfo culture) {
            throw new System.NotImplementedException();
        }

        #endregion

        public override object ProvideValue(System.IServiceProvider serviceProvider) {
            return this;
        }
    }
    public class Products {
        public static List<Product> GetData() {
            List<Product> data = new List<Product>();
            data.Add(new Product() { ProductName = "Chai", 
                UnitPrice = 18, UnitsOnOrder = 10 });
            data.Add(new Product() { ProductName = "Ipoh Coffee", 
                UnitPrice = 36.8, UnitsOnOrder = 12 });
            data.Add(new Product() { ProductName = "Outback Lager", 
                UnitPrice = 12, UnitsOnOrder = 25 });
            data.Add(new Product() { ProductName = "Boston Crab Meat", 
                UnitPrice = 18.4, UnitsOnOrder = 18 });
            data.Add(new Product() { ProductName = "Konbu", 
                UnitPrice = 6, UnitsOnOrder = 24 });
            return data;
        }
    }
    public class Product {
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsOnOrder { get; set; }
    }
}
