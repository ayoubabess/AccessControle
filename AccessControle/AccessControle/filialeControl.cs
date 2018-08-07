using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion_pointage_tourniquet.BaseClass;
using System.Diagnostics;

namespace Gestion_pointage_tourniquet
{
    public partial class filialesControl : MetroFramework.Controls.MetroUserControl
    {
        public filialesControl()
        {
            InitializeComponent();
            
            RemplirGrid();
        }
        DbEntities entity = new DbEntities();

        public string PersonnelMat { get; private set; }

        //ObservableCollection<PERSONNEL> personnels ; 
        public void RemplirGrid()
        {
            //  LoadPicture.Show();

            
                GridViewPersonnel.DataSource = entity.SOCIETE.Select(recordset => new
                {
                    IdSociete = recordset.CODE_S,
                    Nom= recordset.NOM_S,
                    Adresse= recordset.ADR_S,
                    Ville= recordset.VILLE,
                    Pay= recordset.PAY,
                    CODE_POSTAL= recordset.CODE_POSTAL,
      
                    Fillale= recordset.FILIALE 




    }).ToList();
           

            // LoadPicture.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
              

                GridViewPersonnel.DataSource = entity.SOCIETE.Where(p => p.VILLE.ToLower().Contains(textBox2.Text.ToLower())).Select(recordset => new
                {
                    IdSociete = recordset.CODE_S,
                    Nom = recordset.NOM_S,
                    Adresse = recordset.ADR_S,
                    Ville = recordset.VILLE,
                    Pay = recordset.PAY,
                    CODE_POSTAL = recordset.CODE_POSTAL,

                    Fillale = recordset.FILIALE




                }).ToList();
            }
            else
                RemplirGrid();
            
        }
       private void textBox3_TextChanged(object sender, EventArgs e)
        {
 
          if (!string.IsNullOrWhiteSpace(textBox3.Text))
            {
               
               GridViewPersonnel.DataSource = entity.SOCIETE.Where(p => p.PAY.ToLower().Contains(textBox3.Text.ToLower())).Select(recordset => new
               {
                   IdSociete = recordset.CODE_S,
                   Nom = recordset.NOM_S,
                   Adresse = recordset.ADR_S,
                   Ville = recordset.VILLE,
                   Pay = recordset.PAY,
                   CODE_POSTAL = recordset.CODE_POSTAL,

                   Fillale = recordset.FILIALE




               }).ToList();
            }
          else
              RemplirGrid();
         
        }
     

        private void GridViewPersonnel_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PersonnelMat = GridViewPersonnel.SelectedRows[0].Cells[0].Value.ToString();
            ModifierFiliale ModifierFiliale = new ModifierFiliale(Convert.ToDecimal(PersonnelMat));
            var dialogresult = ModifierFiliale.ShowDialog();
            //if(dialogresult==DialogResult.Yes || dialogresult==DialogResult.OK)
            RemplirGrid();
     


        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            MessageFormtYesOrNO MessageFormtYesOrNO = new MessageFormtYesOrNO("Voulez vous supprimer cet enregistrement");
            var result = MessageFormtYesOrNO.ShowDialog();
            if (result == DialogResult.Yes)
            {
                PersonnelMat = GridViewPersonnel.SelectedRows[0].Cells[0].Value.ToString();
                decimal societeId = Convert.ToDecimal(PersonnelMat);
                entity.SOCIETE.Remove(entity.SOCIETE.Single(p => p.CODE_S == societeId));
                entity.SaveChanges();
                RemplirGrid();
            }
           
       
        }
        private void button2_Click(object sender, EventArgs e)
        {
            PersonnelMat = GridViewPersonnel.SelectedRows[0].Cells[0].Value.ToString();
            
            //Form form3 = new Form3(PersonnelMat);
            //var dialogresult = form3.ShowDialog();
            ////if(dialogresult==DialogResult.Yes || dialogresult==DialogResult.OK)
            //RemplirGrid(GridViewPersonnel);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Form2 frm = new Form2();
            //var dialogresult= frm.ShowDialog();
            //RemplirGrid(GridViewPersonnel);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            AjoutFiliale AjoutFiliale = new AjoutFiliale();
            var DialogResult = AjoutFiliale.ShowDialog();
            RemplirGrid();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            PersonnelMat = GridViewPersonnel.SelectedRows[0].Cells[0].Value.ToString();
            ModifierFiliale ModifierFiliale = new ModifierFiliale(Convert.ToDecimal(PersonnelMat));
            var dialogresult = ModifierFiliale.ShowDialog();
            //if(dialogresult==DialogResult.Yes || dialogresult==DialogResult.OK)
            RemplirGrid();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {


                GridViewPersonnel.DataSource = entity.SOCIETE.Where(p => p.NOM_S.ToLower().Contains(textBox1.Text.ToLower())).Select(recordset => new
                {
                    IdSociete = recordset.CODE_S,
                    Nom = recordset.NOM_S,
                    Adresse = recordset.ADR_S,
                    Ville = recordset.VILLE,
                    Pay = recordset.PAY,
                    CODE_POSTAL = recordset.CODE_POSTAL,

                    Fillale = recordset.FILIALE




                }).ToList();
            }
            else
                RemplirGrid();
        }
    }
}
