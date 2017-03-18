FROM microsoft/dotnet
COPY . /a/
RUN ls -l /a
#CMD cd /a/ParallelTest && \ 
#    dotnet restore && \
#    dotnet build -c Release && \
#    dotnet bin/Release/netcoreapp1.1/ParallelTest.dll 3000000
CMD cd /a/ParallelTest.UnitTests && \ 
    dotnet restore && \
    dotnet test -c Release
