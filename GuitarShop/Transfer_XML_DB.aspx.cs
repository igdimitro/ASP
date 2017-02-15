using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using GuitarShop.App_Code;

namespace GuitarShop
{
    public partial class Transfer_XML_DB : System.Web.UI.Page
    {
        private int numberOfFiles = 0;
        private GuitarShopEntities6 context = new GuitarShopEntities6();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                XMLParser parser = new XMLParser();
                string[] files = Directory.GetFiles(Server.MapPath("~/App_Data"), "*.xml", SearchOption.AllDirectories);
                foreach (string fileName in files)
                {
                    numberOfFiles++;
                    try 
                    {
                        parser.LoadGuitarShopFromXML(fileName);
                        GuitarShops gs = parser.GuitarShop;
                        var gss = from r in context.GuitarShops                             
                                  select r.GuitarShopID;
                        if(gss.Contains(gs.GuitarShopID))
                        {
                            LiteralControl lic = new LiteralControl("<p class=\"fail\">" + numberOfFiles + ". "
                                + fileName + " - Магазин за китари с ID=" + gs.GuitarShopID + " вече съществува в БД!</p>");
                            PanelResults.Controls.Add(lic);
                        }
                        else
                        {
                            context.GuitarShops.AddObject(gs);
                            context.SaveChanges();
                            LiteralControl lic = new LiteralControl("<p class=\"success\">" + numberOfFiles
                                + ". " + fileName + " - Обработен успешно!</p>");
                            PanelResults.Controls.Add(lic);
                        }
                    }
                    catch(Exception ex)
                    {
                        LiteralControl lic = new LiteralControl("<p class=\"fail\">" + numberOfFiles + ". "
                            + fileName + " - " + ex.Message + " " + ex.InnerException + "</p>");
                       PanelResults.Controls.Add(lic);
                    }
                }
            }
        }

        protected void TruncateDB(object sender, EventArgs e)
        {
            SqlConnection con =
                new SqlConnection();
            con.ConnectionString = "Data Source=DESK403\\SQLEXPRESS;Initial Catalog=GuitarShop;Integrated Security=True";
            List<SqlCommand> commands = new List<SqlCommand>();
            commands.Add(new SqlCommand(@"delete from GuitarShop.dbo.AcousticGuitars"));
            commands.Add(new SqlCommand(@"delete from GuitarShop.dbo.Amplifiers"));
            commands.Add(new SqlCommand(@"delete from GuitarShop.dbo.ClassicalGuitars"));
            commands.Add(new SqlCommand(@"delete from GuitarShop.dbo.Contacts"));
            commands.Add(new SqlCommand(@"delete from GuitarShop.dbo.Strings"));
            commands.Add(new SqlCommand(@"delete from GuitarShop.dbo.Pickups"));
            commands.Add(new SqlCommand(@"delete from GuitarShop.dbo.ElectricGuitars"));
            commands.Add(new SqlCommand(@"delete from GuitarShop.dbo.GuitarShops"));
            con.Open();
            foreach (SqlCommand c in commands)
            {
                c.Connection = con;
                c.CommandType = System.Data.CommandType.Text;
                c.ExecuteNonQuery();
            }
            con.Close();

            GridView1.DataBind();
            GridView3.DataBind();
        }
    }
}