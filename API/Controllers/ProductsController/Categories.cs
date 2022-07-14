using Core.Interfaces;
using Core.Models.ProductModels;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ProductsController;

public class Categories : BaseApiController
{
    private readonly IGenericRepository<Category> _categoryRepo;
    public Categories (DatabaseContext context, IGenericRepository<Category> categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    // Get
    [HttpGet("get")]
    public async Task<ActionResult<List<Category>>> GetCategories()
    {
        return Ok(await _categoryRepo.ListAllAsync());
    }

    // GetByID
    [HttpGet("get/{id}")]
    public async Task<ActionResult<Category>> GetCategoryById(int id)
    {
        return Ok(await _categoryRepo.GetByIdAsync(id));
    }

    // Add
    [HttpPost("add")]
    public async Task<ActionResult<Category>> AddCategory(Category category)
    {
        category.Slug = _categoryRepo.SetSlug(category.CategoryName);
        await _categoryRepo.Add(category);
        return Ok(category);
    }

    // Update 
    [HttpPut("update")]
    public async Task<ActionResult<Category>> UpdateCategory(Category val)
    {
        await _categoryRepo.Update(val);
        return Ok(val);
    }

    // Delete
    [HttpDelete("delete")]
    public async Task<ActionResult<Category>> DeleteCategroy(int ID)
    {
        try
        {
            await _categoryRepo.Delete(ID);
            return Ok("Category with id: " + ID + " succesfully removed");
        }
        catch (Exception)
        {
            throw new Exception("Category with ID: " + ID + " doesn't exist.");
        }
    }
}
