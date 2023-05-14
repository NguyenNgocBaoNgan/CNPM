using System;

namespace LibraryMSWF.Entity
{
    public class Book
    {
        // Thuộc tính của sách 
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public string BookISBN { get; set; }
        public int BookPrice { get; set; }
        public int BookCopies { get; set; }
        public string BookImage { get; set; }
        // 1 còn sách
        // 2 hết sách 
        public int BookStatus { get; set; }
    }
}
