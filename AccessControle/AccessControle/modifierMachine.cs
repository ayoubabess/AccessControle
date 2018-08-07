using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion_pointage_tourniquet.BaseClass;

namespace Gestion_pointage_tourniquet
{
    public partial class modifierMachine : MetroFramework.Forms.MetroForm
    {
        decimal machineID;
        DbEntities entity = new DbEntities();
        public modifierMachine(decimal machineID)
         {
            this.machineID = machineID;
            MACHINE Machine = entity.MACHINE.FirstOrDefault(machine =>machine.ID_M  == machineID);
            
             
              
           // ID_LECTEUR = 1;
            //SOCIETE = societe;
                InitializeComponent();
            cb1.Text = Machine.ID_M.ToString();
            cb2.SelectedItem = Machine.TYPE_M;

            tb1.Text = Machine.LIB;
            tb2.Text = Machine.IP;
            tb3.Text = Machine.PORT.ToString();
            tb4.Text = Machine.PWD;
            comboboxSociete.DataSource = entity.SOCIETE.ToList();
                comboboxSociete.DisplayMember = "NOM_S";
                comboboxSociete.ValueMember = "CODE_S";
                comboboxSociete.SelectedValue = Machine.CODE_S;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            SOCIETE societe = entity.SOCIETE.FirstOrDefault(S => S.CODE_S.Equals((decimal)comboboxSociete.SelectedValue));
            MACHINE Machine = entity.MACHINE.FirstOrDefault(machine =>machine.ID_M  == machineID);

               
                Machine.TYPE_M = cb2.Text;
                Machine.CODE_S = societe.CODE_S;
                Machine.LIB = tb1.Text;
                Machine.IP = tb2.Text;
                Machine.PORT = Convert.ToDecimal(tb3.Text);
                Machine.PWD = tb4.Text;
                Machine.ID_LECTEUR = 1;
               // Machine.SOCIETE = societe;






                entity.SaveChanges();


                MessageFormtOK MessageFormtOK = new MessageFormtOK("Modification avec success...");
                var result = MessageFormtOK.ShowDialog();

                Close();
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();

            }
          
        }
    }
}
