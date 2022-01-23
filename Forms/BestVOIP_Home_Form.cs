using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestVOIP.Forms
{
    public partial class BestVOIP_Home_Form : Form
    {
        public BestVOIP_Home_Form()
        {
            InitializeComponent();
        }

        private void Telefonata_Button_Click(object sender, EventArgs e)
        {
            ButtonUI(Telefonata_Button, Contatto_Button, Impostazioni_Button, Navigation_Panel, bestVOIP_Telefonata_UserControl1);
        }

        private void Contatto_Button_Click(object sender, EventArgs e)
        {
            ButtonUI(Contatto_Button, Telefonata_Button, Impostazioni_Button, Navigation_Panel, bestVOIP_Contatto_UserControl1);
        }

        private void Impostazioni_Button_Click(object sender, EventArgs e)
        {
            ButtonUI(Impostazioni_Button, Telefonata_Button, Contatto_Button, Navigation_Panel, bestVOIP_Impostazioni_UserControl1);
        }

        private void ButtonUI(Button mainButton, Button otherButton1, Button otherButton2, Panel navigationPanel, UserControl mainUserControl)
        {
            // Main Button (Clicked Button)
            mainButton.BackColor = Color.FromArgb(46, 51, 73);
            mainButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(46, 51, 73);
            mainButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 51, 73);
            mainButton.FlatAppearance.CheckedBackColor = Color.FromArgb(46, 51, 73);

            // Sets The Navigation Panel To Clicked Button
            navigationPanel.Top = mainButton.Top;
            navigationPanel.Height = mainButton.Height;

            otherButton1.BackColor = Color.FromArgb(24, 30, 54);
            otherButton1.FlatAppearance.MouseDownBackColor = Color.FromArgb(24, 30, 54);
            otherButton1.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 30, 54);
            otherButton1.FlatAppearance.CheckedBackColor = Color.FromArgb(24, 30, 54);

            otherButton2.BackColor = Color.FromArgb(24, 30, 54);
            otherButton2.FlatAppearance.MouseDownBackColor = Color.FromArgb(24, 30, 54);
            otherButton2.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 30, 54);
            otherButton2.FlatAppearance.CheckedBackColor = Color.FromArgb(24, 30, 54);

            // Sets The UserControl To View
            mainUserControl.BringToFront();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimize_Button_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
