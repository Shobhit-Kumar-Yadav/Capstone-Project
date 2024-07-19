using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookApp.Model; // Replace with your namespace for Author and DbContext

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly ClassApplicationDbContext _context;

    public AuthorsController(ClassApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/authors
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
    {
        return await _context.Authors.ToListAsync();
    }

    // GET: api/authors/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Author>> GetAuthor(int id)
    {
        var author = await _context.Authors.FindAsync(id);

        if (author == null)
        {
            return NotFound();
        }

        return author;
    }

    // POST: api/authors
    [HttpPost]
    public async Task<ActionResult<Author>> PostAuthor(Author author)
    {
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAuthor), new { id = author.AuthorId }, author);
    }

    // PUT: api/authors/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAuthor(int id, Author author)
    {
        if (id != author.AuthorId)
        {
            return BadRequest();
        }

        _context.Entry(author).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AuthorExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/authors/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author == null)
        {
            return NotFound();
        }

        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AuthorExists(int id)
    {
        return _context.Authors.Any(e => e.AuthorId == id);
    }
}
