using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace backendMVC.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class BooksController : ControllerBase
  {
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
      _bookService = bookService;
    }

    
    // GET: api/Books
    [HttpGet]
    public IEnumerable<Book> Get()
    {
      return _bookService.GetAllBooks();
    }

    // GET: api/Books/{id}
    [HttpGet("{id}")]
    public IActionResult Get(int id)
{
  var book = _bookService.GetBookById(id);

  return book == null ? NotFound() : Ok(book);
}

    // POST: api/Books
    [HttpPost]
    public IActionResult Post([FromBody] Book book)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _bookService.AddBook(book);

      return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
    }

    // PUT: api/Books/{id}
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Book book)
    {
      if (id != book.Id)
      {
        return BadRequest();
      }

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _bookService.UpdateBook(book);

      return NoContent();
    }

    // DELETE: api/Books/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      _bookService.DeleteBook(id);

      return NoContent();
    }
  }
}
