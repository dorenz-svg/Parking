using Parking.Abstractions.Services;
using System;
using System.Windows.Forms;

namespace Parking.UI
{
    public partial class Persons : Form
    {
        private readonly IPersonService _personService;
        public Persons(IPersonService personService)
        {
            _personService = personService;
            InitializeComponent();
        }

        private void Persons_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) )
            {
                MessageBox.Show("неверно введены данные");
                return;
            }

            var result = await _personService.GetPerson(textBox1.Text);
            if (result is null)
            {
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                MessageBox.Show("User Not Found");
            }
            else
            {
                textBox2.Text = result.Id.ToString();
                textBox3.Text = result.Name;
                textBox4.Text = result.SurName;
                textBox5.Text = result.Phone;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("неверно введены данные");
                return;
            }

            await _personService.CreatePerson(new Abstractions.Models.CreatePersonModel
            {
                Name = textBox3.Text,
                SurName = textBox4.Text,
                Phone = textBox5.Text
            });
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("неверно введены данные");
                return;
            }

            await _personService.DeletePerson(textBox1.Text);
        }
    }
}
