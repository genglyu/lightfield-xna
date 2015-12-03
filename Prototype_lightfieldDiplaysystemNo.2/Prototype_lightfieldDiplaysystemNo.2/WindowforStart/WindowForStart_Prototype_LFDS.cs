using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prototype_lightfieldDiplaysystemNo2.WindowforStart
{
    public partial class WindowForStart_Prototype_LFDS : Form
    {
        public WindowForStart_Prototype_LFDS()
        {
            InitializeComponent();
            configDataInStart.LoadFromFile("ConfigFile");
            UpdateFromConfigData();

        }

        private void WindowForStart_Prototype_LFDS_Load(object sender, EventArgs e)
        {

        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Apply_Click(object sender, EventArgs e)
        {
            SaveToConfigData();
            configDataInStart.SaveConfigDataToFile("ConfigFile");
        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            configDataInStart = new ConfigTools.ConfigData_of_XML();
            UpdateFromConfigData();
        }

    }
}
