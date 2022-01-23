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

        string domainName, username, password, srcCidName, src, dest;

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
            sqlConnection.Open();
            SqlCommand readCommand = new SqlCommand("Select * From BestVOIP_Configuration_Table", sqlConnection);
            SqlDataReader reader = readCommand.ExecuteReader();

            while (reader.Read())
            {
                domainName = reader[0].ToString();
                username = reader[1].ToString();
                password = reader[2].ToString();
                srcCidName = reader[3].ToString();
                src = reader[4].ToString();
            }

            sqlConnection.Close();

            dest = Dest_TextBox.Text;

            webRequest = WebRequest.Create($"https://{domainName}/app/click_to_call/click_to_call.php?username={username}&password={password}!&src_cid_name={srcCidName}&src={src}&dest={dest}");
            webRequest.Method = "POST";

            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(dataStream);
            string responseFromServer = streamReader.ReadToEnd();

            MessageBox.Show(responseFromServer);

            streamReader.Close();
            dataStream.Close();
            response.Close();
        }
    }
}
