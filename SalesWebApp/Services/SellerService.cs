﻿using SalesWebApp.Data;
using SalesWebApp.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebApp.Services.Exceptions;

namespace SalesWebApp.Services
{
    public class SellerService
    {
        private readonly SalesWebAppContext _context;

        public SellerService(SalesWebAppContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<Seller> FindByIdAsync (int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            if(!await _context.Seller.AnyAsync(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
