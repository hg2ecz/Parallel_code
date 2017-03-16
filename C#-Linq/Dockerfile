FROM microsoft/dotnet
COPY * /a/
RUN cd /a && \ 
    dotnet restore && \
    dotnet build -c Release && \
    dotnet bin/Release/netcoreapp1.1/ParallelTest.dll 3000000
