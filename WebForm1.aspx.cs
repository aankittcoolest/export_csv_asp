using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Data;
using System.IO;

public partial class WebForm1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        string strDelimeter = ddlExportFormat.SelectedValue == "COMMA DELIMITED" ? "," : "|";
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        StringBuilder sb = new StringBuilder();
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT [ID],[Name],[Location] FROM [dbo].[Departments];SELECT [ID],[Name],[DepartmentID] FROM [dbo].[Employees];", con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            ds.Tables[0].TableName = "Departments";
            ds.Tables[1].TableName = "Employees";

            foreach (DataRow departmentDR in ds.Tables["Departments"].Rows)
            {
                int departmentId = Convert.ToInt32(departmentDR["ID"]);
                sb.Append(departmentId.ToString() + strDelimeter);
                sb.Append(departmentDR["Name"].ToString() + strDelimeter);
                sb.Append(departmentDR["Location"].ToString());
                sb.Append("\r\n");

                foreach (DataRow employeeDR in ds.Tables["Employees"].Select("DepartmentId = '" + departmentId.ToString() + "'"))
                {
                    sb.Append(employeeDR["ID"].ToString() + strDelimeter);
                    sb.Append(employeeDR["Name"].ToString() + strDelimeter);
                    sb.Append(departmentId.ToString());
                    sb.Append("\r\n");
                }

            }
        }

        //string strFileName = strDelimeter == "," ? "Data.csv" : "Data.txt";
        string strFileName = "Data.csv";

        StreamWriter file = new StreamWriter(@"C:\Users\Ankit\OneDrive\Documents\ExportedData\" + strFileName);
        file.WriteLine(sb.ToString());
        file.Close();
    }

    
}