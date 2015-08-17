using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BattleWin
{
    public partial class BattleForm : Form, BattleEngine.IConsole
    {
        public BattleForm(BattleEngine.Game game)
        {
            InitializeComponent();
            this.game = game;            
            this.game.Console = this;
        }

        BattleEngine.Game game;

        public void ConsoleWrite(string message)
        {
            this.ConsoleRichTextBox.AppendText(message);
        }
        public void ConsoleWriteLine(string message)
        {
            this.ConsoleRichTextBox.AppendText(message + System.Environment.NewLine);
        }

        private void AddPlayerToolStripButton_Click(object sender, EventArgs e)
        {
            BattleEngine.RandomName rname = new BattleEngine.RandomName(this.game.RandomEngine);
            BattleEngine.Player.Player player = new BattleEngine.Player.Player(rname.GetRandomName());
            this.game.AddPlayer(player);
        }

        private void RollToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.game.RollAttributes();
            }
            catch (Exception exp)
            {
                MessageBox.Show(this, exp.Message, exp.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ConsoleWriteLine(exp.StackTrace);
            }
        }

        private void BattleToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.game.Battle();
            }
            catch (Exception exp)
            {
                MessageBox.Show(this, exp.Message, exp.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ConsoleWriteLine(exp.StackTrace);
            }
        }

        private void BattleForm_Load(object sender, EventArgs e)
        {
            this.game.GuiLoaded();
        }
    }
}
