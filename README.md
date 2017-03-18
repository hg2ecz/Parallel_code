# Parallel_code
How to run code on multicore CPU?

[![Build Status](https://travis-ci.org/fuszenecker/Parallel_code.svg?branch=master)](https://travis-ci.org/fuszenecker/Parallel_code)

# Test result on Raspberry Pi3:

<table>
<tr><th>Prog</th><th>normal modulo</th><th>floatdiv</th></tr>
<tr><td>(C-OpenMP-)noparallel<td>17.204s</td><td>7.631s</td></tr>
<tr><td colspan="2">LUA-noparallel (LuaJIT)<td>14.606s</td></tr>
<tr><td colspan="2">Python-noparallel (Pypy)<td>27.347s</td></tr>

<tr><th colspan="2">Parallel</th></tr>
<tr><td>C-OpenMP<td>4.706s</td><td>2.071s</td></tr>
<tr><td>C-pthread<td>4.407s</td><td>2.040s</td></tr>
<tr><td>C++-for_each<td>4.632s</td><td>1.934s</td></tr>

<tr><td colspan="2">C#-Linq<td>8.290s</td></tr>
<tr><td colspan="2">C#-ParallelFor<td>8.159s</td></tr>
<tr><td colspan="2">C#-Tasks<td>7.699s</td></tr>

<tr><td colspan="2">Python-multiprocessing (Pypy)<td>18.273s</td></tr>
<tr><td colspan="2">Python-thread-verySlow (Pypy)<td>119.7s</td></tr>
</table>
