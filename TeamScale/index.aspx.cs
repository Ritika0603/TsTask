using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text;
using System.Web.Script.Serialization;
using TeamScale.logger;

namespace TeamScale
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                string m_Conn = ConfigurationManager.AppSettings["DB"].ToString();
                //string m_Conn = Directory.GetCurrentDirectory() + "/exercise01.sqlite";
                SQLiteConnection conread = new SQLiteConnection("Data Source=" + m_Conn);
                conread.Open();
                string selectSQL = "select rd.id,rd.age,wc.name as workclass_name,ed.name as education_name,education_num,ms.name as marital_status,oc.name as occupation,rc.name as race,sx.name as sex,capital_gain,capital_loss,hours_week,co.name as country,over_50k from records as rd INNER JOIN workclasses as wc ON rd.workclass_id = wc.id INNER JOIN education_levels as ed ON rd.education_level_id = ed.id INNER JOIN marital_statuses as ms ON rd.marital_status_id = ms.id INNER JOIN occupations as oc ON rd.occupation_id = oc.id INNER JOIN races as rc ON rd.race_id = rc.id INNER JOIN sexes as sx ON rd.sex_id = sx.id INNER JOIN countries as co ON rd.country_id = co.id";
                SQLiteCommand selectCommand = new SQLiteCommand(selectSQL, conread);
                SQLiteDataReader dataReader = selectCommand.ExecuteReader();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("records");
                dt.Load(dataReader);
                ds.Tables.Add(dt);
                using (StreamWriter writer = new StreamWriter(ConfigurationManager.AppSettings["output_csv"].ToString()))
                {
                    Writer.WriteDataTable(dt, writer, true);
                }
                //Response.Clear();
                //Response.AddHeader("content-disposition", "attachment; filename=" + "Record.csv");
                //Response.WriteFile(ConfigurationManager.AppSettings["output_csv"].ToString());
                //Response.ContentType = "";
                //Response.End();
            }
            catch (Exception ex)
            {
                loggerWorker.addLog(ex.Message + " " + ex.InnerException + " " + DateTime.Now);
            }




            //// Create a table in the database to receive the information from the DataSet

        }
        public static class Writer
        {
            public static void WriteDataTable(DataTable sourceTable, TextWriter writer, bool includeHeaders)
            {
                if (includeHeaders)
                {
                    IEnumerable<String> headerValues = sourceTable.Columns
                        .OfType<DataColumn>()
                        .Select(column => QuoteValue(column.ColumnName));

                    writer.WriteLine(String.Join(",", headerValues));
                }

                IEnumerable<String> items = null;

                foreach (DataRow row in sourceTable.Rows)
                {
                    items = row.ItemArray.Select(o => QuoteValue(o?.ToString() ?? String.Empty));
                    writer.WriteLine(String.Join(",", items));
                }

                writer.Flush();
            }

            private static string QuoteValue(string value)
            {
                return String.Concat("\"",
                value.Replace("\"", "\"\""), "\"");
            }
        }
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static string getUserDetail(string id)
        {
            try
            {
                string m_Conn = ConfigurationManager.AppSettings["DB"].ToString();
                //string m_Conn = Directory.GetCurrentDirectory() + "/exercise01.sqlite";
                SQLiteConnection conread = new SQLiteConnection("Data Source=" + m_Conn);
                conread.Open();
                string selectSQL = "select rd.id,rd.age,wc.name as workclass_name,ed.name as education_name,education_num,ms.name as marital_status,oc.name as occupation,rc.name as race,sx.name as sex,capital_gain,capital_loss,hours_week,co.name as country,over_50k from records as rd INNER JOIN workclasses as wc ON rd.workclass_id = wc.id INNER JOIN education_levels as ed ON rd.education_level_id = ed.id INNER JOIN marital_statuses as ms ON rd.marital_status_id = ms.id INNER JOIN occupations as oc ON rd.occupation_id = oc.id INNER JOIN races as rc ON rd.race_id = rc.id INNER JOIN sexes as sx ON rd.sex_id = sx.id INNER JOIN countries as co ON rd.country_id = co.id where rd.id=" + id + "";
                SQLiteCommand selectCommand = new SQLiteCommand(selectSQL, conread);
                SQLiteDataReader dataReader = selectCommand.ExecuteReader();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                ds.Tables.Add(dt);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string daresult = DataSetToJSON(ds);
                        return daresult;
                    }
                }
                return "false";
            }
            catch(Exception ex)
            {
                loggerWorker.addLog(ex.Message + " " + ex.InnerException + " " + DateTime.Now);
                return ex.Message;
            }
           
        }
        public static string DataSetToJSON(DataSet ds)
        {

            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (DataTable dt in ds.Tables)
            {
                object[] arr = new object[dt.Rows.Count + 1];

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    arr[i] = dt.Rows[i].ItemArray;
                }

                dict.Add(dt.TableName, arr);
            }

            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Serialize(dict);
        }
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static string getSalaryCateory(string id)
        {
            try
            {
                string m_Conn = ConfigurationManager.AppSettings["DB"].ToString();
                bool getSalDet = false;
                //string m_Conn = Directory.GetCurrentDirectory() + "/exercise01.sqlite";
                SQLiteConnection conread = new SQLiteConnection("Data Source=" + m_Conn);
                conread.Open();
                string selectSQL = "select over_50K from records where id=" + id + "";
                SQLiteCommand selectCommand = new SQLiteCommand(selectSQL, conread);
                SQLiteDataReader dataReader = selectCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    getSalDet = dataReader.GetBoolean(0);
                }

                return Convert.ToString(getSalDet);
            }
            catch(Exception ex)
            {
                loggerWorker.addLog(ex.Message + " " + ex.InnerException + " " + DateTime.Now);
                return ex.Message;
            }
            
        }

    }
}