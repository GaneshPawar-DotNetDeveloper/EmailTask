using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Send_Email_MVC_.Models
{
    public class EmailModel
    {
        [Required, Display(Name = "Recipient Email"), EmailAddress]
        public string To { get; set; }

        [Required, Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required, Display(Name = "Message")]
        public string Body { get; set; }
    }
}