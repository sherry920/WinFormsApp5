using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TheCave;

namespace WinFormsApp5
{
    public partial class AddOrderForm : Form
    {
        public AddOrderForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderForm f=new OrderForm();
            f.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            order d = new order();
            Repo rd = new Repo();
            rd.Database.EnsureCreated();
            d.totalPrice = int.Parse(textBox1.Text);
            d.quantity = int.Parse(textBox2.Text);
            d.time = int.Parse(textBox7.Text);

            d.userId = rd.users.
                ToList().Where(c => c.UserName == comboBox2.Text).
                 FirstOrDefault().ID;

            d.productId = rd.products.
                ToList().Where(c => c.productName == comboBox1.Text).
                 FirstOrDefault().Id;
            d.cientId = rd.clients.
                ToList().Where(c => c.Name == comboBox3.Text).
                 FirstOrDefault().Id;

            rd.orders.Add(d);
            rd.SaveChanges();
            MessageBox.Show("Done");


        }

        private void AddOrderForm_Load(object sender, EventArgs e)
        {
            Repo rd= new Repo();
            comboBox1.DataSource =
             rd.products.ToList().
             Select(c => c.productName).ToList();

            comboBox3.DataSource =
             rd.clients.ToList().
             Select(c => c.Name).ToList();
            comboBox2.DataSource =
             rd.users.ToList().
             Select(c => c.UserName).ToList();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
