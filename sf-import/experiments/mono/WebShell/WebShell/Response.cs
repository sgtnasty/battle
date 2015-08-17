// 
//  Result.cs
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
using System.Text;
using Newtonsoft.Json;

namespace WebShell
{
	public class Response
	{
		public Response (string json)
		{
			// http://json.codeplex.com
			
		}
	}
	
	[JsonObject (MemberSerialization.OptIn)]
	public class GoogleJson
	{
		[JsonProperty]
		public string responseDetails;

		[JsonProperty]
		public string responseStatus;
		
		[JsonProperty]
		public List<Dictionary<string, string>> results;
		
		public GoogleJson (string json)
		{
			this.responseStatus = JsonConvert.DeserializeObject<string> ("responseStatus");
			this.results = JsonConvert.DeserializeObject<List<Dictionary<string, string>>> ("results");
			/*
			this.responseDetails = JsonConvert.DeserializeObject ("responseDetails", typeof (string));
			this.results = JsonConvert.DeserializeObject ("results", typeof (List<Dictionary<string, string>>));
			*/
		}
	}
}

