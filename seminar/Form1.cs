using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace seminar
{
    public partial class Form1 : Form
    {
        private int totalMinutes;
        private int seconds;

        public SoundPlayer alertSound = new SoundPlayer();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            SetStartValues();
        }

        private void SetStartValues()
        {
            if (int.TryParse(inputBox.Text, out int result))
            {
                totalMinutes = result - 1;
                seconds = 60;
                lblTime.Text = result.ToString();
                btnStart.Visible = true;
            }
            else
            {
                lblTime.Text = "00:00";
                btnStart.Visible = false;
            }
        }
        private void inputBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void tmrSeconds_Tick(object sender, EventArgs e)
        {
            --seconds;
            if (seconds >= 0)
            {
                PrintTime();
            }
            else
            {
                --totalMinutes;
                seconds = 59;
                PrintTime();
            }

            if (totalMinutes <= 4)
            {
               
                if (seconds % 2 == 0)
                {
                    lblTime.BackColor = Color.Yellow;
                }
                else
                {
                    lblTime.BackColor = Color.Red;
                }
            }
        }

        private void PrintTime()
        {
            lblTime.Text = $"{totalMinutes}:{seconds}";
        }
        private void btnStart_Click_1(object sender, EventArgs e)
        {
            tmrSeconds.Start();
            tmrMinutes.Start();
        }

        private void tmrMinutes_Tick(object sender, EventArgs e)
        {
            if (totalMinutes == 5)
            {
                PlayAlarmSound();
            }
            if (totalMinutes == 0)
            {
                tmrSeconds.Stop();
                tmrMinutes.Stop();
                seconds = 0;
                PrintTime();
                PlayAlarmSound();
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        { 
            tmrMinutes.Stop();
            tmrSeconds.Stop();
            lblTime.Text = "00:00";
            SetStartValues();
            ResetColors();
        }
        private void PlayAlarmSound()
        {
            alertSound.SoundLocation = "C:\\Windows\\Media\\Alarm01.wav";
            alertSound.Play();
        }
        private void ResetColors()
        {
            lblTime.BackColor = Color.Transparent;
        }
       
    }
}
    



