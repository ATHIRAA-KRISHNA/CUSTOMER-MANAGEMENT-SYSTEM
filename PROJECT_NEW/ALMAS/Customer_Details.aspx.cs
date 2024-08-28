using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace PROJECT_NEW.ALMAS
{
    public partial class Customer_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
         protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string customerName = txtCustomerName.Text;
                int customerId = SaveCustomerDetails(customerName);

                SaveDocument(customerId, fuVisa, txtVisaExpiryDate.Text, "Visa");
                SaveDocument(customerId, fuPassport, txtPassportExpiryDate.Text, "Passport");

                lblMessage.Text = "Customer details saved successfully!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                //lblMessage.Text = "Error: " + ex.Message;
            }
        }

        private int SaveCustomerDetails(string customerName)
        {
            int customerId = 0;
            string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string storedProcedure = "CUSTOMERDETAIL";  // CUSTOMERDETAIL is the name of your stored procedure
                SqlCommand cmd = new SqlCommand(storedProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerName", customerName);

                con.Open();

               
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    customerId = Convert.ToInt32(result);  
                }
                else
                {
                   
                    customerId = 0;  
                }
            }


            return customerId;
        }

        private void SaveDocument(int customerId, FileUpload fileUpload, string expiryDate, string documentType)
        {
            if (fileUpload.HasFile)
            {
                string filePath = SaveFile(fileUpload);
                DateTime expiry = DateTime.Parse(expiryDate);

                string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string storedProcedure = "DocumentDetail";  
                    SqlCommand cmd = new SqlCommand(storedProcedure, con);
                    cmd.CommandType = CommandType.StoredProcedure;  // Set the command type to StoredProcedure
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    cmd.Parameters.AddWithValue("@DocumentType", documentType);
                    cmd.Parameters.AddWithValue("@DocumentFilePath", filePath);
                    cmd.Parameters.AddWithValue("@ExpiryDate", expiry);

                    con.Open();
                    cmd.ExecuteNonQuery();  // Execute  procedure
                }

            }
        }

        private string SaveFile(FileUpload fileUpload)
        {
            string folderPath = Server.MapPath("~/Uploads/");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = folderPath + Path.GetFileName(fileUpload.FileName);
            fileUpload.SaveAs(filePath);
            return filePath;
        }
    }
}