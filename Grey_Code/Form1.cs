using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

        private void OnButtonClick(object sender, EventArgs e)
        {
            List<int> elems = PrepareSetElements(setElementsTextBox.Text);

            setElementsTextBox.Text = String.Join(" ", elems);

            BitScale bitScale = new();

            bitScale.Init(elems.ToArray());

            SetupTable(bitScale);
        }

        private List<int> PrepareSetElements(string rawString)
        {
            string[] rawElements = FormatString(setElementsTextBox.Text).Split(' ');

            List<int> elems = new();

            foreach (string rawElem in rawElements)
            {
                if (int.TryParse(rawElem, out int num)) elems.Add(num);
            }

            elems.Sort();

            elems = elems.Distinct().ToList();

            return elems;
        }

        private void SetupTable(BitScale bitScale)
        {
            dataGrid.DataSource = bitScale.BuildSubsets();

            if (!dataTableIsSet)
            {
                dataGrid.Columns[0].HeaderText = "Порядковый номер";
                dataGrid.Columns[0].Width = 150;

                dataGrid.Columns[1].HeaderText = "Код Грея";
                dataGrid.Columns[1].Width = 200;

                dataGrid.Columns[2].HeaderText = "Соответствующее подмножество";
                dataGrid.Columns[2].Width = 190;

                dataTableIsSet = true;
            }
        }

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
