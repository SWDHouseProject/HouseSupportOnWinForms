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
    public partial class ChooseCategories : Form
    {
        public static String [] listOfCategories = { "cena", "metraż", "lokalizacja", "wyposazenie",
            "ilosc pokoi", "cena mediów", "komunikacja miejska", "rodzaj ogrzewania", "różność mediów"};
        public static List<String> listOfChoosenCategories = new List<string>();
        public static List<int> listOfChoosenCategoriesByIndex = new List<int>();

        public ChooseCategories()
        {
            InitializeComponent();
            listBox1.Items.AddRange(listOfCategories);
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            MoveListBoxItems(listBox1, listBox2);
        }

        private void MoveListBoxItems(ListBox source, ListBox destination)
        {
            ListBox.SelectedObjectCollection sourceItems = source.SelectedItems;
            foreach (var item in sourceItems)
            {
                destination.Items.Add(item);
            }
            while (source.SelectedItems.Count > 0)
            {
                source.Items.Remove(source.SelectedItems[0]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MoveListBoxItems(listBox2, listBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count == 5)
            {
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    var x = listBox2.GetItemText(listBox2.Items[i]);
                    listOfChoosenCategories.Add(x);
                    listOfChoosenCategoriesByIndex.Add(Array.FindIndex(listOfCategories, y => y.Equals(x)));
                }

                this.Hide();
                var frm = new Questions();
                frm.Show();
            }
            else
            {
                this.label1.ForeColor = Color.OrangeRed;
            }
        } 
    }
}
