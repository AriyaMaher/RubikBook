using Microsoft.EntityFrameworkCore;
using RubikBook.Core.Interface;
using RubikBook.Database.Context;
using RubikBook.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikBook.Core.Services;

public class OrderService : IOrders
{
    private readonly DatabaseContext _context;
    public OrderService(DatabaseContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        if (_context != null)
        {
            _context.Dispose();
        }
    }

    public async Task<List<Factor>> GetFactors(bool isPay)
    {
        var factors = _context.Factors.Include(f=>f.FactorDetails).Where(f=>f.IsPay==true).ToList();
        return await Task.FromResult(factors);
    }
}
