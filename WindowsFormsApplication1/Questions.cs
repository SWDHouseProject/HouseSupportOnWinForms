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
    public partial class Questions : Form
    {
        public static double[] numberRepresentation;
        List<ComboBox> listOfCombosBoxs = new List<ComboBox>();
        public static string[] QuestionsStrings = { "Najbardziej znacznie", "Bardzo znacznie", "znacznie", "Umiarkowanie", "Równoważne", "Niewiele mniej ważna", "Mniej ważna", "Dużo mniej ważna", "Najmniej ważna" };
        public Questions()
        {
            InitializeComponent();
            CreateQuestionSentences();

        }

        public void CreateQuestionSentences()
        {
            var p = new Point(12,14);
            
            
            for (var i =0; i < ChooseCategories.listOfChoosenCategories.Count; i++)
            {
                for (var j = i+1; j < ChooseCategories.listOfChoosenCategories.Count ; j++)
                {
                    var c = new ComboBox {DropDownStyle = ComboBoxStyle.DropDown, Size = new Size(130,100), Location = new Point(412, p.Y)};
                    c.Items.AddRange(QuestionsStrings);
                    listOfCombosBoxs.Add(c);
                    this.Controls.Add(c);

                    var t = new TextBox
                    { Text = "Czy kategoria: " + ChooseCategories.listOfChoosenCategories[i] + " jest wazniejsza od kategori: " +
                        ChooseCategories.listOfChoosenCategories[j],
                        Location = p,
                        Size = new Size(400,100)
                    };
                    this.Controls.Add(t);
                    p.Y += 25;          
                }  
            }
            var back = new Button {Location = p, Size = new Size(100,20), Text = "Wróc"};
            back.Click += (sender, args) =>
            {
                ChooseCategories.listOfChoosenCategories.Clear();
                ChooseCategories.listOfChoosenCategoriesByIndex.Clear();
                this.Hide();
                var frm = new ChooseCategories();
                frm.Show();
            };
            this.Controls.Add(back);

            var b = new Button { Location = new Point(120, p.Y), Size = new Size(100, 20), Text = "Oblicz" };
            b.Click += BOnClick;
            this.Controls.Add(b);

            ///var cons = new CheckBox() {Location = new Point(220,p.Y), Size = new Size(100,20)};
            //this.Controls.Add(cons);
        }

        double[] conversionFromStringToDoubles(List<ComboBox>c)
        {
            var numberRepresentation = new double[c.Count];
            for (var i = 0; i < c.Count; i++)
            {
                switch (c[i].SelectedIndex)
                {
                    case 0:
                        numberRepresentation[i] = 9;
                        break;
                    case 1:
                        numberRepresentation[i] = 7;
                        break;
                    case 2:
                        numberRepresentation[i] = 5;
                        break;
                    case 3:
                        numberRepresentation[i] = 3;
                        break;
                    case 4:
                        numberRepresentation[i] = 1;
                        break;
                    case 5:
                        numberRepresentation[i] = 1.0/3.0;
                        break;
                    case 6:
                        numberRepresentation[i] = 1.0/5.0;
                        break;
                    case 7:
                        numberRepresentation[i] = 1.0/7.0;
                        break;
                    case 8:
                        numberRepresentation[i] = 1.0/9.0;
                        break;
                }
            }
            return numberRepresentation;
        }

        private void BOnClick(object sender, EventArgs eventArgs)
        {
            numberRepresentation = conversionFromStringToDoubles(listOfCombosBoxs);
            this.Hide();
            var frm = new Form1();
            frm.Show();
        }
    }
}
