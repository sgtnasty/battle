#!/usr/bin/env python3
# -*- coding: utf-8 -*-
# -*- Mode: Python; py-indent-offset: 4 -*-
# vim: tabstop=4 shiftwidth=4 expandtab
"""
	A die roller.
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
# stats
total = 0
avg = 0.0
minroll = 9999999
maxroll = 0
rollsmade = 0
	
class Handler():
	def on_window1_delete_event(self, *args):
		Gtk.main_quit(*args)

	def on_d4toolbutton_clicked(self, *args):
		roll(4)

	def on_d6toolbutton_clicked(self, *args):
		roll(6)

	def on_d8toolbutton_clicked(self, *args):
		roll(8)

	def on_d10toolbutton_clicked(self, *args):
		roll(10)

	def on_d12toolbutton_clicked(self, *args):
		roll(12)

	def on_d20toolbutton_clicked(self, *args):
		roll(20)

	def on_d100toolbutton_clicked(self, *args):
		roll(100)

	def on_cleartoolbutton_clicked(self, *args):
		global total, avg, minroll, maxroll, rollsmade
		textbuffer.set_text('')
		statusbar1.push(0, 'Cleared, average reset')
		total = 0
		avg = 0.0
		minroll = 9999999
		maxroll = 0
		rollsmade = 0
	
def roll(die):
	global total, avg, minroll, maxroll, rollsmade
	x = random.randint(1, die)
	total = total + x
	rollsmade = rollsmade + 1
	if (x<minroll):
		minroll = x
	if (x>maxroll):
		maxroll = x
	avg = total / rollsmade
	statusbar1.push(0, 'Results for %d roll(s): min=%d, avg=%.2f, max=%d' % (rollsmade, minroll, avg, maxroll))
	add_result(die, x)

def add_result(die, result):
	global total
	iter = textbuffer.get_end_iter()
	textbuffer.place_cursor(iter)
	textbuffer.insert_at_cursor('1d%s= %d for a total of %d\n' % (die, result, total))
	iter = textbuffer.get_end_iter()
	textview1.scroll_to_iter(iter, 0.0, False, 0, 0)

if __name__ == '__main__':
	builder = Gtk.Builder()
	builder.add_from_file(join(RESOURCES,"roller.glade"))
	builder.connect_signals(Handler())
	window = builder.get_object("window1")
	textview1 = builder.get_object("textview1")
	textbuffer = textview1.get_buffer()
	# treeview interface
	treeview1 = builder.get_object("treeview1")
	tvcolumn1 = Gtk.TreeViewColumn('History')
	treeview1.append_column(tvcolumn1)
	cell_renderer = Gtk.CellRendererText()
	tvcolumn1.pack_start(cell_renderer, True)
	tvcolumn1.add_attribute(cell_renderer, 'text', 0)
	store = Gtk.ListStore(str)
	treeview1.set_model(store)
	#status bar interface
	statusbar1 = builder.get_object("statusbar1")
	window.show_all()
	Gtk.main()
