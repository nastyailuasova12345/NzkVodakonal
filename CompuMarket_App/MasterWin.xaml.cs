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
    /// Логика взаимодействия для MasterWin.xaml
    /// </summary>
    public partial class MasterWin : Window
    {
        private CallingWizard _currentWizard = new CallingWizard();
        public MasterWin()
        {
            InitializeComponent();
            DataContext = _currentWizard;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_currentWizard.WizardId == 0)
            IlyasovaEntities.GetContext().CallingWizard.Add(_currentWizard);
            IlyasovaEntities.GetContext().SaveChanges();
            MessageBox.Show("Информация сохранена");  
        }
    }
}
