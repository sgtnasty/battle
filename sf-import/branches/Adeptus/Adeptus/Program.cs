// 
//  Program.cs
//  
//  Author:
//       Ronaldo Nascimento <ronaldo1@users.sourceforge.net>
//  
//  Copyright (c) 2010 Ronaldo Nascimento
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
using Gtk;
using Adeptus.Gui;
using Adeptus.Core;

namespace Adeptus
{
	public class Program
	{
		public Program ()
		{
			Gtk.Application.Init ();
			AdeptusWindow window = new AdeptusWindow (new AdeptusSession ());			
			window.ShowAll ();
			Gtk.Application.Run ();
		}
		
		[STAThread]
		public static void Main (string[] args)
		{
			Program p = new Program();
		}
	}
}

