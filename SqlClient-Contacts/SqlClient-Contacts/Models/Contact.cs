using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SqlClient_Contacts.Models
{
    public class Contact
    {
        //TODO: Fill in the contact class
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Title { get; set; }

        public DateTime DateModified { get; set; } 
 
        public Contact()
        {

        }

        public Contact(int contactId, string name, string email, string title, DateTime timeMod)
        {
            this.ContactId = contactId;
            this.Name = name;
            this.Email = email;
            this.Title = title;
            this.DateModified = timeMod;

        }

    }
}