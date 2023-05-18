using System;
using System.Collections.Generic;
using System.IO;
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
using LibraryMSWF.BL;
using Microsoft.Win32;
using Path = System.IO.Path;
using System.IO;
using LibraryMSWF.Entity;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Interaction logic for AdminUpdateBook.xaml
    /// </summary>
    public partial class AdminUpdateBook : Window
    {
        public int bookId;
        //khởi tạo biến để lưu đường dẫn hình ảnh
        public string bookImage = "";
        public string bookImage2 = "";
        private string sourceFile = "";
        private string oldImage = "";
        private string newImage = "";
        public static string PATH_IMAGE_LOAD = "\\..\\..\\..\\Images\\";//thư mục chứa hình khi nhấn hiển thị
        public static string PATH_IMAGE_SAVE = "\\..\\..\\Images\\";//thư mục chứa hình khi thao tác nhấn upload image
        //INITIALIZE THE BOOKS UPDATE =>PL
        public AdminUpdateBook()
        {
            InitializeComponent();
            this.bookId = AdminBooks.updateBook.BookId;
            tbBName.Text = AdminBooks.updateBook.BookName;
            tbBAuthor.Text = AdminBooks.updateBook.BookAuthor;
            tbBISBN.Text = AdminBooks.updateBook.BookISBN;
            tbBPrice.Text = AdminBooks.updateBook.BookPrice.ToString();
            tbBCopy.Text = AdminBooks.updateBook.BookCopies.ToString();

            //xử lý dữ liệu cho trường status
            if (AdminBooks.updateBook.BookStatus == 1)
            {
                cboStatus.SelectedValue = "Actice";
            }
            else
            {
                cboStatus.SelectedValue = "Deactice";
            }

            //gán giá trị lấy từ database lên để sử dụng lúc cập nhật hình ảnh
            this.bookImage = AdminBooks.updateBook.BookImage.ToString();
            // this.bookImage2 = AdminBooks.updateBook.BookImage2.ToString();
            try
            {
                //màn hình chi tiết hiển thị cuốn sách
                string defaultFolder = System.AppDomain.CurrentDomain.BaseDirectory;//D:\\DH20DT\\hk5\\Net\\CuoiKy\\net\\WPF Project\\LibraryManagementSystem\\bin\\Debug\\ thư mục mặc định                                                                 
                string path = Path.Combine(defaultFolder + PATH_IMAGE_LOAD);
                string linkImage = path + this.bookImage;//lấy link hình trực tiếp từ database
                //string linkImage2 = path + this.bookImage2;
                imagePicture.Source = new BitmapImage(new Uri(linkImage));
                // imagePicture_Copy.Source = new BitmapImage(new Uri(linkImage2));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       //SỬA SÁCH

       //4. Người dùng bấm vào nút lưu
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //5.Hệ thống kiểm tra lỗi form (Điền thiếu thông tin)
            if (tbBName.Text != string.Empty && tbBAuthor.Text != string.Empty && tbBISBN.Text != string.Empty && tbBPrice.Text != string.Empty &&
                tbBCopy.Text != string.Empty
                )
            {
                //5.2 Nếu thông tin hợp lệ
                try
                {
                    ComboBoxItem typeItem = (ComboBoxItem)cboStatus.SelectedItem;
                    string value = typeItem.Content.ToString();
                    string status = typeItem.Name.ToString();
                    int bookStatus = 2;
                    if (status == "Actice")
                    {
                        bookStatus = 1;
                    }

                    BookBL bookBL = new BookBL();
                    //6. Kiểm tra lỗi khi update ở database
                    string isDone = bookBL.UpdateBookBL(this.bookId, tbBName.Text, tbBAuthor.Text, tbBISBN.Text, double.Parse(tbBPrice.Text), int.Parse(tbBCopy.Text), this.bookImage,  bookStatus);

                    //6.1 Nếu không có lỗi
                    if (isDone == "true")
                    {
                        //Hiển thị MessageBox thành công
                       MessageBoxResult result = MessageBox.Show("Edit successful..");
                        if(result == MessageBoxResult.OK)
                        {
                            if (!oldImage.Equals(newImage))
                            {
                                if (!File.Exists(newImage))
                                {
                                    File.Copy(sourceFile, newImage);//copy hình ảnh từ ngoài vào trong project(để tạo dữ liệu chứa hình ảnh)
                                                                    //File.Delete(oldImage);
                                    AdminBooks.updateBook = new Book();
                                }      
                                
                            }
                            AdminBooks adminBooks = AdminBooks.getInstance();
                            adminBooks.InitializeAdminBooks();
                            File.Delete(oldImage);
                            this.Close();                         
                        }

                    }
                    //6.2 Nếu có lỗi thì sẽ hiển thị MessageBox lỗi
                    else
                    {
                        MessageBox.Show(isDone + " Try later..");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Book price or Book copy!!!,\nThey should not be a string, Try again..");
                }
                catch (Exception)
                {
                    MessageBox.Show("Some unknown exception is occured!!!, Try again..");
                }
            }//5.1 Nếu sai định dạng sẽ thông báo lỗi
            else
            {
                MessageBox.Show("Enter the fields properly!!!, Every field is required..");
            }
        }

        private void InitializeAdminBooks()
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Khi nhấn vào nút update image là chức năng cập nhật hình ảnh
            try
            {
                //lưu thông tin hình sách
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files|*.bmp;*.jpg;*.png;";// lọc file có đuôi là png, jpg, bmp mới hiển thị ở dialog cho phép lưu hình ảnh
                dialog.FilterIndex = 1;
                if (dialog.ShowDialog() == true)
                {
                    imagePicture.Source = new BitmapImage(new Uri(dialog.FileName));//hiển thị hình ảnh xem trước
                    //imagePicture_Copy.Source = new BitmapImage(new Uri(dialog.FileName));
                    // lưu hình vào thư mực hình ảnh của sourcecode
                    string defaultFolder = System.AppDomain.CurrentDomain.BaseDirectory;                                                               
                    string path = Path.Combine(defaultFolder + PATH_IMAGE_SAVE);//kiểm tra thư mục hình ảnh
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);//nếu thự mục hình ảnh chưa có thì tạo mới
                    }
                    var fileName = System.IO.Path.GetFileName(dialog.FileName);
                    newImage = path + fileName;
                    oldImage = path + this.bookImage;
                    sourceFile = dialog.FileName;
                    //gán đường dẫn hình ảnh vào biến tạm > để khi nhấn save lấy để lưu vào database
                    //this.bookImage2 = fileName;
                    this.bookImage = fileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
