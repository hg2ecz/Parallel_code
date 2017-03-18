# Parallel_code
How to run code on multicore CPU?

[![Build Status](https://travis-ci.org/fuszenecker/Parallel_code.svg?branch=master)](https://travis-ci.org/fuszenecker/Parallel_code)

# Test result on Raspberry Pi3:

<table style="text-al>
<tr><th>Prog</th><th>normal modulo</th><th>floatdiv</th></tr>
<tr><td>C-noparallel</td><td>17.204s</td><td>7.631s</td></tr>
<tr><td>LUA-noparallel (LuaJIT)</td><td colspan="2">14.606s</td></tr>
<tr><td>Python-noparallel (Pypy)</td><td colspan="2">27.347s</td></tr>

<tr><th colspan="3">Parallel on 4 cores</th></tr>
<tr><td>C-OpenMP</td><td>4.706s</td><td>2.071s</td></tr>
<tr><td>C-pthread</td><td>4.407s</td><td>2.040s</td></tr>
<tr><td>C++-for_each</td><td>4.632s</td><td>1.934s</td></tr>

<tr><td>C#-Linq</td><td colspan="2">8.290s</td></tr>
<tr><td>C#-ParallelFor</td><td colspan="2">8.159s</td></tr>
<tr><td>C#-Tasks</td><td colspan="2">7.699s</td></tr>

<tr><td>Python-multiprocessing (Pypy)</td><td colspan="2">18.273s</td></tr>
<tr><td>Python-thread-verySlow (Pypy)</td><td colspan="2">119.7s</td></tr>
</table>
