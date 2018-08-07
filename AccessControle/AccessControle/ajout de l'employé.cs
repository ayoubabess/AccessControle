using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.IO;
using Gestion_pointage_tourniquet.BaseClass;

namespace Gestion_pointage_tourniquet
{
    public partial class ajoutEmployeForm : MetroFramework.Forms.MetroForm
    {
       int emprientID;
        public ajoutEmployeForm()
        {
            
            InitializeComponent();
            try
            {
                comboBox1.DataSource = entity.SOCIETE.ToList();
                comboBox1.DisplayMember = "NOM_S";
                comboBox1.ValueMember = "CODE_S";
                comboBox2.DataSource = entity.SHIFT.ToList();
                comboBox2.DisplayMember = "LIBELLE";
                comboBox2.ValueMember = "CODE";


                var p = entity.PERSONNEL.OrderByDescending(e => e.IDEMPRIENT != null).FirstOrDefault();
                if (p != null)
                {
                    emprientID = (int)p.IDEMPRIENT;
                    emprientID++;
                }
                else
                    emprientID = 1;

            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| png files(*.png)|*.png |All Files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    imageLocation = dialog.FileName;
                    img.ImageLocation = imageLocation;
                }
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Form4 f4 = new Form4();
            //f4.ShowDialog();
        }

        DbEntities entity = new DbEntities();

        public ICollection<SHIFT> Colshift { get; private set; }

        private void button2_Click(object sender, EventArgs e)
        {
           try
           {
            string imgpath = img.ImageLocation;
            
           
           

            FileStream fs = new FileStream((string)imgpath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            FileInfo fi = new FileInfo((string)imgpath);
            byte[] imgdata = br.ReadBytes((int)fi.Length);
            fs.Close();
            br.Close();
              SOCIETE societe=  entity.SOCIETE.FirstOrDefault(S => S.CODE_S.Equals((decimal) comboBox1.SelectedValue));
          SHIFT shift= entity.SHIFT.FirstOrDefault(S => S.CODE == (decimal)comboBox2.SelectedValue);
            

            PERSONNEL p = new PERSONNEL
                {
                    MAT = tb1.Text,
                    NOM = tb2.Text,
                    PRENOM = tb3.Text,
                    TEL = tb4.Text,
                    ADR_P = tb5.Text,
                    VILLE_P = tb6.Text,
                    POSTE = tb7.Text,
                    DATE_EMB = dt.Value,
                    SALAIRE = Convert.ToDecimal(tb8.Text),
                    PHOTO = imgdata,
                    CODE_S=societe.CODE_S,
                    SHIFT= shift,
                    SOCIETE = societe,
                    IDEMPRIENT= emprientID


            };

                entity.PERSONNEL.Add(p);
                entity.SaveChanges();
                ajout.ForeColor = Color.Green;
                MessageFormtOK MessageFormtOK = new MessageFormtOK("ajout avec success");
                var result = MessageFormtOK.ShowDialog(); 
          
            this.Close();
            




           }//Try end
            catch (Exception ex)
            {
            MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
            
        }
        public void Vide_le_Champs()
        {
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            tb6.Text = "";
            tb7.Text = "";
            tb8.Text = "";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'dataSet1.SOCIETE'. Vous pouvez la déplacer ou la supprimer selon les besoins.
         
            // TODO: cette ligne de code charge les données dans la table 'dataSet2.SOCIETE'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            //   this.sOCIETETableAdapter1.Fill(this.dataSet2.SOCIETE);


        }

        private void button5_Click(object sender, EventArgs e)
        { string matrucule = tb1.Text;
            if (!string.IsNullOrWhiteSpace(matrucule))
            {
                
                   AjoutEmpriente AjoutEmpriente = new AjoutEmpriente(tb1.Text, emprientID);
                AjoutEmpriente.Show();
            }
        }
    }
}
