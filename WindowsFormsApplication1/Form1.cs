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
            init = new AHP();
            init.Initialize(i);
            if (init.CalculateConsistency())
                this.checkBox1.CheckState = CheckState.Checked;
            visualiseArray(init.matrix, this.dataGridView1);
            var score = init.startCounting();
            this.textBox1.Text = ConvertArrayToString(score);
            
            init.CalculateConsistency();
        }

        public static void visualiseArray(double [,] q, DataGridView v)
        {
            var d = ToJaggedArray(q);
            v.ColumnCount = d[0].Length;
            for (int i = 0; i < d[0].Length; i++)
            {
                v.Rows.Add(convertToString(d[i]));                            
            }
        }

        public static void visualiseApartmentsArray(Apartment[] q, DataGridView v)
        {
            for (int i = 0; i < ChooseCategories.listOfCategories.Length; i++)
                v.Columns.Add(new DataGridViewTextBoxColumn() {HeaderText = ChooseCategories.listOfCategories[i]});

            for (int i = 0; i < q.ToString().Length; i++)
            {
                v.Rows.Add(q[i].ToString());
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
    }
}
