using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWithArash.Models;

namespace CodeWithArash.Data.Repositories
{
  public interface IUserRepository
  {
    bool IsUserExist(string email);
    void AddUser(Users user);
  }

  public class UserRepository : IUserRepository
  {
    private CodeWithArashContext _context;

    public UserRepository(CodeWithArashContext context)
    {
      _context = context;
    }

    public bool IsUserExist(string email)
    {
      return _context.Users.Any(u => u.Email == email);
    }

    public void AddUser(Users user)
    {
      _context.Users.Add(user);
      _context.SaveChanges();
    }
  }


}
