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

        // Function To Invite the User
        public bool inviteUser(int eventId, int[] userId) {

            Invitation invitation = new Invitation();

            for (int i = 0; i < userId.Length; i++) {
                invitation.EventId = eventId;
                invitation.UserId = userId[i];
                invitation.InvitationActive = 1;

                db.invitation.Add(invitation);
                db.SaveChanges();
            }
            return true;
        }

    }
}