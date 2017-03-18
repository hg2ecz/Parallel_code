#include <iostream>
#include <vector>
#include <algorithm>
#include <atomic>

#include <math.h>
#include <time.h>

#define FALSE 0
#define TRUE !FALSE

int main() {
    double eltime;
    struct timespec gstart, gend;
    clock_gettime(CLOCK_PROCESS_CPUTIME_ID, &gstart);

//    std::vector<int> buffer;
//    for (int i=0; i<MAXNUM-1; i++) buffer.push_back(MAXNUM-i);
    std::vector<int> buffer(MAXNUM-1);
    for (int i=0; i<MAXNUM-1; i++) buffer[i]=MAXNUM-i;

    std::atomic<int> at_primct;
    at_primct = 0;

    std::for_each(buffer.begin(), buffer.end(), [&at_primct](int& i) {
	bool prim = TRUE;
	int sqi = sqrtf(i);
	for (int j = 2; j<=sqi; j++) {
#ifdef floatdiv
	    if (!(i - j*(int)((float)i/j))) { // on ARM11 .. ARM Cortex A53 float div faster than int div
#else
	    if (!(i%j)) {
#endif
		prim=FALSE;
		break;
	    }
	}
/*	if (prim == TRUE) // <-- if type is   int primct;
	#ifdef _GLIBCXX_PARALLEL
	    __sync_fetch_and_add(&primct, 1); // thread safe
	#else
	    primct++;                         // no thread safe
	#endif
*/
	if (prim == TRUE) at_primct++; // std::atomic<int> at_primct;

    });

    clock_gettime(CLOCK_PROCESS_CPUTIME_ID, &gend);
    eltime = 1000.0*(gend.tv_sec - gstart.tv_sec) + (gend.tv_nsec - gstart.tv_nsec)/1000000.;
    int primct = at_primct;
    printf("%d %.3f ms\n", primct, eltime);
}