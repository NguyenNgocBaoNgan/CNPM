using System;
using System.Collections.Generic;
using System.Data;
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

namespace LibraryManagementSystem
{
    public partial class AdminAddBook : Window
    {


        public string bookImage = ""; //khởi tạo biến để lưu tên hình ảnh ví dụ abc.png
        public static string PATH_IMAGE_SAVE = "\\..\\..\\Images\\";//thư mục chứa hình khi thao tác nhấn upload image
        public string linkImageView = "";//đường link vị trí hình ảnh đang chọn để upload

        public AdminAddBook()
        {
            InitializeComponent();
        }
        //THÊM SÁCH
        //4. Người dùng nhấn nút thêm
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //5. Hệ thống kiểm tra lỗi form
            if (tbBName.Text != string.Empty && tbBAuthor.Text != string.Empty && tbBISBN.Text != string.Empty && tbBPrice.Text != string.Empty &&
                tbBCopy.Text != string.Empty
                )
            {
                //5.2 Nếu thông tin hợp lệ
                try
                {
                    //lấy giá trị từ giao diện lưu vào database
                    ComboBoxItem typeItem = (ComboBoxItem)cboStatus.SelectedItem;
                    string status = typeItem.Name.ToString();
                    int bookStatus = 2;
                    if (status == "Actice")
                    {
                        bookStatus = 1;
                    }
                    BookBL bookBL = new BookBL();

                    //6. Kiểm tra lỗi khi lưu xuống database
                    string isDone = bookBL.AddBookBL(tbBName.Text, tbBAuthor.Text, tbBISBN.Text, double.Parse(tbBPrice.Text), int.Parse(tbBCopy.Text), this.bookImage, bookStatus);
                    //6.1 Nếu không có lỗi
                    if (isDone == "true")
                    {
                        string defaultFolder = System.AppDomain.CurrentDomain.BaseDirectory;                                                            
                        string path = Path.Combine(defaultFolder + PATH_IMAGE_SAVE);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string linkImageSave = path + this.bookImage;
                        if (!File.Exists(linkImageSave))
                        {
                            //File.Copy(this.linkImageView, linkImageSave,true);
                            this.coppyFileBuffer(this.linkImageView, linkImageSave);

                        }
                        //Hiển thị MessageThanhCong
                        MessageBox.Show("Add book sucessfully..");
                        AdminBooks admin = AdminBooks.getInstance();
                        admin.InitializeAdminBooks();
                        this.Close();
                    }
                    //6.2 Nếu có lỗi sẽ hiển thị MessageLoi.
                    else
                    {
                        MessageBox.Show(isDone + "Try again..");
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
            }
            //5.1 Nếu thông tin không hợp lệ 
            else
            {
                MessageBox.Show("Enter the fields properly!!!, Every field is required..");
            }
        }

        private void Button_View_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files|*.bmp;*.jpg;*.png;";// lọc file có đuôi là png, jpg, bmp mới hiển thị ở dialog cho phép lưu hình ảnh
                dialog.FilterIndex = 1;
                if (dialog.ShowDialog() == true)
                {
                    imagePicture.Source = new BitmapImage(new Uri(dialog.FileName));//hiển thị hình ảnh xem trước - view

                    this.linkImageView = System.IO.Path.GetFullPath(dialog.FileName);//đường dẫn hình ảnh mới chọn để xem
                    this.bookImage = System.IO.Path.GetFileName(dialog.FileName);//lấy tên file lưu DB 
                    //gán đường dẫn hình ảnh vào biến tạm > để khi nhấn save lấy để lưu vào database
                  
                }
            }
            catch (Exception ex)
            {     
                MessageBox.Show(ex.Message);
            }
        }
	//Ham coppy file
        public void coppyFileBuffer(String source, String dest)
        {

            int SIZEBUFFER = 5;   // tăng lên cải thiện tốc độ đọc
            using (var streamwrite = File.OpenWrite(dest))
            using (var streamread = File.OpenRead(source))
            {
                byte[] buffer = new byte[SIZEBUFFER];
                bool endread = false;
                do
                {
                    int numberRead = streamread.Read(buffer, 0, SIZEBUFFER);
                    if (numberRead == 0) endread = true;
                    else
                    {
                        streamwrite.Write(buffer, 0, numberRead);
                    }
                } while (!endread);
                streamread.Close();
                streamwrite.Close();
            }
        }
    }
}
