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
    public partial class Form1 : Form
    {
        private readonly IPersonService _personService;
        public Form1(IPersonService personService)
        {
            _personService = personService;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _personService.GetPerson("123");
        }
    }
}
