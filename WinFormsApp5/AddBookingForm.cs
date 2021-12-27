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
    public partial class AddBookingForm : Form
    {
        public AddBookingForm()
        {
            InitializeComponent();
        }

        private void AddBookingForm_Load(object sender, EventArgs e)
        {
            Repo rm = new Repo();
            comboBox2.DataSource =
             rm.users.ToList().
             Select(c => c.UserName).ToList();

            comboBox3.DataSource =
             rm.clients.ToList().
             Select(c => c.Name).ToList();
            comboBox1.DataSource =
             rm.rooms.ToList().
             Select(c => c.name).ToList();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            BookingForm v = new BookingForm();
            v.Show();
            Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Booking a = new Booking();
            Repo rm = new Repo();
            rm.Database.EnsureCreated();
            a.time = textBox2.Text;
            a.NumberOfChairs = int.Parse(textBox5.Text);
            a.TotalPrice = int.Parse(textBox6.Text);
            a.UserID = rm.users.
                ToList().Where(c => c.UserName == comboBox2.Text).
                 FirstOrDefault().ID;

            a.ClientID = rm.clients.
                ToList().Where(c => c.Name == comboBox3.Text).
                 FirstOrDefault().Id;
            a.RoomID = rm.rooms.
                ToList().Where(c => c.name == comboBox1.Text).
                 FirstOrDefault().Id;

            a.NumberOfHours = int.Parse(textBox7.Text);
            rm.bookings.Add(a);
            rm.SaveChanges();
            MessageBox.Show("Done");

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
