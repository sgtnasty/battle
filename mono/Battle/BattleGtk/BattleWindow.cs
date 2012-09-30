//  
//  MyClass.cs
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
using Gtk;
using BatteLib;
using BatteLib.UI;

namespace BattleGtk
{
    public class BattleWindow : Gtk.Window, IBattleWindow
    {
        public BattleWindow (Session session) : base (WindowType.Toplevel)
        {
            this.session = session;
            this.DeleteEvent += (o, args) => { Gtk.Application.Quit (); };
        }
        
        private Session session;
        
        
        #region IBattleWindow implementation
        public Session GetSession ()
        {
            return this.session;
        }
        #endregion
    }
}

