using Parking.Abstractions.Services;
using System;
using System.Windows.Forms;

namespace Parking.UI
{
    public partial class Payments : Form
    {
        private readonly IPaymentService _paymentService;
        public Payments(IPaymentService paymentService)
        {
            _paymentService = paymentService;
            InitializeComponent();
        }

        private void Payments_Load(object sender, EventArgs e)
        {
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=await _paymentService.GetPayments(textBox1.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await _paymentService.DeletePayment(textBox1.Text);
        }
    }
}
