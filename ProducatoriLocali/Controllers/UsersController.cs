using ProducatoriLocali.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ProducatoriLocali.Controllers
{
    public class UsersController : Controller
    {
        public string schema = "http://";
        public string host = "localhost";
        public string port = "64103";
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: Users
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(schema + host + ":" + port + "/api/apiaccountmanager");

                var postTask = client.PostAsJsonAsync<User>("/api/apiaccountmanager/register", user);
                postTask.Wait();

                var result = postTask.Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ViewBag.ResponseType = "Ok";
                    ViewBag.Message = "V-ati inregistrat cu succes!";
                    var usr = db.Utilizatori.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
                    Session["LocalProducerAppUserId"] = usr.UserId;
                    Session["LocalProducerAppUserFirstName"] = usr.FirstName;
                    Session["LocalProducerAppUserLastName"] = usr.LastName;
                    return View();
                }
                else
                {
                    ViewBag.ResponseType = "Error";
                    ViewBag.Message = "Eroare la procesarea datelor. Va rugam sa completati toate campurile necesare si sa incercati din nou";
                    return View(user);
                }
            }
        }

        [HttpGet]
        public ActionResult Login(string Email, string Parola)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(schema + host + ":" + port + "/api/apiaccountmanager");

                var getTask = client.GetAsync("/api/apiaccountmanager/login?Email=" + Email + "&Parola=" + Parola);
                getTask.Wait();

                var result = getTask.Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var usr = db.Utilizatori.Where(x => x.Email == Email && x.Password == Parola).FirstOrDefault();
                    if(usr != null)
                    {
                        Session["LocalProducerAppUserId"] = usr.UserId;
                        Session["LocalProducerAppUserFirstName"] = usr.FirstName;
                        Session["LocalProducerAppUserLastName"] = usr.LastName;
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        [HttpGet]
        public ActionResult MyAccount()
        {
            if(Session["LocalProducerAppUserId"] != null)
            {
                UserProductsViewModel prodViewModel = new UserProductsViewModel();
                var userid = Guid.Parse(Session["LocalProducerAppUserId"].ToString());
                var currentUser = db.Utilizatori.Where(x => x.UserId == userid).FirstOrDefault();
                prodViewModel.Utilizator = currentUser;

                var activeProd = db.Products.Where(x => x.PostEndDate >= DateTime.Now).ToList();
                prodViewModel.ActivePosts.AddRange(activeProd);

                var inactiveProd = db.Products.Where(x => x.PostEndDate < DateTime.Now).ToList();
                prodViewModel.InactivePosts.AddRange(inactiveProd);

                return View(prodViewModel);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult MyAccount(User user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(schema + host + ":" + port + "/api/apiaccountmanager");

                var putTask = client.PutAsJsonAsync<User>("/api/apiaccountmanager/modifyaccountinfo", user);
                putTask.Wait();

                var result = putTask.Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TempData["ResponseType"] = "Ok";
                    TempData["Message"] = "Ati actualizat cu succes datele contului dumneavoastra!";
                    return View(user);
                }
                else
                {
                    TempData["ResponseType"] = "Error";
                    TempData["Message"] = "A aparut o eroare la procesarea modificarea informatiilor asociate contului dvs. Va rugam sa incercati din nou.";
                    return View(user);
                }
            }
        }

        public ActionResult Logout()
        {
            Session["LocalProducerAppUserId"] = null;
            Session["LocalProducerAppUserFirstName"] = null;
            Session["LocalProducerAppUserLastName"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}