using Gestion_pointage_tourniquet.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_pointage_tourniquet
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        DbEntities entity = new DbEntities();
        
        string PersonnelMat;
        byte[] imgdata;

        public Form3(string PersonnelMat)
        {
           
            this.PersonnelMat=  PersonnelMat;
            InitializeComponent();

            try
            {
                PERSONNEL p = entity.PERSONNEL.FirstOrDefault(per => per.MAT == PersonnelMat);
                tb1.Text = p.MAT;
                tb2.Text = p.NOM;
                tb3.Text = p.PRENOM;
                tb4.Text = p.TEL;
                tb5.Text = p.ADR_P;
                tb6.Text = p.VILLE_P;
                tb7.Text = p.POSTE;
                dt.Value = p.DATE_EMB.Value;
                tb8.Text = p.SALAIRE.ToString();
                imgdata = p.PHOTO;
                MemoryStream ms = new MemoryStream(imgdata);
                img.Image = Image.FromStream(ms);

                comboBox1.DataSource = entity.SOCIETE.ToList();
                comboBox1.DisplayMember = "NOM_S";
                comboBox1.ValueMember = "CODE_S";
                comboBox1.SelectedValue = p.CODE_S;
                comboBox2.DataSource = entity.SHIFT.ToList();
                comboBox2.DisplayMember = "LIBELLE";
                comboBox2.ValueMember = "CODE";
                comboBox1.SelectedValue = p.SHIFT.CODE;
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string imgpath = img.ImageLocation;
           // int salaire = 0;

            try
            {
                if (imgpath != null)
                {
                    FileStream fs = new FileStream((string)imgpath, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    FileInfo fi = new FileInfo((string)imgpath);
                    imgdata = br.ReadBytes((int)fi.Length);
                    fs.Close();
                    br.Close();
                }

                PERSONNEL personnel = entity.PERSONNEL.FirstOrDefault(per => per.MAT == PersonnelMat);
                personnel.MAT = tb1.Text;
                personnel.NOM = tb2.Text;
                personnel.PRENOM = tb3.Text;
                personnel.TEL = tb4.Text;
                personnel.ADR_P = tb5.Text;
                personnel.VILLE_P = tb6.Text;
                personnel.POSTE = tb7.Text;
                personnel.DATE_EMB = dt.Value;
                personnel.SALAIRE = Convert.ToDecimal(tb8.Text);
                personnel.PHOTO = imgdata;

                           
                entity.SaveChanges();
               // ajout.ForeColor = Color.Green;
                
                
               // Vide_le_Champs();
                this.Close();
               //var dialogresult = MessageBox.Show("ajout avec success");




            }//Try end
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
          
        }

        public void Vide_le_Champs()
        {
            tb1.Text = string.Empty;
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            tb6.Text = "";
            tb7.Text = "";
            tb8.Text = "";
        }
        private void Supprimer_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res;
                res = MessageBox.Show("Voulez vous supprimer cet employee", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    entity.PERSONNEL.Remove(entity.PERSONNEL.Single(p => p.MAT == PersonnelMat));
                    entity.SaveChanges();
                    this.Close();

                }

            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| png files(*.png)|*.png |All Files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    img.ImageLocation = imageLocation;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }
}
