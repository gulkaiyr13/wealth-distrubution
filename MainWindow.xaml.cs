using Syncfusion.UI.Xaml.Charts;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WhealthDistributionSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void NumericalAxis_LabelCreated(object sender, LabelCreatedEventArgs e)
        {
            double value = Convert.ToDouble(e.AxisLabel.LabelContent);
            double trillionValue = value / 1000000;
            if(trillionValue <= 100)
            {
                e.AxisLabel.LabelContent = $"${trillionValue}T";
            }
            else
            {
                e.AxisLabel.LabelContent = string.Empty;
                e.AxisLabel.Position = 0;
            }
        }

        private void NumericalAxis_ActualRangeChanged(object sender, ActualRangeChangedEventArgs e)
        {
            customAxis.Maximum = (double?)e.ActualMaximum;
            customAxis.Minimum = (double?)e.ActualMinimum;
        }
    }


    public class ValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string content = value.ToString();

            // Define your color mappings based on content
            switch (content)
            {
                case "Bottom 50%":
                    return "#A94438";
                case "50 - 90%":
                    return "#CD5C08";
                case "90 - 99%":
                    return "#E8C872";
                case "Top 0.9%":
                    return "#BBE2EC";
                case "Top 0.1%":
                    return "#DFF5FF";
                default:
                    return null; // Return default color or null
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}