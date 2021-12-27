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
    public partial class EditOrderForm : Form
    {
        order order;
        public EditOrderForm(order o)
        {
            InitializeComponent();
            order = o;
            textBox5.Text = o.quantity.ToString();


        }
        public EditOrderForm(IEnumerable<order> orders)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderForm s = new OrderForm();
            s.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Repo rd = new Repo();
            rd.Database.EnsureCreated();

            order.quantity = int.Parse(textBox5.Text);


            order.productId = rd.products.
             ToList().Where(c => c.productName == comboBox1.Text).
             FirstOrDefault().Id;

            order.cientId = rd.clients.
                ToList().Where(c => c.Name == comboBox2.Text).
                FirstOrDefault().Id;

            order.userId = rd.users.
                ToList().Where(c => c.UserName == comboBox3.Text).
                FirstOrDefault().ID;

            rd.orders.Update(order);
            rd.SaveChanges();
            MessageBox.Show("Done");
        }

        private void EditOrderForm_Load(object sender, EventArgs e)
        {
            Repo rd = new Repo();
            comboBox3.DataSource =
             rd.users.ToList().
             Select(c => c.UserName).ToList();

            comboBox2.DataSource =
             rd.clients.ToList().
             Select(c => c.Name).ToList();

            comboBox1.DataSource =
             rd.products.ToList().
             Select(c => c.productName).ToList();

        }
    }
}
