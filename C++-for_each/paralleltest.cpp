#include <iostream>
#include <vector>
#include <algorithm>

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

    int primct=0;

    std::for_each(buffer.begin(), buffer.end(), [&primct](int& i) {
	bool prim = TRUE;
	int sqi = sqrt(i);
	for (int j = 2; j<=sqi; j++) {
	    if (!(i%j)) {
		prim=FALSE;
		break;
	    }
	}
	if (prim == TRUE)
#ifdef _GLIBCXX_PARALLEL
	    __sync_fetch_and_add(&primct, 1); // thread safe
#else
	    primct++;
#endif
    });

    clock_gettime(CLOCK_PROCESS_CPUTIME_ID, &gend);
    eltime = 1000.0*(gend.tv_sec - gstart.tv_sec) + (gend.tv_nsec - gstart.tv_nsec)/1000000.;
    printf("%d %.3f ms\n", primct, eltime);
}