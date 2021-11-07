using ProducatoriLocali.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducatoriLocali.Repositories
{
    public interface IUserMessagesRepository
    {
        ApiMessagesResponse InsertUserMessagesInDb(SendUserMessagesDTO sum);
    }
}
