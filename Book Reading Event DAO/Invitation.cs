using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Reading_Event_DAO
{
    public class Invitation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int InvitationActive { get; set; }

        public int EventId { get; set; }
        public int UserId { get; set; }


        public virtual Event Event { get; set; }

       // public virtual User User { get; set; }
    }
}