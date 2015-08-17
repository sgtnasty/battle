//  
//  MediaManager.cs
//  
//  Author:
//       Ronaldo Nascimento <ronaldo1@sourceforge.net>
// 
//  Copyright (c) 2010 Ronaldo Nascimento
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
using System.IO;
using Gtk;
using Gdk;

namespace Battle.Gui
{
	public class MediaManager
	{		
		public static Gtk.Image GetImageFromBaseFile(string basefile)
		{
			string basepath = string.Format("{0}{1}Gui{2}{3}",
			                                System.Environment.CurrentDirectory,
			                                System.IO.Path.DirectorySeparatorChar,
			                                System.IO.Path.DirectorySeparatorChar,
			                                basefile);
			Console.WriteLine(basepath);
			return new Gtk.Image(basepath);
		}
		public static Gdk.Pixbuf GetPixbufFromBaseFile(string basefile)
		{
			string basepath = string.Format("{0}{1}Gui{2}{3}",
			                                System.Environment.CurrentDirectory,
			                                System.IO.Path.DirectorySeparatorChar,
			                                System.IO.Path.DirectorySeparatorChar,
			                                basefile);
			Console.WriteLine(basepath);
			return new Gdk.Pixbuf(basepath);
		}
		public static string GetHtml(string basefile)
		{
			string fullpath = string.Format("{0}{1}Gui{2}{3}",
			                                System.Environment.CurrentDirectory,
			                                System.IO.Path.DirectorySeparatorChar,
			                                System.IO.Path.DirectorySeparatorChar,
			                                basefile);
			Console.WriteLine(fullpath);
			TextReader r = new  StreamReader(fullpath);
			return r.ReadToEnd();
		}
	}
}

