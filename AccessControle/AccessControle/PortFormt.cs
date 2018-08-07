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
   
    public partial class PortFormt: MetroFramework.Forms.MetroForm
    {



        public static SerialPort port;
        private static string outPut = "";
        public static bool StopBits = false;
        private static string idEmprient = "";
        private static string sens = "Entrée";
        public PortFormt(String message)
        {
            
            InitializeComponent();

          
      
        }
      public static void initialiser()
        {
            try
            {
                port = new SerialPort();
                port.BaudRate = 9600;
                port.PortName = "COM5";
                port.Open();
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);

            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
}
      private static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
      {
          try
          {

              outPut += port.ReadExisting();
          }   
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }

         

      }
         public static void matching()
        {
            try
            {

                initialiser();

                while (!StopBits)
                {
                    while (!outPut.Contains("Found ID "))
                    {
                        //Console.Write(".");
                    }
                    outPut = "";
                    while (idEmprient == "" || idEmprient == "\n")
                    {
                        idEmprient = port.ReadExisting();
                    }

                    // while(!outPut.Contains("operation terminé"))
                    Console.Write(idEmprient);
                    decimal id;

                    if (Decimal.TryParse(idEmprient, out id))
                    {
                        Console.WriteLine(id);
                        idEmprient = "";


                        DbEntities entity = new DbEntities();
                        MACHINE machine = entity.MACHINE.Where(m => m.ID_M == 21).FirstOrDefault();
                        PERSONNEL p = entity.PERSONNEL.FirstOrDefault(per => per.IDEMPRIENT == id);
                        DateTime Datenow = DateTime.Now;
                        DateTime Datedebut = (DateTime)p.SHIFT.DATEDDEBUT;
                        DateTime Datedefin = (DateTime)p.SHIFT.DATEDFIN;
                        DateTime Heuredebut = (DateTime)p.SHIFT.HEUREDEBUT;
                        DateTime Heuredefin = (DateTime)p.SHIFT.HEUREFIN;
                        //DateTime heuredebutpause = (DateTime)p.SHIFT.FirstOrDefault().HEUREDEBUT;
                        //DateTime heuredefinpause = (DateTime)p.SHIFT.FirstOrDefault().HEUREFIN;
                        if (Datedebut.CompareTo(Datenow) <= 0 && Datedefin.CompareTo(Datenow) >= 0 && Heuredebut.TimeOfDay.CompareTo(Datenow.TimeOfDay) <= 0 && Heuredefin.TimeOfDay.CompareTo(Datenow.TimeOfDay) >= 0)
                        {
                            var count = entity.POINTAGE.Where(point => point.MAT.Equals(p.MAT)).Count();
                            if (count % 2 == 0)
                                sens = "Entrée";
                            else
                                sens = "Sortie";
                            port.Write("1");
                            POINTAGE Pointage = new POINTAGE
                            {

                                MAT = p.MAT,
                                DATE_P = Datenow,
                                ID_M = machine.ID_M,
                                SENS = sens,
                                PERSONNEL = p,
                                MACHINE = machine
                            };
                            entity.POINTAGE.Add(Pointage);
                            entity.SaveChanges();

                            if (sens == "Entrée")
                            {
                                NotificationPointageForm MessageFormt = new NotificationPointageForm("Entrée enregitré pour : " + p.NOM + " " + p.PRENOM + " le " + Datenow.ToShortDateString() + " à " + Datenow.ToShortTimeString());
                                MessageFormt.ShowDialog();
                            }
                            else
                            {
                                NotificationPointageForm MessageFormt = new NotificationPointageForm("Sortie enregisté pour : " + p.NOM + " " + p.PRENOM + "le " + Datenow.ToShortDateString() + " à " + Datenow.ToShortTimeString());
                                MessageFormt.ShowDialog();
                            }

                        }
                        else
                        {
                            port.Write("2");
                            MessageFormError MessageForm = new MessageFormError("Access refusé pour : " + p.NOM + " " + p.PRENOM + "le " + Datenow.ToShortDateString() + " à " + Datenow.ToShortTimeString());

                            MessageForm.ShowDialog();
                        }
                    }
                    else
                    { port.Write("2"); Console.WriteLine("Unable to parse '{0}'.", idEmprient); }

                    //StopBits = true;
                }
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
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
