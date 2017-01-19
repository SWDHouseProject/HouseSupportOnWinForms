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
    public partial class Results : Form
    {
        private List<Apartment> a;
        private List<AHP> listOfCategoriesAhps = new List<AHP>();
        public Results()
        {
            InitializeComponent();

            a = new List<Apartment>();
            var ap = new Apartment(40000,20,10,5000,3,200,5,"Gazowy", "Internet, Gaz, Woda, Prąd");
            a.Add(ap);
            ap = new Apartment(100000,40,20,3000,2,250,7, "Elektryczne", "Internet, Gaz, Woda, Prąd");
            a.Add(ap);
            ap = new Apartment(20000,70, 20, 8000,4,400,5,"Miejskie", "Internet, Gaz, Woda, Prąd, Tv");
            a.Add(ap);
            ap = new Apartment(30000, 50, 30, 9000, 4, 300, 15, "Miejskie", "Internet, Gaz, Woda, Prąd, Tv");
            a.Add(ap);
            ap = new Apartment(15000, 45, 15, 7000, 3, 200, 20, "Miejskie", "Internet, Gaz, Woda, Prąd, Tv");
            a.Add(ap);

            listOfCategoriesAhps = generateMatrix();
            var res = countResults(Form1.init, listOfCategoriesAhps);
            GeneratureButtons(ChooseCategories.listOfChoosenCategories.ToArray());
            visualiseApartmentsArray(a.ToArray(), this.dataGridView1);
        }

        List<AHP> generateMatrix()
        {
            List<AHP> listOfMatrixPerCategory = new List<AHP>();
            var rnd = new Random();
            for (int i = 0; i < ChooseCategories.listOfCategories.Length; i++)
            {
                var categoryMatrix = new AHP();
                List<double> valuesToGeneratelist = new List<double>();
                for (int j = 0 ; j < 10 ; j++) valuesToGeneratelist.Add(rnd.Next(1, 9));
                categoryMatrix.Initialize(valuesToGeneratelist.ToArray());
                categoryMatrix.startCounting();
                listOfMatrixPerCategory.Add(categoryMatrix);
            }
            return listOfMatrixPerCategory;
        }

        void visualiseApartmentsArray(Apartment[] q, DataGridView v)
        {
            foreach (string category in ChooseCategories.listOfCategories)
                v.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = category });

            foreach (var apartment in q)
            {
                 v.Rows.Add(apartment.ToArrayStrings());
            }
        }

        double[] countResults(AHP mainMatrix,List<AHP> categoryMatrixes)
        {
            var results = new double[mainMatrix.average.Length];
            for (var i = 0; i < mainMatrix.average.Length; i++)
            {
                foreach (var averangeValue in mainMatrix.average)
                {
                    results[i] += averangeValue*categoryMatrixes[ChooseCategories.listOfChoosenCategoriesByIndex[i]].average[i];
                }
            }
            return results;
        }

        List<Button> GeneratureButtons(string[] values)
        {
            Point p = new Point(12,14);
            List<Button> buttons = new List<Button>();
            int i = 0;
            foreach (var v in values)   
            {
                var b = new Button();
                b.Text = v;
                b.Size = new Size(100,20);
                b.Location = p;
                p.X += b.Size.Width + 10;
                //We want to have correct categories. 
                b.Name = ChooseCategories.listOfChoosenCategoriesByIndex[i].ToString();
                i++;
                b.Click += BOnClick;
                buttons.Add(b);
                this.Controls.Add(b);
            }
            return buttons;
        }

        private void BOnClick(object sender, EventArgs eventArgs)
        {
            var b = (Button)sender;
            var frm = new ShowMatrix(listOfCategoriesAhps[int.Parse(b.Name)]);
            frm.Show();
        }
    }
}
