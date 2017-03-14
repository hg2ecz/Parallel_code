TARGET=Program.exe

all:
	mcs -optimize Program.cs -out:$(TARGET)

clean:
	rm -f $(TARGET)

test:
	bash -c "time ./Program.exe 3000000"
