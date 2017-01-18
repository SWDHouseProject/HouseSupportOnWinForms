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
        public Questions()
        {
            InitializeComponent();
            CreateQuestionSentences();
        }

        public void CreateQuestionSentences()
        {
            var p = new Point(12,14);
            
            string[] values = { "Największe znaczenie", "Bardzo duże znaczenie", "Duże znaczenie", "Umiarkowane znaczenie", "Równoważne" };
            for (var i =0; i < ChooseCategories.listOfChoosenCategories.Count; i++)
            {
                for (var j = i+1; j < ChooseCategories.listOfChoosenCategories.Count ; j++)
                {
                    var t = new TextBox();
                    var c = new ComboBox();
                    
                    c.Items.AddRange(values);
                    c.DropDownStyle = ComboBoxStyle.DropDown;
                    c.Size = new Size(130,100);
                    c.Location = new Point(412, p.Y);
                    c.Name = "c" + i;
                    listOfCombosBoxs.Add(c);

                    t.Text = "Czy kategoria: " + ChooseCategories.listOfChoosenCategories[i] + " jest wazniejsza od kategori: " + 
                        ChooseCategories.listOfChoosenCategories[j];
                    t.Location = p;
                    t.Size = new Size(400,100);
                    t.TabIndex = 0;
                    t.Visible = true;
                    t.Name = "w";

                    p.Y += 25;
                    this.Controls.Add(c);
                    this.Controls.Add(t);            
                }  
            }
            var b = new Button{Location = new Point(120, p.Y), Size = new Size(100, 20), Text = "Oblicz"};        
            b.Click += BOnClick;
            this.Controls.Add(b);

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
