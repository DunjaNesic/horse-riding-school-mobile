using horse_riding_school.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace horse_riding_school.Services
{
    interface IUserService
    {
        Task<User> Login(string email, string password);
    }
}
