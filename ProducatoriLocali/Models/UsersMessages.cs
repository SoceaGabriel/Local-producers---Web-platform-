using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProducatoriLocali.Models
{
    [Table("UsersMessages")] 
    public class UsersMessages 
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public Guid MessageId { get; set; } 
        public Guid UserWhoSendMessageId { get; set; } 
        public Guid UserWhoReceiveMessage { get; set; } 
        public string UserWhoSendMessageName { get; set; } 
        public string UserWhoReceivedMessageName { get; set; }  
        [Required(ErrorMessage = "Message is required to be complete.")] 
        public string MessageText { get; set; } 
        [Required(ErrorMessage = " Generated Date is required to be complete.")] 
        public DateTime GeneratedDate { get; set; } 
    }
}