using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWithArash.Models;

namespace CodeWithArash.Data.Repositories
{
   public interface IGroupRepository
   {
       IEnumerable<Category> GetAllCategories();
       IEnumerable<ShowGroupViewModel> GetGroupForShow();
   }

   public class GroupRepository : IGroupRepository
   {
       private CodeWithArashContext _context;

       public GroupRepository(CodeWithArashContext context)
       {
           _context = context;
       }

       public IEnumerable<Category> GetAllCategories()
       {
           return _context.Categories;
       }

       public IEnumerable<ShowGroupViewModel> GetGroupForShow()
       {
          return _context.Categories
               .Select(c => new ShowGroupViewModel()
               {
                   GroupId = c.Id,
                   GroupName = c.Name,
                   ProductCount = _context.ProductInCategories.Count(g => g.CategoryId == c.Id)
               }).ToList();
        }
   }
}
