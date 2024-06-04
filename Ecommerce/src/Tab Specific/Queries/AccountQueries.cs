using System;
using System.Collections.Generic;
using System.Linq;
using ProjectNS;

namespace ProjectNS.AccountNS
{
    class Queries
    {
        public class Return
        {
            public Return(bool theBool, int? id = null)
            {
                this.TheBool = theBool;
                this.Id = id;
            }
            public bool TheBool { get; }
            public int? Id { get; }
        }


        public static Return Exist(DbDataContext db, String username, String password)
        {
            List<User> list = db.Users.
                Where(
                    u => u.username.Equals(username) &&
                    u.password.Equals(password)
                ).
                ToList();
            return list.Count() == 0 ?
                new Return(false) :
                new Return(true, list.First().id);
        }


        public static Return Add(DbDataContext db, String username, String password)
        {
            bool usernameIsAlreadyTaken = db.Users.
                Any(
                    u => u.username.Equals(username)
                );
            /*The username identifies an account, and the password protects it.
             * The username both is what needs to be unique as well as not be what protects
             * the account, because you need to be able to tell the user to choose
             * a different one (you wouldn't be able to tell a user to choose a different
             * username and password combination because the one they input was taken already).*/
            if (usernameIsAlreadyTaken)
            {
                return new Return(false);
            }

            User user = new User()
            {
                username = username,
                password = password,
                balance = 0
            };

            db.Users.InsertOnSubmit(user);
            db.SubmitChanges();

            /*In case 2 queries to the db were made to find if the same username was taken,
             * and they are both told that it is untaken, so they both get inserted:*/
            int thisId = user.id;
            var first = db.Users.
                Where(
                    u => u.username.Equals(username)
                ).
                OrderBy(
                    u => u.id
                ).
                First();
            if (first.id == thisId)
            {
                return new Return(true, first.id);
            }
            db.Users.DeleteOnSubmit(user);
            db.SubmitChanges();
            return new Return(false);
        }
    }
}
