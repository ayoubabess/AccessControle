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
    public partial class ShiftControl : MetroFramework.Controls.MetroUserControl
    {
        DbEntities entity = new DbEntities();
        private decimal shiftCODE;

        public ShiftControl()
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
                // GridViewPersonnel.DataSource = 
                var list = entity.SHIFT.Select(recordset => new
                 {
                     CODE = recordset.CODE,
                     LIBELLE = recordset.LIBELLE,



                     DATEDDEBUT = recordset.DATEDDEBUT,
                     DATEDFIN = recordset.DATEDFIN,
                     HEUREDEBUT = recordset.HEUREDEBUT,
                     HEUREFIN = recordset.HEUREFIN,
                     HEUREDEBUTPAUSE = recordset.HEUREDEBUTPAUSE,
                     HEUREFINPAUSE = recordset.HEUREFINPAUSE,
                     WEEKEND = recordset.WEEKEND == 1 ? "oui" : "non",
                     VACANCE = recordset.VACANCE == 1 ? "oui" : "non",
                     JOURSFERIES = recordset.JOURSFERIES == 1 ? "oui" : "non",
                     Societe = recordset.SOCIETE.NOM_S

                 }).ToList();
                List<ShiftGrid> listGrid = new List<ShiftGrid>();
                foreach (var person in list)
                {
                    ShiftGrid Shiftgrid = new ShiftGrid();
                    Shiftgrid.CODE = person.CODE;
                    Shiftgrid.LIBELLE = person.LIBELLE;
                    Shiftgrid.DATEDDEBUT = person.DATEDDEBUT.Value.ToShortDateString();
                    Shiftgrid.DATEDFIN = person.DATEDFIN.Value.Date;
                    Shiftgrid.HEUREDEBUT = person.HEUREDEBUT.Value.ToShortTimeString();
                    Shiftgrid.HEUREFIN = person.HEUREFIN.Value.TimeOfDay;
                    Shiftgrid.HEUREDEBUTPAUSE = person.HEUREDEBUTPAUSE.Value.TimeOfDay;
                    Shiftgrid.HEUREFINPAUSE = person.HEUREFINPAUSE.Value.TimeOfDay;
                    Shiftgrid.WEEKEND = person.WEEKEND;
                    Shiftgrid.VACANCE = person.VACANCE;
                    Shiftgrid.JOURSFERIES = person.JOURSFERIES;
                    Shiftgrid.Societe = person.Societe;
                    listGrid.Add(Shiftgrid);

                }
                GridViewPersonnel.DataSource = listGrid;
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
                  entity.SHIFT.Where(p => p.LIBELLE.ToLower().Contains(textBox1.Text.ToLower())).Select(recordset => new
                  {
                      CODE = recordset.CODE,
                      LIBELLE = recordset.LIBELLE,



                      DATEDDEBUT = recordset.DATEDDEBUT,
                      DATEDFIN = recordset.DATEDFIN,
                      HEUREDEBUT = recordset.HEUREDEBUT,
                      HEUREFIN = recordset.HEUREFIN,
                      HEUREDEBUTPAUSE = recordset.HEUREDEBUTPAUSE,
                      HEUREFINPAUSE = recordset.HEUREFINPAUSE,
                      WEEKEND = recordset.WEEKEND == 1 ? "oui" : "non",
                      VACANCE = recordset.VACANCE == 1 ? "oui" : "non",
                      JOURSFERIES = recordset.JOURSFERIES == 1 ? "oui" : "non",
                      Societe = recordset.SOCIETE.NOM_S
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           try
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {

                    var list =
                  entity.SHIFT.Where(p => p.SOCIETE.NOM_S.ToLower().Contains(textBox2.Text.ToLower())).Select(recordset => new
                  {
                      CODE = recordset.CODE,
                      LIBELLE = recordset.LIBELLE,



                      DATEDDEBUT = recordset.DATEDDEBUT,
                      DATEDFIN = recordset.DATEDFIN,
                      HEUREDEBUT = recordset.HEUREDEBUT,
                      HEUREFIN = recordset.HEUREFIN,
                      HEUREDEBUTPAUSE = recordset.HEUREDEBUTPAUSE,
                      HEUREFINPAUSE = recordset.HEUREFINPAUSE,
                      WEEKEND = recordset.WEEKEND == 1 ? "oui" : "non",
                      VACANCE = recordset.VACANCE == 1 ? "oui" : "non",
                      JOURSFERIES = recordset.JOURSFERIES == 1 ? "oui" : "non",
                      Societe = recordset.SOCIETE.NOM_S
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

           }

        private void GridViewPersonnel_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Form form3 = new Form3(GridViewPersonnel.Rows[e.RowIndex].Cells[0].Value.ToString());
           var dialogresult= form3.ShowDialog();
            //if(dialogresult==DialogResult.Yes || dialogresult==DialogResult.OK)
            RemplirGrid();
     


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked==true)
                {

                    var list =
                  entity.SHIFT.Where(p => p.VACANCE==1).Select(recordset => new
                  {
                      CODE = recordset.CODE,
                      LIBELLE = recordset.LIBELLE,



                      DATEDDEBUT = recordset.DATEDDEBUT,
                      DATEDFIN = recordset.DATEDFIN,
                      HEUREDEBUT = recordset.HEUREDEBUT,
                      HEUREFIN = recordset.HEUREFIN,
                      HEUREDEBUTPAUSE = recordset.HEUREDEBUTPAUSE,
                      HEUREFINPAUSE = recordset.HEUREFINPAUSE,
                      WEEKEND = recordset.WEEKEND == 1 ? "oui" : "non",
                      VACANCE = recordset.VACANCE == 1 ? "oui" : "non",
                      JOURSFERIES = recordset.JOURSFERIES == 1 ? "oui" : "non",
                      Societe = recordset.SOCIETE.NOM_S
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
                if (checkBox2.Checked == true)
                {

                    var list =
                  entity.SHIFT.Where(p => p.WEEKEND==1).Select(recordset => new
                  {
                      CODE = recordset.CODE,
                      LIBELLE = recordset.LIBELLE,



                      DATEDDEBUT = recordset.DATEDDEBUT,
                      DATEDFIN = recordset.DATEDFIN,
                      HEUREDEBUT = recordset.HEUREDEBUT,
                      HEUREFIN = recordset.HEUREFIN,
                      HEUREDEBUTPAUSE = recordset.HEUREDEBUTPAUSE,
                      HEUREFINPAUSE = recordset.HEUREFINPAUSE,
                      WEEKEND = recordset.WEEKEND == 1 ? "oui" : "non",
                      VACANCE = recordset.VACANCE == 1 ? "oui" : "non",
                      JOURSFERIES = recordset.JOURSFERIES == 1 ? "oui" : "non",
                      Societe = recordset.SOCIETE.NOM_S
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

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox3.Checked == true)
                {

                    var list =
                  entity.SHIFT.Where(p => p.JOURSFERIES== 1).Select(recordset => new
                  {
                      CODE = recordset.CODE,
                      LIBELLE = recordset.LIBELLE,



                      DATEDDEBUT = recordset.DATEDDEBUT,
                      DATEDFIN = recordset.DATEDFIN,
                      HEUREDEBUT = recordset.HEUREDEBUT,
                      HEUREFIN = recordset.HEUREFIN,
                      HEUREDEBUTPAUSE = recordset.HEUREDEBUTPAUSE,
                      HEUREFINPAUSE = recordset.HEUREFINPAUSE,
                      WEEKEND = recordset.WEEKEND == 1 ? "oui" : "non",
                      VACANCE = recordset.VACANCE == 1 ? "oui" : "non",
                      JOURSFERIES = recordset.JOURSFERIES == 1 ? "oui" : "non",
                      Societe = recordset.SOCIETE.NOM_S
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
    }
    public class ShiftGrid
    {
        public ShiftGrid()
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
