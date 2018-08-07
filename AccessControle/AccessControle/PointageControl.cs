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
using System.Data.Entity;

namespace Gestion_pointage_tourniquet
{
    public partial class PointageControl : MetroFramework.Controls.MetroUserControl
    {
        DbEntities entity = new DbEntities();
        private decimal shiftCODE;

        public PointageControl()
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
        private BindingList<POINTAGE> bindingList=new BindingList<POINTAGE>();

        //ObservableCollection<PERSONNEL> personnels ; 
        public  void RemplirGrid()
        {
            //  LoadPicture.Show();

            // GridViewPersonnel.DataSource = 
        
                //datedebut = recordset.DATEDDEBUT.Value.ToShortDateString(),
                //dateFin = recordset.DATEDFIN.Value.ToShortDateString(),
                //heuredebut = recordset.HEUREDEBUT.Value.ToShortTimeString(),
                //heureFin = recordset.HEUREFIN.Value.ToShortTimeString(),
                //Heuredebutpause=  recordset.HEUREDEBUTPAUSE.Value.ToShortTimeString(),
                //heurefinpause = recordset.HEUREFINPAUSE.Value.ToShortTimeString(),




           //entity.POINTAGE.Load();

           //bindingList = new BindingList<POINTAGE>(entity.POINTAGE.Local.ToBindingList());
             GridViewPersonnel.DataSource=entity.POINTAGE.Select(recordset => new
            {Date=recordset.DATE_P,
                sens= recordset.SENS,
                Nom_Personnel=recordset.PERSONNEL.NOM,
                recordset.MACHINE.SOCIETE.NOM_S,
               
               Machine= recordset.ID_M
               
            }).ToList();
        }
      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {

                    var list =
                  entity.POINTAGE.Where(p => p.PERSONNEL.NOM.Contains(textBox1.Text.ToLower())).Select(recordset => new
                {
                    Date = recordset.DATE_P,
                    sens = recordset.SENS,
                    Nom_Personnel = recordset.PERSONNEL.NOM,
                    recordset.MACHINE.SOCIETE.NOM_S,

                    Machine = recordset.ID_M

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

        

        private void GridViewPersonnel_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Form form3 = new Form3(GridViewPersonnel.Rows[e.RowIndex].Cells[0].Value.ToString());
           var dialogresult= form3.ShowDialog();
            //if(dialogresult==DialogResult.Yes || dialogresult==DialogResult.OK)
            RemplirGrid();
     


        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            RemplirGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Voulez vous supprimer cet enregisteremet", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                shiftCODE = (decimal)GridViewPersonnel.SelectedRows[0].Cells[0].Value;
               
                    entity.SHIFT.Remove(entity.SHIFT.FirstOrDefault(shift => shift.CODE == shift.CODE));
                    entity.SaveChanges();
                
               
                RemplirGrid();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersonnelMat = GridViewPersonnel.SelectedRows[0].Cells[0].Value.ToString();
            int idshift = Convert.ToInt16(PersonnelMat);
            ModifierShift ShiftForm= new ModifierShift(idshift);
            var dialogresult = ShiftForm.ShowDialog();
            //if(dialogresult==DialogResult.Yes || dialogresult==DialogResult.OK)
            RemplirGrid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
           
            AjoutShift ajoutshift = new AjoutShift();
            var result = ajoutshift.ShowDialog();
            RemplirGrid();
        }

        private void GridViewPersonnel_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in GridViewPersonnel.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                var x = Myrow.Cells[1].Value;
                if (Myrow.Cells[1].Value.Equals("Entrée"))// Or your condition 
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                DateTime date = dateTimePicker1.Value;
                    var list =
                  entity.POINTAGE.Where(p => p.DATE_P<=date).Select(recordset => new
                  {
                      Date = recordset.DATE_P,
                      sens = recordset.SENS,
                      Nom_Personnel = recordset.PERSONNEL.NOM,
                      recordset.MACHINE.SOCIETE.NOM_S,

                      Machine = recordset.ID_M

                  }).ToList();
                    if (list != null)
                        GridViewPersonnel.DataSource = list;


               
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (checkBox2.Checked == false)
                {
                    var list =
                  entity.POINTAGE.Where(p => p.SENS == "Entrée").Select(recordset => new
                  {
                      Date = recordset.DATE_P,
                      sens = recordset.SENS,
                      Nom_Personnel = recordset.PERSONNEL.NOM,
                      recordset.MACHINE.SOCIETE.NOM_S,

                      Machine = recordset.ID_M

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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == false)
                {
                    var list =
                        entity.POINTAGE.Where(p => p.SENS != "Entrée").Select(recordset => new
                        {
                            Date = recordset.DATE_P,
                            sens = recordset.SENS,
                            Nom_Personnel = recordset.PERSONNEL.NOM,
                            recordset.MACHINE.SOCIETE.NOM_S,

                            Machine = recordset.ID_M

                        }).ToList();
                    if (list != null)
                        GridViewPersonnel.DataSource = list;

                }
                else {
                    RemplirGrid();
                }

            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
        }
    }
    public class PointageGrid
    {
        public PointageGrid()
        { }
        public decimal CODE { get; set; }
        public string LIBELLE { get; set; }

        public string Societe { get; set; }
        //public decimal CODE_S { get; set; }
        public string VACANCE { get; set; }
        public string JOURSFERIES { get; set; }
        public string WEEKEND { get; set; }
        public string DATEDDEBUT { get; set; }
        public Nullable<System.DateTime> DATEDFIN { get; set; }
        public string HEUREDEBUT { get; set; }
        public Nullable<System.TimeSpan> HEUREFIN { get; set; }
        public Nullable<System.TimeSpan> HEUREDEBUTPAUSE { get; set; }
        public Nullable<System.TimeSpan> HEUREFINPAUSE { get; set; }
       
    }
}
