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
    public partial class FormRecords : Form
    {
        public int TotalCount { get; set; } = 0;
        public int CurrentPage { get; set; } = 1;
        private int limit = 100;
        private List<RecordsViewItem> recordDataSource;
        private int columnIndex = -1;
        public FormRecords()
        {
            InitializeComponent();

            RecordsTableInit(CurrentPage, limit);

            RecordsTable.CellClick += RecordsTable_CellClick;

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
            };

            foreach (DataGridViewColumn column in RecordsTable.Columns)
                column.ReadOnly = true;

            PrevPageButton.Enabled = false;
            if (CurrentPage >= TotalCount)
                NextPageButton.Enabled = false;

            RecordsTable.Columns[0].HeaderText = "Номер Истории";
            RecordsTable.Columns[1].HeaderText = "Отделение";
            RecordsTable.Columns[2].HeaderText = "Дата Посупления";
            RecordsTable.Columns[3].HeaderText = "Дата выписки";
            RecordsTable.Columns[4].HeaderText = "Код МКБ";
            RecordsTable.Columns[0].Width = 100;
            RecordsTable.Columns[1].Width = 300;
            RecordsTable.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RecordsTable.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RecordsTable.DefaultCellStyle = cellStyle;



        }
        private void RecordsTableInit(int currentPage, int limit)
        {
            DBase dBase = new DBase();
            (int, List<RecordItem>) Record = dBase.GetTable<RecordItem>(currentPage, limit);
            dBase.CloseDatabaseConnection();
            TotalCount = Record.Item1;

            recordDataSource = Record.Item2.Select(Record => new RecordsViewItem()
            {
                HistoryNumber = Record.HistoryNumber,
                DepartmentID = Record.DepartmentID,
                DateOfReceipt = Record.DateOfReceipt,
                DateOfDischarge = Record.DateOfDischarge,
                MKBCode = Record.MKBCode

            }).ToList();
            RecordsTable.DataSource = recordDataSource;

            CountPageTextBox.Text = $"{CurrentPage} / {TotalCount}";
        }
        private void NextPageButton_Click(object sender, EventArgs e)
        {
            if (CurrentPage + 1 <= TotalCount)
            {
                CurrentPage += 1;
                PrevPageButton.Enabled = true;
                RecordsTableInit(CurrentPage, limit);

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
                RecordsTableInit(CurrentPage, limit);

                if (CurrentPage - 1 < 1)
                    PrevPageButton.Enabled = false;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            TotalCount = 1;
            CurrentPage = 1;

            Dictionary<string, object> fields = new Dictionary<string, object>();
            if (HistoryNumberTextField.Text != "")
                fields.Add("HistoryNumber", HistoryNumberTextField.Text);
            if (DepartmentTextField.Text != "")
                fields.Add("DepartmentID", DepartmentTextField.Text);
            if (DateOfReceiptTextField.Text != "")
                fields.Add("DateOfReceipt", DateTime.Parse(DateOfReceiptTextField.Text));
            if (DateOfDischargeTextField.Text != "")
                fields.Add("DateOfDischarge", DateTime.Parse(DateOfDischargeTextField.Text));
            if (MKBCodeTextField.Text != "")
                fields.Add("MKBCode", MKBCodeTextField.Text);


            if (fields.Count != 0)
            {
                DBase dBase = new DBase();
                List<RecordItem> Record = dBase.SearchData<RecordItem>(fields);
                dBase.CloseDatabaseConnection();

                List<RecordsViewItem> RecordDataSource = Record.Select(Record => new RecordsViewItem()
                {
                    HistoryNumber = Record.HistoryNumber,
                    DepartmentID = Record.DepartmentID,
                    DateOfReceipt = Record.DateOfReceipt,
                    DateOfDischarge = Record.DateOfDischarge,
                    MKBCode = Record.MKBCode
                }).ToList();
                RecordsTable.DataSource = RecordDataSource;

                CountPageTextBox.Text = $"1 / 1";
                PrevPageButton.Enabled = false;
                NextPageButton.Enabled = false;
            }
            else
            {
                RecordsTableInit(CurrentPage, limit);
                PrevPageButton.Enabled = false;
                NextPageButton.Enabled = true;
            }
        }

        private void DateOfReceiptTextField_TextChanged(object sender, EventArgs e)
        {
            string text = DateOfReceiptTextField.Text.Replace(".", "");
            bool isNotError = ValidationForm.ValidationIsNumber(text, TextError, Color.Red, "Дата может содержать только цифры !");
            if (isNotError)
            {
                ValidationForm.DateFormatting(DateOfReceiptTextField);
                isNotError = ValidationForm.DateIsValid(DateOfReceiptTextField.Text, TextError);
            }
            ErrorsFormRecords.DateOfReceipt = !isNotError;
            if (DateOfReceiptTextField.Text == "")
            {
                TextError.Text = "";
                ErrorsFormRecords.DateOfReceipt = false;
            }
            if (ErrorsFormRecords.DateOfReceipt && TextError.Text != "")
                DateOfReceiptTextField.ForeColor = Color.Red;
            else
                DateOfReceiptTextField.ForeColor = Color.Black;
        }

        private void DateOfDischargeTextField_TextChanged(object sender, EventArgs e)
        {
            string text = DateOfDischargeTextField.Text.Replace(".", "");
            bool isNotError = ValidationForm.ValidationIsNumber(text, TextError, Color.Red, "Дата может содержать только цифры !");
            if (isNotError)
            {
                ValidationForm.DateFormatting(DateOfDischargeTextField);
                isNotError = ValidationForm.DateIsValid(DateOfDischargeTextField.Text, TextError);
            }
            ErrorsFormRecords.DateOfDischarge = !isNotError;
            if (DateOfDischargeTextField.Text == "")
            {
                TextError.Text = "";
                ErrorsFormRecords.DateOfDischarge = false;
            }
            if (ErrorsFormRecords.DateOfDischarge && TextError.Text != "")
                DateOfDischargeTextField.ForeColor = Color.Red;
            else
                DateOfDischargeTextField.ForeColor = Color.Black;
        }

        private void RecordsTable_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) return;

            Func<RecordsViewItem, object> sortingFunc;

            switch (e.ColumnIndex)
            {
                case 1:
                    sortingFunc = record => record.HistoryNumber;
                    break;
                case 2:
                    sortingFunc = record => record.DepartmentID;
                    break;
                case 3:
                    sortingFunc = record => record.DateOfReceipt;
                    break;
                case 4:
                    sortingFunc = record => record.DateOfDischarge;
                    break;
                default:
                    sortingFunc = record => record.MKBCode;
                    break;
            }

            if (columnIndex != e.ColumnIndex)
            {
                recordDataSource = recordDataSource.OrderBy(sortingFunc).ToList();
                columnIndex = e.ColumnIndex;
            }
            else
            {
                List<RecordsViewItem> RecordDataSourceNew = recordDataSource.ToList();
                RecordDataSourceNew.Reverse();
                recordDataSource = RecordDataSourceNew;
            }

            RecordsTable.DataSource = recordDataSource;
        }


    }
    class RecordsViewItem
    {
        public int HistoryNumber { get; set; }
        public int DepartmentID { get; set; }
        public DateTime DateOfReceipt { get; set; }
        public DateTime DateOfDischarge { get; set; }
        public string MKBCode { get; set; }

    }

    static class ErrorsFormRecords
    {
        static public bool HistoryNumber { get; set; } = false;
        static public bool DepartmentID { get; set; } = false;
        static public bool DateOfReceipt { get; set; } = false;
        static public bool DateOfDischarge { get; set; } = false;
        static public bool MKBCode { get; set; } = false;
    }
}
