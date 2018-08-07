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
    public partial class authentification : MetroFramework.Forms.MetroForm
    {
        public authentification()
        {
            InitializeComponent();
            label3.Text ="";
        }

        DbEntities entity = new DbEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var log = login.Text;
                var pass = password.Text;
                var result = entity.ADMIN.Where(a => a.LOGIN == log && a.PASSWORD == pass).FirstOrDefault();
                if (result != null)
                {


                    if (result.Type.Equals("admin"))
                    {
                        new Form1("admin").Show();

                    }
                    else
                    {
                        new Form1("personnel").Show();
                        this.Hide();
                       
                    }
                }
                else
                {
                    password.Text = "";
                    label3.Text = "login ou mot de passe incorrect";
                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void login_TextChanged(object sender, EventArgs e)
        {
            label3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            label3.Text = "";
        }
    }
}
