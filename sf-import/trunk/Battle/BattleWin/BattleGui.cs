using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BattleWin
{
    public class BattleGui : BattleEngine.IBattleGui, BattleEngine.IConsole
    {
        public BattleGui()
        {
        }

        public void Init(BattleEngine.Game game)
        {
            this.game = game;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            this.battle_form = new BattleForm(this.game);
            this.game.BattleGui = this;
        }

        private BattleEngine.Game game;
        private BattleForm battle_form;

        public void Run()
        {
            Application.Run(this.battle_form);
        }

        public void DoEvents()
        {
            Application.DoEvents();
        }
		
		public void ShowAttackDialog (string details)
		{
		}

        public void ConsoleWrite(string message)
        {
            this.battle_form.ConsoleWrite(message);
        }

        public void ConsoleWriteLine(string message)
        {
            this.battle_form.ConsoleWriteLine(message);
        }
    }
}
