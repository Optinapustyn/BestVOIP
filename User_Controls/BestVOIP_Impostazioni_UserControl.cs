using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BestVOIP.User_Controls
{
    public partial class BestVOIP_Impostazioni_UserControl : UserControl
    {
        // Variables
        string domainName, username, password, srcCidName, src;

        // Database Connection
        SqlConnection sqlConnection = new SqlConnection(Classes.Database.databaseString);

        public BestVOIP_Impostazioni_UserControl()
        {
            InitializeComponent();
        }

        private void BestVOIP_Impostazioni_UserControl_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand readCommand = new SqlCommand("Select * From BestVOIP_Configuration_Table", sqlConnection);
            SqlDataReader reader = readCommand.ExecuteReader();

            while (reader.Read())
            {
                DomainName_TextBox.Text = "  Domain: " + reader[0].ToString();
                Username_TextBox.Text = "  Username: " + reader[1].ToString();
                Password_TextBox.Text = "  Password: " + reader[2].ToString();
                SrcCidName_TextBox.Text = "  Src Cid Name: " + reader[3].ToString();
                Src_TextBox.Text = "  Src: " + reader[4].ToString();
            }

            sqlConnection.Close();
        }

        private void DomainName_TextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (DomainName_TextBox.Text == "  Domain Name:")
            {
                DomainName_TextBox.Clear();
            }
        }

        private void Username_TextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Username_TextBox.Text == "  Username:")
            {
                Username_TextBox.Clear();
            }
        }

        private void Password_TextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Password_TextBox.Text == "  Password:")
            {
                Password_TextBox.Clear();
            }
        }

        private void SrcCidName_TextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (SrcCidName_TextBox.Text == "  Src Cid Name:")
            {
                SrcCidName_TextBox.Clear();
            }
        }

        private void Src_TextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Src_TextBox.Text == "  Src:")
            {
                Src_TextBox.Clear();
            }
        }

        private void SalvaImpostazioni_Button_Click(object sender, EventArgs e)
        {
            if (DomainName_TextBox.Text != "" && Username_TextBox.Text != "" && Password_TextBox.Text != "" && SrcCidName_TextBox.Text != "" && Src_TextBox.Text != "")
            {
                // Setting The Variables
                domainName = DomainName_TextBox.Text;
                username = Username_TextBox.Text;
                password = Password_TextBox.Text;
                srcCidName = SrcCidName_TextBox.Text;
                src = Src_TextBox.Text;

                // SQL Operations
                sqlConnection.Open();
                SqlCommand updateConfigurationData = new SqlCommand("Update BestVOIP_Configuration_Table Set DomainName = @p1, Username = @p2, Password = @p3, SrcCidName = @p4, Src = @p5", sqlConnection);
                updateConfigurationData.Parameters.AddWithValue("@p1", domainName);
                updateConfigurationData.Parameters.AddWithValue("@p2", username);
                updateConfigurationData.Parameters.AddWithValue("@p3", password);
                updateConfigurationData.Parameters.AddWithValue("@p4", srcCidName);
                updateConfigurationData.Parameters.AddWithValue("@p5", src);
                updateConfigurationData.ExecuteNonQuery();
                sqlConnection.Close();

                // Show The MessageBox After The Operation
                MessageBox.Show("Configuration File Saved.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please Enter The Required Datas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
