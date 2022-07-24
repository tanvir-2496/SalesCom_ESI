using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.OleDb;
using System.IO;

namespace POS.DAL
{
    class ImportFromExcel
    {
        private string strConnection;
        public ImportFromExcel(string filePath)
        {

            if(Path.GetExtension(filePath).ToLower()==".xlsx")

            strConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + filePath + @";Extended Properties=""Excel 12.0;HDR=YES""";

            else
            strConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + filePath + @";Extended Properties=""Excel 8.0;HDR=YES""";
        }

        public DataTable LoadFromExcel()
        {
            DataSet excelData = new DataSet();

            OleDbDataAdapter data = new OleDbDataAdapter(ExcelSourceCommand(), strConnection);
            data.TableMappings.Add("Table", "ExcelData");
            data.Fill(excelData);

            return excelData.Tables["ExcelData"];
        }
        private string ExcelSourceCommand()
        {
            string scommand = string.Empty;
            scommand = "SELECT  *	 FROM [Sheet1$]";
            return scommand;
        }

        

    }
}
