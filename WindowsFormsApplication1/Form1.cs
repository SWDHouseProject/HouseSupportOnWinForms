using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public static AHP init;
        public Form1()
        {  
            InitializeComponent();
            double[] i = Questions.numberRepresentation;
            VisualizeLegend(legend);
            init = new AHP();
            init.Initialize(i);
            startAhp();

            this.dataGridView1.CellEndEdit += (sender, args) =>
            {
                var m = ReadMatrix(dataGridView1);
                init.resetMatrix(m);

                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                startAhp();
            };


        }

        void startAhp()
        {
            visualiseArray(init.matrix, this.dataGridView1, ChooseCategories.listOfChoosenCategories.ToArray());
            var score = init.startCounting();
            this.textBox1.Text = ConvertArrayToString(score.OrderByDescending(s => s).ToArray());


            if (init.CalculateConsistency() < 0.1)
            {
                this.checkBox1.CheckState = CheckState.Checked; 
            }
            else
            {
                this.checkBox1.CheckState = CheckState.Unchecked;
            }
            this.checkBox1.Text = " " + init.CalculateConsistency();

            
        }

        public static void VisualizeLegend(TextBox tbBox)
        {
            int i = 9;
            tbBox.Text = "";
            foreach (var option in Questions.QuestionsStrings)
            {
                tbBox.Text += option + " = " + i + "\r\n";
                i -= 2;
            }
            
        }

        public static void visualiseArray(double [,] q, DataGridView v, string []headers)
        {
            foreach (var category in headers)
                v.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = category });

            var d = ToJaggedArray(q);
            v.ColumnCount = d[0].Length;
            for (int i = 0; i < d[0].Length; i++)
            {
                v.Rows.Add(convertToString(d[i]));
                v.Rows[i].HeaderCell.Value = headers[i];
                v.RowHeadersWidth = 130;
            }
        }

        public string ConvertArrayToString(double[] s)
        {
            string output = "";
            int i = 0;
            foreach (var s1 in s)
            {
                output += ChooseCategories.listOfChoosenCategories[i] + " " + s1.ToString() + "\r\n";
                i++;
            }
            return output;
        }

        public static string[] convertToString<T>(T[] d)
        {
            List<string> s = new List<string>();
            foreach (T v in d)
            {
                s.Add(v.ToString()); 
            }
            return s.ToArray();
        }

        public static T[][] ToJaggedArray<T>(T[,] twoDimensionalArray)
        {
            int rowsFirstIndex = twoDimensionalArray.GetLowerBound(0);
            int rowsLastIndex = twoDimensionalArray.GetUpperBound(0);
            int numberOfRows = rowsLastIndex + 1;

            int columnsFirstIndex = twoDimensionalArray.GetLowerBound(1);
            int columnsLastIndex = twoDimensionalArray.GetUpperBound(1);
            int numberOfColumns = columnsLastIndex + 1;

            T[][] jaggedArray = new T[numberOfRows][];
            for (int i = rowsFirstIndex; i <= rowsLastIndex; i++)
            {
                jaggedArray[i] = new T[numberOfColumns];

                for (int j = columnsFirstIndex; j <= columnsLastIndex; j++)
                {
                    jaggedArray[i][j] = twoDimensionalArray[i, j];
                }
            }
            return jaggedArray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new Results();
            frm.Show();
        }

        double[,] ReadMatrix(DataGridView v)
        {
            var array = new double[v.RowCount -1, v.ColumnCount];
            foreach (DataGridViewRow i in dataGridView1.Rows)
            {
                if (i.IsNewRow) continue;
                foreach (DataGridViewCell j in i.Cells)
                {
                    array[j.RowIndex, j.ColumnIndex] = Double.Parse(j.Value != null ? (string)j.Value:"1");
                }
            }
            return array;
        }
    }
}
