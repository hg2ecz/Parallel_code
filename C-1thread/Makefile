CC=gcc
CFLAGS =-Wall -O2 -funroll-all-loops

CFLAGS+=-DMAXNUM=1000000

LDFLAGS=-lm -s
OBJS=paralleltest.o

TARGET=noparallel

all: $(OBJS)
	$(CC) $(OBJS) $(LDFLAGS) -o $(TARGET)

clean:
	rm -rf $(OBJS) $(TARGET)

test:
	bash -c "time ./noparallel"
