using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using nJoyIt.Data;
using nJoyIt.Models;

namespace nJoyIt.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public EFUserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ApplicationUser GetUserByUserName(string username) => _db.Users.SingleOrDefault(user => user.UserName == username);
    }
}
