using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ProjectForNeuralab
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Application["connString"] = @"Data Source=.\SQLEXPRESS;AttachDBFilename=|DataDirectory|\Users.mdf;Integrated Security=True;User Instance=True;";
        }

        //exporting database to XML//
        protected void btnExportXML_Click(object sender, EventArgs e)
        {
            string connString = Application["connString"].ToString(); //using connection string from application state//
            string fileName = txtFileName.Text; //initializing employee input//
            string email = txtEmail.Text; //initializing employee input//


                if (File.Exists(System.Web.Hosting.HostingEnvironment.MapPath("~/doc/" + fileName + ".xml"))) //first checking if file with same name exists//
                {
                    lblResult.Text = "File with same name already exists. Please provide different name.";
                    lblResult.Visible = true;
                }
                else //if file with same name does not exist, call method to export into XML and show result to employee//
                {
                    string result = DataExport.exportIntoXML(fileName,connString);
                    lblResult.Text = result;
                    lblResult.Visible = true;
                }
        }

        //exporting database to CSV//
        protected void btnExportCSV_Click(object sender, EventArgs e)
        {
            string connString = Application["connString"].ToString(); //using connection string from application state//
            string fileName = txtFileName.Text; //initializing employee input//
            string email = txtEmail.Text; //initializing employee input//

                if (File.Exists(System.Web.Hosting.HostingEnvironment.MapPath("~/doc/" + fileName + ".csv"))) //first checking if file with same name exists//
                {
                    lblResult.Text = "File with same name already exists. Please provide different name.";
                    lblResult.Visible = true;
                }
                else //if file with same name does not exist, call method to export into CSV and show result to employee//
                {
                    string result = DataExport.exportIntoCSV(fileName, connString);
                    lblResult.Text = result;
                    lblResult.Visible = true;
                }
        }

        //show user data button click//
        protected void btnShow_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Application["connString"].ToString();
                SqlCommand comm1 = new SqlCommand ("SELECT * FROM UserData",conn);
                SqlDataAdapter da1 = new SqlDataAdapter(comm1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                GridView1.DataSource = ds1;
                GridView1.DataBind();
                GridView1.Visible = true;
            }
        }



    }
}