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

def roll2d10(min_roll):
	x = 0
	y = 0
	while (x < min_roll):
		x = random.randint(1,10)
	while (y < min_roll):
		y = random.randint(1,10)
	return (x + y)

def rolld10():
	return random.randint(1,10)
	
def rolld100():
	return (random.randint(1,10)) * 10 + random.randint(1,10)
	
def Significance(value):
	if (value < 16):
		return "Feeble"
	elif (value < 21):
		return "Poor"
	elif (value < 26):
		return "Inferior"
	elif (value < 36):
		return "Average"
	elif (value < 41):
		return "Superior"
	elif (value < 46):
		return "Great"
	elif (value < 51):
		return "Magnificent"
	else:
		return "Heroic - A Daemon's Willpower!"
	
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
		self.hwbase = {}
		self.careers = []
		self.career = ''
		self.wounds = 0
		self.fate = 0
		
	
	def generateHomeworld(self):
		x = rolld100()
		if (x >= 1 and x <= 20):
			self.homeworld = "Feral World"
			self.hwbase = {'WS': 20, 'BS':20, 'S':25, 'T':25, 'Ag':20, 'Int':20, 'Per':20, 'WP':15, 'Fel':15 }
			self.careers = ['Assasin', 'Guardsman', 'Imperial Psyker', 'Scum']
		elif (x > 20 and x <= 45):
			self.homeworld = "Hive World"
			self.hwbase = {'WS': 20, 'BS':20, 'S':20, 'T':15, 'Ag':20, 'Int':20, 'Per':20, 'WP':20, 'Fel':25 }
			self.careers = ['Arbitrator', 'Assasin', 'Cleric', 'Guardsman', 'Imperial Psyker', 'Scum', 'Tech-Priest']
		elif (x > 45 and x <= 90):
			self.homeworld = "Imperial World"
			self.hwbase = {'WS': 20, 'BS':20, 'S':20, 'T':20, 'Ag':20, 'Int':20, 'Per':20, 'WP':20, 'Fel':20 }
			self.careers = ['Adept', 'Arbitrator', 'Assasin', 'Cleric', 'Guardsman', 'Imperial Psyker', 'Scum', 'Tech-Priest']
		else:
			self.homeworld = "Void Born"
			self.hwbase = {'WS': 20, 'BS':20, 'S':15, 'T':20, 'Ag':20, 'Int':20, 'Per':20, 'WP':25, 'Fel':20 }
			self.careers = ['Adept', 'Arbitrator', 'Assasin', 'Cleric', 'Imperial Psyker', 'Scum', 'Tech-Priest']
		
	def generateStats(self, min_roll = 1):
		self.stats.weaponskill = roll2d10(min_roll) + self.hwbase['WS']
		self.stats.ballisticskill = roll2d10(min_roll) + self.hwbase['BS']
		self.stats.strength = roll2d10(min_roll) + self.hwbase['S']
		self.stats.toughness = roll2d10(min_roll) + self.hwbase['T']
		self.stats.agility = roll2d10(min_roll) + self.hwbase['Ag']
		self.stats.intelligence = roll2d10(min_roll) + self.hwbase['Int']
		self.stats.perception = roll2d10(min_roll) + self.hwbase['Per']
		self.stats.willpower = roll2d10(min_roll) + self.hwbase['WP']
		self.stats.fellowship = roll2d10(min_roll) + self.hwbase['Fel']
		
	def generateCareer(self):
		x = rolld100()
		if (self.homeworld == 'Feral World'):
			if (x < 31):
				self.career = self.careers[0]
			elif (x<81):
				self.career = self.careers[1]
			elif (x<91):
				self.career = self.careers[2]
			else:
				self.career = self.careers[3]
		elif (self.homeworld == 'Hive World'):
			if (x<18):
				self.career = self.careers[0]
			elif (x<21):
				self.career = self.careers[1]
			elif (x<26):
				self.career = self.careers[2]
			elif (x<36):
				self.career = self.careers[3]
			elif (x<41):
				self.career = self.careers[4]
			elif (x<90):
				self.career = self.careers[5]
			else:
				self.career = self.careers[6]
		elif (self.homeworld == 'Imperial World'):
			if (x<13):
				self.career = self.careers[0]
			elif (x<26):
				self.career = self.careers[1]
			elif (x<39):
				self.career = self.careers[2]
			elif (x<53):
				self.career = self.careers[3]
			elif (x<66):
				self.career = self.careers[4]
			elif (x<80):
				self.career = self.careers[5]
			elif (x<91):
				self.career = self.careers[6]
			else:
				self.career = self.careers[7]
		elif (self.homeworld == 'Void Born'):
			if (x<11):
				self.career = self.careers[0]
			elif (x<21):
				self.career = self.careers[1]
			elif (x<26):
				self.career = self.careers[2]
			elif (x<36):
				self.career = self.careers[3]
			elif (x<76):
				self.career = self.careers[4]
			elif (x<86):
				self.career = self.careers[5]
			else:
				self.career = self.careers[6]
				
	def generateWounds(self):
		if (self.homeworld == 'Feral World'):
			self.wounds = random.randint(1,5) + 9
		elif (self.homeworld == 'Hive World'):
			self.wounds = random.randint(1,5) + 8
		elif (self.homeworld == 'Imperial World'):
			self.wounds = random.randint(1,5) + 8
		elif (self.homeworld == 'Void Born'):
			self.wounds = random.randint(1,5) + 6

	def generateFate(self):
		x = rolld10()
		if (self.homeworld == 'Feral World'):
			if (x < 4):
				self.fate = 1
			else:
				self.fate = 2
		elif (self.homeworld == 'Hive World'):
			if (x<4):
				self.fate = 1
			elif (x<9):
				self.fate = 2
			else:
				self.fate = 3
		elif (self.homeworld == 'Imperial World'):
			if (x<4):
				self.fate = 2
			elif (x<9):
				self.fate = 2
			else:
				self.fate = 3
		elif (self.homeworld == 'Void Born'):
			if (x<4):
				self.fate = 2
			elif (x<9):
				self.fate = 3
			else:
				self.fate = 3
	
