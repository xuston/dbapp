using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using OfficeOpenXml;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace database_application
{
    public partial class Databaseapplication : Form
    {
        public int numb = 0;
        public int numb2 = 0;
        public BindingSource bindingSource = new BindingSource();
        public Databaseapplication()
        {
            InitializeComponent();


        }

        private void Databaseapplication_Load(object sender, EventArgs e)
        {

            tablechoose.Items.Add("<Выберите таблицу>");
            tablechoose.DropDownStyle = ComboBoxStyle.DropDownList;
            tablechoose.SelectedIndex = 7;
            Columnchooser.Enabled = false;
            searchbox.Enabled = false;
            search.Enabled = false;
            addinf.Enabled = false;
            chnginf.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            delif.Enabled = false;
            infoftsearch.Hide();
        }

        public void click()
        {
            aplly.PerformClick();
        }

        public void aplly_Click(object sender, EventArgs e)
        {
            bindingSource.Clear();
            workspace.DataSource = null;
            workspace.Rows.Clear();
            workspace.Columns.Clear();
            Database data = new Database();
            Database.table = tablechoose.Text;
            if (tablechoose.Text != "<Выберите таблицу>")
            {
                bindingSource.DataSource = data.gettable();
                Columnchooser.Enabled = true;
                searchbox.Enabled = true;
                search.Enabled = true;
                addinf.Enabled = true;
                chnginf.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                delif.Enabled = true;
                Columnchooser.DataSource = data.GetColumns();
                Columnchooser.DropDownStyle = ComboBoxStyle.DropDownList;
                Columnchooser.SelectedIndex = Columnchooser.Items.Count - 1;
            }
            else
            {
                delif.Enabled = false;
                chnginf.Enabled = false;
                button2.Enabled = false;
                button1.Enabled = false;
                addinf.Enabled = false;
                bindingSource.DataSource = null;
                Columnchooser.Enabled = false;
                searchbox.Enabled = false;
                search.Enabled = false;
            };
            workspace.DataSource = bindingSource;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void workspace_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tablechoose_Click(object sender, EventArgs e)
        {


        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {
            if (Columnchooser.Text != "<Выберите столбец для поиска>")
            {
                Database.flag = Fulltsearch.Checked;
                bindingSource.Clear();
                workspace.DataSource = null;
                workspace.Rows.Clear();
                workspace.Columns.Clear();
                Database data = new Database();
                Database.table = tablechoose.Text;
                Database.colomn = Columnchooser.Text;
                bindingSource.DataSource = data.Search(searchbox.Text);
                workspace.DataSource = bindingSource;

            }

        }

        private void Fulltsearch_Click(object sender, EventArgs e)
        {
            if (!Fulltsearch.Checked)
            {
                infoftsearch.Hide();
            }
            else infoftsearch.Show();
        }

        private void addinf_Click(object sender, EventArgs e)
        {
            adding add = new adding();

            if (Columnchooser.Items.Count == 6)
            {
                add.lablet[0] = Columnchooser.GetItemText(Columnchooser.Items[1]);
                add.lablet[1] = Columnchooser.GetItemText(Columnchooser.Items[2]);
                add.lablet[2] = Columnchooser.GetItemText(Columnchooser.Items[3]);
                add.lablet[3] = Columnchooser.GetItemText(Columnchooser.Items[4]);
            }
            else
            {
                add.lablet[0] = Columnchooser.GetItemText(Columnchooser.Items[1]);
                add.lablet[1] = Columnchooser.GetItemText(Columnchooser.Items[2]);
                add.lablet[2] = Columnchooser.GetItemText(Columnchooser.Items[3]);
                add.lablet[3] = Columnchooser.GetItemText(Columnchooser.Items[4]);
                add.lablet[4] = Columnchooser.GetItemText(Columnchooser.Items[5]);
            }
            add.Show();
        }

        private void delif_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Вы действительно хотите удалить выбранную запись?",
                 "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            string id = workspace.CurrentRow.Cells[0].Value.ToString();
            //MessageBox.Show(id);
            //MessageBox.Show(Columnchooser.GetItemText(Columnchooser.Items[0]));
            //
            Database.deletefrom(id, Columnchooser.GetItemText(Columnchooser.Items[0]));
            bindingSource.Clear();
            workspace.DataSource = null;
            workspace.Rows.Clear();
            workspace.Columns.Clear();
            Database data = new Database();
            Database.table = tablechoose.Text;
            bindingSource.DataSource = data.gettable();
            Columnchooser.DataSource = data.GetColumns();
            workspace.DataSource = bindingSource;
        }

        private void chnginf_Click(object sender, EventArgs e)
        {

            chnginf chng = new chnginf();
            chng.id = workspace.CurrentRow.Cells[0].Value.ToString();
            chng.columnname = Columnchooser.GetItemText(Columnchooser.Items[0]);

            if (Columnchooser.Items.Count == 6)
            {
                chng.lablet[0] = Columnchooser.GetItemText(Columnchooser.Items[1]);
                chng.lablet[1] = Columnchooser.GetItemText(Columnchooser.Items[2]);
                chng.lablet[2] = Columnchooser.GetItemText(Columnchooser.Items[3]);
                chng.lablet[3] = Columnchooser.GetItemText(Columnchooser.Items[4]);
                chng.textbt[0] = workspace.CurrentRow.Cells[1].Value.ToString();
                chng.textbt[1] = workspace.CurrentRow.Cells[2].Value.ToString();
                chng.textbt[2] = workspace.CurrentRow.Cells[3].Value.ToString();
                chng.textbt[3] = workspace.CurrentRow.Cells[4].Value.ToString();
            }
            else
            {
                chng.lablet[0] = Columnchooser.GetItemText(Columnchooser.Items[1]);
                chng.lablet[1] = Columnchooser.GetItemText(Columnchooser.Items[2]);
                chng.lablet[2] = Columnchooser.GetItemText(Columnchooser.Items[3]);
                chng.lablet[3] = Columnchooser.GetItemText(Columnchooser.Items[4]);
                chng.lablet[4] = Columnchooser.GetItemText(Columnchooser.Items[5]);
                chng.textbt[0] = workspace.CurrentRow.Cells[1].Value.ToString();
                chng.textbt[1] = workspace.CurrentRow.Cells[2].Value.ToString();
                chng.textbt[2] = workspace.CurrentRow.Cells[3].Value.ToString();
                chng.textbt[3] = workspace.CurrentRow.Cells[4].Value.ToString();
                chng.textbt[4] = workspace.CurrentRow.Cells[5].Value.ToString();
            }
            chng.Show();



        }

        private void otch_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\data\word\output" + numb + ".docx";
                numb++;
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
                {
                    // Создаём основной документ
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                    mainPart.Document = new Document(new Body());

                    // Получаем тело документа
                    Body body = mainPart.Document.Body;

                    // Создаём таблицу
                    Table table = new Table();

                    // Добавляем стиль таблицы
                    TableProperties tblProperties = new TableProperties(
                        new TableBorders(
                            new TopBorder { Val = BorderValues.Single, Size = 4 },
                            new BottomBorder { Val = BorderValues.Single, Size = 4 },
                            new LeftBorder { Val = BorderValues.Single, Size = 4 },
                            new RightBorder { Val = BorderValues.Single, Size = 4 },
                            new InsideHorizontalBorder { Val = BorderValues.Single, Size = 4 },
                            new InsideVerticalBorder { Val = BorderValues.Single, Size = 4 }));
                    table.AppendChild(tblProperties);

                    // Добавляем заголовок таблицы
                    TableRow headerRow = new TableRow();
                    foreach (DataGridViewColumn column in workspace.Columns)
                    {
                        TableCell headerCell = new TableCell(new Paragraph(new Run(new Text(column.HeaderText))));
                        headerRow.Append(headerCell);
                    }
                    table.Append(headerRow);

                    // Добавляем строки данных
                    foreach (DataGridViewRow row in workspace.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            TableRow tableRow = new TableRow();
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                string cellText = cell.Value?.ToString() ?? string.Empty;
                                TableCell tableCell = new TableCell(new Paragraph(new Run(new Text(cellText))));
                                tableRow.Append(tableCell);
                            }
                            table.Append(tableRow);
                        }
                    }

                    // Добавляем таблицу в документ
                    body.AppendChild(table);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message);
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\data\excel");
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\data\excel\output" + numb2 + ".xlsx";
                numb2++;
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    // Создаём новый лист
                    var worksheet = excelPackage.Workbook.Worksheets.Add("Data");

                    // Заполняем заголовки столбцов
                    for (int col = 0; col < workspace.Columns.Count; col++)
                    {
                        worksheet.Cells[1, col + 1].Value = workspace.Columns[col].HeaderText;
                    }

                    // Заполняем данные
                    for (int row = 0; row < workspace.Rows.Count; row++)
                    {
                        for (int col = 0; col < workspace.Columns.Count; col++)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = workspace.Rows[row].Cells[col].Value;
                        }
                    }

                    // Сохраняем файл
                    FileInfo excelFile = new FileInfo(filePath);
                    excelPackage.SaveAs(excelFile);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message);
            }
        }

        private void otch_Click_1(object sender, EventArgs e)
        {
            bindingSource.Clear();
            workspace.DataSource = null;
            workspace.Rows.Clear();
            workspace.Columns.Clear();
            bindingSource.DataSource = Database.query1();
            workspace.DataSource = bindingSource;
            delif.Enabled = false;
            chnginf.Enabled = false;
            addinf.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
            Columnchooser.Enabled = false;
            searchbox.Enabled = false;
            search.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bindingSource.Clear();
            workspace.DataSource = null;
            workspace.Rows.Clear();
            workspace.Columns.Clear();
            bindingSource.DataSource = Database.query2();
            workspace.DataSource = bindingSource;
            delif.Enabled = false;
            chnginf.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
            addinf.Enabled = false;
            Columnchooser.Enabled = false;
            searchbox.Enabled = false;
            search.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bindingSource.Clear();
            workspace.DataSource = null;
            workspace.Rows.Clear();
            workspace.Columns.Clear();
            bindingSource.DataSource = Database.query3();
            workspace.DataSource = bindingSource;
            delif.Enabled = false;
            chnginf.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
            addinf.Enabled = false;
            Columnchooser.Enabled = false;
            searchbox.Enabled = false;
            search.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bindingSource.Clear();
            workspace.DataSource = null;
            workspace.Rows.Clear();
            workspace.Columns.Clear();
            bindingSource.DataSource = Database.query4();
            workspace.DataSource = bindingSource;
            delif.Enabled = false;
            chnginf.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
            addinf.Enabled = false;
            Columnchooser.Enabled = false;
            searchbox.Enabled = false;
            search.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bindingSource.Clear();
            workspace.DataSource = null;
            workspace.Rows.Clear();
            workspace.Columns.Clear();
            bindingSource.DataSource = Database.query5();
            workspace.DataSource = bindingSource;
            delif.Enabled = false;
            chnginf.Enabled = false;
            addinf.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
            Columnchooser.Enabled = false;
            searchbox.Enabled = false;
            search.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bindingSource.Clear();
            workspace.DataSource = null;
            workspace.Rows.Clear();
            workspace.Columns.Clear();
            bindingSource.DataSource = Database.query6();
            workspace.DataSource = bindingSource;
            delif.Enabled = false;
            chnginf.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
            addinf.Enabled = false;
            Columnchooser.Enabled = false;
            searchbox.Enabled = false;
            search.Enabled = false;
        }
    }
}
