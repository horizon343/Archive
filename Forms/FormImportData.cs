using Archive.Data;
using Archive.DB;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using System.Reflection;

namespace Archive.Forms
{
    public partial class FormImportData : Form
    {
        private readonly string exampleImportPatientPathFile = "JSON/ExampleImportPatients.json";
        private readonly string exampleImportRecordPathFile = "JSON/ExampleImportRecords.json";
        private readonly string exampleImportNewPatientPathFile = "JSON/ExampleImportNewPatients.json";
        private readonly string exampleImportNewRecordPathFile = "JSON/ExampleImportNewRecords.json";
        private readonly string exampleImportMKBPathFile = "JSON/ExampleImportMKB.json";
        private readonly string exampleImportDepartmentPathFile = "JSON/ExampleImportDepartments.json";
        private readonly string exampleImportStorageLocationPathFile = "JSON/ExampleImportStorageLocation.json";
        private readonly string[] Columns = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        string EndSymbol = StorageLocation.currentStorageLocation ?? "Б";

        public FormImportData()
        {
            InitializeComponent();
        }

        #region Import
        private void ImportStorageLocation_Click(object sender, EventArgs e)
        {
            OpenFile<StorageLocationItem>(ImportStorageLocation, new string[] { "StorageLocationID", "Title" }, "StorageLocationID");
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
            ToggleButtonState(false);
            MessageBox.Show("Сначала выберите таблицу с пациентами, потом с картами");
            try
            {
                List<string> selectedFiles = new List<string>(2);
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Excel Files|*.xlsx";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                        selectedFiles.Add(openFileDialog.FileNames[0]);
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                        selectedFiles.Add(openFileDialog.FileNames[0]);
                    this.Cursor = Cursors.WaitCursor;
                    if (selectedFiles.Count == 2)
                    {

                        Thread ImportPatientAndRecordThread = new Thread(() =>
                        {
                            ImportPatientAndRecordFromExcel(selectedFiles[0], selectedFiles[1], ProgressLabel);

                            try
                            {
                                this.Invoke(() =>
                                {
                                    this.Cursor = Cursors.Default;
                                    ToggleButtonState(true);
                                });
                            }
                            catch { }
                        });
                        ImportPatientAndRecordThread.Start();
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        ToggleButtonState(true);
                    }
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                ToggleButtonState(true);

                MessageBox.Show($"Ошибка выбора файлов для импорта: [{ex.Message}]");
            }
        }
        private void ImportNewPatientAndRecord_Click(object sender, EventArgs e)
        {
            ToggleButtonState(false);
            MessageBox.Show("Сначала выберите таблицу с пациентами, потом с картами");
            try
            {
                List<string> selectedFiles = new List<string>(2);
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Excel Files|*.xlsx";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                        selectedFiles.Add(openFileDialog.FileNames[0]);
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                        selectedFiles.Add(openFileDialog.FileNames[0]);

                    if (selectedFiles.Count == 2)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        Thread ImportNewPatientAndRecordThread = new Thread(() =>
                        {
                            ImportNewPatientAndRecordFromExcel(selectedFiles[0], selectedFiles[1], ProgressLabel);

                            try
                            {
                                this.Invoke(() =>
                                {
                                    this.Cursor = Cursors.Default;
                                    ToggleButtonState(true);
                                });
                            }
                            catch { }
                        });
                        ImportNewPatientAndRecordThread.Start();
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        ToggleButtonState(true);
                    }
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                ToggleButtonState(true);

                MessageBox.Show($"Ошибка выбора файла для импорта: {ex.Message}");
            }
        }

