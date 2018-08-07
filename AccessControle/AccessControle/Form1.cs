using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;
using Gestion_pointage_tourniquet.BaseClass;
using System.Collections.ObjectModel;

namespace Gestion_pointage_tourniquet
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private BackgroundWorker myWorker = new BackgroundWorker();
        public Form1(string accee)
        {
            InitializeComponent();
            if (accee.Equals("admin"))
            {
                button3.Hide();//Enabled = false;
                groupBox1.Hide();
            }
            else
            {
                button5.Enabled = false;
                button7.Enabled = false;
                button13.Enabled = false;
                button10.Enabled = false;
                button5.Hide();
                button7.Hide();
                button13.Hide();
                button10.Hide();
                PersonnelgroupBox.Hide();
                groupBox4.Hide();
                groupBox2.Hide();
                groupBox3.Hide();
            }
            PersonnelgroupBox.Hide();
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            LoadPicture.Hide();

            //myWorker.DoWork += new DoWorkEventHandler(myWorker_DoWork);
            //myWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myWorker_RunWorkerCompleted);
        }
      
        bool isShow = false;
        private void button5_Click(object sender, EventArgs e)
        {
            
           
           
            if (!PersonnelgroupBox.Visible)
            {
                
                PersonnelgroupBox.Show();
                isShow = true;
                groupBox1.Hide();
                groupBox2.Hide();
                groupBox3.Hide();
                groupBox4.Hide();
            }
            else
            {
                PersonnelgroupBox.Hide();
                isShow = false;
            }
        }


        private async Task<UserControl> callpersonelControl()
        {

            //panel3.Controls.RemoveAt(0);
            UserControl1 usercontrol = new UserControl1();
            usercontrol.Dock = DockStyle.Fill;
            return usercontrol;

            
        }
        private async void ListPersonnelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                labelNav.Text = "Gerer personnels";
                LoadPicture.Show();
                //try
                //{
                panel3.Controls.RemoveAt(1);

                var control = await callpersonelControl();
                panel3.Controls.Add(control);
                //}catch(Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}


                LoadPicture.Hide();
                // label1.Text = "liste de personnels";
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
        }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PersonnelgroupBox.Hide();
        }

        private async void AjoutPersonnelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ajoutEmployeForm frm = new ajoutEmployeForm();
                var result = frm.ShowDialog();
                panel3.Controls.RemoveAt(1);

                var control = await callpersonelControl();
                panel3.Controls.Add(control);
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
        }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (groupBox1 .Visible== false)
            {
                groupBox1.Show();
                isShow = true;
               PersonnelgroupBox.Hide();
                groupBox2.Hide();
                groupBox3.Hide();
                groupBox4.Hide();
            }
            else
            {
                groupBox1.Hide();
                isShow = false;
            }
        }
        private async Task<UserControl> callmachineControl()
        {
             //panel3.Controls.RemoveAt(0);
                MachineControl machinecontrol = new MachineControl();
                machinecontrol.Dock = DockStyle.Fill;
                return machinecontrol;
         
        }


        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                labelNav.Text = "Gerer machines";
                LoadPicture.Show();
                try
                {
                    panel3.Controls.RemoveAt(1);

                    var control = await callmachineControl();
                    panel3.Controls.Add(control);
                }
                catch (Exception ex)
                {
                    MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                    var result = MessageForm.ShowDialog();
                }


                LoadPicture.Hide();
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ajoutMachine ajoutMachine = new ajoutMachine();
                var result = ajoutMachine.ShowDialog();
                LoadPicture.Show();
               
                    panel3.Controls.RemoveAt(1);

                    var control = await callmachineControl();
                    panel3.Controls.Add(control);
               


                LoadPicture.Hide();
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (groupBox2.Visible == false)
            {
                groupBox2.Show();
                isShow = true;
                PersonnelgroupBox.Hide();
                groupBox1.Hide();
                groupBox3.Hide();
                groupBox4.Hide();
            }
            else
            {
                groupBox2.Hide();
                isShow = false;
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                AjoutFiliale AjoutFiliale = new AjoutFiliale();
                var DialogResult = AjoutFiliale.ShowDialog();
                labelNav.Text = "Gestion des filiales";
                LoadPicture.Show();

                panel3.Controls.RemoveAt(1);

                var control = await callfillaleControl();
                panel3.Controls.Add(control);



                LoadPicture.Hide();
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
        }
        private async Task<UserControl> callfillaleControl()
        {

            //panel3.Controls.RemoveAt(0);
            filialesControl usercontrol = new filialesControl();
            usercontrol.Dock = DockStyle.Fill;
            return usercontrol;


        }
        private async void button6_Click(object sender, EventArgs e)
        {
            labelNav.Text = "Gestion des filiales";
            LoadPicture.Show();
            try
            {
                panel3.Controls.RemoveAt(1);

                var control = await callfillaleControl();
                panel3.Controls.Add(control);
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }


            LoadPicture.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (groupBox3.Visible == false)
            {
                groupBox3.Show();
                isShow = true;
                PersonnelgroupBox.Hide();
                groupBox1.Hide();
                groupBox2.Hide();
                groupBox4.Hide();
            }
            else
            {
                groupBox3.Hide();
                isShow = false;
            }
        }
        private async Task<UserControl> callShiftControl()
        {

            //panel3.Controls.RemoveAt(0);
            ShiftControl machinecontrol = new ShiftControl();
            machinecontrol.Dock = DockStyle.Fill;
            return machinecontrol;


        }
        private async void button9_Click(object sender, EventArgs e)
        {
            labelNav.Text = "Gestion des shifts";
            LoadPicture.Show();
            try
            {
                panel3.Controls.RemoveAt(1);

                var control = await callShiftControl();
                panel3.Controls.Add(control);
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }


            LoadPicture.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private async Task<UserControl> callshiftControl()
        {

            //panel3.Controls.RemoveAt(0);
            ShiftControl  usercontrol = new ShiftControl();
            usercontrol.Dock = DockStyle.Fill;
            return usercontrol;


        }
        private async void button8_Click(object sender, EventArgs e)
        {
            try
            {
                AjoutShift ajoutshift = new AjoutShift();
                var result = ajoutshift.ShowDialog();

                panel3.Controls.RemoveAt(1);

                var control = await callshiftControl();
                panel3.Controls.Add(control);
            }
            catch (Exception ex)
            {
                MessageFormError MessageForm = new MessageFormError(ex.Message.ToString());
                var result = MessageForm.ShowDialog();
            }
            /*DbEntities entity = new DbEntities();
            SHIFT shift = entity.SHIFT.FirstOrDefault(per => per.CODE == 2);
            DateTime d = DateTime.Now;
            DateTime dshift =(DateTime)shift.DATEDDEBUT;
            //if (d.ToShortDateString().CompareTo(dshift.ToShortDateString()) == 0)
            //{ MessageBox.Show(d.ToShortDateString() + "ego" + dshift.ToShortDateString()); }
            //else
            //    MessageBox.Show(d.ToShortDateString() + "different" + dshift.ToShortDateString());
            if (d.ToShortTimeString().CompareTo(dshift.ToShortTimeString()) == 0)
            { MessageBox.Show(d.ToShortTimeString() + "ego" + dshift.ToShortTimeString()); }
            else
                MessageBox.Show(d.ToShortTimeString() + "different" + dshift.ToShortTimeString());
                */

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void PersonnelgroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private async Task<UserControl> callPointageControl()
        {

            //panel3.Controls.RemoveAt(0);
            PointageControl pointagecontrol = new PointageControl();
            pointagecontrol.Dock = DockStyle.Fill;
            return pointagecontrol;


        }
        private async void button12_Click(object sender, EventArgs e)
        {
            labelNav.Text = "Gestion des shifts";
            LoadPicture.Show();
            try
            {
                panel3.Controls.RemoveAt(1);

                var control = await callPointageControl();
                panel3.Controls.Add(control);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            LoadPicture.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {

            if (groupBox4.Visible == false)
            {
                groupBox4.Show();
                isShow = true;
                PersonnelgroupBox.Hide();
                groupBox1.Hide();
                groupBox2.Hide();
                groupBox3.Hide();
            }
            else
            {
                groupBox4.Hide();
                isShow = false;
            }
        }
    }
}
