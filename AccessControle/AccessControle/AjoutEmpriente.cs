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
    
    public partial class AjoutEmpriente : MetroFramework.Forms.MetroForm
    {
        string outPut = "";
        private int EmprientID;
        private string MatriculeId;
        private int Etape;
        DbEntities entity = new DbEntities();
        
        public AjoutEmpriente(string matriculeId,int emprientID )
        {
            this.EmprientID = emprientID;
            MatriculeId = matriculeId;
            Etape = 0;
            InitializeComponent();
            try
            {
                tb1.Text = MatriculeId;

              

                if (!PortFormt.port.IsOpen)
                    PortFormt.port.Open();
                //    myport.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 20;
                progressBar1.Style = ProgressBarStyle.Marquee;
                //progressBar1.Hide();
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Etape)
                {
                    case 0:
                        PortFormt.port.Write("1");FirstFingerPrintScan();
                        break;
                    case 1:
                        SecondFingerPrintScan();
                             break;
                    case 2:
                        FingerPrintMatching();
                        break;
                    case 3:
                        Close();//myport.Close();
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
           
        }

        private void FingerPrintMatching()
        {
            button1.Enabled = false;
            while (!outPut.Contains("Stored!"))
            {

                  outPut = PortFormt.port.ReadExisting();
             //   richTextBox1.Text += outPut;


            }
            
        //    myport.Write("1");//contenuer
            button1.Enabled = true;
            panel3.BackColor = Color.Green;
            Etape = 3;
            button1.Text = "Terminer";
        }

        private void SecondFingerPrintScan()
        {
            button1.Enabled = false;
            progressBar1.Show();
            while (!outPut.Contains("Creating"))
            {

                 outPut = PortFormt.port.ReadExisting();
                 if (outPut.Length == 100)
                     outPut = "";
            //    richTextBox1.Text += outPut;


            }
           
          //  myport.Write("1");//contenuer


            progressBar1.Hide();
            panel2.BackColor = Color.Green;
            Etape = 2;
            button1.Enabled = true;

        }

        private void FirstFingerPrintScan()
        {
            button1.Enabled = false;
            button1.Text = "Etape suivant";
            //string outPut = "";
            
            
           
            while (!outPut.Contains("start"))//"Please type in the ID # (from 1 to 127) you want to save this finger as..."
            {
                 outPut = PortFormt.port.ReadLine();

                //richTextBox1.Text += outPut;

                 if (outPut.Length == 100)
                     outPut = "";

            }
           
            Console.Write("start");
          //  myport.Write("1");//contenuer

            PortFormt.port.Write(EmprientID.ToString());
            
            progressBar1.Show();
            outPut = "";
                 while (!outPut.Contains("Remove"))//"Remove finger"
            {
                outPut += PortFormt.port.ReadLine();
                if (outPut.Length == 100)
                    outPut = "";
               // richTextBox1.Text += outPut;



            }
               
            Console.Write("remove");
            //myport.Write("1");//contenuer
            progressBar1.Hide();
            panel1.BackColor = Color.Green;
            Etape = 1;
            button1.Enabled = true;
        }
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Boolean progressBar = true;
            // Show all the incoming data in the port's buffer
          outPut += PortFormt.port.ReadLine();
           
            // Invoke(new Action(() => richTextBox1.Text += outPut));
            //));



         //   Console.WriteLine(outPut);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
           // myport.Close();
        }
    }
}
