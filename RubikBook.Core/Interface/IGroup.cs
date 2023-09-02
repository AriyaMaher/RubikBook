using RubikBook.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikBook.Core.Interface;

public interface IGroup:IDisposable
{
    Task<List<Group>> GetGroups(bool? notShow = null);
    Task<Group> GetGroup(int groupId);
    Task<bool> EditGroup(Group group);
    Task<bool> AddGroup(Group group);
    Task<bool> DeleteGroup(int groupId);
}
