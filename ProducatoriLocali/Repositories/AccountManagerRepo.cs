using ProducatoriLocali.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;

namespace ProducatoriLocali.Repositories
{
    public class AccountManagerRepo : IAccountManagerRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ApiAccountResponse Login(string email, string passwordHash)
        {
            try
            {
                var user = db.Utilizatori.Where(x => x.Email == email && x.Password == passwordHash).FirstOrDefault();
                if (user != null)
                {
                    return ApiAccountResponse.LOGIN_SUCCESS;
                }
                else
                {
                    return ApiAccountResponse.LOGIN_ERROR;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: AccountManagerRepo > Login: " + ex);
                return ApiAccountResponse.LOGIN_EXCEPTION;
            }
            
        }

        public ApiAccountResponse Register(User user)
        {
            try
            {
                if(user.Password != user.ReenteredPassword)
                {
                    return ApiAccountResponse.REGISTER_ERROR;
                }
                else
                {
                    db.Utilizatori.Add(user);
                    db.SaveChanges();
                    return ApiAccountResponse.REGISTER_SUCCESS;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: AccountManagerRepo > Register: " + ex);
                return ApiAccountResponse.REGISTER_EXCEPTION;
            }
        }

        public ApiAccountResponse ModifyAccountInfo(User user)
        {
            try
            {
                var localUser = db.Utilizatori.Where(x => x.UserId == user.UserId).FirstOrDefault();
                if ((localUser != null) && (user.Password == user.ReenteredPassword))
                {
                    localUser.Email = user.Email;
                    localUser.FirstName = user.FirstName;
                    localUser.LastName = user.LastName;
                    localUser.PhoneNumber = user.PhoneNumber;
                    localUser.Password = user.Password;
                    localUser.ReenteredPassword = user.ReenteredPassword;
                    db.SaveChanges();
                    return ApiAccountResponse.MODIFYACCOUNTINFO_SUCCESS;
                }
                else
                {
                    return ApiAccountResponse.MODIFYACCOUNTINFO_ERROR;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: AccountManagerRepo > ModifyAccountInfo: " + ex);
                return ApiAccountResponse.MODIFYACCOUNTINFO_EXCEPTION;
            }
        }
    }
}