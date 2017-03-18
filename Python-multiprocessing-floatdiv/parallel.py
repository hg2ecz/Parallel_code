#!/usr/bin/pypy
# -*- coding: utf8 -*-

MAXNUM = 3000000

import math
from multiprocessing import Process, Value, Lock


def primtest_thread(vi, primct):
    while (1):
	with vi.get_lock():
	    i=vi.value
	    vi.value-=1
	if i < 2: return # end
	prim = True
	sqi = int(math.sqrt(i))
	for j in xrange(2, sqi+1):
	    if not (i - j*int((float(i))/j)): # i%j .. faster on ARM Cortex if without hw int div
		prim=False
		break
	if prim == True:
	    with primct.get_lock():
		primct.value+=1

if __name__ == '__main__':
    globi = Value('i', MAXNUM)
    gprimct = Value('i', 0)
    procs = [Process(target=primtest_thread, args=(globi, gprimct)) for i in range(8)]

    for p in procs: p.start()
    for p in procs: p.join()

    print gprimct.value
