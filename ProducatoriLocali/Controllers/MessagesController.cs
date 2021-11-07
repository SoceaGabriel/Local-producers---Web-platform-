using ProducatoriLocali.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ProducatoriLocali.Controllers
{
    public class MessagesController : Controller
    {
        public string schema = "http://";
        public string host = "localhost";
        public string port = "64103";
        public ApplicationDbContext db = new ApplicationDbContext();

        // GET: Messages
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Messages(Guid? UserID)
        {
            List<UsersConversations> uc = new List<UsersConversations>();
            var producerId = Guid.Parse(Session["LocalProducerAppUserId"].ToString());
            var users = db.UsersMessages.Where(x => x.UserWhoReceiveMessage == producerId).Select(x => x.UserWhoSendMessageName).Distinct().ToList();
            users.AddRange(db.UsersMessages.Where(x => x.UserWhoSendMessageId == producerId).Select(x => x.UserWhoReceivedMessageName).Distinct().ToList());
            users = users.Distinct().ToList();
            foreach (var usr in users)
            {
                var userId = db.UsersMessages.Where(x => x.UserWhoReceivedMessageName == usr).Select(x => x.UserWhoReceiveMessage).FirstOrDefault();
                if (userId != null && userId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {
                    uc.Add(new UsersConversations
                    {
                        UserId = userId,
                        UserName = usr
                    });
                }
                else
                {
                    var userID = db.UsersMessages.Where(x => x.UserWhoSendMessageName == usr).Select(x => x.UserWhoSendMessageId).FirstOrDefault();
                    uc.Add(new UsersConversations
                    {
                        UserId = userID,
                        UserName = usr
                    });
                }
            }
            //Lista de utilizatori cu care utilizatorul curent a conversat
            ViewBag.ConversationWithUsers = uc;
            if (UserID == null)
            {
                var firstConversation = uc.FirstOrDefault();
                //Lista de mesaje intre cei 2 useri
                var userConvesation = db.UsersMessages.Where(x => (x.UserWhoSendMessageId == producerId && x.UserWhoReceiveMessage == firstConversation.UserId) || (x.UserWhoSendMessageId == firstConversation.UserId && x.UserWhoReceiveMessage == producerId)).ToList();
                ViewBag.CurrentUserId = firstConversation.UserId;
                ViewBag.CurrentUserName = firstConversation.UserName;
                return View(userConvesation);
            }
            else
            {
                //Lista de mesaje intre cei 2 useri
                var userConvesation = db.UsersMessages.Where(x => (x.UserWhoSendMessageId == producerId && x.UserWhoReceiveMessage == UserID) || (x.UserWhoSendMessageId == UserID && x.UserWhoReceiveMessage == producerId)).ToList();
                ViewBag.CurrentUserId = UserID;
                ViewBag.CurrentUserName = uc.Where(x => x.UserId == UserID).FirstOrDefault().UserName;
                return View(userConvesation);
            }
        }

        public ActionResult GetMessages(string UserID)
        {
            

            var producerId = Guid.Parse(Session["LocalProducerAppUserId"].ToString());
            var users = db.UsersMessages.Where(x => x.UserWhoReceiveMessage == producerId).ToList();
            return Json(new { data = users }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUsersConversation()
        {
            var producerId = Guid.Parse(Session["LocalProducerAppUserId"].ToString());
            var users = db.UsersMessages.Where(x => x.UserWhoReceiveMessage == producerId).Select(x => x.UserWhoSendMessageName).Distinct().ToList();
            return Json(new { data = users }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddUserMessages(Guid send, Guid receiv, string mess)
        {
            using (var client = new HttpClient())
            {
                SendUserMessagesDTO sumDTO = new SendUserMessagesDTO
                {
                    messages = mess,
                    receiver = receiv,
                    sender = send
                };

                client.BaseAddress = new Uri(schema + host + ":" + port + "/api/apiusermessages");
                var postTask = client.PostAsJsonAsync<SendUserMessagesDTO>("/api/apiusermessages/insertmessage", sumDTO);
                postTask.Wait();
                var result = postTask.Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return Json(new { success = true, messaggeText = "Mesajul a fost trimis cu succes" });
                }
                else
                {
                    return Json(new { success = true, messaggeText = "Mesajul nu a putut fi trimis" });
                }
            }
        }

    }
}