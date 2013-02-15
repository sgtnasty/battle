#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
	Random character generation.
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

import random

def rolld10():
	return random.randint(1,10)
	
def rolld100():
	return (random.randint(1,10)) * 10 + random.randint(1,10)
	
class Stats:
	def __init__(self):
		self.weaponskill = 0
		self.ballisticskill = 0
		self.strength = 0
		self.toughness = 0
		self.agility = 0
		self.intelligence = 0
		self.perception = 0
		self.willpower = 0
		self.fellowship = 0

class PC:
	def __init__(self):
		self.stats = Stats()
		self.homeworld = ''
	
	def generateHomeworld(self):
		x = rolld100()
		if (x >= 1 and x <= 20):
			self.homeworld = "Feral World"
		elif (x > 20 and x <= 45):
			self.homeworld = "Hive World"
		elif (x > 45 and x <= 90):
			self.homeworld = "Imperial World"
		else:
			self.homeworld = "Void Born"
		
	def generateStats(self):
		self.stats.weaponskill = rolld10()+rolld10()+20
		self.stats.ballisticskill = rolld10()+rolld10()+20
		self.stats.strength = rolld10()+rolld10()+20
		self.stats.toughness = rolld10()+rolld10()+20
		self.stats.agility = rolld10()+rolld10()+20
		self.stats.intelligence = rolld10()+rolld10()+20
		self.stats.perception = rolld10()+rolld10()+20
		self.stats.willpower = rolld10()+rolld10()+20
		self.stats.fellowship = rolld10()+rolld10()+20
	
if __name__ == '__main__':
	random.seed()
	pc = PC()
	print("STAGE 1: HOMEWORLD")
	pc.generateHomeworld()
	print(pc.homeworld)
	print("STAGE 2: GENERATE CHARACTERISTICS")
	pc.generateStats()
	print("WS : %02d" % pc.stats.weaponskill)
	print("BS : %02d" % pc.stats.ballisticskill)
	print("S  : %02d" % pc.stats.strength)
	print("T  : %02d" % pc.stats.toughness)
	print("Ag : %02d" % pc.stats.agility)
	print("Int: %02d" % pc.stats.intelligence)
	print("Per: %02d" % pc.stats.perception)
	print("WP : %02d" % pc.stats.willpower)
	print("Fel: %02d" % pc.stats.fellowship)
