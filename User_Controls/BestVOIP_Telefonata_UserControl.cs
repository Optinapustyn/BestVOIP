using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.Data.SqlClient;
using System.IO;

namespace BestVOIP.User_Controls
{
    public partial class BestVOIP_Telefonata_UserControl : UserControl
    {
        WebRequest webRequest;

        string domainName, username, password, srcCidName, src;

        SqlConnection sqlConnection = new SqlConnection(Classes.Database.databaseString);

        public BestVOIP_Telefonata_UserControl()
        {
            InitializeComponent();
        }

        private void BestVOIP_Telefonata_UserControl_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                sqlConnection.Open();

                SqlCommand readTableCommand = new SqlCommand("Select * From BestVOIP_Contact_Table", sqlConnection);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                DataTable dt = new DataTable();

                sqlDataAdapter.SelectCommand = readTableCommand;
                sqlDataAdapter.Fill(dt);

                Contact_DataGridView.DataSource = dt;

                sqlConnection.Close();
            }
        }

        private void AvviaChiamata_Button_Click(object sender, EventArgs e)
        {
            webRequest = WebRequest.Create("https://11111(DOMAIN)/app/click_to_call/click_to_call.php?username=2222(USERNAME)&password=33333(PASSWORD)!&src_cid_name=4444(VALUE CUSTOM)&src=55555(EXTENSION)&dest=666666(PASTE NUMER");
            webRequest.Method = "POST";

            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            MessageBox.Show(responseFromServer);

            reader.Close();
            dataStream.Close();
            response.Close();
        }
    }
}
