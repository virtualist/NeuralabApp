using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace ProjectForNeuralab
{
    /// <summary>
    /// DataExport class contains methods for exporting database into XML or CSV documents.
    /// </summary>
    class DataExport
    {
        /// <summary>
        /// Method exports database from the provided connection string to the XML file with provided name.
        /// </summary>
        /// <param name="fileName">Name of the new file that method will create.</param>
        /// <param name="connString">Connection string for database that will be exported.</param>
        /// <returns>Result that will notify employee on success status.</returns>
        public static string exportIntoXML(string fileName, string connString)
        {
            string result;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM UserData", conn);
                command.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds, "UserData");
                //Get a FileStream object//
                StreamWriter xmlDoc = new StreamWriter(System.Web.Hosting.HostingEnvironment.MapPath("~/doc/" + fileName + ".xml"), false);
                //Apply the WriteXml method to write an XML document//
                ds.WriteXml(xmlDoc);
                xmlDoc.Close();
            }
            if (File.Exists(System.Web.Hosting.HostingEnvironment.MapPath("~/doc/" + fileName + ".xml")))
            {
                result = "Successfully created XML file: " + fileName + ".xml";
            }
            else
            {
                result = "Operation failed!";
            }

            return result;
        }



        /// <summary>
        /// Method exports database from the provided connection string to the CSV file with provided name.
        /// </summary>
        /// <param name="fileName">Name of the new file that method will create.</param>
        /// <param name="connString">Connection string for database that will be exported.</param>
        /// <returns>Result that will notify employee on success status.</returns>
        public static string exportIntoCSV(string fileName, string connString)
        {
            string result;
            using (SqlConnection conn1 = new SqlConnection(connString))
            {
                SqlCommand command1 = new SqlCommand("SELECT * FROM UserData", conn1);
                StreamWriter CsvfileWriter = new StreamWriter(System.Web.Hosting.HostingEnvironment.MapPath("~/doc/" + fileName + ".csv"));
                command1.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(command1);
                DataTable table = new DataTable();
                da.Fill(table);

                WriteToStream(CsvfileWriter, table, true, true);

                if (File.Exists(System.Web.Hosting.HostingEnvironment.MapPath("~/doc/" + fileName + ".csv")))
                {
                    result = "Successfully created XML file: " + fileName + ".csv";
                }
                else
                {
                    result = "Operation failed!";
                }

                return result;

            }
        }
        //Method that formats whole table data and writes it to the stream//
        public static void WriteToStream(TextWriter stream, DataTable table, bool header, bool quoteall)
        {
            if (header)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    WriteItem(stream, table.Columns[i].Caption, quoteall);
                    if (i < table.Columns.Count - 1)
                        stream.Write(',');
                    else
                        stream.Write('\n');
                }
            }

            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    WriteItem(stream, row[i], quoteall);
                    if (i < table.Columns.Count - 1)
                        stream.Write(',');
                    else
                        stream.Write('\n');
                }
            }
            stream.Flush();
            stream.Close();

        }


        //Method that formats each item (value from database - like name or email)//
        private static void WriteItem(TextWriter stream, object item, bool quoteall)
        {
            if (item == null)
                return;
            string s = item.ToString();
            if (quoteall || s.IndexOfAny("\",\x0A\x0D".ToCharArray()) > -1)
                stream.Write("\"" + s.Replace("\"", "\"\"") + "\"");
            else
                stream.Write(s);
            stream.Flush();
        }


        

    }

    
}