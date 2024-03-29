﻿using Parking.Abstractions.Services;
using System;
using System.Windows.Forms;

namespace Parking.UI
{
    public partial class Rates : Form
    {
        private readonly IRatesService _ratesService;
        public Rates(IRatesService ratesService)
        {
            _ratesService = ratesService;
            InitializeComponent();
        }

        private void Rates_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await _ratesService.GetRates();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("неверно введены данные");
                return;
            }

            await _ratesService.CreateRate(new Abstractions.Models.CreateRateModel 
            {
                CostPerHour=decimal.Parse(textBox1.Text),
                Discount=float.Parse(textBox2.Text)
            });
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("неверно введены данные");
                return;
            }

            await _ratesService.DeleteRate(long.Parse(textBox3.Text));
        }
    }
}
