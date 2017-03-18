# Parallel_code
How to run code on multicore CPU?

[![Build Status](https://travis-ci.org/fuszenecker/Parallel_code.svg?branch=master)](https://travis-ci.org/fuszenecker/Parallel_code)

# Test result on Raspberry Pi3 and Odroid-C2:

<table>
<tr><th></th><th colspan="2">Raspberry Pi3@32 bit</th><th colspan="2">Odroid-C2@64 bit</th></tr>
<tr><th>Prog</th><th>normal modulo</th><th>floatdiv</th><th>normal modulo</th><th>floatdiv</th></tr>
<tr><td>C-noparallel</td><td>17.204s<br>2.674s (with hw div)</td><td>7.631s</td> <td>2.016s</td><td>4.996s</td></tr>
<tr><td>C++-noparallel</td><td>18.323s<br>2.845s (with hw div)</td><td>5.587s</td> <td>2.009s</td><td>5.043s</td></tr>
<tr><td>LUA-noparallel (LuaJIT)</td><td colspan="2">14.606s</td> <td colspan="2">11.425s</td></tr>
<tr><td>Python-noparallel (Pypy)</td><td colspan="2">27.347s</td> <td colspan="2">no JIT, very slow </td></tr>
<tr><td>C#-noparallel (mono)</td><td colspan="2">29.375s</td> <td colspan="2">6.685s</td></tr>

<tr><th colspan="5">Parallel on 4 cores</th></tr>
<tr><td>C-OpenMP</td><td>4.706s<br>0.757s (with hw div)</td><td>2.071s</td>  <td>0.602s</td><td>1.357s</td></tr>
<tr><td>C-pthread</td><td>4.407s<br>1.018s (with hw div)</td><td>2.040s</td>  <td>0.685s</td><td>1.357s</td></tr>
<tr><td>C++-for_each</td><td>4.632s<br>0,768s (with hw div)</td><td>1.934s</td>  <td>0.533s</td><td>1.298s</td></tr>

<tr><td>C#-Linq</td><td colspan="2">8.290s</td> <td colspan="2">2.140s</td></tr>
<tr><td>C#-ParallelFor</td><td colspan="2">8.159s</td> <td colspan="2">2.089s</td></tr>
<tr><td>C#-Tasks</td><td colspan="2">7.699s</td> <td colspan="2">1.773s</td></tr>

<tr><td>Python-multiprocessing (Pypy)</td><td colspan="2">18.273s</td> <td colspan="2">no JIT, very slow</td></tr>
<tr><td>Python-thread-verySlow (Pypy)</td><td colspan="2">119.7s</td> <td colspan="2">no JIT, very slow</td></tr>
</table>


# Software without hardware div:

* on Cortex A53@32 bit Linux -march=native or -mcpu=native
* -march=armv7-a
* -mcpu=cortex-[a5 a8 a9] and arm1176jzf-s and
* on 32 bit ARM Linux <b>without</b> -mcpu=  or -march=armv8-* parameters

# Software with hardware div instruction:

* -march=armv8-*
* <b>-mcpu=</b>cortex-[a7 a12 a15 a17] and all armv8 <b>-mcpu=</b>cortex-[a32 a35 a53 a72]
* default on all 64 bit Linux
