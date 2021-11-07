using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProducatoriLocali.Models
{
    public class SendUserMessagesDTO
    {
        public Guid sender { get; set; }
        public Guid receiver { get; set; }
        public string messages { get; set; }
    }
}