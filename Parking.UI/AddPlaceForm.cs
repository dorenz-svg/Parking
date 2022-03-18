using Parking.Abstractions.Services;
using System;
using System.Windows.Forms;

namespace Parking.UI
{
    public partial class AddPlaceForm : Form
    {
        private readonly IPlacesService _placesService;
        public AddPlaceForm(IPlacesService placesService)
        {
            _placesService = placesService;
            InitializeComponent();
        }

        private void AddPlaceForm_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("неверно введены данные");
                return;
            }

            await _placesService.CreatePlace(new Abstractions.Models.CreatePlaceModel 
            {
                IdRates=long.Parse(textBox1.Text),
                PersonId= long.Parse(textBox2.Text)
            }); 
        }
    }
}
