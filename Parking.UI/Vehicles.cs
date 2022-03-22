using Parking.Abstractions.Services;
using System;
using System.Collections;
using System.Windows.Forms;

namespace Parking.UI
{
    public partial class Vehicles : Form
    {
        private readonly IVehicleService _vehicleService;
        public Vehicles(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("неверно введены данные");
                return;
            }

            var result = await _vehicleService.GetVehicle(textBox1.Text);

            if (result is null)
            {
                MessageBox.Show("Vehicle Not Found");
            }
            else
            {
                BindingSource bindingSource = new BindingSource();
                bindingSource.Add(result);
                dataGridView1.DataSource = bindingSource;
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("неверно введены данные");
                return;
            }

            await _vehicleService.DeleteVehicle(textBox1.Text);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("неверно введены данные");
                return;
            }

            await _vehicleService.AddVehicleToPerson(textBox2.Text, long.Parse(textBox3.Text));
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await _vehicleService.GetVehicles();
        }
    }
}
