using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Grey_Code
{
    public partial class Form1 : Form
    {
        Boolean dataTableIsSet = false;

        public Form1()
        {
            InitializeComponent();
        }

        // обработаем клик на кнопку "Сгенерировать подмножества"
        private void OnButtonClick(object sender, EventArgs e)
        {
            // подготовим сырые данные, полученные из пользовательского ввода
            List<int> elems = PrepareSetElements(setElementsTextBox.Text);

            // заменим введенные пользователем данные на очищенные
            setElementsTextBox.Text = String.Join(" ", elems);

            BitScale bitScale = new();

            bitScale.Init(elems.ToArray());

            Subset[] subsets = bitScale.BuildSubsets();
           
            SetupTable(subsets);

            // записываем в файл, только если число подмножеств больше 15
            if (elems.Count > 4)
            {
                WriteListToFile(subsets);
            }
        }

        private List<int> PrepareSetElements(string rawString)
        {
            // форматируем строку
            string[] rawElements = FormatString(setElementsTextBox.Text).Split(' ');

            List<int> elems = new();

            // добавляем в список элементов множества только числа
            foreach (string rawElem in rawElements)
            {
                if (int.TryParse(rawElem, out int num)) elems.Add(num);
            }

            // сортируем
            elems.Sort();

            // убираем дубликаты
            elems = elems.Distinct().ToList();

            return elems;
        }

        // записываем подмножества в файл
        private void WriteListToFile(Subset[] subsets)
        {
            // получаем информацию о текущей папке
            DirectoryInfo dirInfo = new(AppDomain.CurrentDomain.BaseDirectory);

            string fileName = dirInfo.FullName + "subsets.txt";

            try
            {
                // записываем элементы списка в файл
                using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.Default))
                {
                    foreach (Subset subset in subsets)
                    {
                        sw.WriteLine(subset.FullInfo);
                    }
                }

                MessageBox.Show("Список подможеств сохранен в файле " + fileName);
            } catch
            {
                MessageBox.Show("Не удалось сохранить файл " + fileName);
            }
        }

        private void SetupTable(Subset[] subsets)
        {
            dataGrid.DataSource = subsets;

            if (!dataTableIsSet)
            {
                dataGrid.Columns[0].HeaderText = "Порядковый номер";
                dataGrid.Columns[0].Width = 150;

                dataGrid.Columns[1].HeaderText = "Код Грея";
                dataGrid.Columns[1].Width = 200;

                dataGrid.Columns[2].HeaderText = "Соответствующее подмножество";
                dataGrid.Columns[2].Width = 190;

                dataGrid.Columns[3].Visible = false;

                dataTableIsSet = true;
            }
        }

        // убираем лишние пробелы
        private static string FormatString(string str)
        {
            string formattedString;

            Regex regex = new(@"\s+");
            formattedString = regex.Replace(str, " ");

            return formattedString.Trim();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
