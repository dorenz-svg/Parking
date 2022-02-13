using Autofac;
using Parking.Abstractions.Services;
using System;
using System.Windows.Forms;

namespace Parking.UI
{
    public partial class Main : Form
    {
        public Main(IPersonService personService)
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<Payments>();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<Persons>();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<Places>();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<Rates>();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<Vehicles>();
            form.Show();
        }
    }
}
