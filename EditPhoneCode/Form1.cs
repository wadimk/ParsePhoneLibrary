using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PhoneParser;

namespace EditPhoneCode
{
    public partial class Form1 : Form
    {
        phone p;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            p = new phone();
            this.countriesCount.Text = p.countries.Count().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.savetoxml();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


    }
}
