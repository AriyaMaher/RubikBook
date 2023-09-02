using RubikBook.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikBook.Core.Interface;

public interface IPublisher:IDisposable
{
    Task<List<Publisher>> GetPublishers();
    Task<Publisher> GetPublisher(int id);
    Task<bool> AddPublisher(Publisher publisher);
    Task<bool> DeletePublisher(int id);
}
