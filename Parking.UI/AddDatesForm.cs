using Parking.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking.UI
{
    public partial class AddDatesForm : Form
    {
        private readonly IPlacesService _placesService;
        public AddDatesForm(IPlacesService placesService)
        {
            _placesService = placesService;
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("неверно введены данные");
                return;
            }

            await _placesService.AddDates(long.Parse(textBox1.Text), dateTimePicker1.Value, dateTimePicker2.Value);
        }
    }
}
