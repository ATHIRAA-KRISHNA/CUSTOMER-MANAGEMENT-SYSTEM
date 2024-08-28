using ClosedXML.Excel;
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
    public partial class SearchCustomerDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSearch_Click(object sender, EventArgs e)
{
    string fromDate = txtFromDate.Text;
    string toDate = txtToDate.Text;
    if (fromDate != "" && toDate != "")
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string storedProcedure = "GetDocuments";  // Stored procedure name
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;  
                 
                        cmd.Parameters.AddWithValue("@FromDate", DateTime.Parse(fromDate));
                        cmd.Parameters.AddWithValue("@ToDate", DateTime.Parse(toDate));

                        // Create SqlDataAdapter to fill DataTable
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);  
                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                           
                            ViewState["CustomerData"] = dt;
                        }
                    }
                }

            }


            else
    {
        lblMessage.Text = "There Is No Document Found Inbetween This Period!!";
    }
}

protected void btnExportToExcel_Click(object sender, EventArgs e)
{
    DataTable dt = ViewState["CustomerData"] as DataTable;

    if (dt != null && dt.Rows.Count > 0)
    {
        using (XLWorkbook wb = new XLWorkbook())
        {
            var ws = wb.Worksheets.Add("CustomerData");

            ws.Cell(1, 1).InsertTable(dt.AsEnumerable());

            ws.Columns().AdjustToContents();

            using (MemoryStream stream = new MemoryStream())
            {
                wb.SaveAs(stream);
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=CustomerData.xlsx");
                Response.BinaryWrite(stream.ToArray());
                Response.End();
            }
        }
    }
    else
    {
        lblMessage.Text = "No data available to export.";
    }
}
    }
}