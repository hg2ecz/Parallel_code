CC=gcc
CFLAGS =-Wall -O2 -funroll-all-loops -std=gnu11

CFLAGS+=-DMAXNUM=3000000 -fopenmp -DCPUNUM=`nproc` -Dfloatdiv

LDFLAGS=-lm -s -lgomp
OBJS=paralleltest.o

TARGET=parallel

all: $(OBJS)
	$(CC) $(OBJS) $(LDFLAGS) -o $(TARGET)

clean:
	rm -f $(OBJS) $(TARGET)

test:
	bash -c "time ./$(TARGET)"
