TARGET=Program.exe

all:
	mcs -optimize Program.cs -out:$(TARGET)

clean:
	rm -f $(TARGET)

test:
	bash -c "time ./$(TARGET) 3000000"
