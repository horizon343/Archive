using Archive.Data;
using Archive.DB;

namespace Archive
{
    public partial class Form1 : Form
    {
        private Button currentButton;
        private int tempIndex;
        private Form activeForm;

        public Form1()
        {
            InitializeComponent();

            DBase dBase = new DBase();
            dBase.CreateTables();
            dBase.CloseDatabaseConnection();

            Task.Run(async () =>
            {
                DataBase dataBase = new DataBase();
                if (DataBase.errorWhenConnection)
                {
                    this.Close();
                    return;
                }

                await MKB.GetMKB();
                await Departments.GetDepartment();
                await StorageLocation.GetStorageLocation();
            });
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.Orange;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }
            }

        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormRecords(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormPatients(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormMKB(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void ImportDataButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormImportData(), sender);
        }

        private void Departments_button_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormDepartments(), sender);
        }
    }
}