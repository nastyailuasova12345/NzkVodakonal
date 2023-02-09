using CompuMarket_App.DB;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CompuMarket_App
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private readonly User _currentUser;
        public ProductPage(User authUser)
        {
            InitializeComponent();
            _currentUser = authUser;
            DataContext = _currentUser;
            //var allTypes = IlyasovaFriendEntities.GetContext().TypeTovar.ToList();
            //allTypes.Insert(0, new TypeTovar
            //{ Title = "Все типы" });
            //ComboType.ItemsSource = allTypes;
            //ComboType.SelectedIndex = 0;
            //ComboFilter.SelectedIndex = 0;

            //if (authUser.UserId == 1)
            //{ RegularRowSize.MinHeight = 50; }
            //else
            //{  RegularRowSize.MaxHeight = 0; }

            UpdateProduct();
        }
        private void UpdateProduct()
        {
            var currentProduct = IlyasovaEntities.GetContext().Services.ToList();
            currentProduct = currentProduct.Where(p => p.FIO.ToLower().Contains(txtSearches.Text.ToLower())).ToList();
            // if (ComboType.SelectedIndex > 0)
            //   currentProduct = currentProduct.Where(p => p.TypeTovar == ComboType.SelectedItem as TypeTovar).ToList();

          //  if (ComboFilters.IsChecked.Value)
               // currentProduct = currentProduct.Where(p => p.isPaid).ToList();
            if (ComboFilteres.SelectedIndex == 0)
                currentProduct = currentProduct.OrderBy(p => p.ServiseID).ToList();
            if (ComboFilteres.SelectedIndex == 1)
                currentProduct = currentProduct.OrderBy(p => p.INN).ToList();
            if (ComboFilteres.SelectedIndex == 2)
                currentProduct = currentProduct.OrderByDescending(p => p.INN).ToList();
            if (ComboFilteres.SelectedIndex == 3)
                currentProduct = currentProduct.OrderBy(p => p.FIO).ToList();

            LViewProduct.ItemsSource = currentProduct;
        }
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProduct();
        }
        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }
        private void CheckActive_Checked(object sender, RoutedEventArgs e)
        {
            UpdateProduct();
        }
        private void ComboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
                IlyasovaEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            UpdateProduct();
        }
        private void AddProdctR_Click(object sender, RoutedEventArgs e)
        {
            if (_currentUser.UserId == 1)
            //    Manager.MainFrame.Navigate(new ProductEditPage((sender as Grid).DataContext as Products));
           // else
                Manager.MainFrame.Navigate(new ViewProduct((sender as Button).DataContext as Services, DataContext as User));
        }
        private void Grid123_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_currentUser.UserId == 1)
                Manager.MainFrame.Navigate(new ProductEditPage((sender as Grid).DataContext as Services));
          //  else
             //   Manager.MainFrame.Navigate(new ViewProduct((sender as Grid).DataContext as Products, DataContext as Users));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ProductEditPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var productForRemoving = LViewProduct.SelectedItems.Cast<Services>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {productForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    IlyasovaEntities.GetContext().Services.RemoveRange(productForRemoving);
                    IlyasovaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    LViewProduct.ItemsSource = IlyasovaEntities.GetContext().Services.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void CheckActiveteded_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckActiveteded_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void ComboFilteres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtSearches_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnNewMaster_Click(object sender, RoutedEventArgs e)
        {
            MasterWin f = new MasterWin();
            f.Show(); 
        }

        private void btnPeredat_Click(object sender, RoutedEventArgs e)
        {
            Shetchik s = new Shetchik();
            s.Show();
        }
    }
}

