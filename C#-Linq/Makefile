TARGET=Program.exe

all:
	mcs -optimize ParallelTest/Program.cs -out:$(TARGET)

clean:
	rm -f $(TARGET)

test:
	bash -c "time ./$(TARGET) 3000000"
