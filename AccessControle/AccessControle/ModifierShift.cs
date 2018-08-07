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
    
    public partial class ModifierShift: MetroFramework.Forms.MetroForm
    {
        public int shiftID;
        DbEntities entity = new DbEntities();


        public ModifierShift(int shiftID)
        {
            this.shiftID = shiftID;
            SHIFT Shift = entity.SHIFT.FirstOrDefault(shift => shift.CODE == shiftID);
            
            InitializeComponent();
            comboBox1.DataSource = entity.SOCIETE.ToList();
            comboBox1.DisplayMember = "NOM_S";
            comboBox1.ValueMember = "CODE_S";
           // comboBox1.SelectedValue = Shift.CODE_S;
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
               TextboxLibelle.Text=Shift.LIBELLE;
               dateTimePicker1.Value=(DateTime)Shift.DATEDDEBUT;
               dateTimePicker2.Value=(DateTime)Shift.DATEDFIN;
               dateTimePicker3.Value=(DateTime)Shift.HEUREDEBUT;
               dateTimePicker4.Value=(DateTime)Shift.HEUREFIN;
               dateTimePicker5.Value=(DateTime)Shift.HEUREDEBUTPAUSE;
               dateTimePicker6.Value=(DateTime)Shift.HEUREFINPAUSE;
               
            if(Shift.WEEKEND==1)
                checkBoxWeekend.Checked=true;
            else 
                checkBoxWeekend.Checked=false;
             if(Shift.VACANCE==1)
                checkBoxVacances.Checked=true;
            else 
                checkBoxVacances.Checked=false;
            if(Shift.JOURSFERIES==1)
                checkBoxJoursferies.Checked=true;
            else 
                checkBoxJoursferies.Checked=false;


                 



        }

        private void button1_Click(object sender, EventArgs e)
        {
            SOCIETE societe = entity.SOCIETE.FirstOrDefault(S => S.CODE_S.Equals((decimal)comboBox1.SelectedValue));
            //     var ID = entity.SHIFT.First().CODE;

            SHIFT Shift = entity.SHIFT.FirstOrDefault(shift => shift.CODE == shiftID);

           
                //    CODE = ID + 1,
               // CODE = 5,
                Shift.LIBELLE = TextboxLibelle.Text;
                Shift.DATEDDEBUT = dateTimePicker1.Value;
                Shift.DATEDFIN = dateTimePicker2.Value;
                Shift.HEUREDEBUT = dateTimePicker3.Value;
                Shift.HEUREFIN = dateTimePicker4.Value;
                Shift.HEUREDEBUTPAUSE = dateTimePicker5.Value;
                Shift.HEUREFINPAUSE = dateTimePicker6.Value;
                Shift.WEEKEND= checkBoxWeekend.Checked ? 1 : 0;
                Shift.VACANCE = checkBoxVacances.Checked?1:0;
                Shift.JOURSFERIES= checkBoxJoursferies.Checked ? 1 : 0;
                
               Shift.CODE_S = societe.CODE_S;
              Shift.SOCIETE = societe;

       

            
            entity.SaveChanges();
            this.Close();
            MessageFormtOK MessageFormtOK = new MessageFormtOK("modification avec success...");
            var result= MessageFormtOK.ShowDialog();
           
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
