using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Sql;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using LibraryMSWF.BL;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibraryMSWF.Entity;
using System.Collections.ObjectModel;
using Path = System.IO.Path;
using System.IO;

namespace LibraryManagementSystem
{

    public partial class AdminBooks : UserControl
    {
        public static Book updateBook = new Book();
        private static AdminBooks adminBooks;
        private AdminBooks()
        {
            InitializeComponent();
            InitializeAdminBooks();
        }

        public void InitializeAdminBooks()
        {
            try
            {
                BookBL bookBl = new BookBL();
                DataSet ds = bookBl.GetAllBooksBL();

                ObservableCollection<Book> lst = new ObservableCollection<Book>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lst.Add(new Book
                    {
                        BookName = Convert.ToString(dr["BookName"]),
                        BookId = Convert.ToInt32(dr["BookId"]),
                        BookAuthor = Convert.ToString(dr["BookAuthor"]),
                        BookISBN = Convert.ToString(dr["BookISBN"]),
                        BookCopies = Convert.ToInt32(dr["BookCopies"]),
                        BookPrice = Convert.ToInt32(dr["BookPrice"]),
                        BookStatus = Convert.ToInt32(dr["BookStatus"]),
                        //gán hình ảnh vào danh sách sách
                        BookImage = Convert.ToString(dr["BookImage"]),
                    });
                }
                dgBooks.ItemsSource = lst;//list book lưu vào datagridview, dữ liệu lấy từ database gán vào bảng
            }
            catch (Exception)
            {
                MessageBox.Show("Some unknown exception is occured!!!, Try again..");
            }
            
        }
        
        private void BtnDetail_Click(object sender, RoutedEventArgs e)
        {
            Book book = dgBooks.SelectedItem as Book;//lấy thông tin 1 dòng tương đương 1 cuốn sách > chuyển qua màn hình detail
            if (book != null)
            {
                updateBook = book;
                AdminDetailBook adminDetailBook = new AdminDetailBook();
                adminDetailBook.Show();
            }
            else
            {
                MessageBox.Show("Select a book to detail...");
            }
        }
        //SỬA SÁCH
        //1. Người dùng chọn sách và chọn sửa
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Book book = dgBooks.SelectedItem as Book;
            if (book!= null)
            {
                updateBook = book;
                AdminUpdateBook adminUpdateBook = new AdminUpdateBook();
                // 2. Hiển thị màn hình form điền thông tin sửa sách
                adminUpdateBook.Show();
            }
            else
            {
                MessageBox.Show("Select a book to update...");
            }
        }
        //XOÁ SÁCH
        //1. Người dùng chọn cuốn sách và nhấn xoá
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book book = dgBooks.SelectedItem as Book;

                if (book != null)
                {
                    //2.Message hiển thị thông báo có muốn xoá không
                    MessageBoxResult result = MessageBox.Show("You sure delete?","Delete", MessageBoxButton.YesNo);
                    //3.Nếu chọn có thì sẽ xoá sách 
                    if(result == MessageBoxResult.Yes) {
                        BookBL bookBL = new BookBL();
                        bool isDone = bookBL.DeleteBookBL(book.BookId);
                        if (isDone)
                        {
                            string defaultFolder = System.AppDomain.CurrentDomain.BaseDirectory;// lấy vị trí source code                                                                
                            string path = Path.Combine(defaultFolder+ AdminAddBook.PATH_IMAGE_SAVE);
                            string image = Path.Combine(path, book.BookImage);

                            AdminBooks.updateBook = new Book();

                           
                            //4.Hiển thị thông báo xoá thành công
                            MessageBox.Show("Book deleted complete..");
                            InitializeAdminBooks();

                            try
                            {

                                //Xoá hình ảnh của cuốn sách.
                                File.Delete(image);
                            }
                            catch (IOException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Try later..");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select a book to delete...");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Some unknown exception is occured!!!, Try again..");
            }

        }
        //THÊM SÁCH
        //1. Người dùng chọn Thêm Sách
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AdminAddBook adminAddBook = new AdminAddBook();
            //2. Hiển thị màn hình điền thông tin sách
            adminAddBook.Show();
        }

        public static AdminBooks getInstance()
        {
            if(adminBooks == null)
            {
                adminBooks = new AdminBooks();
            }
            return adminBooks;
        }

    }
}
