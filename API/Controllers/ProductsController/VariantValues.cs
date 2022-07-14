using API.DTOs.ProductsDTOs;
using Core.Interfaces;
using Core.Models.ProductModels;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.ProductsController;

public class VariantValues : BaseApiController
{
    private readonly DatabaseContext _context;
    private readonly IGenericRepository<VariantValue> _variantValuesRepo;
    public VariantValues(DatabaseContext context, IGenericRepository<VariantValue> variantValuesRepo)
    {
        _variantValuesRepo = variantValuesRepo;
        _context = context;
    }

    // Get
    [HttpGet("get/{id}")]
    public async Task<ActionResult<VariantValues>> GetVariantValues(int id)
    {
       return Ok(await _context.VariantValues.Include(v => v.Variant)
                                             .Where(m => m.VariantId == id)
                                             .ToListAsync());
    }

    // Add
    [HttpPost("add")]
    public async Task<ActionResult<VariantValues>> AddVariantValue(VariantValueDTO variantValue)
    {
        try
        {
            var newVariantValue = new VariantValue();

            newVariantValue.VariantValueName = char.ToUpper(variantValue.VariantValueName[0]) + variantValue.VariantValueName.Substring(1); ;
            newVariantValue.VariantValueDescription = variantValue.VariantValueDescription;
            newVariantValue.VariantValueCode = variantValue.VariantValueCode;
            newVariantValue.Slug = _variantValuesRepo.SetSlug(variantValue.VariantValueName);
            newVariantValue.VariantId = variantValue.VariantId;

            await _variantValuesRepo.Add(newVariantValue);

            return Ok(newVariantValue);
        }
        catch (Exception)
        {
            throw new Exception("Already exists: " + variantValue.VariantValueName);
        }
    }

    // Update
    [HttpPut("update")]
    public async Task<ActionResult<VariantValue>> UpdateValue(VariantValue value)
    {
        await _variantValuesRepo.Update(value);
        return Ok("Value ID: " + value.ID + " has been succesfully updated");
    }

    // Delete
    [HttpDelete("delete")]
    public async Task<ActionResult<VariantValue>> DeleteValue(int ID)
    {
        try
        {
            await _variantValuesRepo.Delete(ID);
            return Ok();
        }
        catch (Exception)
        {
            throw new Exception("This value doesn't exists");
        }
        
    }
}
