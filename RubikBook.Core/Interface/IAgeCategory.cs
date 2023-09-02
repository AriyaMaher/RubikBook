using RubikBook.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikBook.Core.Interface;

public interface IAgeCategory:IDisposable
{
    Task<List<AgeCategory>> GetAgeCategories();
    Task<AgeCategory> GetAgeCategory(int id);
    Task<bool> AddAgeCate(AgeCategory ageCategory);
    Task<bool> DeleteAge(int ageCateId);
}
