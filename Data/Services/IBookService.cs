using BookStoreWebAPI.Data.Models;

namespace BookStoreWebAPI.Data.Services
{
     public interface IBookService
    {        
        List<Book>? GetBooks();
        Book? GetBook(int bookId);
        void AddBook(Book book);
        void UpdateBook(int bookId, Book book);

        void DeleteBook(int bookId);
    }
}