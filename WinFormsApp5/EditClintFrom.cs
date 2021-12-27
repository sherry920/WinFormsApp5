using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TheCave;

namespace WinFormsApp5
{
    public partial class EditClintFrom : Form
    {
        Client client;
        public EditClintFrom(Client c)
        {
            InitializeComponent();
            client = c;
            textBox2.Text = c.Name;
            textBox3.Text = c.PhoneNumber.ToString();
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            ClientForm f =new ClientForm();
            f.Show();
            Hide();
        }

        private void EditClintFrom_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Repo rc = new Repo();
            rc.Database.EnsureCreated();

            client.Name = textBox2.Text;
            client.PhoneNumber = int.Parse(textBox3.Text);

            rc.clients.Update(client);
            rc.SaveChanges();
            MessageBox.Show("Done");
        }
    }
}
