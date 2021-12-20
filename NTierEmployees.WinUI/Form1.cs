using NTierEmployees.BLL.Repositories;
using NTierEmployees.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTierEmployees.WinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EmployeesRepository er = new EmployeesRepository();
        Employee updateE;

        private void button1_Click(object sender, EventArgs e)
        {
            er.Insert(new Employee
            {
                FirstName = textBox1.Text,
                LastName = textBox2.Text,
                Title = textBox3.Text,
                City = textBox4.Text
            });
            ListAll();
            Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateE.FirstName = textBox1.Text;
            updateE.LastName = textBox2.Text;
            updateE.Title = textBox3.Text;
            updateE.City = textBox4.Text;
            er.Update(updateE);
            ListAll();
            Clear();
        }

        public void ListAll()
        {
            dataGridView1.DataSource = er.SelectAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListAll();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int id = ((int)dataGridView1.SelectedRows[0].Cells[0].Value);
            updateE = er.SelectById(id);
            textBox1.Text = updateE.FirstName;
            textBox2.Text = updateE.LastName;
            textBox3.Text = updateE.Title;
            textBox4.Text = updateE.City;
            ListAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            er.Delete((int)dataGridView1.SelectedRows[0].Cells[0].Value);
            ListAll();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string search = textBox5.Text;
            dataGridView1.DataSource = er.FindByName(search);
        }
        public void Clear()
        {
            foreach (var item in Controls)
            {
                if (item is TextBox)
                {
                    TextBox t = (TextBox)item;
                    t.Clear();
                }
            }
        }

    }
}
