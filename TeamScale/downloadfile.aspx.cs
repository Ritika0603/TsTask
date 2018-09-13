using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamScale.logger;

namespace TeamScale
{
    public partial class downloadfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                try
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment;filename=record.csv");
                    Response.Charset = "";
                    Response.ContentType = "application/text";
                    Response.Output.Write(ConfigurationManager.AppSettings["output_csv"].ToString());
                    Response.Flush();
                    Response.End();


                }
                catch (FileNotFoundException ex)
                {
                    loggerWorker.addLog(ex.Message + " " + ex.InnerException + " " + DateTime.Now);
                    Response.Redirect("index.aspx");
                }
                catch (Exception ex)
                {
                    loggerWorker.addLog(ex.Message + " " + ex.InnerException + " " + DateTime.Now);
                    Response.Redirect("index.aspx");
                }

            }
            catch (Exception ex)
            {
                loggerWorker.addLog(ex.Message + " " + ex.InnerException + " " + DateTime.Now);

            }
        }
    }
}