using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.Entities
{
    public class SessionToken
    {   
        public SessionToken() { }
        public SessionToken(string jti, int userid, DateTime expDate)
        {
            this.Jti = jti;
            this.ExpirationDate = expDate;
            this.UserId = userid;
        }           

        [Key]
        public string Jti { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
