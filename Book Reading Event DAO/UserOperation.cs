using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Reading_Event_DAO {

    class UserOperation {

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
    }
}