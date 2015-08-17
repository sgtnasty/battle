using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Battle
{
    public partial class MainForm : Form, IConsole
    {
        public MainForm(Game game)
        {
            this.game = game;
            this.game.Console = this;
            InitializeComponent();
        }

        private Game game;

        private void AboutToolStripButton_Click(object sender, EventArgs e)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            object[] title = asm.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            this.ConsoleWrite(((AssemblyTitleAttribute)title[0]).Title);
            this.ConsoleWrite(" (");
            object[] product = asm.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            this.ConsoleWrite(((AssemblyProductAttribute)product[0]).Product);
            this.ConsoleWriteLine(")");
            object[] description = asm.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            this.ConsoleWriteLine(((AssemblyDescriptionAttribute)description[0]).Description);
            object[] copyright = asm.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            this.ConsoleWriteLine(((AssemblyCopyrightAttribute)copyright[0]).Copyright);
            this.ConsoleWrite("Version: ");
            this.ConsoleWriteLine(asm.GetName().Version.ToString());
        }

        public void ConsoleWrite(string message)
        {
            this.richTextBox1.SelectionStart = this.richTextBox1.Text.Length;
            this.richTextBox1.AppendText(message);
        }

        public void ConsoleWriteLine(string message)
        {
            this.ConsoleWrite(message + System.Environment.NewLine);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.AboutToolStripButton.PerformClick();
            this.game.RollAttributes();
            this.printStartGame();
        }

        public void StatusUpdate(string message)
        {
            this.toolStripStatusLabel1.Text = message;
        }

        private void GoToolStripButton_Click(object sender, EventArgs e)
        {
            this.Go();
        }

        private void printStartGame()
        {
            this.ConsoleWriteLine(this.game.Player1.ToString());
            this.ConsoleWriteLine(this.game.Player2.ToString());
            this.StatusUpdate("Ready for battle!");
            this.ConsoleWriteLine("Ready for battle!");
        }

        private void ReRollToolStripButton_Click(object sender, EventArgs e)
        {
            this.game.RollAttributes();
            this.printStartGame();
        }

        public void Go()
        {
            this.GoToolStripButton.Enabled = false;
            this.ReRollToolStripButton.Enabled = false;
            this.game.Run();
            this.GoToolStripButton.Enabled = true;
            this.ReRollToolStripButton.Enabled = true;
        }
    }
}
