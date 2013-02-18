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
	
def significance(value):
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
			self.hwbase = {'WS': 20, 'BS':20, 'S':25, 'T':25, 'Ag':20, \
				'Int':20, 'Per':20, 'WP':15, 'Fel':15 }
			self.careers = ['Assasin', 'Guardsman', 'Imperial Psyker', 'Scum']
		elif (x > 20 and x <= 45):
			self.homeworld = "Hive World"
			self.hwbase = {'WS': 20, 'BS':20, 'S':20, 'T':15, 'Ag':20, \
				'Int':20, 'Per':20, 'WP':20, 'Fel':25 }
			self.careers = ['Arbitrator', 'Assasin', 'Cleric', 'Guardsman', \
				'Imperial Psyker', 'Scum', 'Tech-Priest']
		elif (x > 45 and x <= 90):
			self.homeworld = "Imperial World"
			self.hwbase = {'WS': 20, 'BS':20, 'S':20, 'T':20, 'Ag':20, \
				'Int':20, 'Per':20, 'WP':20, 'Fel':20 }
			self.careers = ['Adept', 'Arbitrator', 'Assasin', 'Cleric', \
				'Guardsman', 'Imperial Psyker', 'Scum', 'Tech-Priest']
		else:
			self.homeworld = "Void Born"
			self.hwbase = {'WS': 20, 'BS':20, 'S':15, 'T':20, 'Ag':20, \
				'Int':20, 'Per':20, 'WP':25, 'Fel':20 }
			self.careers = ['Adept', 'Arbitrator', 'Assasin', 'Cleric', \
				'Imperial Psyker', 'Scum', 'Tech-Priest']
		
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

def one_or_other(one, other):
	x = random.randint(0,1)
	if (x == 0):
		return one
	else:
		return other

def one_or_other_or(one, other, orther):
	x = random.randint(0,2)
	if (x == 0):
		return one
	elif (x == 1):
		return other
	else:
		return orther

