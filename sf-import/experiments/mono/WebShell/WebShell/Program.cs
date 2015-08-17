// 
//  Program.cs
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
using Gtk;
using GLib;

namespace WebShell
{
	public class Program
	{
		public Program ()
		{
			this.session = new Session ();
			this.session.RegisterCommands ();
		}
		
		protected Session session;
		protected GladeWindow gwin;
		
		public void LaunchGlade ()
		{
			Gtk.Application.Init ();
			ExceptionManager.UnhandledException += HandleExceptionManagerUnhandledException;
			this.gwin = new GladeWindow (this.session);
			//Console.WriteLine (System.Environment.CurrentDirectory);
			//throw new Exception ("eeeeeeeeee");
			Gtk.Application.Run ();
		}

		void HandleExceptionManagerUnhandledException (UnhandledExceptionArgs args)
		{
			Exception ex = (Exception)args.ExceptionObject;
			
			Console.WriteLine("Unhandled Exception: {0}", ex.GetType ().ToString ());
			Console.WriteLine("\t{0}", ex.Message);
			Console.WriteLine("\t{0}", ex.Source);
			Console.WriteLine("\t{0}", ex.StackTrace);

			MessageDialog d = new MessageDialog (null, DialogFlags.Modal, MessageType.Error,
			                                     ButtonsType.Close, true, "<b>{0}</b>: {1} at <i>{2}</i>", 
			                                     ex.GetType ().ToString(),
			                                     ex.Message, ex.Source);
			d.Run ();
			d.Hide ();
			d.Dispose ();
			args.ExitApplication = true;
		}
				
		public static void Main (string[] args)
		{
			Program p = new Program ();
			p.LaunchGlade ();
		}
	}
}

