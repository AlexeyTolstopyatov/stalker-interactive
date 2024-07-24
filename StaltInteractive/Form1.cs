using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaltInteractive
{
    /*
     *      (С) Толстопятов Алексей А. 2022.
     * Мой первый проект File System Watcher -- Stalker Interactive.
     * Исходный код не изменялся с 14.09.2021. Вот такой я был жопа.
     * 
     */

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FSWatch.EnableRaisingEvents = true;
            textBox1.WordWrap = true;
            textBox1.TabStop = false;
            notifyIcon1.Visible = true;
            notifyIcon1.Text = "Stalker Interactive BP";
            this.Text = "Stalker Interactive CI";
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            
        }

        [STAThread]
        public void Logging()
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            notifyIcon1.BalloonTipTitle = "Stalker Interactive";
            notifyIcon1.BalloonTipText = "Приложение запущено";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ShowBalloonTip(1000);

            textBox1.Text = "[Система]: Stalker Interactive v 1.0.0.0 \n";
        }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) => 
            this.WindowState = FormWindowState.Normal;
        private void FSWatch_Changed(object sender, System.IO.FileSystemEventArgs e) => 
            textBox1.AppendText($"[  ИЗМЕНЕНО   ]: {e.FullPath} \r\n");
        private void FSWatch_Created(object sender, System.IO.FileSystemEventArgs e) => 
            textBox1.AppendText($"[   СОЗДАНО   ]: {e.FullPath} \r\n");
        private void FSWatch_Deleted(object sender, System.IO.FileSystemEventArgs e) => 
            textBox1.AppendText($"[   УДАЛЕНО   ]: {e.FullPath} \r\n");
        private void FSWatch_Renamed(object sender, System.IO.RenamedEventArgs e) =>    
            textBox1.AppendText($"[ПЕРЕИМЕНОВАНО]: {e.OldFullPath} -> {e.FullPath}\r\n");
    }
}
