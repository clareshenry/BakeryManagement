using BakeryManagement.Domain.Entities;
using BakeryManagement.Domain.Interfaces;
using BakeryManagement.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BakeryManagement.Infrastructure.Persistence
{
    public class BreadRepository
    {
        // private readonly ApplicationDbContext _context;

        // public BreadRepository(ApplicationDbContext context)
        // {
        //     _context = context;
        // }
        //
        // public async Task<IEnumerable<Bread>> GetAllAsync()
        // {
        //     return await _context.Breads.ToListAsync();
        // }
        //
        // public async Task<Bread?> GetByIdAsync(int id)
        // {
        //     return await _context.Breads.FindAsync(id);
        // }
        //
        // public async Task AddAsync(Bread bread)
        // {
        //     await _context.Breads.AddAsync(bread);
        //     await _context.SaveChangesAsync();
        // }
        //
        // public async Task UpdateAsync(Bread bread)
        // {
        //     _context.Breads.Update(bread);
        //     await _context.SaveChangesAsync();
        // }
        //
        // public async Task DeleteAsync(int id)
        // {
        //     var bread = await _context.Breads.FindAsync(id);
        //     if (bread != null)
        //     {
        //         _context.Breads.Remove(bread);
        //         await _context.SaveChangesAsync();
        //     }
        // }
    }
}
