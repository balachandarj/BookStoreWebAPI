using System.Text.Json;
using BookStoreWebAPI.Data.Models;

namespace BookStoreWebAPI.Data
{
     public static class BooksDB
    {
        public static List<Book>? Books { get; set; }
        static BooksDB()
        {
            string fileName = "Data/Books.json";
            string jsonString = File.ReadAllText(fileName);
            Books =JsonSerializer.Deserialize<List<Book>>(jsonString);
        }
    }
}