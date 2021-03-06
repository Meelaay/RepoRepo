﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
namespace RepoRepo
{
    public partial class Form1 : Form
    {
        private Form2 _form2 = new Form2();
        public Form1()
        {
            InitializeComponent();
            /**
             * Ways to improve UI :
             *      -make background color red, black or something != white
             *      -change to all red spaces in group area
             *      -remove background from pieces 
             *      -change pictureBox to Pot1...
             */
            buttonValidate.Enabled = false;

            GlobalEngine.engine32 = new Engine32Teams(_form2, buttonValidate);
                        
            this.Size = new Size((int) (Engine32Teams.MENUBOX.Width * 1.25) + 200,
                                 (int) (Engine32Teams.MENUBOX.Height * 1.18)
                                );
            
            StartPosition = FormStartPosition.CenterScreen;

            this.Controls.Add(Engine32Teams.MENUBOX);

            foreach (var picture in GlobalEngine.engine32.GetPotPictureBoxes(Engine32Teams.POTNUMBERS[0]))
            {
                this.Controls.Add(picture);
            }
            foreach (var picture in GlobalEngine.engine32.GetPotPictureBoxes(Engine32Teams.POTNUMBERS[1]))
            {
                this.Controls.Add(picture);
            }
            foreach (var picture in GlobalEngine.engine32.GetPotPictureBoxes(Engine32Teams.POTNUMBERS[2]))
            {
                this.Controls.Add(picture);
            }
            foreach (var picture in GlobalEngine.engine32.GetPotPictureBoxes(Engine32Teams.POTNUMBERS[3]))
            {
                this.Controls.Add(picture);
            }
            Engine32Teams.RussiaToA();
            
            this.pictureBox1.SendToBack();

            manualToolStripMenuItem_Click(null, null);

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Engine32Teams.Hide();
            pot1Button.Visible = false;
            pot2Button.Visible = false;
            pot3Button.Visible = false;
            pot4Button.Visible = false;
        }

        private void automaticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Engine32Teams.ShowAndFixPosition();
            pot1Button.Visible = true;
            pot2Button.Visible = true;
            pot3Button.Visible = true;
            pot4Button.Visible = true;
        }

        private void buttonValidate_Click(object sender, EventArgs e)
        {
            Engine32Teams.ValidateClicked();
            
            //pop the new form2 with groupA as main one then fix the other stuff of visibility and clicking
        }

        private void pot1Button_Click(object sender, EventArgs e)
        {
            Engine32Teams.RandomizePot1();
            pot1Button.Enabled = false;
        }

        private void pot2Button_Click(object sender, EventArgs e)
        {
            Engine32Teams.RandomizePot2();
            pot2Button.Enabled = false;
        }

        private void pot3Button_Click(object sender, EventArgs e)
        {
            Engine32Teams.RandomizePot3();
            pot3Button.Enabled = false;
        }

        private void pot4Button_Click(object sender, EventArgs e)
        {
            Engine32Teams.RandomizePot4();
            pot4Button.Enabled = false;
        }
    }
}
