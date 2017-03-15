#!/usr/bin/pypy
# -*- coding: utf8 -*-

MAXNUM = 3000000

import math
import threading

primct = 0
sem_globi = threading.Semaphore()
sem_pct = threading.Semaphore()

def primtest_thread():
    global sem
    global globi
    global primct

    while (1):
	with sem_globi:
	    globi-=1
	    i=globi
	if i < 2: return # end
	prim = True
	sqi = int(math.sqrt(i))
	for j in xrange(2, sqi+1):
	    if not (i%j):
		prim=False
		break
	if prim == True:
	    with sem_pct:
		primct+=1

if __name__ == '__main__':
    globi = MAXNUM
    gprimct = 0
    procs = [threading.Thread(target=primtest_thread, args=()) for i in range(8)]

    for p in procs: p.start()
    for p in procs: p.join()

    print primct
