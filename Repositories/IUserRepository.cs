using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using nJoyIt.Models;

namespace nJoyIt.Repositories
{
    public interface IUserRepository
    {
        ApplicationUser GetUserByUserName(string username);
    }
}
