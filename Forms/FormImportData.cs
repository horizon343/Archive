using Archive.DB;
using OfficeOpenXml;

namespace Archive.Forms
{
    public partial class FormImportData : Form
    {
        public FormImportData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Импорт данных из Excel
        /// </summary>
        /// <typeparam name="T">Таблица (MKBItem, PatientItem и т.д.)</typeparam>
        /// <param name="filePath">Путь к Excel файлу</param>
        /// <param name="button">Кнопка</param>
        /// <param name="propertys">Поля из таблицы (AutoIncrement не нужны)</param>
        private void ImportDataFromExcel<T>(string filePath, Button button, string[] propertys) where T : new()
        {
            try
            {
                button.Enabled = false;

                // Установка лицензии
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    int columnCount = worksheet.Dimension.Columns;

                    //Проверка корректности таблицы Excel
                    if (typeof(T) == typeof(DepartmentItem) && columnCount != 1)
                    {
                        MessageBox.Show($"Количество столбцов в импортируемой таблице должно быть равно 1 (названия отделений начиная с первой строки). " +
                            $"Текущее число столбцов: {columnCount}");
                        return;
                    }
                    else if (typeof(T) == typeof(MKBItem) && columnCount != 2)
                    {
                        MessageBox.Show($"Количество столбцов в импортируемой таблице должно быть равно 2 (код и название, начиная с первой строки). " +
                            $"Текущее число столбцов: {columnCount}");
                        return;
                    }

                    // Создание списка для перезаписи таблицы
                    List<T> importedData = new List<T>();
                    for (int row = 1; row <= rowCount; row++)
                    {
                        T rowData = new T();

                        for (int col = 1; col <= columnCount; col++)
                        {
                            var prop = typeof(T).GetProperty(propertys[col - 1]);
                            if (prop != null)
                                prop.SetValue(rowData, worksheet.Cells[row, col].Text);
                        }
                        importedData.Add(rowData);
                    }

                    // Перезаписываем таблицу
                    DBase dBase = new DBase();
                    dBase.ClearTable<T>();
                    dBase.SetDataTable<T>(importedData);
                    dBase.CloseDatabaseConnection();

                    MessageBox.Show($"Успешно перезаписано {importedData.Count} записей !");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Ошибка импорта: [{error.Message}]");
            }
            finally
            {
                button.Enabled = true;
            }
        }

        /// <summary>
        /// Выбор файла
        /// </summary>
        /// <typeparam name="T">Таблица (MKBItem, PatientItem и т.д.), передается в ImportDataFromExcel</typeparam>
        /// <param name="button">Кнопка, передается в ImportDataFromExcel</param>
        /// <param name="propertys">Поля из таблицы (AutoIncrement не нужны), передается в ImportDataFromExcel</param>
        private void OpenFile<T>(Button button, string[] propertys) where T : new()
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Excel Files|*.xlsx";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        ImportDataFromExcel<T>(filePath, button, propertys);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Ошибка выбора файла для импорта [{error}]");
            }
        }

        private void ImportDepartmentsButton_Click(object sender, EventArgs e)
        {
            OpenFile<DepartmentItem>(ImportDepartmentsButton, new string[] { "Title" });
        }

        private void ImportMKBButton_Click(object sender, EventArgs e)
        {
            OpenFile<MKBItem>(ImportMKBButton, new string[] { "MKBCode", "Title" });
        }

        private void ImportPatientAndRecordButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Сначала выберите таблицу с пациентами, потом с картами");
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
            catch (Exception error)
            {
                MessageBox.Show($"Ошибка выбора файла для импорта [{error}]");
            }
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
                ImportPatientAndRecordButton.Enabled = false;

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

                    //Проверка корректности таблицы Excel
                    if (patientColumnCount != 12)
                    {
                        MessageBox.Show($"Количество столбцов в таблице пациентов должно быть равно 12. Текущее число столбцов: {patientColumnCount}");
                        return;
                    }
                    else if (recordColumnCount != 6)
                    {
                        MessageBox.Show($"Количество столбцов в таблице карты должно быть равно 6. Текущее число столбцов: {recordColumnCount}");
                        return;
                    }

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
                            MessageBox.Show($"Ошибка добавления карты: строка {row} пропущена");
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
                                PatientNumber = PatientNumber,
                                LastName = patientWorksheet.Cells[row, 3].Text,
                                FirstName = patientWorksheet.Cells[row, 4].Text,
                                MiddleName = patientWorksheet.Cells[row, 5].Text,
                                DateOfBirth = DateTime.TryParse(patientWorksheet.Cells[row, 6].Text, out DateTime dateOfBirth) ? dateOfBirth.Date : default,
                                Region = patientWorksheet.Cells[row, 7].Text,
                                District = patientWorksheet.Cells[row, 8].Text,
                                City = patientWorksheet.Cells[row, 9].Text,
                                Address = patientWorksheet.Cells[row, 10].Text,
                                Phone = patientWorksheet.Cells[row, 11].Text,
                                Index = int.TryParse(patientWorksheet.Cells[row, 12].Text, out int index) ? index : default,
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
            finally
            {
                ImportPatientAndRecordButton.Enabled = true;
            }
        }
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
