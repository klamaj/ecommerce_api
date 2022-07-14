using Core.Interfaces;
using Core.Models.ProductModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ProductsController;

public class Images : BaseApiController
{
    private readonly IGenericRepository<Image> _imageRepo;
    public Images (IGenericRepository<Image> imageRepo)
    {
        _imageRepo = imageRepo;
    }
    
    // GetById
    [HttpGet("get/{id}")]
    public async Task<ActionResult<Image>> GetImageById(int id)
    {
        return Ok(await _imageRepo.GetByIdAsync(id));
    }

    // Delete
    [HttpDelete("delete")]
    public async Task<ActionResult<Image>> RemoveImage(int ID)
    {
        return Ok(await _imageRepo.Delete(ID));
    }

    // Update
    [HttpPut("update")]
    public async Task<ActionResult<Image>> UpdateImage(Image val)
    {
        return Ok(await _imageRepo.Update(val));
    }
}
