using Archive.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Archive.Validation;

namespace Archive.Forms
{
    public partial class FormDepartments : Form
    {
        public int TotalCount { get; set; } = 0;
        public int CurrentPage { get; set; } = 1;
        private int limit = 100;
        public FormDepartments()
        {
            InitializeComponent();

            DepartmentsTableInit(CurrentPage, limit);

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
            };



            foreach (DataGridViewColumn column in DepartmentsTable.Columns)
                column.ReadOnly = true;

            PrevPageButton.Enabled = false;
            if (CurrentPage >= TotalCount)
                NextPageButton.Enabled = false;


            DepartmentsTable.Columns[0].HeaderText = "ID";
            DepartmentsTable.Columns[1].HeaderText = "Отделение";
            DepartmentsTable.Columns[0].Width = 100;
            DepartmentsTable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DepartmentsTable.DefaultCellStyle = cellStyle;

        }
        private void data_show()
        {


        }
        private void DepartmentsTableInit(int currentPage, int limit)
        {
            // Получение таблицы пациентов из базы данных
            DBase dBase = new DBase();
            (int, List<DepartmentItem>) Department = dBase.GetTable<DepartmentItem>(currentPage, limit);
            dBase.CloseDatabaseConnection();
            TotalCount = Department.Item1;

            // Выбираем только необходимые поля и добавляем пациентов втаблицу
            List<DepartmentViewItem> DepartmentDataSource = Department.Item2.Select(Department => new DepartmentViewItem()
            {
                DepartmentID = Department.DepartmentID,
                Title = Department.Title
            }).ToList();
            DepartmentsTable.DataSource = DepartmentDataSource;

            CountPageTextBox.Text = $"{CurrentPage} / {TotalCount}";
        }

        private void NextPageButton_Click(object sender, EventArgs e)
        {
            if (CurrentPage + 1 <= TotalCount)
            {
                CurrentPage += 1;
                PrevPageButton.Enabled = true;
                DepartmentsTableInit(CurrentPage, limit);

                if (CurrentPage + 1 > TotalCount)
                    NextPageButton.Enabled = false;
            }
        }

        private void PrevPageButton_Click(object sender, EventArgs e)
        {
            if (CurrentPage - 1 >= 1)
            {
                CurrentPage -= 1;
                NextPageButton.Enabled = true;
                DepartmentsTableInit(CurrentPage, limit);

                if (CurrentPage - 1 < 1)
                    PrevPageButton.Enabled = false;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            TotalCount = 1;
            CurrentPage = 1;

            Dictionary<string, object> fields = new Dictionary<string, object>();
            if (DepartmentIDTextField.Text != "")
                fields.Add("DepartmentID", DepartmentIDTextField.Text);
            if (DepartmentTitleTextField.Text != "")
                fields.Add("Title", DepartmentTitleTextField.Text);


            if (fields.Count != 0)
            {
                DBase dBase = new DBase();
                List<DepartmentItem> Department = dBase.SearchData<DepartmentItem>(fields);
                dBase.CloseDatabaseConnection();

                List<DepartmentViewItem> DepartmentDataSource = Department.Select(Department => new DepartmentViewItem()
                {
                    DepartmentID = Department.DepartmentID,
                    Title = Department.Title
                }).ToList();
                DepartmentsTable.DataSource = DepartmentDataSource;

                CountPageTextBox.Text = $"1 / 1";
                PrevPageButton.Enabled = false;
                NextPageButton.Enabled = false;
            }
            else
            {
                DepartmentsTableInit(CurrentPage, limit);
                PrevPageButton.Enabled = false;
                NextPageButton.Enabled = true;
            }
        }
    }


    class DepartmentViewItem
    {
        public int DepartmentID { get; set; }
        public string Title { get; set; }

    }
}


