#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
	A battle simulator.
    Copyright (C) 2013  Ronaldo Nascimento <ronaldo1@users.sf.net>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
"""

from gi.repository import Gtk, Gdk
import random, string, math

class Handler():
	def on_window1_delete_event(self, *args):
		Gtk.main_quit(*args)
	
	def on_about_toolbutton_clicked(self, *args):
		ad = Gtk.AboutDialog()
		ad.set_program_name("Battle")
		ad.set_version("0.0.1")
		ad.set_copyright("(c) 2013 by Ronaldo Nascimento")
		ad.set_comments("A battle simulator.")
		ad.set_website("https://github.com/sgtnasty")
		ad.set_website_label("Support")
		ad.set_authors(["Ronaldo Nascimento"])
		#ad.set_logo()
		ad.set_license('Distributed under the GPL v3 license.\nhttp://www.gnu.org/licenses/gpl-3.0.html')
		ad.run()
		ad.destroy()

def battle():
	builder = Gtk.Builder()
	builder.add_from_file("battle.glade")
	builder.connect_signals(Handler())
	window = builder.get_object("window1")
	window.show_all()
	Gtk.main()

if __name__ == '__main__':
	battle()
