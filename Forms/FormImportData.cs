using Archive.DB;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using System.IO.Packaging;
using System.Reflection;

namespace Archive.Forms
{
    public partial class FormImportData : Form
    {
        private readonly string exampleImportPatientPathFile = "JSON/ExampleImportPatients.json";
        private readonly string exampleImportRecordPathFile = "JSON/ExampleImportRecords.json";
        private readonly string exampleImportMKBPathFile = "JSON/ExampleImportMKB.json";
        private readonly string exampleImportDepartmentPathFile = "JSON/ExampleImportDepartments.json";
        private readonly string[] Columns = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public FormImportData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Импорт данных из Excel
        /// </summary>
        /// <typeparam name="T">Таблица (MKBItem, PatientItem и т.д.)</typeparam>
        /// <param name="filePath">Путь к Excel файлу</param>
        /// <param name="propertys">Поля из таблицы</param>
        private void ImportDataFromExcel<T>(string filePath, string[] propertys, string primaryKey) where T : new()
        {
            try
            {
                // Установка лицензии
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    int columnCount = worksheet.Dimension.Columns;

                    //Проверка корректности таблицы Excel
                    if (typeof(T) == typeof(DepartmentItem) && columnCount != 2)
                    {
                        MessageBox.Show($"Некорректная таблица с отделениями, смотрите пример для импорта");
                        return;
                    }
                    else if (typeof(T) == typeof(MKBItem) && columnCount != 2)
                    {
                        MessageBox.Show($"Некорректная таблица с МКБ, смотрите пример для импорта");
                        return;
                    }

                    // Создание списка для добавления в таблицу
                    List<T> importedData = new List<T>();
                    for (int row = 1; row <= rowCount; row++)
                    {
                        T rowData = new T();

                        for (int col = 1; col <= columnCount; col++)
                        {
                            var prop = typeof(T).GetProperty(propertys[col - 1]);
                            if (prop != null)
                                prop.SetValue(rowData, Convert.ChangeType(worksheet.Cells[row, col].Text, prop.PropertyType));
                        }
                        importedData.Add(rowData);
                    }

                    // Разбиение данных на порции
                    List<List<T>> importedDataPortion = new List<List<T>>();
                    for (int i = 0; i < importedData.Count; i += 1000)
                        importedDataPortion.Add(importedData.GetRange(i, Math.Min(1000, importedData.Count - i)));

                    // Добавление в базу данных
                    DataBase dataBase = new DataBase();
                    foreach (List<T> data in importedDataPortion)
                        Task.Run(async () =>
                        {
                            await dataBase.MergeEntry<T>(data, primaryKey);
                        }).Wait();

                    MessageBox.Show($"Успешно добавлено {importedData.Count} записей!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка импорта: [{ex.Message}]");
            }
        }

        /// <summary>
        /// Выбор файла
        /// </summary>
        /// <typeparam name="T">Таблица (MKBItem, PatientItem и т.д.), передается в ImportDataFromExcel</typeparam>
        /// <param name="button">Кнопка</param>
        /// <param name="propertys">Поля из таблицы, передается в ImportDataFromExcel</param>
        private void OpenFile<T>(Button button, string[] propertys, string primaryKey) where T : new()
        {
            button.Enabled = false;
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Excel Files|*.xlsx";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        ImportDataFromExcel<T>(filePath, propertys, primaryKey);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"При открытии файла произошла ошибка: [{ex.Message}]");
            }
            button.Enabled = true;
        }

