using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Akademetre.Models.Session
{
    public class Helpers
    {
        Dictionary<string, User> user = null;
        public Helpers()
        {
            user = new Dictionary<string, User>();
        }
        public List<User> UserList { get => user.Values.ToList(); }

        public void Add(User item)
        {

            user.Add(item.Email, item);
        }
    }
}