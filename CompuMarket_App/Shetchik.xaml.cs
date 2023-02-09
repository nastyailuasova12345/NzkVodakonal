using CompuMarket_App.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CompuMarket_App
{
    /// <summary>
    /// Логика взаимодействия для Shetchik.xaml
    /// </summary>
    public partial class Shetchik : Window
    {
        private MeterReadings _currentReadings = new MeterReadings();
        public Shetchik()
        {
            InitializeComponent();
            DataContext = _currentReadings;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_currentReadings.ReadingId == 0)
                IlyasovaEntities.GetContext().MeterReadings.Add(_currentReadings);
            IlyasovaEntities.GetContext().SaveChanges();
            MessageBox.Show("Информация сохранена");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (_currentReadings.ReadingId == 0)
                IlyasovaEntities.GetContext().MeterReadings.Add(_currentReadings);
            IlyasovaEntities.GetContext().SaveChanges();
            MessageBox.Show("Информация сохранена");
        }
    }
}
