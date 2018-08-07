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
    public partial class MachineControl : MetroFramework.Controls.MetroUserControl
    {
        public MachineControl()
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
            GridViewMachine.DataSource = entity.MACHINE.Select(recordset => new
            {
                Id_Machine = recordset.ID_M,
                Libellé = recordset.LIB,
                Type_M = recordset.TYPE_M,
                Ip = recordset.ID_M,
                Port = recordset.PORT,
                PWD = recordset.PWD,

                //PHOTO = recordset.PHOTO,

                Societe = recordset.SOCIETE.NOM_S

            }).ToList();

            // LoadPicture.Hide();




            // LoadPicture.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {

                var list =
              entity.MACHINE.Where(p => p.TYPE_M.ToLower().Contains(textBox1.Text.ToLower())).Select(recordset => new
              {
                  Id_Machine = recordset.ID_M,
                  Libellé = recordset.LIB,
                  Type_M = recordset.TYPE_M,
                  Ip = recordset.ID_M,
                  Port = recordset.PORT,
                  PWD = recordset.PWD,

                  //PHOTO = recordset.PHOTO,

                  Societe = recordset.SOCIETE.NOM_S

              }).ToList();
                if (list != null)
                    GridViewMachine.DataSource = list;


            }
            else
                RemplirGrid();
        
    
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {

                var list =
              entity.MACHINE.Where(p => p.SOCIETE.NOM_S.ToLower().Contains(textBox1.Text.ToLower())).Select(recordset => new
              {
                  Id_Machine = recordset.ID_M,
                  Libellé = recordset.LIB,
                  Type_M = recordset.TYPE_M,
                  Ip = recordset.ID_M,
                  Port = recordset.PORT,
                  PWD = recordset.PWD,

                  //PHOTO = recordset.PHOTO,

                  Societe = recordset.SOCIETE.NOM_S

              }).ToList();
                if (list != null)
                    GridViewMachine.DataSource = list;


            }
            else
                RemplirGrid();
        }


        private void GridViewPersonnel_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Form form3 = new Form3(GridViewMachine.Rows[e.RowIndex].Cells[0].Value.ToString());
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
            try
            {
                DialogResult res;
                res = MessageBox.Show("Voulez vous supprimer cet enregisteremet", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    PersonnelMat = GridViewMachine.SelectedRows[0].Cells[0].Value.ToString();
                    entity.PERSONNEL.Remove(entity.PERSONNEL.Single(p => p.MAT == PersonnelMat));
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
                var machineID = GridViewMachine.SelectedRows[0].Cells[0].Value.ToString();
                modifierMachine modifierMachine = new modifierMachine(Convert.ToDecimal(machineID));
                var result = modifierMachine.ShowDialog();
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
                ajoutMachine ajoutMachine = new ajoutMachine();
                var result = ajoutMachine.ShowDialog();
                RemplirGrid();
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {

                var list =
              entity.MACHINE.Where(p => p.LIB.ToLower().Contains(textBox1.Text.ToLower())).Select(recordset => new
              {
                  Id_Machine = recordset.ID_M,
                  Libellé = recordset.LIB,
                  Type_M = recordset.TYPE_M,
                  Ip = recordset.ID_M,
                  Port = recordset.PORT,
                  PWD = recordset.PWD,

                  //PHOTO = recordset.PHOTO,

                  Societe = recordset.SOCIETE.NOM_S

              }).ToList();
                if (list != null)
                    GridViewMachine.DataSource = list;


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

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {

                var list =
              entity.MACHINE.Where(p => p.TYPE_M.ToLower().Contains(textBox2.Text.ToLower())).Select(recordset => new
              {
                  Id_Machine = recordset.ID_M,
                  Libellé = recordset.LIB,
                  Type_M = recordset.TYPE_M,
                  Ip = recordset.ID_M,
                  Port = recordset.PORT,
                  PWD = recordset.PWD,

                  //PHOTO = recordset.PHOTO,

                  Societe = recordset.SOCIETE.NOM_S

              }).ToList();
                if (list != null)
                    GridViewMachine.DataSource = list;


            }
            else
                RemplirGrid();

        }

      
    }
}