        public void ImportNewPatientAndRecordFromExcel(string patientFilePath, string recordFilePath, Label ProgressText)
        {
            try
            {
                // Установка лицензии
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                double progress = 0;
                try
                {
                    this.Invoke(() =>
                    {
                        ProgressText.Text = $"{progress}% / 100%";
                    });
                }
                catch { }

                using (ExcelPackage patientPackage = new ExcelPackage(new FileInfo(patientFilePath)))
                using (ExcelPackage recordPackage = new ExcelPackage(new FileInfo(recordFilePath)))
                {
                    ExcelWorksheet patientWorksheet = patientPackage.Workbook.Worksheets[0];
                    int patientRowCount = patientWorksheet.Dimension.Rows;
                    int patientColumnCount = patientWorksheet.Dimension.Columns;
                    ExcelWorksheet recordWorksheet = recordPackage.Workbook.Worksheets[0];
                    int recordRowCount = recordWorksheet.Dimension.Rows;
                    int recordColumnCount = recordWorksheet.Dimension.Columns;

                    // Проверка корректности таблиц Excel
                    if (patientColumnCount != 12)
                    {
                        MessageBox.Show($"Некорректная таблица с пациентами, смотрите пример для импорта");
                        return;
                    }
                    else if (recordColumnCount != 8)
                    {
                        MessageBox.Show($"Некорректная таблица с картами, смотрите пример для импорта");
                        return;
                    }

                    // Получение карт
                    List<RecordItem> records = new List<RecordItem>(recordRowCount);
                    for (int row = 1; row <= recordRowCount; row++)
                    {
                        if (Guid.TryParse(recordWorksheet.Cells[row, 1].Text, out Guid RecordID) &&
                            int.TryParse(recordWorksheet.Cells[row, 2].Text, out int DepartmentID) &&
                            Guid.TryParse(recordWorksheet.Cells[row, 3].Text, out Guid PatientID) &&
                            double.TryParse(recordWorksheet.Cells[row, 4].Text, out double DateOfReceiptNumber) &&
                            double.TryParse(recordWorksheet.Cells[row, 5].Text, out double DateOfDischargeNumber) &&
                            int.TryParse(recordWorksheet.Cells[row, 6].Text, out int HistoryNumber) &&
                            recordWorksheet.Cells[row, 7].Text != "" &&
                            recordWorksheet.Cells[row, 8].Text != "")
                            records.Add(new RecordItem()
                            {
                                RecordID = RecordID,
                                DepartmentID = DepartmentID,
                                PatientID = PatientID,
                                DateOfReceipt = DateTime.FromOADate(DateOfReceiptNumber),
                                DateOfDischarge = DateTime.FromOADate(DateOfDischargeNumber),
                                HistoryNumber = HistoryNumber,
                                MKBCode = recordWorksheet.Cells[row, 7].Text,
                                StorageLocationID = recordWorksheet.Cells[row, 8].Text
                            });

                        try
                        {
                            this.Invoke(() =>
                            {
                                ProgressText.Text = $"{Math.Round(progress + ((double)row / recordRowCount * 25), 2)}% / 100%";
                            });
                        }
                        catch { }
                    }
                    progress = 25;

                    // Получение пациентов
                    List<PatientItem> patients = new List<PatientItem>(patientRowCount);
                    for (int row = 1; row <= patientRowCount; row++)
                    {
                        if (Guid.TryParse(patientWorksheet.Cells[row, 1].Text, out Guid PatientID) &&
                            patientWorksheet.Cells[row, 2].Text != "" &&
                            patientWorksheet.Cells[row, 3].Text != "" &&
                            patientWorksheet.Cells[row, 4].Text != "" &&
                            double.TryParse(patientWorksheet.Cells[row, 6].Text, out double DateOfBirthNumber))
                            patients.Add(new PatientItem()
                            {
                                PatientID = PatientID,
                                PatientNumber = patientWorksheet.Cells[row, 2].Text,
                                LastName = patientWorksheet.Cells[row, 3].Text,
                                FirstName = patientWorksheet.Cells[row, 4].Text,
                                MiddleName = patientWorksheet.Cells[row, 5].Text,
                                DateOfBirth = DateTime.FromOADate(DateOfBirthNumber),
                                Region = patientWorksheet.Cells[row, 7].Text,
                                District = patientWorksheet.Cells[row, 8].Text,
                                City = patientWorksheet.Cells[row, 9].Text,
                                Address = patientWorksheet.Cells[row, 10].Text,
                                Phone = patientWorksheet.Cells[row, 11].Text,
                                IndexAddress = patientWorksheet.Cells[row, 12].Text
                            });

                        try
                        {
                            this.Invoke(() =>
                            {
                                ProgressText.Text = $"{Math.Round(progress + ((double)row / patientRowCount * 25), 2)}% / 100%";
                            });
                        }
                        catch { }
                    }
                    progress = 50;

                    // Разбиение данных на порции
                    int limitPatient = 150;
                    int limitRecord = 250;
                    List<List<PatientItem>> patientsPortion = new List<List<PatientItem>>(patients.Count);
                    for (int i = 0; i < patients.Count; i += limitPatient)
                        patientsPortion.Add(patients.GetRange(i, Math.Min(patients.Count - i, limitPatient)));
                    List<List<RecordItem>> recordsPortion = new List<List<RecordItem>>(records.Count);
                    for (int i = 0; i < records.Count; i += limitRecord)
                        recordsPortion.Add(records.GetRange(i, Math.Min(records.Count - i, limitRecord)));

                    // Добавление в базу данных
                    DataBase dataBase = new DataBase();
                    Task.Run(async () =>
                    {
                        for (int i = 0; i < patientsPortion.Count; i++)
                        {
                            await dataBase.MergeEntry<PatientItem>(patientsPortion[i], "PatientID");

                            try
                            {
                                this.Invoke(() =>
                                {
                                    ProgressText.Text = $"{Math.Round(progress + ((double)i / patientsPortion.Count * 25), 2)}% / 100%";
                                });
                            }
                            catch { }
                        }
                        progress = 75;

                        for (int i = 0; i < recordsPortion.Count; i++)
                        {
                            await dataBase.MergeEntry<RecordItem>(recordsPortion[i], "RecordID");

                            try
                            {
                                this.Invoke(() =>
                                {
                                    ProgressText.Text = $"{Math.Round(progress + ((double)i / recordsPortion.Count * 25), 2)}% / 100%";
                                });
                            }
                            catch { }
                        }
                    }).Wait();

                    try
                    {
                        this.Invoke(() =>
                        {
                            ProgressText.Text = "";
                        });
                    }
                    catch { }
                    MessageBox.Show($"Успешно добавлено {patients.Count} пациентов и {records.Count} карт!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка импорта: [{ex.Message}]");
            }
        }
        /// <summary>
        /// Импорт пациентов и карты
        /// </summary>
        /// <param name="patientFilePath"></param>
        /// <param name="recordFilePath"></param>
        private void ImportPatientAndRecordFromExcel(string patientFilePath, string recordFilePath, Label ProgressText)
        {
            try
            {
                // Установка лицензии
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                double progress = 0;
                try
                {
                    this.Invoke(() =>
                    {
                        ProgressText.Text = $"{progress}% / 100%";
                    });
                }
                catch { }

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

                    // Создание списка карт
                    List<RecordItemDraft> recordsDraft = new List<RecordItemDraft>(recordRowCount);
                    for (int row = 1; row <= recordRowCount; row++)
                    {
                        if (int.TryParse(recordWorksheet.Cells[row, 1].Text, out int PatientID) &&
                            DateTime.TryParse(recordWorksheet.Cells[row, 2].Text, out DateTime dateOfReceipt) &&
                            DateTime.TryParse(recordWorksheet.Cells[row, 3].Text, out DateTime dateOfDischarge) &&
                            int.TryParse(recordWorksheet.Cells[row, 4].Text, out int departmentID) &&
                            int.TryParse(recordWorksheet.Cells[row, 5].Text, out int historyNumber) &&
                            recordWorksheet.Cells[row, 6].Text.Length != 0)
                            recordsDraft.Add(new RecordItemDraft()
                            {
                                PatientID = PatientID,
                                DateOfReceipt = dateOfReceipt.Date,
                                DateOfDischarge = dateOfDischarge.Date,
                                DepartmentID = departmentID,
                                HistoryNumber = historyNumber,
                                MKBCode = recordWorksheet.Cells[row, 6].Text,
                            });

                        try
                        {
                            this.Invoke(() =>
                            {
                                ProgressText.Text = $"{Math.Round(progress + ((double)row / recordRowCount * 25), 2)}% / 100%";
                            });
                        }
                        catch { }
                    }
                    progress = 25;

                    // Создание списков пациентов и карт
                    List<RecordItem> recordItem = new List<RecordItem>(recordsDraft.Count);
                    List<PatientItem> patientItem = new List<PatientItem>(patientRowCount);
                    for (int row = 1; row <= patientRowCount; row++)
                    {
                        if (int.TryParse(patientWorksheet.Cells[row, 1].Text, out int PatientIDDraft) &&
                            patientWorksheet.Cells[row, 3].Text.Length != 0 &&
                            patientWorksheet.Cells[row, 4].Text.Length != 0 &&
                            DateTime.TryParse(patientWorksheet.Cells[row, 6].Text, out DateTime dateOfBirth))
                        {
                            Guid PatientID = Guid.NewGuid();

                            List<RecordItemDraft> recordsDraftSelect = recordsDraft.FindAll(recordDraft => recordDraft.PatientID == PatientIDDraft);
                            foreach (RecordItemDraft recordItemDraft in recordsDraftSelect)
                                recordItem.Add(new RecordItem()
                                {
                                    RecordID = Guid.NewGuid(),
                                    PatientID = PatientID,
                                    DateOfReceipt = recordItemDraft.DateOfReceipt.Date,
                                    DateOfDischarge = recordItemDraft.DateOfDischarge.Date,
                                    DepartmentID = recordItemDraft.DepartmentID,
                                    HistoryNumber = recordItemDraft.HistoryNumber,
                                    MKBCode = recordItemDraft.MKBCode,
                                    StorageLocationID = EndSymbol
                                });

                            patientItem.Add(new PatientItem()
                            {
                                PatientID = PatientID,
                                PatientNumber = "",
                                LastName = patientWorksheet.Cells[row, 3].Text,
                                FirstName = patientWorksheet.Cells[row, 4].Text,
                                MiddleName = patientWorksheet.Cells[row, 5].Text,
                                DateOfBirth = dateOfBirth.Date,
                                Region = patientWorksheet.Cells[row, 7].Text,
                                District = patientWorksheet.Cells[row, 8].Text,
                                City = patientWorksheet.Cells[row, 9].Text,
                                Address = patientWorksheet.Cells[row, 10].Text,
                                Phone = patientWorksheet.Cells[row, 11].Text,
                                IndexAddress = patientWorksheet.Cells[row, 12].Text
                            });
                        }

                        try
                        {
                            this.Invoke(() =>
                            {
                                ProgressText.Text = $"{Math.Round(progress + ((double)row / patientRowCount * 25), 2)}% / 100%";
                            });
                        }
                        catch { }
                    }
                    progress = 50;

                    DataBase dataBase = new DataBase();
                    // Добавление пациентов в базу данных
                    for (int i = 0; i < patientItem.Count; i++)
                    {
                        // Устанавливаем PatientNumber
                        List<PatientItem> patients;
                        int PatientNumber = 1;
                        List<int> patientNumbers = new List<int>();
                        Task.Run(async () =>
                        {
                            patients = await dataBase.GetEntriesStartAndEndCharacter<PatientItem>(patientItem[i].LastName.Substring(0, 1), EndSymbol, "PatientNumber", "PatientNumber");
                            foreach (PatientItem patientItem in patients)
                                patientNumbers.Add(int.Parse(patientItem.PatientNumber.Split("-")[1]));
                        }).Wait();
                        patientNumbers.Sort();
                        foreach (int number in patientNumbers)
                        {
                            if (PatientNumber == number)
                                PatientNumber += 1;
                            else
                                break;
                        }

                        // Сохранение в базе данных
                        PatientItem newPatient = new PatientItem()
                        {
                            PatientID = patientItem[i].PatientID,
                            PatientNumber = $"{patientItem[i].LastName.Substring(0, 1)}-{PatientNumber}-{EndSymbol}",
                            LastName = patientItem[i].LastName,
                            FirstName = patientItem[i].FirstName,
                            MiddleName = patientItem[i].MiddleName,
                            DateOfBirth = patientItem[i].DateOfBirth,
                            Region = patientItem[i].Region,
                            District = patientItem[i].District,
                            City = patientItem[i].City,
                            Address = patientItem[i].Address,
                            Phone = patientItem[i].Phone,
                            IndexAddress = patientItem[i].IndexAddress,
                        };

                        Task.Run(async () =>
                        {
                            await dataBase.InsertEntry<PatientItem>(newPatient);
                        }).Wait();

                        try
                        {
                            this.Invoke(() =>
                            {
                                ProgressText.Text = $"{Math.Round(progress + ((double)i / patientItem.Count * 25), 2)}% / 100%";
                            });
                        }
                        catch { }
                    }
                    progress = 75;

                    // Разбиение данных на порции
                    int portion = 5;
                    List<List<RecordItem>> recordItemPortion = new List<List<RecordItem>>(recordItem.Count);
                    for (int i = 0; i < recordItem.Count; i += portion)
                        recordItemPortion.Add(recordItem.GetRange(i, Math.Min(portion, recordItem.Count - i)));
                    // Добавление в базу данных
                    for (int i = 0; i < recordItemPortion.Count; i++)
                    {
                        Task.Run(async () =>
                        {
                            await dataBase.InsertEntry<RecordItem>(recordItemPortion[i]);
                        }).Wait();

                        try
                        {
                            this.Invoke(() =>
                            {
                                ProgressText.Text = $"{Math.Round(progress + ((double)i / recordItemPortion.Count * 25), 2)}% / 100%";
                            });
                        }
                        catch { }
                    }

                    try
                    {
                        this.Invoke(() =>
                        {
                            ProgressText.Text = "";
                        });
                    }
                    catch { }
                    MessageBox.Show($"Успешно добавлено {patientItem.Count} пациентов и {recordItem.Count} карт!");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Ошибка импорта: [{error.Message}]");
            }
        }
        /// <summary>
        /// Импорт данных из Excel
        /// </summary>
        /// <typeparam name="T">Таблица (MKBItem, PatientItem и т.д.)</typeparam>
        /// <param name="filePath">Путь к Excel файлу</param>
        /// <param name="propertys">Поля из таблицы</param>
        private void ImportDataFromExcel<T>(string filePath, string[] propertys, string primaryKey, Label ProgressText) where T : new()
        {
            try
            {
                // Установка лицензии
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                double progress = 0;
                try
                {
                    this.Invoke(() =>
                    {
                        ProgressText.Text = $"{progress}% / 100%";
                    });
                }
                catch { }

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

                        try
                        {
                            this.Invoke(() =>
                            {
                                ProgressText.Text = $"{Math.Round(progress + ((double)row / rowCount * 30), 2)}% / 100%";
                            });
                        }
                        catch { }
                    }
                    progress = 30;

                    // Разбиение данных на порции
                    List<List<T>> importedDataPortion = new List<List<T>>();
                    for (int i = 0; i < importedData.Count; i += 1000)
                    {
                        importedDataPortion.Add(importedData.GetRange(i, Math.Min(1000, importedData.Count - i)));

                        try
                        {
                            this.Invoke(() =>
                            {
                                ProgressText.Text = $"{Math.Round(progress + ((double)i / importedData.Count * 20), 2)}% / 100%";
                            });
                        }
                        catch { }
                    }
                    progress = 50;

                    // Добавление в базу данных
                    DataBase dataBase = new DataBase();
                    for (int i = 0; i < importedDataPortion.Count; i++)
                    {
                        Task.Run(async () =>
                        {
                            await dataBase.MergeEntry<T>(importedDataPortion[i], primaryKey);
                        }).Wait();

                        try
                        {
                            this.Invoke(() =>
                            {
                                ProgressText.Text = $"{Math.Round(progress + ((double)i / importedDataPortion.Count * 50), 2)}% / 100%";
                            });
                        }
                        catch { }
                    }

                    try
                    {
                        this.Invoke(() =>
                        {
                            ProgressText.Text = "";
                        });
                    }
                    catch { }
                    MessageBox.Show($"Успешно добавлено {importedData.Count} записей!");
                }
            }
            catch (Exception ex)
            {
                try
                {
                    this.Invoke(() =>
                    {
                        ProgressText.Text = "";
                    });
                }
                catch { }

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
            this.Cursor = Cursors.WaitCursor;
            button.Enabled = false;
            ToggleButtonState(false);
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Excel Files|*.xlsx";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;

                        Thread ImportDataFromExcelThread = new Thread(() =>
                        {
                            ImportDataFromExcel<T>(filePath, propertys, primaryKey, ProgressLabel);
                            try
                            {
                                this.Invoke(() =>
                                {
                                    this.Cursor = Cursors.Default;
                                    button.Enabled = true;
                                    ToggleButtonState(true);
                                });
                            }
                            catch { }
                        });
                        ImportDataFromExcelThread.Start();
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        button.Enabled = true;
                        ToggleButtonState(true);
                    }
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                button.Enabled = true;
                ToggleButtonState(true);

