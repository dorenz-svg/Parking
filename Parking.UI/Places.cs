using Autofac;
using Parking.Abstractions.Services;
using System;
using System.Windows.Forms;

namespace Parking.UI
{
    public partial class Places : Form
    {
        private readonly IPlacesService _placesService;
        public Places(IPlacesService placesService)
        {
            _placesService = placesService;
            InitializeComponent();
        }

        private void Places_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await _placesService.GetPlaces();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("неверно введены данные");
                return;
            }

            var result = await _placesService.GetPlace(long.Parse(textBox1.Text));
            if (result is null)
            {
                MessageBox.Show("Place Not Found");
            }
            else
            {
                textBox2.Text = result.Id.ToString();
                textBox3.Text = result.PersonName;
                textBox4.Text = result.Cost;
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("неверно введены данные");
                return;
            }

            await _placesService.DeletePlace(long.Parse(textBox1.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<AddPlaceForm>();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<AddDatesForm>();
            form.Show();
        }
    }
}
