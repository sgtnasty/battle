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

__author__ = "Ronaldo Nascimento <ronaldo1@users.sf.net>"
__version__ = "0.1"
__copyright_ = "Copyright (c) 2013 by Ronaldo Nascimento"
__license__ = "GPL"

from gi.repository import Gtk, Gdk, GObject
from os.path import abspath, dirname, join
import random, string, math, cairo

RESOURCES = abspath(dirname(__file__))

class Throw():
    def __init__(self, dietype, result):
        self.dietype = dietype
        self.result = result
        
    def __str__(self):
        return '1d%s= %d' % (self.dietype, self.result)

class Session():
    def __init__(self):
        self.throws = []
        self.total = 0
        self.minthrow = 999999
        self.maxthrow = 0
        self.avgthrow = 0.0
        
    def addThrow(self, throw):
        self.throws.append(throw)
        self.total = self.total + throw.result
        if (throw.result < self.minthrow):
            self.minthrow = throw.result
        if (throw.result > self.maxthrow):
            self.maxthrow = throw.result
        self.avgthrow = self.total / len(self.throws)
        
    def __str__(self):
        return "%d throw(s) for a total of %d" % (len(self.throws), self.total)

    def stats(self):
       return 'Results for %d roll(s): min=%d, avg=%.2f, max=%d' % (len(self.throws), self.minthrow, self.avgthrow, self.maxthrow)

current_session = Session()
    
class Handler():
    def on_window1_delete_event(self, *args):
        Gtk.main_quit(*args)

    def on_d4toolbutton_clicked(self, *args):
        for i in range(spinbutton1.get_value_as_int()):
            roll(4)

    def on_d6toolbutton_clicked(self, *args):
        for i in range(spinbutton1.get_value_as_int()):
            roll(6)

    def on_d8toolbutton_clicked(self, *args):
        for i in range(spinbutton1.get_value_as_int()):
            roll(8)

    def on_d10toolbutton_clicked(self, *args):
        for i in range(spinbutton1.get_value_as_int()):
            roll(10)

    def on_d12toolbutton_clicked(self, *args):
        for i in range(spinbutton1.get_value_as_int()):
            roll(12)

    def on_d20toolbutton_clicked(self, *args):
        for i in range(spinbutton1.get_value_as_int()):
            roll(20)

    def on_d100toolbutton_clicked(self, *args):
        for i in range(spinbutton1.get_value_as_int()):
            roll(100)

    def on_cleartoolbutton_clicked(self, *args):
        global current_session
        textbuffer.set_text('')
        statusbar1.push(0, 'Cleared, average reset')
        # add the current_session to the history tree
        iter = store.append()
        store.set(iter, 0, current_session)
        store.set(iter, 1, str(current_session))
        # clear the current_session
        print(current_session)
        current_session = Session()
        
    def on_abouttoolbutton_clicked(self, *args):
        aboutdlg = Gtk.AboutDialog()
        aboutdlg.set_program_name("Roller")
        aboutdlg.set_version("0.1")
        aboutdlg.set_copyright("Ronaldo Nascimento")
        aboutdlg.set_comments("A die rolling utility")
        aboutdlg.set_license("GNU GENERAL PUBLIC LICENSE v3 http://www.gnu.org/licenses/gpl-3.0.txt")
        aboutdlg.set_website("http://github.com/sgtnasty/battle")
        aboutdlg.set_authors(["Ronaldo Nascimento <ronaldo1@users.sf.net>"])
        aboutdlg.set_artists(["Ronaldo Nascimento <ronaldo1@users.sf.net>"])
        aboutdlg.run()
        aboutdlg.destroy()
    
def roll(die):
    global current_session
    x = random.randint(1, die)
    throw = Throw(die, x)
    current_session.addThrow(throw)
    statusbar1.push(0, current_session.stats())
    add_result(throw)

def add_result(throw):
    global current_session
    iter = textbuffer.get_end_iter()
    textbuffer.place_cursor(iter)
    #textbuffer.insert_at_cursor('1d%s= %d for a total of %d\n' % (die, result, total))
    textbuffer.insert_at_cursor(str(throw))
    textbuffer.insert_at_cursor('\n')
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
    cell_renderer1 = Gtk.CellRendererText()
    tvcolumn1.pack_start(cell_renderer1, True)
    tvcolumn1.add_attribute(cell_renderer1, 'text', 1)
    #store = Gtk.ListStore(str)
    store = Gtk.ListStore(GObject.TYPE_PYOBJECT, str)
    treeview1.set_model(store)
    # spin button
    spinbutton1 = builder.get_object("spinbutton1")
    #status bar interface
    statusbar1 = builder.get_object("statusbar1")
    window.show_all()
    Gtk.main()
