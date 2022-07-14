using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class GenericRepository<T> : IGenericRepository<T> where T : Base
{
    private readonly DatabaseContext _context;
    public GenericRepository(DatabaseContext context)
    {
        _context = context;
    }

    // Add
    public async Task<T> Add(T Base)
    {
        _context.Set<T>().Add(Base);
        await _context.SaveChangesAsync();

        return Base;
    }

    // Delete
    public async Task<T> Delete(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity is null)
        {
            return entity;
        }

        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    // GetByID
    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    // Get
    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    // ListAsyncWithSpec
    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    // Set SKU
    public string SetSKU(int productId, int brandId, int categoryId, string variantName)
    {
        var brand = _context.Brands.Find(brandId);
        var category = _context.Categories.Find(categoryId);
        string[] variant = variantName.Split('-');

        string sku = category.CategoryCode + "/" + productId;
        foreach (var word in variant)
        {
            // var neword =  char.ToUpper(word[0]) + word.Substring(1);
            var code = _context.VariantValues.Where(x => x.Slug == word).First();
            sku += code.VariantValueCode;
        }

        return sku + "/" + brand.BrandCode;
    }

    // SetSlug
    public string SetSlug(string val)
    {
        return val.Replace(' ', '-').ToLower();
    }

    // Update
    public async Task<T> Update(T Base)
    {
        _context.Entry(Base).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Base;
    }

    // Apply Specification
    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
    }
}