                MessageBox.Show($"При открытии файла произошла ошибка: [{ex.Message}]");
            }
        }
        #endregion

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
        private void ExampleImportStorageLocation_Click(object sender, EventArgs e)
        {
            ExampleImport(ExampleImportStorageLocation, "Места хранения", exampleImportStorageLocationPathFile);
        }
        private void ExampleImportNewPatientAndRecord_Click(object sender, EventArgs e)
        {
            ExampleImport(ExampleImportNewPatientAndRecord, "Пациенты", exampleImportNewPatientPathFile);
            ExampleImport(ExampleImportNewPatientAndRecord, "Карты", exampleImportNewRecordPathFile);
        }

        private void ExampleImport(Button button, string fileName, string exampleFilePath)
        {
            this.Cursor = Cursors.WaitCursor;
            button.Enabled = false;
            ToggleButtonState(false);

            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    saveFileDialog.FileName = fileName;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Thread ExampleImportThread = new Thread(() =>
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
                            try
                            {
                                this.Invoke(() =>
                                {
                                    this.Cursor = Cursors.Default;
                                    button.Enabled = true;
                                    ToggleButtonState(true);
                                });
                            }
                            catch { }
                        });
                        ExampleImportThread.Start();
                    }
                    else
                    {
                        button.Enabled = true;
                        this.Cursor = Cursors.Default;
                        ToggleButtonState(true);
                    }
                }
            }
            catch (Exception ex)
            {
                button.Enabled = true;
                this.Cursor = Cursors.Default;
                ToggleButtonState(true);

                MessageBox.Show($"Ошибка загрузки примера импорта {fileName}: {ex.Message}");
            }
        }
        #endregion

        #region Export
        private void ExportDepartmentButton_Click(object sender, EventArgs e)
        {
            ExportOnExcel<DepartmentItem>(ExportDepartmentButton, "Отделения", "DepartmentID", ProgressLabel);
        }
        private void ExportMKBButton_Click(object sender, EventArgs e)
        {
            ExportOnExcel<MKBItem>(ExportMKBButton, "МКБ", "MKBCode", ProgressLabel);
        }
        private void ExportPatientAndRecordButton_Click(object sender, EventArgs e)
        {
            ExportOnExcel<PatientItem>(ExportPatientAndRecordButton, "Пациенты", "PatientID", ProgressLabel);
            ExportOnExcel<RecordItem>(ExportPatientAndRecordButton, "Карты", "RecordID", ProgressLabel2);
        }
        private void ExportStorageLocation_Click(object sender, EventArgs e)
        {
            ExportOnExcel<StorageLocationItem>(ExportStorageLocation, "Места хранения", "StorageLocationID", ProgressLabel);
        }

        private void ExportOnExcel<T>(Button button, string fileName, string IDField, Label ProgressText) where T : new()
        {
            this.Cursor = Cursors.WaitCursor;
            button.Enabled = false;
            ToggleButtonState(false);
            ProgressText.Text = "0% / 100%";
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    saveFileDialog.FileName = fileName;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        Thread ExportOnExcelThread = new Thread(() =>
                        {
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

                                    try
                                    {
                                        this.Invoke(() =>
                                        {
                                            double progress = Math.Round((double)currentPage / totalPage * 100, 2);
                                            ProgressText.Text = $"{progress}% / 100%";
                                        });
                                    }
                                    catch { }
                                }

                                excelPackage.SaveAs(new System.IO.FileInfo(filePath));

                                try
                                {
                                    this.Invoke(() =>
                                    {
                                        button.Enabled = true;
                                        this.Cursor = Cursors.Default;
                                        ToggleButtonState(true);
                                        ProgressText.Text = "";
                                    });
                                }
                                catch { }
                            }
                        });
                        ExportOnExcelThread.Start();
                    }
                    else
                    {
                        button.Enabled = true;
                        this.Cursor = Cursors.Default;
                        ToggleButtonState(true);
                        ProgressText.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                button.Enabled = true;
                this.Cursor = Cursors.Default;
                ProgressText.Text = "";
                ToggleButtonState(true);

                MessageBox.Show($"Ошибка экспорта: {ex.Message}");
            }
        }
        #endregion

        private void ToggleButtonState(bool value)
        {
            ExportDepartmentButton.Enabled = value;
            ExportMKBButton.Enabled = value;
            ExportPatientAndRecordButton.Enabled = value;
            ExportStorageLocation.Enabled = value;

            ExampleImportDepartments.Enabled = value;
            ExampleImportMKB.Enabled = value;
            ExampleImportPatientAndRecord.Enabled = value;
            ExampleImportStorageLocation.Enabled = value;
            ExampleImportNewPatientAndRecord.Enabled = value;

            ImportStorageLocation.Enabled = value;
            ImportDepartmentsButton.Enabled = value;
            ImportMKBButton.Enabled = value;
            ImportPatientAndRecordButton.Enabled = value;
            ImportNewPatientAndRecord.Enabled = value;

            Data.Data.IsActiveMenu = value;
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