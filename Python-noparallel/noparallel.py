#!/usr/bin/pypy
# -*- coding: utf8 -*-

MAXNUM = 3000000

import math

if __name__ == '__main__':
    i = MAXNUM
    primct = 0
    for i in xrange(MAXNUM, 1, -1):
	prim = True
	sqi = int(math.sqrt(i))
	for j in xrange(2, sqi+1):
	    if not (i%j):
		prim=False
		break
	if prim == True:
	    primct+=1

    print primct
