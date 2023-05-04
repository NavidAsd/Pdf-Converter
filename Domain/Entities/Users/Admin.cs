using Domain.Entities.Commons;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Users
{
    public class Admin : BaseEntity
    {
        public string FullName { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string AccountImage { set; get; }
        public bool AddAdmin { set; get; } = false;
        public bool RemoveAdmin { set; get; } = false;

        //recovery
        [Column(TypeName = "datetime")]
        public DateTime? CodeExpiration { set; get; }
        public long? Code { set; get; }
        public bool Used { set; get; }

    }
}
