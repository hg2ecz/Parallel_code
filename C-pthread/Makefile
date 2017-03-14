CC=gcc
CFLAGS =-Wall -O2 -funroll-all-loops

CFLAGS+=-DMAXNUM=3000000

LDFLAGS=-lm -s -lpthread
OBJS=paralleltest.o

TARGET=parallel

all: $(OBJS)
	$(CC) $(OBJS) $(LDFLAGS) -o $(TARGET)

clean:
	rm -f $(OBJS) $(TARGET)

test:
	bash -c "time ./parallel"
