using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Zadatak2
{
    public partial class Form1 : Form
    {
        public string cs = GetConnectionString("PPPK_DZ3");

        public Form1()
        {
            InitializeComponent();
        }

        private static string GetConnectionString(string imeBaze)
        {
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            csb.DataSource = "win-vm\\SQLEXPRESS";
            csb.UserID = "sa";
            csb.Password = "sql";
            csb.ConnectTimeout = 5;
            csb.InitialCatalog = imeBaze;

            return csb.ConnectionString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String path = Application.StartupPath + @"\Studenti.xml";
                KreirajXMLDatoteku(path);
                MessageBox.Show("Podaci su zapisani u datoteku " + path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void KreirajXMLDatoteku(String path)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Student", new SqlConnection(cs));
            DataTable tblStudenti = new DataTable("Studenti");
            da.Fill(tblStudenti);

            XmlWriterSettings xmlPostavke = new XmlWriterSettings();
            xmlPostavke.Indent = true;
            XmlWriter xmlWriter = XmlWriter.Create(path, xmlPostavke);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("studenti");

            foreach (DataRow row in tblStudenti.Rows)
            {
                xmlWriter.WriteStartElement("student");

                xmlWriter.WriteAttributeString("id", row["IDStudent"].ToString());
                xmlWriter.WriteElementString("ime", row["Ime"].ToString());
                xmlWriter.WriteElementString("prezime", row["Prezime"].ToString());
                xmlWriter.WriteElementString("jmbg", row["Jmbg"].ToString());
                xmlWriter.WriteElementString("email", row["Email"].ToString());

                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();

            xmlWriter.Close();

        }
    }
}
