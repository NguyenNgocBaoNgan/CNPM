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

namespace LibraryManagementSystem
{

    public partial class AdminHome : Window
    {
        private AdminBooks adminBooks;

        //Quản lí Sách
        public AdminHome()
        {
            InitializeComponent();
            //AdminBooks adminBooks = new AdminBooks();
            adminBooks = AdminBooks.getInstance();
            adminStackPanel.Children.Clear();
            adminStackPanel.Children.Add(adminBooks);
         }
        //1. Người dùng nhấn vào nút Manager Book
        private void BtnBooks_Click(object sender, RoutedEventArgs e)
        {
            
            //AdminBooks adminBooks = new AdminBooks();

            adminBooks = AdminBooks.getInstance();
            adminStackPanel.Children.Clear();
            //2. Hiển thị màn hình Admin Book
            adminStackPanel.Children.Add(adminBooks);
        }
        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            AdminUsers adminUsers = new AdminUsers();
            adminStackPanel.Children.Clear();
            adminStackPanel.Children.Add(adminUsers);
        }
        private void BtnRequests_Click(object sender, RoutedEventArgs e)
        {
            AdminRequests adminRequests = new AdminRequests();
            adminStackPanel.Children.Clear();
            adminStackPanel.Children.Add(adminRequests);

        }
        private void BtnAccepted_Click(object sender, RoutedEventArgs e)
        {
            AdminAccepted adminAccepted = new AdminAccepted();
            adminStackPanel.Children.Clear();
            adminStackPanel.Children.Add(adminAccepted);

        }
        //LOGOUT ADMIN HOME =>PL
        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            AdminReturn adminReturn = new AdminReturn();
            adminStackPanel.Children.Clear();
            adminStackPanel.Children.Add(adminReturn);
        }

    }
}
