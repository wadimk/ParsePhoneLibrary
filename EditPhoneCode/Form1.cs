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

        private BindingList<Country> countrieslist;
        private int iCount;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            p = new phone();

        }


        private void bindGrid()
        {
            this.countriesDataGrid.AutoGenerateColumns = false;
            
            //create the column programatically
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            DataGridViewTextBoxColumn colCountry = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell, 
                Name = "Name",
                HeaderText = "Country Name",
                DataPropertyName = "Name" // Tell the column which property of FileName it should use
            };
            countriesDataGrid.Columns.Add(colCountry);


            DataGridViewTextBoxColumn colCode = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                Name = "Code",
                HeaderText = "Country Code",
                DataPropertyName = "Code" // Tell the column which property of FileName it should use
            };
            countriesDataGrid.Columns.Add(colCode);

            var list = p.countries.ToList();
            var filenamesList = new BindingList<Country>(list); // <-- BindingList

            //Bind BindingList directly to the DataGrid, no need of BindingSource
            countriesDataGrid.DataSource = filenamesList;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            p.loadfromxml();
            this.countriesCount.Text = p.countries.Count().ToString();
            bindGrid();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            p.savetoxml();
        }


    }
}
