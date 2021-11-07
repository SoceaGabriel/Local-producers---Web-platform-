using ProducatoriLocali.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducatoriLocali.Repositories
{
    public interface IAccountManagerRepository
    {
        ApiAccountResponse Login(string userName, string passwordHash);
        ApiAccountResponse Register(User user);
        ApiAccountResponse ModifyAccountInfo(User user);
    }
}
