using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace PROJECT_NEW.ALMAS
{
    public partial class cust : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Get customer name and expiry date
            string customerName = txtCustomerName.Text;
            DateTime expiryDate;
            DateTime.TryParse(txtExpiryDate.Text, out expiryDate);

            // Get file paths and save files
            string visaFilePath = SaveFile(fuVisaUpload);
            string passportFilePath = SaveFile(fuPassportUpload);
            string otherDocumentFilePath = SaveFile(fuOtherDocument);

            // Save details to database
            SaveCustomerDetails(customerName, visaFilePath, passportFilePath, otherDocumentFilePath, expiryDate);
        }

        private string SaveFile(FileUpload fileUpload)
        {
            if (fileUpload.HasFile)
            {
                string filePath = Path.Combine(Server.MapPath("~/Uploads/"), fileUpload.FileName);
                fileUpload.SaveAs(filePath);
                return filePath;
            }
            return null;
        }

        private void SaveCustomerDetails(string customerName, string visaFilePath, string passportFilePath, string otherDocumentFilePath, DateTime expiryDate)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spInsertCustomerDetails", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerName", customerName);
                    cmd.Parameters.AddWithValue("@VisaFilePath", visaFilePath);
                    cmd.Parameters.AddWithValue("@PassportFilePath", passportFilePath);
                    cmd.Parameters.AddWithValue("@OtherDocumentFilePath", otherDocumentFilePath);
                    cmd.Parameters.AddWithValue("@ExpiryDate", expiryDate);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}