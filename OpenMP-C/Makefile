all:
	@make -f Makefile-noparallel clean
	@make -f Makefile-noparallel
	@echo "\n"
	@make -f Makefile-parallel clean
	@make -f Makefile-parallel
	@echo "\n"

clean:
	@make -f Makefile-noparallel clean
	@make -f Makefile-parallel clean

test:
	bash -c "time ./noparallel"
	@echo "\n\n"
	bash -c "time ./parallel"
