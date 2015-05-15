using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;

namespace SqlClient_Contacts.Models
{
    public class ContactDataAccess
    {

        /// <summary>
        /// Inserts a Contact into the contact database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static bool InsertContact(string name, string email, string title)
        {
            //TODO: INSERT contact in database
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                //declares a variable for the scope of the code block
                con.Open(); //opens the conection to the database
                try //tries to execute the query
                {
                    //sql insert call
                    SqlCommand command = new SqlCommand("insert into Contacts (name,email,title) values (@name,@email,@title)", con);
                    command.Parameters.Add(new SqlParameter("name", name));
                    command.Parameters.Add(new SqlParameter("email", email));
                    command.Parameters.Add(new SqlParameter("title", title));
                    //executes the query
                    command.ExecuteNonQuery();
                    return true;
                }
                catch //if theres a problem executing query
                {
                    return false;
                }
            }

        }
           
        
        /// <summary>
        /// Deletes a row from the contacts table by contact ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteContact(int id)
        {
            //TODO: DELETE contact in the database by ID
           
               using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                //declares a variable for the scope of the code block
                con.Open(); //opens the conection to the database
                try
                {
                    //sql call to delete the row
                    SqlCommand command = new SqlCommand("Delete from Contacts where contactID=@id", con);
                    command.Parameters.Add(new SqlParameter("id", id));
            
                    //executes the query
                    command.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }


        /// <summary>
        /// Gets a contact row by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns a row based by the contact ID field</returns>
        public static Contact GetContactById(int id)
        {
            //TODO: SELECT a contact from the database by Id

            Contact card = new Contact();

            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {

                 
                //declares a variable for the scope of the code block
                con.Open(); //opens the conection to the database
                try
                {
                   
                    //sql call to make the selection
                    SqlCommand command = new SqlCommand("Select * from Contacts where contactID=@id", con);
                    command.Parameters.Add(new SqlParameter("id", id));

                    //executes the query and returns the row to a reader
                    SqlDataReader reader = command.ExecuteReader();
                    //while there are rows in the reader
                    while (reader.Read())
                    {
                        //get the row values
                        int contactid = reader.GetInt32(0);    // contact id
                        string name = reader.GetString(1);  // Name string
                        string email = reader.GetString(2); // email
                        string title = reader.GetString(3); // title string

                        //assign those values to the card object
                        card.ContactId = contactid;
                        card.Name = name;
                        card.Email = email;
                        card.Title = title;
                    }

                 

                }
                catch //if it catches an error
                {
                    return card;
                }
            }

            return card; //returns a row of type contact 
            
        }


        /// <summary>
        /// gets all the contacts in the contact table
        /// </summary>
        /// <returns></returns>
        public static List<Contact> GetAllContacts() 
        {
            //TODO: SELECT all contacts from the database

            List<Contact> listOfContacts = new List<Contact>();

            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                //declares a variable for the scope of the code block
                con.Open(); //opens the conection to the database
                try
                {
                    //sql call
                    SqlCommand command = new SqlCommand("Select * from Contacts", con);
                    
                    //executes the query and saves it to a sql reader
                    SqlDataReader reader = command.ExecuteReader();
                    //while the reader has rows
                    while (reader.Read())
                    {
                        //gets the values from the row
                        int contactid = reader.GetInt32(0);    // Weight int
                        string name = reader.GetString(1);  // Name string
                        string email = reader.GetString(2); // email string
                        string title = reader.GetString(3); // title string

                        //adds the values into the list as a contact object
                        listOfContacts.Add(new Contact() { ContactId = contactid, Name = name, Email = email, Title = title });
                    }

                    

                }
                catch//if it catches an error
                {
                    return listOfContacts;
                }
            }
            return listOfContacts; //return the contacts
        }



        /// <summary>
        /// updates a row in the contact table based in the contact ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static bool UpdateContact(int id, string name, string email, string title)
        {
            //TODO: UPDATE contact in the database by Id
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                //declares a variable for the scope of the code block
                con.Open(); //opens the conection to the database
                try
                {
                    
                    //sql calln to update the table row
                    SqlCommand command = new SqlCommand("UPDATE Contacts set name=@name, email=@email, title=@title, dateModified=@dateModified where contactID= @id", con);
                    command.Parameters.Add(new SqlParameter("id", id));
                    command.Parameters.Add(new SqlParameter("name", name));
                    command.Parameters.Add(new SqlParameter("email", email));
                    command.Parameters.Add(new SqlParameter("title", title));
                    command.Parameters.Add(new SqlParameter("dateModified", DateTime.Now ));//adds the current time to refect the last time it was modified
                    //executes the query
                    command.ExecuteNonQuery();
                    return true;
                }
                catch //if it catches an error
                {
                    return false;
                }
            }
           
        }

    }
}