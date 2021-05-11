#Specify the following
# 01: an SDK
# ____ MS dotnet SDK
FROM  mcr.microsoft.com/dotnet/sdk as base

# 02: a WORKSPACE
WORKDIR /app

# 03: FILES (copied)
# Copy the source-root to the destination root
#COPY . . 
COPY <physical> <virtual>

#04: a COMPILE
RUN dotnet build;

#05: an ASSEMBLY
# Debug | Release
RUN dotnet publish --configuration  Debug -p PizzaBoxClient -o out PizzaBox.Client;

# "Application with batteries included":
#06: a RUNTIME
# ____ ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet

#07: a RUN LOCATION
WORKDIR /run 

#08: copy to the run location
COPY --from=base /app/out .; 

#09: LAUNCH
CMD [ “dotnet”, “run”, “PizzaBox.Client.dll” ]
#——————[EoF]. 
