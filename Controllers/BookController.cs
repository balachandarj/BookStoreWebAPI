using BookStoreWebAPI.Data.Models;
using BookStoreWebAPI.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BookStoreWebAPI.Controllers;

[ApiController]
[Route("api/Books/")]
public class BookController : ControllerBase
{
    IBookService _service;

    public BookController(IBookService service)
    {
        _service = service;
    }

    /// <summary>
    /// Add a new Book to the store
    /// </summary>        
    /// <param name="body">Book object that needs to be added to the store</param>
    /// <response code="405">Invalid input</response>
    [HttpPost("AddBook")] 
    public IActionResult AddBook([FromBody] Book book)
    {
        _service.AddBook(book);
        return Ok("Added a new Book");
    }


    // Get All Books
    [HttpGet("GetBooks")]
    public IActionResult GetBooks()
    {
        var books = _service.GetBooks();
        return Ok(books);
    }

    // Get a Book
    [HttpGet("GetBook/{id}")]
    public IActionResult GetBook(int id)
    {
        var book = _service.GetBook(id);
        return Ok(book);
    }

    // Get a Book
    [HttpDelete("DeleteBook/{id}")]
    public IActionResult DeleteBook(int id)
    {
        _service.DeleteBook(id);
        return Ok("Deleted");
    }

    // Get a Book
    [HttpPut("UpdateBook/{id}")]
    public IActionResult UpdateBook(int id, [FromBody] Book book)
    {
        _service.UpdateBook(id, book);
        return Ok("Updated");
    }

}
