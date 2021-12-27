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
    public partial class EditBookingForm : Form
    {
        Booking booking;

        public EditBookingForm(Booking b)
        {
            InitializeComponent();
            booking = b;
            textBox2.Text = b.time;
            textBox5.Text = b.NumberOfChairs.ToString();
            textBox6.Text = b.TotalPrice.ToString();
            textBox7.Text = b.NumberOfHours.ToString();
            button2.Click += Button2_Click;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Repo rm = new Repo();
            rm.Database.EnsureCreated();

            booking.time = textBox2.Text;
            booking.NumberOfChairs = int.Parse(textBox5.Text);
            booking.TotalPrice = int.Parse(textBox6.Text);
            booking.NumberOfHours = int.Parse(textBox7.Text);

            booking.RoomID = rm.rooms.
             ToList().Where(c => c.name == comboBox1.Text).
             FirstOrDefault().Id;
            booking.ClientID=rm.clients.
                ToList().Where(c => c.Name==comboBox2.Text).
                FirstOrDefault().Id;
            booking.UserID = rm.users.
                ToList().Where(c => c.UserName == comboBox3.Text).
                FirstOrDefault().ID;

            rm.bookings.Update(booking);
            rm.SaveChanges();
            MessageBox.Show("Done");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BookingForm s = new BookingForm();
            s.Show();
            Hide();

        }

        private void EditBookingForm_Load(object sender, EventArgs e)
        {

            Repo rm = new Repo();
            comboBox3.DataSource =
             rm.users.ToList().
             Select(c => c.UserName).ToList();

            comboBox2.DataSource =
             rm.clients.ToList().
             Select(c => c.Name).ToList();

            comboBox1.DataSource =
             rm.rooms.ToList().
             Select(c => c.name).ToList();




        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
