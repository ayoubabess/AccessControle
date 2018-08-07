using Gestion_pointage_tourniquet.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_pointage_tourniquet
{
    public partial class ModifierFiliale : MetroFramework.Forms.MetroForm
    {
        DbEntities entity = new DbEntities();
        decimal fillaleID;
        public ModifierFiliale(decimal fillaleID)
        {
            InitializeComponent();
            this.fillaleID = fillaleID;
            SOCIETE SOCIETE = entity.SOCIETE.FirstOrDefault(societe => societe.CODE_S == fillaleID);
            tb2.Text = SOCIETE.NOM_S;
            tb3.Text = SOCIETE.ADR_S;
            tb4.Text = SOCIETE.VILLE;
            tb5.Text = SOCIETE.CODE_POSTAL.ToString(); ;
            tb6.Text = SOCIETE.TEL_S;
            tb7.Text = SOCIETE.PAY;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SOCIETE SOCIETE = entity.SOCIETE.FirstOrDefault(societe => societe.CODE_S == fillaleID);


                SOCIETE.NOM_S = tb2.Text;
                    SOCIETE.ADR_S = tb3.Text;
                    SOCIETE.VILLE=tb4.Text;
                    SOCIETE.CODE_POSTAL= Convert.ToDecimal(tb5.Text);
                    SOCIETE.TEL_S=tb6.Text;
                    SOCIETE.PAY=tb7.Text;



              

                
               
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
