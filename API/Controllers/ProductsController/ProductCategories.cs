using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.ProductsController;

public class ProductCategories : BaseApiController
{
    private readonly DatabaseContext _context;
    public ProductCategories(DatabaseContext context)
    {
        _context = context;
    }
    
    // Get
    [HttpGet("get")]
    public async Task<ActionResult<List<ProductCategories>>> GetProductCategories()
    {
        return Ok(await _context.ProductCategories.Include(c => c.Category).Include(p => p.Product).ToListAsync());
    }
}
