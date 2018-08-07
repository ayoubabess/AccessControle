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
    public partial class AjoutFiliale : MetroFramework.Forms.MetroForm
    {
        DbEntities entity = new DbEntities();
        public AjoutFiliale()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SOCIETE SOCIETE = new SOCIETE
                {
                   
                    NOM_S = tb2.Text,
                    ADR_S = tb3.Text,
                    VILLE=tb4.Text,
                    CODE_POSTAL= Convert.ToDecimal(tb5.Text),
                    TEL_S=tb6.Text,
                    PAY=tb7.Text,



                };

                
                entity.SOCIETE.Add(SOCIETE);
                entity.SaveChanges();

     
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
