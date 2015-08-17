// 
//  AssemblyAttributes.cs
//  
//  Author:
//       Ronaldo Nascimento <ronaldo1@users.sf.net>
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
using System.Reflection;

namespace BattleEngine
{
	public class AssemblyAttributes
	{
		public AssemblyAttributes (Type type)
		{
			this.inspect (type);
		}
		
		private void inspect (Type type)
		{
			Assembly assembly = type.Assembly;
			object[] title = assembly.GetCustomAttributes (typeof (AssemblyTitleAttribute), false);
			this.Title = ((AssemblyTitleAttribute)title[0]).Title;
			object[] product = assembly.GetCustomAttributes (typeof (AssemblyProductAttribute), false);
			this.Product = ((AssemblyProductAttribute)product[0]).Product;
			object[] description = assembly.GetCustomAttributes (typeof (AssemblyDescriptionAttribute), false);
			this.Description = ((AssemblyDescriptionAttribute)description[0]).Description;
			object[] copyright = assembly.GetCustomAttributes (typeof (AssemblyCopyrightAttribute), false);
			this.Copyright = ((AssemblyCopyrightAttribute)copyright[0]).Copyright;
			object[] company = assembly.GetCustomAttributes (typeof (AssemblyCompanyAttribute), false);
			this.Company = ((AssemblyCompanyAttribute)company[0]).Company;
			this.Version = assembly.GetName ().Version.ToString ();			
			this.QualifiedName = type.ToString ();
			this.ManifestModule = assembly.ManifestModule.Name;
		}
		
		public override string ToString ()
		{
			return string.Format ("[AssemblyAttributes: Title={0}, Product={1}, Description={2}, Copyright={3}, Company={4}, Version={5}]", Title, Product, Description, Copyright, Company, Version);
		}
		
		public string TechDetails ()
		{
			return string.Format ("{0} Version={1} Module={2}", this.QualifiedName, this.Version, this.ManifestModule);
		}
		
		#region Members
		public string ManifestModule
		{
			get;
			private set;
		}
		public string QualifiedName
		{
			get;
			private set;
		}
		public string Title
		{
			get;
			private set;
		}
		public string Product
		{
			get;
			private set;
		}
		public string Description
		{
			get;
			private set;
		}
		public string Copyright
		{
			get;
			private set;
		}
		public string Company
		{
			get;
			private set;
		}
		public string Version
		{
		get;
		private set;
		}
	#endregion
	}
}

