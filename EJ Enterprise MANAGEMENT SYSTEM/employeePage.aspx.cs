using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Data;

namespace EJ_Enterprise_MANAGEMENT_SYSTEM
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private readonly string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\EJ Enterprise MANAGEMENT SYSTEM\EJ Enterprise MANAGEMENT SYSTEM\App_Data\Database1.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            empList.DataBind();
        }

        protected void register_Click(object sender, EventArgs e)
        {
            // Get user input from form

            string name = empname.Value;
            string password = txtpassword.Value;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                        "swal('Invalid!', 'Invalid Name or Password!', 'error')", true);
                return;
            }
                // Generate a random salt for each user
                string salt = GenerateSalt();

            // Combine the password and salt and then hash
            string hashedPassword = HashPassword(password, salt);

            try
            {
                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO EMPLOYEE (EMP_NAME, EMP_PASS, SALT) " +
                            "VALUES (@name, @pass, @salt)";
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@pass", hashedPassword);
                        cmd.Parameters.AddWithValue("@salt", salt);

                        var ctr = cmd.ExecuteNonQuery();
                        if (ctr >= 1)
                        {
                            //Response.Write("<script>alert('New Employee account successfully registered!')</script>");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                "swal('Account Regstered!', 'New Employee account successfully registered!', 'success')", true);
                            empname.Value = string.Empty;
                            empList.DataBind();

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
                        "swal('Unsuccessfull!', '"+ ex.Message +"', 'error')", true);
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

        protected void SuspendEmp_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;

            int empId = Convert.ToInt32(empList.DataKeys[rowIndex].Value);

            try
            {
                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE EMPLOYEE SET EMP_STATUS = 'Suspend' WHERE EMP_ID = @id";
                        cmd.Parameters.AddWithValue("@id", empId);

                        var ctr = cmd.ExecuteNonQuery();
                        if (ctr >= 1)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                "swal('Suspended!', 'Employee Account Suspended Successfully!', 'success')", true);
                            empList.DataBind();
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

            int empId = Convert.ToInt32(empList.DataKeys[rowIndex].Value);

            try
            {
                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE EMPLOYEE SET EMP_STATUS = 'Active' WHERE EMP_ID = @id";
                        cmd.Parameters.AddWithValue("@id", empId);

                        var ctr = cmd.ExecuteNonQuery();
                        if (ctr >= 1)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                "swal('Unsuspended!', 'Employee Account Unsuspended Successfully!', 'success')", true);
                            empList.DataBind();
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

            int empId = Convert.ToInt32(empList.DataKeys[rowIndex].Value);

            try
            {
                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE EMPLOYEE SET EMP_STATUS = 'Inactive' WHERE EMP_ID = @id";
                        cmd.Parameters.AddWithValue("@id", empId);

                        var ctr = cmd.ExecuteNonQuery();
                        if (ctr >= 1)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                "swal('Account Removed!', 'Employee Account Removed Successfully!', 'success')", true);
                            empList.DataBind();
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
            string name = UpdateName.Value;
            string password = UpdatePass.Value;


            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                        "swal('Invalid!', 'Invalid Name or Password!', 'error')", true);
                return;
            }
            else
            {
                if (int.TryParse(EmpId.Value, out id))
                {
                    string salt = GenerateSalt();
                    string hashPass = HashPassword(password, salt);

                    using (var db = new SqlConnection(con))
                    {
                        db.Open();
                        using (var cmd = db.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "UPDATE EMPLOYEE SET EMP_NAME = @name, EMP_PASS = @pass WHERE EMP_ID = @id AND EMP_STATUS = 'Active'";
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@pass", hashPass);
                            cmd.Parameters.AddWithValue("@id", id);

                            var ctr = cmd.ExecuteNonQuery();
                            if (ctr >= 1)
                            {
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                    "swal('Account Updated!', 'Employee Account Updated Successfully!', 'success')", true);
                                UpdateName.Value = string.Empty;
                                EmpId.Value = string.Empty;
                                empList.DataBind();
                            }
                            else
                            {
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                                        "swal('Invalid!', 'Invalid ID!', 'error')", true);
                                UpdateName.Value = string.Empty;
                                EmpId.Value = string.Empty;
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