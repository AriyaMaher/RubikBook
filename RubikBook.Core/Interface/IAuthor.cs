using RubikBook.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikBook.Core.Interface;

public interface IAuthor:IDisposable
{
    Task<List<Author>> GetAuthors();
    Task<Author> GetAuthor(int AuthorId);
    Task<bool> AddAuthor(Author author);
    Task<bool> EditAuthor(Author author);
    Task<bool> DeleteAuthor(int AuthorId);
}
