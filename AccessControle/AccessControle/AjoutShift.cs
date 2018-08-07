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
    
    public partial class AjoutShift: MetroFramework.Forms.MetroForm
    {

        DbEntities entity = new DbEntities();
      

        public AjoutShift( )
        {
            
            InitializeComponent();
            try
            {
                comboBox1.DataSource = entity.SOCIETE.ToList();
                comboBox1.DisplayMember = "NOM_S";
                comboBox1.ValueMember = "CODE_S";
                this.dateTimePicker3.CustomFormat = "hh:mm tt";
                this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dateTimePicker3.ShowUpDown = true;
                this.dateTimePicker4.CustomFormat = "hh:mm tt";
                this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dateTimePicker4.ShowUpDown = true;
                this.dateTimePicker5.CustomFormat = "hh:mm tt";
                this.dateTimePicker5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dateTimePicker5.ShowUpDown = true;
                this.dateTimePicker6.CustomFormat = "hh:mm tt";
                this.dateTimePicker6.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dateTimePicker6.ShowUpDown = true;


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
                SOCIETE societe = entity.SOCIETE.FirstOrDefault(S => S.CODE_S.Equals((decimal)comboBox1.SelectedValue));
                //     var ID = entity.SHIFT.First().CODE;



                SHIFT shift = new SHIFT
                {
                    //    CODE = ID + 1,
                    // CODE = 5,
                    LIBELLE = TextboxLibelle.Text,
                    DATEDDEBUT = dateTimePicker1.Value,
                    DATEDFIN = dateTimePicker2.Value,
                    HEUREDEBUT = dateTimePicker3.Value,
                    HEUREFIN = dateTimePicker4.Value,
                    HEUREDEBUTPAUSE = dateTimePicker5.Value,
                    HEUREFINPAUSE = dateTimePicker6.Value,
                    WEEKEND = checkBoxWeekend.Checked ? 1 : 0,
                    VACANCE = checkBoxVacances.Checked ? 1 : 0,
                    JOURSFERIES = checkBoxJoursferies.Checked ? 1 : 0,

                    CODE_S = societe.CODE_S,
                    SOCIETE = societe

                };

                entity.SHIFT.Add(shift);
                entity.SaveChanges();
                MessageFormtOK MessageFormtOK = new MessageFormtOK("ajout avec success");
                var result = MessageFormtOK.ShowDialog();


                this.Close();
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
