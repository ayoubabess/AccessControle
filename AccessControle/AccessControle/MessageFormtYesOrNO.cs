using Gestion_pointage_tourniquet.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_pointage_tourniquet
{
    
    public partial class MessageFormtYesOrNO: MetroFramework.Forms.MetroForm
    {




        public MessageFormtYesOrNO(String message)
        {
            
            InitializeComponent();

            richTextBox1.Text = message;
            button1.DialogResult = DialogResult.Yes;
            button2.DialogResult = DialogResult.Cancel;
            this.AcceptButton = button1;
            // Set the cancel button of the form to button2.
            this.CancelButton = button2;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

      

       
    }
}
