using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archive.Forms
{
    public partial class FormPatientAndRecords : Form
    {
        public FormPatientAndRecords()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var FormAddRecord = new FormAddRecord();
            FormAddRecord.Show();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
