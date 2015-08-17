// 
//  Search.cs
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
using System.Text;
using System.Net;
using System.IO;

namespace WebShell.Commands
{
	public class Search : Command
	{
		public Search ()
		{
		}
		
		public string url;
		public string status;
		public string response;
		
		public override Results Execute (string[] parameters)
		{
			// http://duckduckgo.com/api.html
			string duckduckgo = "http://api.duckduckgo.com/?q={0}&format=json&pretty=1";
			string google = "http://ajax.googleapis.com/ajax/services/search/web?v=1.0&q={0}";
			string searchurl = google;
			string encoded = System.Web.HttpUtility.HtmlEncode (parameters[0].Substring (1));
			this.url = string.Format (searchurl, encoded.Replace(" ", "+"));
			WebRequest request = WebRequest.Create (url);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
			this.status = response.StatusDescription;
			Stream dataStream = response.GetResponseStream ();
			TextReader reader = new StreamReader (dataStream);			
			string buf = reader.ReadToEnd ();
			reader.Close ();
			dataStream.Close ();
			response.Close ();
			this.response = buf;
			
			Results r = new Results ();
			r.Message = buf;
			return r;
		}
		
		public override string Alias ()
		{
			return "$ {search parameter}";
		}

	}
}

