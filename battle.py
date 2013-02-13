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

def battle():
	builder = Gtk.Builder()
	builder.add_from_file("battle.glade")
	builder.connect_signals(Handler())
	window = builder.get_object("window1")
	window.show_all()
	Gtk.main()

if __name__ == '__main__':
	battle()
