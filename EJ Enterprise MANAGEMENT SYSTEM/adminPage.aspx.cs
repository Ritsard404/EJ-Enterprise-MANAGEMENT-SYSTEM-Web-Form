using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Data;

namespace EJ_Enterprise_MANAGEMENT_SYSTEM
{
    public partial class adminPage : System.Web.UI.Page
    {
        private readonly string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\EJ Enterprise MANAGEMENT SYSTEM\EJ Enterprise MANAGEMENT SYSTEM\App_Data\Database1.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            adminList.DataBind();
        }

        protected void register_Click(object sender, EventArgs e)
        {
            string fname = adminfname.Value;
            string lname = adminlname.Value;
            string adminContact = admincontact.Value;
            string password = adminpass.Value;
            string salt = GenerateSalt();
            string hashedPass = HashPassword(password, salt);


            if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname) || string.IsNullOrEmpty(adminContact) || string.IsNullOrEmpty(password))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                        "swal('Invalid!', 'Invalid Name or Password!', 'error')", true);
                return;
            }

            // Perform manual validation
            if (!Regex.IsMatch(adminContact, "[0-9]{11}"))
            {
                // Display error message or handle validation failure

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                        "swal('Invalid!', 'Contact Number!', 'error')", true);
                return;
            }

            try
            {
                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO ADMIN(ADMIN_FNAME, ADMIN_LNAME, ADMIN_CONTACT, ADMIN_PASS, SALT) " +
                            "VALUES (@fname, @lname, @contact, @pass, @salt)";
                        cmd.Parameters.AddWithValue("@fname", fname);
                        cmd.Parameters.AddWithValue("@lname", lname);
                        cmd.Parameters.AddWithValue("@contact", adminContact);
                        cmd.Parameters.AddWithValue("@pass", hashedPass);
                        cmd.Parameters.AddWithValue("@salt", salt);

                        var ctr = cmd.ExecuteNonQuery();
                        if (ctr >= 1)
                        {
                            //Response.Write("<script>alert('New Employee account successfully registered!')</script>");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                "swal('Account Regstered!', 'New admin account successfully registered!', 'success')", true);
                            adminfname.Value = string.Empty;
                            adminlname.Value = string.Empty;
                            admincontact.Value = string.Empty;
                            adminList.DataBind();

                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                    "swal('Unsuccessfull!', 'No record registered!', 'error')", true);
                        }
                    }

                    db.Close();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                        "swal('Unsuccessfull!', '" + ex.Message + "', 'error')", true);
            }
        }
        protected string GenerateSalt()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var saltChars = new char[16];
            for (int i = 0; i < saltChars.Length; i++)
            {
                saltChars[i] = chars[random.Next(chars.Length)];
            }
            return new string(saltChars);
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

        protected void Suspendadmin_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;

            int adminID = Convert.ToInt32(adminList.DataKeys[rowIndex].Value);

            try
            {
                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE ADMIN SET ADMIN_STATUS = 'Suspend' WHERE ADMIN_ID = @id";
                        cmd.Parameters.AddWithValue("@id", adminID);

                        var ctr = cmd.ExecuteNonQuery();
                        if (ctr >= 1)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                "swal('Suspended!', 'Admin Account Suspended Successfully!', 'success')", true);
                            adminList.DataBind();
                        }
                    }

                    db.Close();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                        "swal('Unsuccessfull!', '" + ex.Message + "', 'error')", true);
            }
        }

        protected void Unsuspend_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;

            int adminId = Convert.ToInt32(adminList.DataKeys[rowIndex].Value);

            try
            {
                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE ADMIN SET ADMIN_STATUS = 'Active' WHERE ADMIN_ID = @id";
                        cmd.Parameters.AddWithValue("@id", adminId);

                        var ctr = cmd.ExecuteNonQuery();
                        if (ctr >= 1)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                "swal('Unsuspended!', 'Employee Account Unsuspended Successfully!', 'success')", true);
                            adminList.DataBind();
                        }
                    }

                    db.Close();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                        "swal('Unsuccessfull!', '" + ex.Message + "', 'error')", true);
            }
        }


        protected Boolean IsSuspended(string status)
        {
            return status == "Suspend";
        }

        protected Boolean IsActive(string status)
        {
            return status == "Active";
        }

        protected void Remove_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;

            int adminId = Convert.ToInt32(adminList.DataKeys[rowIndex].Value);

            try
            {
                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE ADMIN SET ADMIN_STATUS = 'Inactive' WHERE ADMIN_ID = @id";
                        cmd.Parameters.AddWithValue("@id", adminId);

                        var ctr = cmd.ExecuteNonQuery();
                        if (ctr >= 1)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                "swal('Account Removed!', 'Employee Account Removed Successfully!', 'success')", true);
                            adminList.DataBind();
                        }
                    }

                    db.Close();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                        "swal('Unsuccessfull!', '" + ex.Message + "', 'error')", true);
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            int id;
            string fname = Updateadminfname.Value;
            string lname = Updateadminlname.Value;
            string contact = Updateadmincontact.Value;
            string password = Updateadminpass.Value;


            if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname) || string.IsNullOrEmpty(contact) || string.IsNullOrEmpty(password))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                        "swal('Invalid!', 'Invalid Name or Password!', 'error')", true);
                return;
            }
            else
            {
                if (int.TryParse(AdminId.Value, out id))
                {
                    string salt = GenerateSalt();
                    string hashPass = HashPassword(password, salt);

                    using (var db = new SqlConnection(con))
                    {
                        db.Open();
                        using (var cmd = db.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "UPDATE ADMIN SET ADMIN_LNAME = @lname, ADMIN_FNAME = @fname, ADMIN_CONTACT = @cont, ADMIN_PASS = @pass WHERE ADMIN_ID = @id AND ADMIN_STATUS = 'Active'";
                            cmd.Parameters.AddWithValue("@lname", lname);
                            cmd.Parameters.AddWithValue("@fname", fname);
                            cmd.Parameters.AddWithValue("@cont", contact);
                            cmd.Parameters.AddWithValue("@pass", hashPass);
                            cmd.Parameters.AddWithValue("@id", id);

                            var ctr = cmd.ExecuteNonQuery();
                            if (ctr >= 1)
                            {
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                    "swal('Account Updated!', 'Employee Account Updated Successfully!', 'success')", true);
                                AdminId.Value = string.Empty;
                                Updateadminfname.Value = string.Empty;
                                Updateadminlname.Value = string.Empty;
                                Updateadmincontact.Value = string.Empty;
                                adminList.DataBind();
                            }
                            else
                            {
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                        "swal('Invalid!', 'Invalid ID!', 'error')", true);
                                AdminId.Value = string.Empty;
                                Updateadminfname.Value = string.Empty;
                                Updateadminlname.Value = string.Empty;
                                Updateadmincontact.Value = string.Empty;
                                return;

                            }
                        }

                        db.Close();
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                            "swal('Invalid!', 'Invalid ID!', 'error')", true);
                    return;
                }

            }
        }
    }
}