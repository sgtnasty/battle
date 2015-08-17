// 
//  Command.cs
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
namespace WebShell.Commands
{
	public abstract class Command : ICommand
	{
		#region ICommand implementation
		public abstract Results Execute (string[] parameters);

		public string Register ()
		{
			return this.GetType ().ToString ();
		}

		public abstract string Alias ();
		#endregion
		public override string ToString ()
		{
			return string.Format ("{0} alias: {1}", this.Register (), this.Alias ());
		}
	}
}

