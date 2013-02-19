#!/usr/bin/env python3
# -*- coding: utf-8 -*-
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

class Handler():
    def on_window1_delete_event(self, *args):
        Gtk.main_quit(*args)

    def on_d4toolbutton_clicked(self, *args):
        add_result('d4', random.randint(1, 4))

    def on_d6toolbutton_clicked(self, *args):
        add_result('d6', random.randint(1, 6))

    def on_d8toolbutton_clicked(self, *args):
        add_result('d8', random.randint(1, 8))

    def on_d10toolbutton_clicked(self, *args):
        add_result('d10', random.randint(1, 10))

    def on_d12toolbutton_clicked(self, *args):
        add_result('d12', random.randint(1, 12))

    def on_d20toolbutton_clicked(self, *args):
        add_result('d20', random.randint(1, 20))

    def on_d100toolbutton_clicked(self, *args):
        add_result('d100', random.randint(1, 100))

    def on_cleartoolbutton_clicked(self, *args):
        textbuffer.set_text('')

def add_result(die, result):
    textbuffer.insert_at_cursor('%s= %d\n' % (die, result))

if __name__ == '__main__':
    builder = Gtk.Builder()
    builder.add_from_file(join(RESOURCES,"roller.glade"))
    builder.connect_signals(Handler())
    window = builder.get_object("window1")
    textview1 = builder.get_object("textview1")
    textbuffer = textview1.get_buffer()

    treeview1 = builder.get_object("treeview1")
    tvcolumn1 = Gtk.TreeViewColumn('History')
    treeview1.append_column(tvcolumn1)
    cell_renderer = Gtk.CellRendererText()
    tvcolumn1.pack_start(cell_renderer, True)
    tvcolumn1.add_attribute(cell_renderer, 'text', 0)

    store = Gtk.ListStore(str)
    treeview1.set_model(store)

    window.show_all()
    Gtk.main()
