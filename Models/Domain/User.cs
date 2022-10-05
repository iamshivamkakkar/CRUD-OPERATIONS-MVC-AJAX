using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shivam.Models.Domain
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmailAddress { get; set; }
        public string UserPassword { get; set; }
        public string UserGender { get; set; }
    }
}