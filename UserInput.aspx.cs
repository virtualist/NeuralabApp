using System;
using System.Data.SqlClient;

namespace ProjectForNeuralab
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Application["connString"] = @"Data Source=.\SQLEXPRESS;AttachDBFilename=|DataDirectory|\Users.mdf;Integrated Security=True;User Instance=True;";
        }
        

        protected void btnSend_Click(object sender, EventArgs e)//user submits data//
        {
            DateTime date = DateTime.Now;
            string name = txtBoxName.Text.ToString(); /////////////////////////////////////
            string email = txtBoxEmail.Text.ToString(); // initializing employee input////
            string note = txtBoxNote.Text.ToString(); ////////////////////////////////////

            if (TextStringUtils.checkEmailValidation(email)) //validating provided email//
            { //email validation successful//
                string dictionary = DateTimeUtils.generateStringFromDate() + name + email; //formatting new string we will use for generating key//
                string userKey = TextStringUtils.generateRandomStringOnInputDictionary(dictionary);

                string connString = Application["connString"].ToString(); //using connection string from application state//

                    //writing user records to the database//
                    using (SqlConnection conn1 = new SqlConnection(connString))
                        {
                            string query1 = "INSERT INTO UserData (name,email,note,keyId) VALUES ('"+name+"','"+email+"','"+note+"','"+userKey+"')";
                            conn1.Open();
                            using (SqlCommand cmd1 = new SqlCommand(query1, conn1))
                            {
                                int count = (int) cmd1.ExecuteNonQuery(); //count will be 1 if query was successful//

                                if (count > 0) //if query was successful//
                                {
                                    lblResult.Text = "User data successfully written into database."; //display success to employee//
                                    lblResult.Visible = true;
                                }
                            }
                        }

            }
            else //email is in worng format and we want to notice user about that//
            {
                lblResult.Text = "Provided email has incorrect format!";
                lblResult.Visible = true;
            }
            
        }

    }
}