if __name__ == '__main__':
	random.seed()
	pc = PC()
	print("***** STAGE 1: HOMEWORLD")
	pc.generateHomeworld()
	print(pc.homeworld)
	print("**** STAGE 2: GENERATE CHARACTERISTICS")
	pc.generateStats(7)
	print("WS : %02d    %s" % (pc.stats.weaponskill, Significance(pc.stats.weaponskill)))
	print("BS : %02d    %s" % (pc.stats.ballisticskill, Significance(pc.stats.ballisticskill)))
	print("S  : %02d    %s" % (pc.stats.strength, Significance(pc.stats.strength)))
	print("T  : %02d    %s" % (pc.stats.toughness, Significance(pc.stats.toughness)))
	print("Ag : %02d    %s" % (pc.stats.agility, Significance(pc.stats.agility)))
	print("Int: %02d    %s" % (pc.stats.intelligence, Significance(pc.stats.intelligence)))
	print("Per: %02d    %s" % (pc.stats.perception, Significance(pc.stats.perception)))
	print("WP : %02d    %s" % (pc.stats.willpower, Significance(pc.stats.willpower)))
	print("Fel: %02d    %s" % (pc.stats.fellowship, Significance(pc.stats.fellowship)))
	#print('Available careers: ', end="")
	#print(pc.careers)
	print("***** STAGE 3: DETERMINE CAREER PATH")
	pc.generateCareer()
	print(pc.career)
	print("***** STAGE 4: SPEND EXPERIENCE POINTS, BUY EQUIPMENT")
	pc.generateWounds()
	print("Wounds = %d" % pc.wounds)
	pc.generateFate()
	print("Fate = %d" % pc.fate)
