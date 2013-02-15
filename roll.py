#!/usr/bin/env python3

import random

def roll3d6():
	a = random.randint(1,6)
	b = random.randint(1,6)
	c = random.randint(1,6)
	#print('\t%d %d %d = %d' % (a,b,c, (a+b+c)))
	return a + b + c
	
def rollset():
	s = roll3d6()
	d = roll3d6()
	i = roll3d6()
	t = roll3d6()
	w = roll3d6()
	c = roll3d6()
	tot = s + d + i + t + w + c
	avg = tot/6.0
	if (avg > 16.0):
		#print("*************************************************** BAM")
		print('%02d  %02d  %02d  %02d  %02d  %02d    > %f' % (s,d,i,t,w,c, avg))
	
def rollsets(count):
	for n in range(count):
		rollset()

random.seed()
print('%(language)s has %(#)03d quote types.' % {'language': "Python", "#": 2})
print("STR DEX INT CON WIS CHA   > Avg")
rollsets(10000000)
