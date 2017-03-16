FROM microsoft/dotnet
COPY * /a/
RUN cd /a/ParallelTest && \ 
    dotnet restore && \
    dotnet build -c Release && \
    dotnet bin/Release/netcoreapp1.1/ParallelTest.dll 3000000
RUN cd /a/ParallelTest.UnitTests && \ 
    dotnet restore && \
    dotnet build -c Release && \
    dotnet test
