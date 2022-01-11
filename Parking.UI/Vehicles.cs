﻿using Parking.Abstractions.Services;
using System;
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
            var result = await _vehicleService.GetVehicle(textBox1.Text);

            if (result is null)
            {
                MessageBox.Show("Vehicle Not Found");
            }
            else
            {
                textBox2.Text = result.CarNumber;
                textBox3.Text = result.NameUser;
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await _vehicleService.DeleteVehicle(textBox1.Text);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await _vehicleService.AddVehicleToPerson(textBox2.Text,textBox3.Text);
        }
    }
}