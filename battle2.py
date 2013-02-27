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

import random

def roll():
    return random.randint(1,6) + random.randint(1,6) + random.randint(1,6)

class Entity(object):
    """docstring for Entity"""
    def __init__(self, name = 'Unknown'):
        self.name = name
        self.attack = 5
        self.defence = 5
        self.hits = 0
        self.speed = 5
    def attack(self, target):
        result = roll() + self.attack - target.defend()
        if (result > 0):
            print("HIT!")
        else:
            print("MISS!")
    def defend(self):
        return roll() + self.defend
    def __repr__(self):
        return '\"%s\".{atk: %d, def: %d}' % (self.name, self.attack, self.defence)

if __name__ == '__main__':
    print("battle/2")
    red = Entity('Red')
    red.attack = 6
    red.defence = 4
    print(red)
    blue = Entity('Blue')
    blue.attack = 4
    blue.defence = 6
    print(blue)
    red.attack(blue)
    blue.attack(red)
