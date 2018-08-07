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
    public partial class ajoutMachine : MetroFramework.Forms.MetroForm
    {
        DbEntities entity = new DbEntities();
        public ajoutMachine()
        {
            InitializeComponent();
            try
            {
                comboboxSociete.DataSource = entity.SOCIETE.ToList();
                comboboxSociete.DisplayMember = "NOM_S";
                comboboxSociete.ValueMember = "CODE_S";
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            SOCIETE societe = entity.SOCIETE.FirstOrDefault(S => S.CODE_S.Equals((decimal)comboboxSociete.SelectedValue));
            MACHINE machine = new MACHINE
            {
              //  ID_M = Convert.ToDecimal(cb1.Text),
                TYPE_M = cb2.Text,
                CODE_S = societe.CODE_S,
                LIB = tb1.Text,
                IP = tb2.Text,
                PORT = Convert.ToDecimal(tb3.Text),
                PWD = tb4.Text,
                ID_LECTEUR = 1,
                SOCIETE= societe
                
            };


                entity.MACHINE.Add(machine);
                entity.SaveChanges();

                MessageBox.Show("ajout avec success...");
                MessageFormtOK MessageFormtOK = new MessageFormtOK("ajout avec success...");
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
