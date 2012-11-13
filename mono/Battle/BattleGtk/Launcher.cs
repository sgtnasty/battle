//  
//  GtkSession.cs
//  
//  Author:
//       Ronaldo Nascimento <ronaldo1@users.sf.net>
// 
//  Copyright (c) 2012 Ronaldo Nascimento
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using BatteLib;
using Gtk;
using Glade;

namespace BattleGtk
{
    /// <summary>
    /// Launcher
    /// </summary>
    public class Launcher
    {
        public Launcher (Session session)
        {
            this.session = session;
        }
        private Session session;
        
        public void Start (ref string[] args)
        {
            Application.Init ("battle", ref args);

            Glade.XML gxml = new Glade.XML ("battle.ui", "mainWindow", null);
            BattleWindow window = new BattleWindow (this.session, 
                                                    (Window)gxml.GetWidget("mainWindow"));
            gxml.Autoconnect (window);
            window.Window.ShowAll ();
            Application.Run ();
            this.Stop ();
        }
        
        public void Stop ()
        {
            Application.Quit ();
        }
    }
}