class Career:
	def __init__(self, pc):
		self.skills = []
		self.talents = []
		self.traits = []
		self.gear = []
		self.rank = 1
		self.title = pc.career
		if (pc.career == 'Adept'):
			self.skills = ['Speak Language (Low Gothic)', 'Literacy', one_or_other('Trade (Copyist)','Trade (Valet)'), 'Common Lore (Imperium)', 'Scholastic Lore (Legend)']
			self.talents = [one_or_other('Melee Weapon Training (Primitive)', 'Pistol Training (SP)'), one_or_other('Light Sleeper', 'Resistance (Cold),'), one_or_other('Sprint', 'Unremarkable')]
			self.gear = [one_or_other('Stub revolver and 6 bullets', 'staff'), 'Administratum robes (Common Quality Clothing)', one_or_other('auto-quill','writing kit'), one_or_other('chrono','hour glass'), one_or_other('data-slate','illuminated'),'tome', 'backpack']
			self.traits = []
			self.rank = 1
			self.title = 'Rank 1: Archivist'
			self.skills.append('Drive (Ground Vehicle)')
			self.skills.append('Common Lore (Administratum)')
			self.talents.append('Sound Constitution')
			pc.stats.intelligence = pc.stats.intelligence + 5
		elif pc.career =='Arbitrator':
			self.skills = ['Speak Language (Low Gothic)','Literacy', 'Common Lore (Adeptus Arbites)', 'CommonLore (Imperium)', 'Inquiry (Fel)']
			self.talents = ['Basic Weapons Training (SP)', 'Melee Weapon Training (Primitive)', one_or_other('Quick Draw', 'Rapid Reload')]
			self.gear = ['Shotgun and 12 shells', 'club', 'brass knuckles', 'knife', one_or_other_or('chain coat','flak vest', 'mesh vest'), 'uniform (Good Quality Clothing)', '3 doses of stimm', 'injector', 'Arbitrator ID', 'chrono', one_or_other('pack of lho-sticks','flask of amasec')]
			self.traits = []
			self.rank = 1
			self.title = 'Rank 1: Trooper'
			pc.stats.ballisticskill = pc.stats.ballisticskill + 5
			#self.skills.append(
		elif pc.career =='Assasin':
			self.skills = ['Speak Language (Low Gothic)', 'Awareness', 'Dodge']
			self.talents = ['Melee Weapon Training (Primitive)', one_or_other('Ambidextrous','Unremarkable'), one_or_other('Thrown Weapon Training', 'Pistol Training (Las)'), 'Basic Weapon Training (SP)', 'Pistol Training (SP)']
			self.gear = [one_or_other_or('Shotgun and 12 shells','hunting rifle and 16 rounds','autogun and 1 clip'), 'sword', 'knife', one_or_other('compact las pistol and 1 charge pack','10 throwing knives'), '3 doses of stimm', 'charm (corpse hair)', 'black bodyglove (Common Quality Clothing)']
			self.traits = []
			self.rank = 1
			self.title = 'Rank 1: Sell Steel'
		elif pc.career =='Cleric':
			self.skills = ['Speak Language (Low Gothic)','Common Lore (Imperial Creed)', 'Literacy', one_or_other('Performer (Singer)','Trade (Copyist)'), one_or_other('Trade (Cook)','Trade (Valet)')]
			self.talents = ['Melee Weapon Training (Primitive)','Pistol Training (SP)', one_or_other('Basic Weapon Training (Primitive)','Thrown Weapon Training (Primitive)')]
			self.gear = [one_or_other('Hammer','sword'), one_or_other('stub revolver and 6 bullets','autopistol and 1 clip'), one_or_other('crossbow and 10 bolts','5 throwing knives'), one_or_other('chain coat','flak vest'), 'aquila necklace', 'Ecclesiarchy robes (Good Quality Clothing)', '4 candles', 'charm (skull)', 'backpack']
			self.traits = []
			self.rank = 1
			self.title = 'Rank 1: Novice'
		elif pc.career =='Guardsman':
			self.skills = ['Speak Language (Low Gothic)', one_or_other('Drive (Ground Vehicle)','Swim')]
			self.talents = ['Melee Weapon Training (Primitive)', one_or_other('Pistol Training (Primitive)','Pistol Training (Las)'), 'Basic Weapons Training (Las)', one_or_other('Basic Weapon Training (Primitive)','Basic Weapons Training (SP)')]
			self.gear = [one_or_other_or('Sword','axe','hammer'), one_or_other('flintlock pistol and 12 shots','las pistol and 1 charge pack'), 'lasgun and 1 charge pack', one_or_other_or('bow and 10 arrows','musket and 12 shots','shotgun and 12 shells'), 'knife', 'guard flak armour', one_or_other('uniform or stealth gear','street clothes (Common Quality Clothing)'), '1 week corpse starch rations', one_or_other_or('mercenary licence','explosive collar (still attached)','Imperial Infantryman’s Uplifting Primer')]
			self.traits = []
			self.rank = 1
			self.title = 'Rank 1: Conscript'
		elif pc.career =='Imperial Psyker':
			self.skills = ['Speak Language (Low Gothic)', 'Psyniscience', 'Invocation', one_or_other('Trade (Merchant)','Trade (Soothsayer)'), 'Literacy']
			self.talents = ['Melee Weapon Training (Primitive)', one_or_other('Pistol Weapon Training (SP)','Pistol Weapon Training (Las)'), 'Psy Rating 1']
			self.gear = [one_or_other('Axe','sword'), 'staff', one_or_other('impact stub revolver and 3 bullets','compact las pistol and 1 charge pack'), 'knife (psykana mercy blade)', 'quilted vest', 'tatty robe (Poor Quality Clothing)', one_or_other_or('book of Imperial saints','or deck of cards','dice'), 'Psy-Focus', 'sanctioning brand']
			self.traits = []
			self.rank = 1
			self.title = 'Sanctionite'
			self.sanctioning()
		elif pc.career =='Scum':
			self.skills = ['Speak Language (Low Gothic)', 'Blather', one_or_other('Charm','Dodge'), 'Deceive', 'Awareness', 'Common Lore (Imperium)']
			self.talents = [one_or_other('Ambidextrous','Unremarkable'), 'Melee Weapon Training (Primitive)', 'Pistol Training (SP)', 'Basic Weapon Training (SP)']
			self.gear = [one_or_other('Autogun and 1 clip','shotgun and 12 shells'), 'autopistol and 1 clip', one_or_other('brass knuckles','club'), 'knife', one_or_other('quilted vest','beast furs'), one_or_other_or('street ware','Rags','dirty coveralls (Poor Quality Clothing)')]
			self.traits = []
			self.rank = 1
			self.title = 'Dreg'
		elif pc.career =='Tech-Priest':
			self.skills = ['Speak Language (Low Gothic)', 'Tech-Use', 'Literacy', 'Secret Tongue (Tech)', one_or_other('Trade (Scrimshawer)','Trade (Copyist)')]
			self.talents = ['Melee Weapon Training (Primitive)', 'Basic Weapon Training (Las)', 'Pistol Training (Las)', 'Electro Graft Use']
			self.traits = ['Mechanicus Implants']
			self.gear = ['Metal staff', 'las pistol and 1 charge pack', 'las carbine and 1 charge pack', 'knife', 'flak vest', 'glow lamp', 'data-slate', 'Mechanicus robes and vestments (Good Quality Clothing)', '1d10 spare parts (power cells, wires, chronometers etc)', 'vial of Sacred Machine Oil']
			self.rank = 1
			self.title = 'Technographer'
	def sanctioning(self):
		x = random.randint(1,100)
		if (x<9):
			self.traits = ['Reconstructed Skull']
		elif (x<15):
			self.traits = ['Hunted']
		elif (x<26):
			self.traits = ['Unlovely Memories']
		elif (x<36):
			self.traits = ['The Horror, the Horror']
		elif (x<43):
			self.traits = ['Pain through Nerve Induction']
		elif (x<50):
			self.traits = ['Dental Probes']
		elif (x<58):
			self.traits = ['Optical Rupture']
		elif (x<64):
			self.traits = ['Screaming Devotions']
		elif (x<71):
			self.traits = ['Irradience']
		elif (x<76):
			self.traits = ['Tongue Bound']
		elif (x<89):
			self.traits = ['Throne Wed']
		elif (x<95):
			self.traits = ['Witch Prickling']
		else:
			self.traits = ['Hypno-doctrination']

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
	
