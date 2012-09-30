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
            Gtk.Application.Init ("battle", ref args);
            BattleWindow window = new BattleWindow (this.session);
            
            window.SetDefaultSize (800, 600);
            window.ShowAll ();
            
            Gtk.Application.Run ();
            this.Stop ();
        }
        
        public void Stop ()
        {
            Gtk.Application.Quit ();
        }
    }
}

