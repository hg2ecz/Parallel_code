#include <stdio.h>
#include <math.h>
#include <time.h>
#include <pthread.h>

#define FALSE 0
#define TRUE !FALSE

static int globi=MAXNUM;
static pthread_mutex_t mut_i = PTHREAD_MUTEX_INITIALIZER;

static int primct=0;
static pthread_mutex_t mut_pct = PTHREAD_MUTEX_INITIALIZER;


static void *primtest_thread(void *arg) {
    while (1) {
	int i;
	pthread_mutex_lock(&mut_i); i=globi--; pthread_mutex_unlock(&mut_i);
	if (i < 2) pthread_exit(0); // end
	_Bool prim = TRUE;
	int sqi = sqrt(i);
	for (int j = 2; j<=sqi; j++) {
	    if (!(i%j)) {
		prim=FALSE;
		break;
	    }
	}
	if (prim == TRUE) {
	    pthread_mutex_lock(&mut_pct); primct++; pthread_mutex_unlock(&mut_pct);
	}
    }
}

int main() {
    double eltime;
    struct timespec gstart, gend;
    clock_gettime(CLOCK_PROCESS_CPUTIME_ID, &gstart);

    pthread_t thread[8];
    for (int i=0; i<8; i++) pthread_create(&thread[i], NULL, primtest_thread, NULL);
    for (int i=0; i<8; i++) pthread_join(thread[i], NULL); // wait all child

    clock_gettime(CLOCK_PROCESS_CPUTIME_ID, &gend);
    eltime = 1000.0*(gend.tv_sec - gstart.tv_sec) + (gend.tv_nsec - gstart.tv_nsec)/1000000.;
    printf("%d %.3f ms\n", primct, eltime);
}