﻿using System;
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
        public ShowMatrix(AHP category)
        {
            InitializeComponent();
            var t = new string[] {"1", "2", "3", "4", "5"};
            Form1.visualiseArray(category.matrix, this.dataGridView1, t);  
        }
    }
}
