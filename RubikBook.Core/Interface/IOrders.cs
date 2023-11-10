
using RubikBook.Database.Models;

namespace RubikBook.Core.Interface;

public interface IOrders : IDisposable
{
    Task<List<Factor>> GetFactors(bool isPay);
}
