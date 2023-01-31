using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace LeitorPMG
{
    public partial class Form1 : Form
    {
        public void CreateFolderAndFile(string path)
        {
            string folder = path.Split('/')[0];

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        public List<string> FormatScriptPDF(string placa, string filename, int quantidade, int folhas, int folha)
        {
            string format = "";
            List<string> formatReturn = new List<string>();

            for (int i = 0; i < quantidade; i++)
            {
                if ((i + 1) == quantidade && folha == folhas)
                {
                    format = "('" + placa + "', '" + filename + "');\n";
                    formatReturn.Add(format);
                } else
                {
                    format = "('" + placa + "', '" + filename + "'),\n";
                    formatReturn.Add(format);
                }

                progressBar1.Value = (i / quantidade) * 100;
            }

            return formatReturn;
        }

        public string FormatScriptExcel(string placa, string comitente, string data, int quantidade, int index)
        {
            string format = "";
            List<string> formatList = new List<string>();

            if((index + 1) == quantidade)
                {
                format = "('" + placa + "', 'VS SALVADO - " + data + " - " + comitente + "');\n";
                formatList.Add(format);
            }
                else
            {
                format = "('" + placa + "', 'VS SALVADO - " + data + " - " + comitente + "'),\n";
                formatList.Add(format);
            }

            progressBar1.Value = (index / quantidade) * 100;

            return formatList[0];
        }

        public static string[] GetCellsAsArray(Worksheet ws, string startCell, string endCell)
        {
            if (startCell == endCell)
            {
                return new string[] { "", ws.Range[startCell].Value };
            }

            return ((Array)ws.Range[startCell + ":" + endCell].Cells.Value).OfType<object>().Select(o => o.ToString()).ToArray();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            list.DataSource = null;
            list.Items.Clear();
            textBox.Text = "";
            progressBar1.Value = 0;

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All Files (*.pdf;*.xlsx;*.xls;*.csv)|*.pdf;*.xlsx;*.xls;*.csv|PDF Files (*.pdf)|*.pdf|Excel Files (*.xlsx;*.xls;*.csv)|*.xlsx;*.xls;*.csv*";
            fileDialog.ShowDialog();

            string filePath = fileDialog.FileName.ToString();
            string fileName = System.IO.Path.GetFileName(filePath);

            textBox.Text = fileName;
            textBox.SelectAll();
            textBox.SelectionAlignment = HorizontalAlignment.Center;
            list.Items.Add(filePath);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            list.DataSource = null;
            list.Items.Clear();
            textBox.Text = "";
            progressBar1.Value = 0;

            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.ShowDialog();

            string filePath = folderDialog.SelectedPath.ToString();
            string fileName = System.IO.Path.GetFileName(filePath);

            textBox.Text = filePath;
            textBox.SelectAll();
            textBox.SelectionAlignment = HorizontalAlignment.Center;

            if (textBox.Text != "")
            {
                var files = System.IO.Directory.GetFiles(filePath, "*.*", System.IO.SearchOption.AllDirectories);
                list.DataSource = files;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_enviar_Click(object sender, EventArgs e)
        {
            if (textBox.Text != "" || textBox.Text != "Enviado com sucesso!")
            {
                btn_enviar.Enabled = false;

                Regex regex = new Regex("");

                string regexPDF = "[A-Z]{3}[0-9][0-9A-Z] ?[0-9]{2}";
                string regexDataExcel = "[0-9]{2}.[0-1][0-9].[0-9]{4}";

                int placasCount = 0;

                List<string> files = new List<string>();
                List<string> filesNames = new List<string>();
                int countedFiles = list.Items.Count;


                foreach (var item in list.Items)
                {
                    if (!item.ToString().Contains("~$"))
                    {
                        string file = item.ToString();
                        string filename = System.IO.Path.GetFileName(file);
                        files.Add(file);
                        filesNames.Add(filename);

                        if (item.ToString().Contains(".pdf") || item.ToString().Contains(".xlsx") || item.ToString().Contains(".xls") || item.ToString().Contains(".csv"))
                        {
                            if (item.ToString().Contains(".pdf"))
                            {
                                string pathTXT = "ExtractedsPMG/SCRIPT - " + DateTime.Now.ToString().Split(' ')[0].Replace("/", ".") + " - INDICE 4.txt";
                                CreateFolderAndFile(pathTXT);
                                File.WriteAllText(pathTXT, "INSERT INTO SALVADOS (placa, descricao) VALUES \n");
                            }
                            else
                            {
                                string pathTXT = "ExtractedsPMG/SCRIPT - " + DateTime.Now.ToString().Split(' ')[0].Replace("/", ".") + " - INDICE 1.txt";
                                CreateFolderAndFile(pathTXT);
                                File.WriteAllText(pathTXT, "INSERT INTO SALVADOS (placa, descricao) VALUES \n");
                            }
                        }
                    }
                }

                for (int i = 0; i < files.Count; i++)
                {
                    if (filesNames[i].Split('.')[1].ToString() != "pdf")
                    {
                        List<string> excelPlacas = new List<string>();
                        List<string> excelComitentes = new List<string>();

                        Application app = new Application();
                        app.Visible = false;

                        Workbook pivotTableWorkbook = app.Workbooks.Open(files[i]);
                        Worksheet worksheet = pivotTableWorkbook.Worksheets["Plan1"];

                        int excelRows = worksheet.UsedRange.Rows.Count;

                        foreach (string item in GetCellsAsArray(worksheet, "H1", "H" + excelRows))
                        {
                            excelPlacas.Add(item);
                        }

                        foreach (string item in GetCellsAsArray(worksheet, "K1", "K" + excelRows))
                        {
                            excelComitentes.Add(item);
                        }

                        regex = new Regex(regexDataExcel);

                        MatchCollection data = regex.Matches(filesNames[i]);

                        placasCount = excelPlacas.Count;

                        if (placasCount != 0)
                        {
                            for (int count = 0; count < excelRows; count++)
                            {
                                string pathTXT = "ExtractedsPMG/SCRIPT - " + DateTime.Now.ToString().Split(' ')[0].Replace("/", ".") + " - INDICE 1.txt";
                                
                                File.AppendAllText(pathTXT, FormatScriptExcel(excelPlacas[count], excelComitentes[count], data[0].Value.Replace(".", "_"), excelRows, count));
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falha! Nenhuma placa foi encontrada no Excel.");
                            break;
                        }
                    }
                    else
                    {
                        using (PdfReader reader = new PdfReader(files[i]))
                        {
                            for (int pageNo = 1; pageNo <= reader.NumberOfPages; pageNo++)
                            {
                                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                                string text = PdfTextExtractor.GetTextFromPage(reader, pageNo, strategy);
                                text = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(text)));
                                regex = new Regex(regexPDF);
                                MatchCollection placas = regex.Matches(text);

                                placasCount = placas.Count;

                                if (placasCount != 0)
                                {
                                    for (int count = 0; count < placasCount; count++)
                                    {
                                        string pathTXT = "ExtractedsPMG/SCRIPT - " + DateTime.Now.ToString().Split(' ')[0].Replace("/", ".") + " - INDICE 4.txt";
                                        File.AppendAllText(pathTXT, FormatScriptPDF(placas[count].Value.Replace(" ", ""), filesNames[i].Split('.')[0], placas.Count, Convert.ToInt32(reader.NumberOfPages), pageNo)[count]);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Falha! Nenhuma placa foi encontrada no PDF.");
                                    break;
                                }
                            }
                        }
                    }
                }

                progressBar1.Value = 100;
                list.DataSource = null;
                list.Items.Clear();
                textBox.SelectAll();
                textBox.SelectionAlignment = HorizontalAlignment.Center;
                btn_enviar.Enabled = true;

                if (placasCount == 0)
                {
                    textBox.Text = "Falha!";
                }
                else
                {
                    textBox.Text = "Enviado!";
                }
            }
            else
            {
                MessageBox.Show("Falha! Escolha um arquivo ou uma pasta.");
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
