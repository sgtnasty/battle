#!/usr/bin/env python
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
from os.path import abspath, dirname, join
import random, string, math, cairo

RESOURCES = abspath(dirname(__file__))

class Handler():
	
	def __init__(self):
		# Create buffer
		self.double_buffer = None
	
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
		
	def on_drawingarea1_configure_event(self, widget, event, data=None):
		"""Configure the double buffer based on size of the widget"""
		print("on_drawingarea1_configure_event")
		# Destroy previous buffer
		if self.double_buffer is not None:
			self.double_buffer.finish()
			self.double_buffer = None
		# Create a new buffer
		self.double_buffer = cairo.ImageSurface(\
			cairo.FORMAT_ARGB32,
			widget.get_allocated_width(),
			widget.get_allocated_height()
			)
		# Initialize the buffer
		self.draw_something()
		return False
		
	def on_drawingarea1_draw(self, widget, cr):
		"""Throw double buffer into widget drawable"""
		print("on_drawingarea1_draw")
		if self.double_buffer is not None:
			cr.set_source_surface(self.double_buffer, 0.0, 0.0)
			cr.paint()
		else:
			print('Invalid double buffer')
		return False
		
	def draw_something(self):
		"""Draw something into the buffer"""
		print("draw_something")
		db = self.double_buffer
		if db is not None:
			print(db)
			# Create cairo context with double buffer as is DESTINATION
			cc = cairo.Context(db)
			# Scale to device coordenates
			cc.scale(db.get_width(), db.get_height())
			# Draw a white background
			cc.set_source_rgb(1, 1, 1)
			# Draw something, in this case a matrix
			rows = 10
			columns = 10
			cell_size = 1.0 / rows
			line_width = 1.0
			line_width, notused = cc.device_to_user(line_width, 0.0)
			for i in range(rows):
				for j in range(columns):
					cc.rectangle(j * cell_size, i * cell_size, cell_size, cell_size)
					cc.set_line_width(line_width)
					cc.set_source_rgb(0, 0, 0)
					cc.stroke()
			# Flush drawing actions
			db.flush()
		else:
			print('Invalid double buffer')

def banner():
	print("Dark Heresy random character generator.")
	print("Copyright (c) 2013 by Ronaldo Nascimento")
	print(
		"""
Dark Heresy collection is © Games Workshop Limited 2008-2012. Games Workshop
, Warhammer 40,000, Warhammer 40,000 Role Play, Dark Heresy, the foregoing 
marks' respective logos, Rogue Trader, Dark Heresy and all associated marks,
logos, places, names, creatures, races and race insignia/devices/logos/
symbols, vehicles, locations, weapons, units and unit insignia, characters, 
products and illustrations from the Warhammer 40,000 universe and the Dark 
Heresy game setting are either ®, TM and/or © Games Workshop Ltd 2000–2013, 
variably registered in the UK and other countries around the world. This 
edition published under license to Fantasy Flight Publishing Inc. All Rights
Reserved to their respective owners.
		""")

def battle():
	banner()
	builder = Gtk.Builder()
	builder.add_from_file(join(RESOURCES,"battle.glade"))
	builder.connect_signals(Handler())
	window = builder.get_object("window1")
	drawingarea1 = builder.get_object("drawingarea1")
	window.show_all()
	Gtk.main()

if __name__ == '__main__':
	battle()
