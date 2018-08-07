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
    public partial class UserControl1 : MetroFramework.Controls.MetroUserControl
    {
        DbEntities entity = new DbEntities();
        public UserControl1()
        { 
            InitializeComponent();
            RemplirGrid();

            //    GridViewPersonnel.DataSource =
            //(from recordset in entity.PERSONNEL

            // select new
            // {
            //     matricule = recordset.MAT,
            //     nom = recordset.NOM,
            //     prenom = recordset.PRENOM,
            //     TEL = recordset.TEL,
            //     ADR_P = recordset.ADR_P,
            //     VILLE_P = recordset.VILLE_P,
            //     POSTE = recordset.POSTE,
            //     DATE_EMB = recordset.DATE_EMB,
            //     SALAIRE = recordset.SALAIRE,
            //     PHOTO = recordset.PHOTO,

            //    Societe= recordset.SOCIETE.NOM_S

            // }).ToList();


        }






        public string PersonnelMat { get; private set; }
        public List<PERSONNEL> list { get; private set; }

        //ObservableCollection<PERSONNEL> personnels ; 
        public  void RemplirGrid()
        {
            //  LoadPicture.Show();
            try
            {
                GridViewPersonnel.DataSource = entity.PERSONNEL.Select(recordset => new
                {
                    matricule = recordset.MAT,
                    nom = recordset.NOM,
                    prenom = recordset.PRENOM,
                    TEL = recordset.TEL,
                    ADR_P = recordset.ADR_P,
                    VILLE_P = recordset.VILLE_P,
                    POSTE = recordset.POSTE,
                    DATE_EMB = recordset.DATE_EMB,
                    SALAIRE = recordset.SALAIRE,
                    Societe = recordset.SOCIETE.NOM_S,
                    SHIFT = recordset.SHIFT.LIBELLE

                    //PHOTO = recordset.PHOTO,



                }).ToList();

                // LoadPicture.Hide();
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
        }
      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {

                    var list =
                  entity.PERSONNEL.Where(p => p.MAT.ToLower().Contains(textBox1.Text.ToLower())).Select(recordset => new
                  {
                      matricule = recordset.MAT,
                      nom = recordset.NOM,
                      prenom = recordset.PRENOM,
                      TEL = recordset.TEL,
                      ADR_P = recordset.ADR_P,
                      VILLE_P = recordset.VILLE_P,
                      POSTE = recordset.POSTE,
                      DATE_EMB = recordset.DATE_EMB,
                      SALAIRE = recordset.SALAIRE,
                      //  PHOTO = recordset.PHOTO,

                      Societe = recordset.SOCIETE.NOM_S,
                      SHIFT = recordset.SHIFT.LIBELLE

                  }).ToList();
                    if (list != null)
                        GridViewPersonnel.DataSource = list;


                }
                else
                    RemplirGrid();
                //      var dataset2 =
                //(from recordset in entities.processlists
                // where recordset.ProcessName == processname
                // select new
                // {
                //     serverName = recordset.ServerName,
                //     processId = recordset.ProcessID,
                //     username = recordset.Username
                // }).ToList();
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {


                    var list =
                         entity.PERSONNEL.Where(p => p.NOM.ToLower().Contains(textBox2.Text.ToLower())).Select(recordset => new
                         {
                             matricule = recordset.MAT,
                             nom = recordset.NOM,
                             prenom = recordset.PRENOM,
                             TEL = recordset.TEL,
                             ADR_P = recordset.ADR_P,
                             VILLE_P = recordset.VILLE_P,
                             POSTE = recordset.POSTE,
                             DATE_EMB = recordset.DATE_EMB,
                             SALAIRE = recordset.SALAIRE,
                             // PHOTO = recordset.PHOTO,

                             Societe = recordset.SOCIETE.NOM_S,
                             SHIFT = recordset.SHIFT.LIBELLE

                         }).ToList();
                    if (list != null)
                        GridViewPersonnel.DataSource = list;
                }
                else
                    RemplirGrid();
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrWhiteSpace(textBox3.Text))
                {




                    var list =
                        entity.PERSONNEL.Where(p => p.PRENOM.ToLower().Contains(textBox3.Text.ToLower())).Select(recordset => new
                        {
                            matricule = recordset.MAT,
                            nom = recordset.NOM,
                            prenom = recordset.PRENOM,
                            TEL = recordset.TEL,
                            ADR_P = recordset.ADR_P,
                            VILLE_P = recordset.VILLE_P,
                            POSTE = recordset.POSTE,
                            DATE_EMB = recordset.DATE_EMB,
                            SALAIRE = recordset.SALAIRE,
                            //     PHOTO = recordset.PHOTO,

                            Societe = recordset.SOCIETE.NOM_S,
                            SHIFT = recordset.SHIFT.LIBELLE

                        }).ToList();
                    if (list != null)
                        GridViewPersonnel.DataSource = list;
                }
                else
                    RemplirGrid();
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
        }

        private void GridViewPersonnel_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Form form3 = new Form3(GridViewPersonnel.Rows[e.RowIndex].Cells[0].Value.ToString());
                var dialogresult = form3.ShowDialog();
                //if(dialogresult==DialogResult.Yes || dialogresult==DialogResult.OK)
                RemplirGrid();
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }


        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            RemplirGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res;
                res = MessageBox.Show("Voulez vous supprimer cet enregisteremet", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    PersonnelMat = GridViewPersonnel.SelectedRows[0].Cells[0].Value.ToString();
                    PERSONNEL personnel = entity.PERSONNEL.Single(p => p.MAT == PersonnelMat);

                    //  personnel.SOCIETE.;
                    entity.SaveChanges();
                    entity.PERSONNEL.Remove(personnel);
                    entity.SaveChanges();


                    RemplirGrid();

                }
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                PersonnelMat = GridViewPersonnel.SelectedRows[0].Cells[0].Value.ToString();
                Form form3 = new Form3(PersonnelMat);
                var dialogresult = form3.ShowDialog();
                //if(dialogresult==DialogResult.Yes || dialogresult==DialogResult.OK)
                RemplirGrid();
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ajoutEmployeForm frm = new ajoutEmployeForm();
                var dialogresult = frm.ShowDialog();
                RemplirGrid();
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
            
        }
    }
}
