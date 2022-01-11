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
            await _placesService.CreatePlace(new Abstractions.Models.CreatePlaceModel 
            {
                IdRates=textBox1.Text,
                PersonId= textBox2.Text
            }); 
        }
    }
}
