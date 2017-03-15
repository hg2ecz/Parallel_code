CXX=g++
CXXFLAGS =-Wall -O2 -funroll-all-loops -std=gnu++14
CXXFLAGS+=-fopenmp -D_GLIBCXX_PARALLEL

CXXFLAGS+=-DMAXNUM=3000000

LDFLAGS =-lm -s -lstdc++
LDFLAGS+=-lgomp

OBJS=paralleltest.o

TARGET=parallel

all: $(OBJS)
	$(CXX) $(OBJS) $(LDFLAGS) -o $(TARGET)

clean:
	rm -f $(OBJS) $(TARGET)

test:
	bash -c "time ./$(TARGET)"