if __name__ == '__main__':
	banner()
	random.seed()
	print("***** DARK HERESY")
	pc = PC()
	print("***** STAGE 1: HOMEWORLD")
	pc.generateHomeworld()
	print(pc.homeworld)
	print("**** STAGE 2: GENERATE CHARACTERISTICS")
	pc.generateStats(2)
	print("WS : %02d    %s" % (pc.stats.weaponskill, \
		significance(pc.stats.weaponskill)))
	print("BS : %02d    %s" % (pc.stats.ballisticskill, \
		significance(pc.stats.ballisticskill)))
	print("S  : %02d    %s" % (pc.stats.strength, \
		significance(pc.stats.strength)))
	print("T  : %02d    %s" % (pc.stats.toughness, \
		significance(pc.stats.toughness)))
	print("Ag : %02d    %s" % (pc.stats.agility, \
		significance(pc.stats.agility)))
	print("Int: %02d    %s" % (pc.stats.intelligence, \
		significance(pc.stats.intelligence)))
	print("Per: %02d    %s" % (pc.stats.perception, \
		significance(pc.stats.perception)))
	print("WP : %02d    %s" % (pc.stats.willpower, \
		significance(pc.stats.willpower)))
	print("Fel: %02d    %s" % (pc.stats.fellowship, \
		significance(pc.stats.fellowship)))
	#print('Available careers: ', end="")
	#print(pc.careers)
	print("***** STAGE 3: DETERMINE CAREER PATH")
	pc.generateCareer()
	print(pc.career)
	career = Career(pc)
	print('Skills ---------------------')
	print(career.skills)
	print('Talents --------------------')
	print(career.talents)
	print('Traits ---------------------')
	print(career.traits)
	print('Gear -----------------------')
	print(career.gear)
	print('Title ----------------------')
	print(career.title)
	print("***** STAGE 4: SPEND EXPERIENCE POINTS, BUY EQUIPMENT")
	pc.generateWounds()
	print("Wounds = %d" % pc.wounds)
	pc.generateFate()
	print("Fate = %d" % pc.fate)
