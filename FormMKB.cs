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
    public partial class FormMKB : Form
    {
        public int TotalCount { get; set; } = 0;
        public int CurrentPage { get; set; } = 1;
        private int limit = 100;
        public FormMKB()
        {
            InitializeComponent();

            MKBTableInit(CurrentPage, limit);

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
            };



            foreach (DataGridViewColumn column in MKBTable.Columns)
                column.ReadOnly = true;

            PrevPageButton.Enabled = false;
            if (CurrentPage >= TotalCount)
                NextPageButton.Enabled = false;


            MKBTable.Columns[0].HeaderText = "Код";
            MKBTable.Columns[1].HeaderText = "Болезнь";
            MKBTable.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MKBTable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MKBTable.DefaultCellStyle = cellStyle;

        }
        private void data_show()
        {


        }
        private void MKBTableInit(int currentPage, int limit)
        {
            // Получение таблицы пациентов из базы данных
            DBase dBase = new DBase();
            (int, List<MKBItem>) MKB = dBase.GetTable<MKBItem>(currentPage, limit);
            dBase.CloseDatabaseConnection();
            TotalCount = MKB.Item1;

            // Выбираем только необходимые поля и добавляем пациентов втаблицу
            List<MKBViewItem> MKBDataSource = MKB.Item2.Select(MKB => new MKBViewItem()
            {
                MKBCode = MKB.MKBCode,
                Title = MKB.Title
            }).ToList();
            MKBTable.DataSource = MKBDataSource;

            CountPageTextBox.Text = $"{CurrentPage} / {TotalCount}";
        }

        private void NextPageButton_Click(object sender, EventArgs e)
        {
            if (CurrentPage + 1 <= TotalCount)
            {
                CurrentPage += 1;
                PrevPageButton.Enabled = true;
                MKBTableInit(CurrentPage, limit);

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
                MKBTableInit(CurrentPage, limit);

                if (CurrentPage - 1 < 1)
                    PrevPageButton.Enabled = false;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            TotalCount = 1;
            CurrentPage = 1;

            Dictionary<string, object> fields = new Dictionary<string, object>();
            if (MKBCodeTextField.Text != "")
                fields.Add("MKBCode", MKBCodeTextField.Text);
            if (DiseaseTextField.Text != "")
                fields.Add("Title", DiseaseTextField.Text);


            if (fields.Count != 0)
            {
                DBase dBase = new DBase();
                List<MKBItem> MKB = dBase.SearchData<MKBItem>(fields);
                dBase.CloseDatabaseConnection();

                List<MKBViewItem> MKBDataSource = MKB.Select(MKB => new MKBViewItem()
                {
                    MKBCode = MKB.MKBCode,
                    Title = MKB.Title
                }).ToList();
                MKBTable.DataSource = MKBDataSource;

                CountPageTextBox.Text = $"1 / 1";
                PrevPageButton.Enabled = false;
                NextPageButton.Enabled = false;
            }
            else
            {
                MKBTableInit(CurrentPage, limit);
                PrevPageButton.Enabled = false;
                NextPageButton.Enabled = true;
            }
        }
    }


    class MKBViewItem
    {
        public string MKBCode { get; set; }
        public string Title { get; set; }

    }
}
