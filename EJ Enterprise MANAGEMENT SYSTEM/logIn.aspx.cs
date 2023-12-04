using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace EJ_Enterprise_MANAGEMENT_SYSTEM.Account_MAnagement
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private readonly string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\EJ Enterprise MANAGEMENT SYSTEM\EJ Enterprise MANAGEMENT SYSTEM\App_Data\Database1.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int id;
            string password = txtpassword.Value;

            if (int.TryParse(txtID.Value, out id)){

                // Check if the entered login credentials are valid
                if (IsValidEmployee(id, password))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                            "swal('Welcome!', 'Welcome Employee!', 'success')", true);
                    Response.Redirect("Home.aspx");
                }
                else if (IsValidAdmin(id, password))
                {

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                            "swal('Welcome!', 'Welcome Admin!', 'success')", true);
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                            "swal('Invalid!', 'Invalid ID or Password!', 'error')", true);
                    return;
                }
            }
            else
            {

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                        "swal('Invalid!', 'Invalid ID or Password!', 'error')", true);
                return;
            }

        }

        protected bool IsValidEmployee(int id, string enteredPass)
        {

            try
            {

                string hashedPasswordFromDatabase;
                string salt;

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM EMPLOYEE WHERE EMP_ID = @id AND EMP_STATUS = 'ACTIVE'";
                        cmd.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader read = cmd.ExecuteReader())
                        {
                            if (read.Read())
                            {
                                hashedPasswordFromDatabase = read["EMP_PASS"].ToString();
                                salt = read["SALT"].ToString();
                                Session["role"] = "employee";
                                Session["id"] = read["EMP_ID"].ToString();
                                Session["name"] = read["EMP_NAME"].ToString();
                            }
                            else
                            {
                                // User not found, login failed
                                return false;
                            }
                        }
                    }

                    db.Close();
                }
                // Hash the entered password with the retrieved salt
                string enteredPasswordHash = HashPassword(enteredPass, salt);

                // Compare the hashed passwords
                return string.Equals(hashedPasswordFromDatabase, enteredPasswordHash);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                        "swal('Unsuccessfull!', '" + ex.Message + "', 'error')", true);
                return false;
            }
        }

        protected bool IsValidAdmin(int id, string enteredPass)
        {

            try
            {
                string hashedPasswordFromDatabase;
                string salt;

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM ADMIN WHERE ADMIN_ID = @id AND ADMIN_STATUS = 'ACTIVE'";
                        cmd.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader read = cmd.ExecuteReader())
                        {
                            if (read.Read())
                            {
                                hashedPasswordFromDatabase = read["ADMIN_PASS"].ToString();
                                salt = read["SALT"].ToString();
                                Session["role"] = "admin";
                                Session["id"] = read["ADMIN_ID"].ToString();
                                Session["name"] = read["ADMIN_FNAME"].ToString()+" "+read["ADMIN_LNAME"].ToString();
                            }
                            else
                            {
                                // User not found, login failed
                                return false;
                            }
                        }
                    }

                    db.Close();
                }
                // Hash the entered password with the retrieved salt
                string enteredPasswordHash = HashPassword(enteredPass, salt);

                // Compare the hashed passwords
                return string.Equals(hashedPasswordFromDatabase, enteredPasswordHash);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                        "swal('Unsuccessfull!', '" + ex.Message + "', 'error')", true);
                return false;
            }
        }

        protected string HashPassword(string password, string salt)
        {
            // Combine the password and salt
            string combinedPassword = password + salt;

            // Choose the hash algorithm (SHA-256 or SHA-512)
            using (var sha256 = SHA256.Create())
            {
                // Convert the combined password string to a byte array
                byte[] bytes = Encoding.UTF8.GetBytes(combinedPassword);

                // Compute the hash value of the byte array
                byte[] hash = sha256.ComputeHash(bytes);

                // Convert the byte array to a hexadecimal string
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    result.Append(hash[i].ToString("x2"));
                }

                return result.ToString();
            }
        }
    }
}