        /// <summary>
        /// Импорт пациентов и карты
        /// </summary>
        /// <param name="patientFilePath"></param>
        /// <param name="recordFilePath"></param>
        private void ImportPatientAndRecordFromExcel(string patientFilePath, string recordFilePath)
        {
            try
            {
                // Установка лицензии
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (ExcelPackage patientPackage = new ExcelPackage(new FileInfo(patientFilePath)))
                using (ExcelPackage recordPackage = new ExcelPackage(new FileInfo(recordFilePath)))
                {
                    ExcelWorksheet patientWorksheet = patientPackage.Workbook.Worksheets[0];
                    int patientRowCount = patientWorksheet.Dimension.Rows;
                    int patientColumnCount = patientWorksheet.Dimension.Columns;

                    ExcelWorksheet recordWorksheet = recordPackage.Workbook.Worksheets[0];
                    int recordRowCount = recordWorksheet.Dimension.Rows;
                    int recordColumnCount = recordWorksheet.Dimension.Columns;

                    //Проверка корректности таблиц Excel
                    if (patientColumnCount != 12)
                    {
                        MessageBox.Show($"Некорректная таблица с пациентами, смотрите пример для импорта");
                        return;
                    }
                    else if (recordColumnCount != 6)
                    {
                        MessageBox.Show($"Некорректная таблица с картами, смотрите пример для импорта");
                        return;
                    }

                    List<string> errors = new List<string>();
                    // Создание списка карт
                    List<RecordItemDraft> recordsDraft = new List<RecordItemDraft>();
                    for (int row = 1; row <= recordRowCount; row++)
                    {
                        if (int.TryParse(recordWorksheet.Cells[row, 1].Text, out int PatientID))
                            recordsDraft.Add(new RecordItemDraft()
                            {
                                PatientID = PatientID,
                                DateOfReceipt = DateTime.TryParse(recordWorksheet.Cells[row, 2].Text, out DateTime dateOfReceipt) ? dateOfReceipt.Date : default,
                                DateOfDischarge = DateTime.TryParse(recordWorksheet.Cells[row, 3].Text, out DateTime dateOfDischarge) ? dateOfDischarge.Date : default,
                                DepartmentID = int.TryParse(recordWorksheet.Cells[row, 4].Text, out int departmentID) ? departmentID : default,
                                HistoryNumber = int.TryParse(recordWorksheet.Cells[row, 5].Text, out int historyNumber) ? historyNumber : default,
                                MKBCode = recordWorksheet.Cells[row, 6].Text,
                            });
                        else
                            errors.Add($"Ошибка добавления карты: строка {row} пропущена (некорректный номер пациента)");
                    }

                    List<RecordItem> recordItem = new List<RecordItem>();
                    // Создание списка пациентов
                    List<PatientItem> patientItem = new List<PatientItem>();
                    for (int row = 1; row <= patientRowCount; row++)
                    {
                        if (int.TryParse(patientWorksheet.Cells[row, 1].Text, out int PatientIDDraft) &&
                            int.TryParse(patientWorksheet.Cells[row, 2].Text, out int PatientNumber))
                        {
                            Guid PatientID = Guid.NewGuid();

                            List<RecordItemDraft> recordsDraftSelect = recordsDraft.FindAll(recordDraft => recordDraft.PatientID == PatientIDDraft);
                            foreach (RecordItemDraft recordItemDraft in recordsDraftSelect)
                                recordItem.Add(new RecordItem()
                                {
                                    PatientID = PatientID,
                                    DateOfReceipt = recordItemDraft.DateOfReceipt.Date,
                                    DateOfDischarge = recordItemDraft.DateOfDischarge.Date,
                                    DepartmentID = recordItemDraft.DepartmentID,
                                    HistoryNumber = recordItemDraft.HistoryNumber,
                                    MKBCode = recordItemDraft.MKBCode,
                                });

                            patientItem.Add(new PatientItem()
                            {
                                PatientID = PatientID,
                                PatientNumber = $"{PatientNumber}",
                                LastName = patientWorksheet.Cells[row, 3].Text,
                                FirstName = patientWorksheet.Cells[row, 4].Text,
                                MiddleName = patientWorksheet.Cells[row, 5].Text,
                                DateOfBirth = DateTime.TryParse(patientWorksheet.Cells[row, 6].Text, out DateTime dateOfBirth) ? dateOfBirth.Date : default,
                                Region = patientWorksheet.Cells[row, 7].Text,
                                District = patientWorksheet.Cells[row, 8].Text,
                                City = patientWorksheet.Cells[row, 9].Text,
                                Address = patientWorksheet.Cells[row, 10].Text,
                                Phone = patientWorksheet.Cells[row, 11].Text,
                                IndexAddress = patientWorksheet.Cells[row, 12].Text,
                            });
                        }
                        else
                            MessageBox.Show($"Ошибка добавления пациента: строка {row} пропущена");
                    }

                    // Перезаписываем таблицу
                    DBase dBase = new DBase();
                    dBase.ClearTable<PatientItem>();
                    dBase.ClearTable<RecordItem>();
                    dBase.SetDataTable<RecordItem>(recordItem);
                    dBase.SetDataTable<PatientItem>(patientItem);
                    dBase.CloseDatabaseConnection();

                    MessageBox.Show($"Успешно перезаписано {patientItem.Count} пациентов и {recordItem.Count} карт !");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Ошибка импорта: [{error.Message}]");
            }
        }


        private void ImportDepartmentsButton_Click(object sender, EventArgs e)
        {
            OpenFile<DepartmentItem>(ImportDepartmentsButton, new string[] { "DepartmentID", "Title" }, "DepartmentID");
        }
        private void ImportMKBButton_Click(object sender, EventArgs e)
        {
            OpenFile<MKBItem>(ImportMKBButton, new string[] { "MKBCode", "Title" }, "MKBCode");
        }
        private void ImportPatientAndRecordButton_Click(object sender, EventArgs e)
        {
            ImportPatientAndRecordButton.Enabled = false;
            MessageBox.Show("Сначала выберите таблицу с пациентами, потом с картами (для выбора нескольких файлов зажмите ctrl)");
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    openFileDialog.Filter = "Excel Files|*.xlsx";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        List<string> selectedFiles = openFileDialog.FileNames.ToList();
                        ImportPatientAndRecordFromExcel(selectedFiles[1], selectedFiles[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выбора файлов для импорта: [{ex.Message}]");
            }
            ImportPatientAndRecordButton.Enabled = true;
        }

        #region Examples imports
        private void ExampleImportDepartments_Click(object sender, EventArgs e)
        {
            ExampleImport(ExampleImportDepartments, "Отделения", exampleImportDepartmentPathFile);
        }
        private void ExampleImportMKB_Click(object sender, EventArgs e)
        {
            ExampleImport(ExampleImportMKB, "МКБ", exampleImportMKBPathFile);
        }
        private void ExampleImportPatientAndRecord_Click(object sender, EventArgs e)
        {
            ExampleImport(ExampleImportPatientAndRecord, "Пациенты", exampleImportPatientPathFile);
            ExampleImport(ExampleImportPatientAndRecord, "Карты", exampleImportRecordPathFile);
        }

        private void ExampleImport(Button button, string fileName, string exampleFilePath)
        {
            button.Enabled = false;
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    saveFileDialog.FileName = fileName;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        using (ExcelPackage excelPackage = new ExcelPackage())
                        {
                            if (File.Exists(exampleFilePath))
                            {
                                var worksheet = excelPackage.Workbook.Worksheets.Add("Sheets");

                                string jsonContext = File.ReadAllText(exampleFilePath);
                                JObject jsonObject = JObject.Parse(jsonContext);
                                foreach (var item in jsonObject)
                                {
                                    if (item.Value != null)
                                        worksheet.Cells[item.Key].Value = item.Value.ToString();
                                }
                                excelPackage.SaveAs(new System.IO.FileInfo(filePath));
                            }
                            else
                            {
                                MessageBox.Show($"Ошибка загрузки примера импорта: {fileName}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки примера импорта {fileName}: {ex.Message}");
            }
            button.Enabled = true;
        }
        #endregion

        #region Export
        private void ExportDepartmentButton_Click(object sender, EventArgs e)
        {
            ExportOnExcel<DepartmentItem>(ExportDepartmentButton, "Отделения", "DepartmentID");
        }
        private void ExportMKBButton_Click(object sender, EventArgs e)
        {
            ExportOnExcel<MKBItem>(ExportMKBButton, "МКБ", "MKBCode");
        }

        private void ExportOnExcel<T>(Button button, string fileName, string IDField) where T : new()
        {
            button.Enabled = false;
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    saveFileDialog.FileName = fileName;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        using (ExcelPackage excelPackage = new ExcelPackage(filePath))
                        {
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheets");

                            int totalPage = 1;
                            int currentPage = 1;
                            int pageSize = 10;
                            DataBase dataBase = new DataBase();

                            while (currentPage <= totalPage)
                            {
                                Task.Run(async () =>
                                {
                                    (List<T>, int) items = await dataBase.GetPagedEntries<T>(currentPage, pageSize, IDField);

                                    for (int i = 1; i <= items.Item1.Count; i++)
                                    {
                                        int row = (currentPage - 1) * pageSize + i;
                                        PropertyInfo[] properties = typeof(T).GetProperties();
                                        for (int column = 0; column < properties.Length; column++)
                                        {
                                            worksheet.Cells[Columns[column] + row].Value = properties[column].GetValue(items.Item1[i - 1]);
                                        }
                                    }

                                    totalPage = items.Item2;
                                    currentPage += 1;
                                }).Wait();
                            }

                            excelPackage.SaveAs(new System.IO.FileInfo(filePath));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта: {ex.Message}");
            }
            button.Enabled = true;
        }
        #endregion
    }

    class RecordItemDraft
    {
        public int DepartmentID { get; set; }

        public int PatientID { get; set; }

        public DateTime DateOfReceipt { get; set; }

        public DateTime DateOfDischarge { get; set; }

        public int HistoryNumber { get; set; }

        public string MKBCode { get; set; }
    }
}
