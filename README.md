# LenkieAssignment
This is the code for the assignment here https://github.com/lenkie-code/full-stack-software-engineer-assessment

## Requirements
1. Visual Studio 17
2. .NET 6

There are 5 projects in the solution at the time of this documentation:
3 of them are library projects for data access, thus:
- Library.IData
- Library.JsonFileDAO
- Library.Core

The other 2 are .NET web applications/project in the solution:
- IDServer4
- Library.WebAPI

## Deployment/Running it.
In order to run it, you'd need to open the solution in Visual Studio (v 17, prefarably) and configure multiple startups in this order:
1. IDServer4
2. Library.WebAPI

