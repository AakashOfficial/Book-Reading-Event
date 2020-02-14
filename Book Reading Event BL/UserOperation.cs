using Book_Reading_Event_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Reading_Event_DAO {

    public class UserOperation {

        private BookReadingContext db;

        public UserOperation() {
            db = new BookReadingContext();
        }

        public bool addUser(User us) {
            if (us == null) {
                return false;
            }
            db.user.Add(us);
            db.SaveChanges();
            return true;
        }

        // Function TO List All the User
        public List<User> getUser() {
            var output = db.user.ToList();
            return output;
        }

        // Function To List all user Id and Name
        public string[] UserIds(int userId) {
            
            var output = db.user.Where(d => d.UserId != userId).ToList();
            string[] listUser = new string[2*output.Count];
            var i = 0;
            foreach (var user in output) {
                // System.Diagnostics.Debug.WriteLine(user.UserName);
                listUser[i] = ""+user.UserId;
                listUser[i+1] = user.UserName;
                i=i+2;
            }
            return listUser;
        }

        // Function To Check ID and Password
        public int checkUser(string useremail, string password) {
            int userId = 0;
            if (useremail == null && useremail == "" && password == null && password == "") {
                return 0;
            }
            var userData = db.user.ToList().Where(d => d.UserEmail == useremail && d.UserPassword == password);
            // System.Diagnostics.Debug.WriteLine(userData.Count<User>());
            foreach (var item in userData) {
                userId = item.UserId;
                // System.Diagnostics.Debug.WriteLine(item.UserId);
            }
            // System.Diagnostics.Debug.WriteLine(userId);
            if (userData != null) {
                return userId;
            } else {
                return 0;
            }
        }

        // Function to Get the User Role
        public string getRole(int userId) {
            var result = db.user.Single(d => d.UserId == userId);
            return result.UserRole ;
        }

        public IEnumerable<User> getUserData() {
            var output = db.user.ToList().Where(d => d.UserRole == "U");
            return output;
        }

        // Function To get the Invited User
        public void alreadyInvited(int eventId) {
            InvitationOperations inv = new InvitationOperations();
            var output = db.invitation.ToList().Where(d => d.EventId == eventId);
        }
    }
}