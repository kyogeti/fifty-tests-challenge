# 50 Tests Challenge

This project aims to practice writing unit tests, in a deliberate and purposeless attempt. The challenge is to write at least 50 unit tests for the entire project.

#### Currently achieved: 18/50

### Setup

- Install [.NET CORE 6 SDK](https://dotnet.microsoft.com/en-us/download);
- ```git clone```
- ```dotnet restore```
- ```dotnet build```
- ```dotnet test```

### Explanation of how the solution works

This POC simulates a people registration microservice. Some interfaces are exposed for registering the person, obtaining the list of registered people and a last one for editing their information. Personnel have an Active state by default and can be deactivated by a disable command.
