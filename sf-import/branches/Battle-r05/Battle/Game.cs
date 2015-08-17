using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battle
{
    public class Game
    {
        public Game()
        {
            this.Console = null;
            this.MinStat = 8;
            this.Player1 = new Player("Player 1");
            this.Player2 = new Player("Player 2");
            this.random = new Random(DateTime.Now.Millisecond);
        }

        private Random random;
        public IConsole Console
        {
            get;
            set;
        }

        public Player Player1
        {
            get;
            private set;
        }
        public Player Player2
        {
            get;
            private set;
        }

        private int min_stat;
        public int MinStat
        {
            get
            {
                return this.min_stat;
            }
            set
            {
                this.min_stat = value;
                this.min_roll = this.min_stat * 6;
            }
        }

        private int min_roll;

        private void RollForPlayer(Player p)
        {
            int roll = 0;
            int rolls = 0;
            while (roll < min_roll)
            {
                rolls++;
                if (this.Console != null)
                    this.Console.ConsoleWriteLine(string.Format("Rolling for {0} seeking an average >= {1}", p.Name, this.min_stat));
                roll = p.RollAttributes(this.random);
                if (this.Console != null)
                {
                    Console.ConsoleWrite(string.Format("Rolled {0} avg={1:0.00}", roll, (double)roll / 6.0));
                    if (roll < min_roll)
                        Console.ConsoleWriteLine(" *** too low! re-rolling...");
                    else
                        Console.ConsoleWriteLine(string.Format(" good roll after {0} tries.", rolls));
                }
            }
        }

        public void RollAttributes()
        {
            this.RollForPlayer(this.Player1);
            if (this.Console != null)
            {
                this.Console.ConsoleWriteLine(this.Player1.GetRollDescription());
            }
            this.RollForPlayer(this.Player2);
            if (this.Console != null)
            {
                this.Console.ConsoleWriteLine(this.Player2.GetRollDescription());
            }
        }

        private bool game_over;

        public void Run()
        {
            this.game_over = false;
            int turn = 1;
            while (!this.game_over)
            {
                System.Windows.Forms.Application.DoEvents();
                if (this.Console != null)
                {
                    this.Console.ConsoleWriteLine("Turn " + turn.ToString());
                }
                turn++;
                if (turn > 10) this.game_over = true;
            }
            if (this.Console != null)
                this.Console.ConsoleWriteLine("Battle Over!");
        }
    }
}
