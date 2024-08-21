using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaborativeNotes.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> LocalFileIds { get; set; }
        public List<string> ContactIds { get; set; }
        public List<string> Invitations { get; set; }

        public User(string id, string username, string password, List<string> localFileIds, List<string> contactIds, List<string> invitations)
        {
            Id = id;
            Username = username;
            Password = password;
            LocalFileIds = localFileIds;
            ContactIds = contactIds;
            Invitations = invitations;
        }
    }
}
