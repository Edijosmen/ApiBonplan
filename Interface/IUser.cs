using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IUser
    {
        Task<bool> SaveUserAsync(User user);
        Task<User> Get_UserAsync( string NameUser);
    }
}
