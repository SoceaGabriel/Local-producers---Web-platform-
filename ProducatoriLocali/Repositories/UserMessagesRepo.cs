using ProducatoriLocali.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProducatoriLocali.Repositories
{
    public class UserMessagesRepo : IUserMessagesRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ApiMessagesResponse InsertUserMessagesInDb(SendUserMessagesDTO sum)
        {
            try
            {
                var UserWhooSend = db.Utilizatori.Where(x => x.UserId == sum.sender).FirstOrDefault();
                var UserWhooReceive = db.Utilizatori.Where(x => x.UserId == sum.receiver).FirstOrDefault();
                UsersMessages mess = new UsersMessages
                {
                    GeneratedDate = DateTime.Now,
                    MessageText = sum.messages,
                    UserWhoReceiveMessage = sum.receiver,
                    UserWhoSendMessageId = sum.sender,
                    UserWhoReceivedMessageName = UserWhooReceive.FirstName + " " + UserWhooReceive.LastName,
                    UserWhoSendMessageName = UserWhooSend.FirstName + " " + UserWhooSend.LastName
                };
                db.UsersMessages.Add(mess);
                db.SaveChanges();
                return ApiMessagesResponse.INSERT_SUCCESS;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: UserMessageRepo - InsertUserMessagesInDb: " + ex.Message);
                return ApiMessagesResponse.INSERT_EXCEPTION;
            }
        }
    }
}