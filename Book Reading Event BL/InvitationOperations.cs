using Book_Reading_Event_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Reading_Event_BL {

    public class InvitationOperations {

        private BookReadingContext db;

        public InvitationOperations() {
            db = new BookReadingContext();
        }

        public bool addInvitation(Invitation invitation) {
            db.invitation.Add(invitation);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<Invitation> getInvitation(int userId) {
            var output = db.invitation.ToList().Where(d=>d.UserId == userId);
            return output;
        }
    }
}