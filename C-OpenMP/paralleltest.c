#include <stdio.h>
#include <math.h>
#include <time.h>

#define FALSE 0
#define TRUE !FALSE

int main() {
    double eltime;
    struct timespec gstart, gend;
    clock_gettime(CLOCK_PROCESS_CPUTIME_ID, &gstart);

    int primct=0;

#if defined(_OPENMP)
//    #pragma omp parallel for reduction(+:primct)
    #pragma omp parallel for reduction(+:primct) num_threads(2*CPUNUM)
#endif

    for (int i=MAXNUM; i>=2; i--) {
	_Bool prim = TRUE;
	int sqi = sqrtf(i);
	for (int j = 2; j<=sqi; j++) {
	    if (!(i%j)) {
		prim=FALSE;
		break;
	    }
	}
	if (prim == TRUE) primct++;
    }

    clock_gettime(CLOCK_PROCESS_CPUTIME_ID, &gend);
    eltime = 1000.0*(gend.tv_sec - gstart.tv_sec) + (gend.tv_nsec - gstart.tv_nsec)/1000000.;
    printf("%d %.3f ms\n", primct, eltime);
}