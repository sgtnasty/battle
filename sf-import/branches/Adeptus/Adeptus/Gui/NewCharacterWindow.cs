// 
//  NewCharacterDialog.cs
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
using System.Resources;
using System.Collections;
using Gtk;
using Adeptus.Core;

namespace Adeptus.Gui
{
	public class NewCharacterWindow : Gtk.Assistant
	{
		private AdeptusSession session;
		public NewCharacterWindow (AdeptusSession session) : base ()
		{
			this.session = session;
			this.build ();
			this.SetPosition (WindowPosition.CenterOnParent);
		}
		
		private void build ()
		{
			this.SetDefaultSize (500,500);
			this.Title = "New Character";
			
			this.build_page_1 ();
			
			this.ShowAll ();
			
			this.Close += HandleClose;
			this.Cancel += HandleCancel;
		}
		
		private void build_page_1 ()
		{
			TextView tv1 = new TextView ();
			
			try 
			{
				string rez = "Adeptus.Resources.resources";
				string key = "mystring1";
				string resourceType = "";
				byte[] resourceData;
				ResourceReader r = new ResourceReader(rez);
				r.GetResourceData (key, out resourceType, out resourceData);
				r.Close();
				System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
				tv1.Buffer.Text = enc.GetString (resourceData);
			}
			catch (Exception exp)
			{
				tv1.Buffer.Text = exp.Message;
			}

			tv1.WrapMode = WrapMode.Word;
			tv1.Editable = false;
			
			this.AppendPage (tv1);
			this.SetPageTitle (tv1, "Introduction");
			this.SetPageType (tv1, AssistantPageType.Intro);
			this.SetPageComplete (tv1, true);
		}

		void HandleCancel (object sender, EventArgs e)
		{
			this.Destroy ();
		}

		void HandleClose (object sender, EventArgs e)
		{
			this.Destroy ();
		}
	}
}

