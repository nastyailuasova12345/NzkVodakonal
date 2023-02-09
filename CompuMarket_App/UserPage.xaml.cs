using CompuMarket_App.DB;
using System.Linq;
using System.Windows.Controls;

namespace CompuMarket_App
{
   
    public partial class UserPage : Page
    {
        private User _currentUser;
        public UserPage(User authUser)
        {
            InitializeComponent();
            _currentUser = authUser;
            DataContext = _currentUser;

            var _order = IlyasovaEntities.GetContext().Payment.ToList();
            _order = _order.Where(p => p.User.UserId == _currentUser.UserId).ToList();
            LViewProduct.ItemsSource = _order;
        }
    }
}
