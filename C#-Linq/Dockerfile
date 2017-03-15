FROM microsoft/dotnet
COPY * /a/
RUN cd /a && dotnet restore
RUN cd /a && dotnet build -c Release
RUN cd /a && dotnet bin/Release/netcoreapp1.1/ParallelTest.dll 3000000
