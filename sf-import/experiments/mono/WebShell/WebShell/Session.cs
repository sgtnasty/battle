// 
//  Session.cs
//  
//  Author:
//       Ronaldo Nascimento <ronaldo1@users.sourceforge.net>
//  
//  Copyright (c) 2011 Ronaldo Nascimento
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;
using WebShell.Commands;

namespace WebShell
{
	public class Session
	{
		public Session ()
		{
			this.commands = new List<ICommand> ();
		}
		
		public string[] About ()
		{
			List<string> about = new List<string> ();
			about.Add (Assembly.GetExecutingAssembly ().GetName ().FullName);
			about.Add ("Copyleft (c) Ronaldo Nascimento <ronaldo1@users.sourceforge.net>");
			return about.ToArray ();
		}
		
		public List<ICommand> commands;
		
		public void RegisterCommands ()
		{
			this.commands.Add (new Search ());
			this.commands.Add (new Quit ());
		}
		
		public Results ProcessCommand (string command)
		{
			Results r = new Results ();
			Console.WriteLine ("Session.ProcessComman ({0})", command);
			r.Message = "Your command was not handled by any command object installed on this system!";
			return r;
		}
	}
}

