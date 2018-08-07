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
    
    public partial class MessageFormError: MetroFramework.Forms.MetroForm
    {

      


        public MessageFormError(String message)
        {
            
            InitializeComponent();

            richTextBox1.Text = message;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

       
    }
}
