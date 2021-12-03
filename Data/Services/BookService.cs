using BookStoreWebAPI.Data.Models;

namespace BookStoreWebAPI.Data.Services
{
     public class BookService : IBookService
    {      
        public void AddBook(Book book)
        {
            BooksDB.Books?.Add(book);
        }

        public void DeleteBook(int bookId)
        {
            var book =BooksDB.Books?.Where(o=>o.BookId==bookId).FirstOrDefault();
            if (book!=null)
            {
                BooksDB.Books?.Remove(book);
            }            
        }

        public Book? GetBook(int bookId)
        {
            var book =BooksDB.Books?.FirstOrDefault(o=>o.BookId==bookId);
            return book;
        }

        public List<Book>? GetBooks()
        {
            return BooksDB.Books;
        }

        public void UpdateBook(int bookId, Book newBook)
        {
            var book =BooksDB.Books?.FirstOrDefault(o=>o.BookId==bookId);

            if(book!=null)
            {
                book.Title=newBook.Title;
            }
        }
    }
}