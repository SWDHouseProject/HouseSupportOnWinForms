using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ShowMatrix : Form
    {
        public ShowMatrix(AHP category, Results parent)
        {
            InitializeComponent();
            var t = new string[] {"1", "2", "3", "4", "5"};
            Form1.visualiseArray(category.matrix2, this.dataGridView1, t);
            Form1.VisualizeLegend(legend);

            button1.Click += (sender, args) =>
            {
                category.resetMatrix(Form1.ReadMatrix(dataGridView1));
                category.startCounting();
                this.Hide();
                parent.refreshArray();
            };;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
