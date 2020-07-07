![Booli logo](https://bcdn.se/images/resources/booli_logo.png)

# Property valuation app using ML.NET powered by [Booli](https://www.booli.se)

## Build
1. `git clone https://github.com/johanpettersson1/BooliAPI.git`
2. `dotnet restore`
3. `dotnet build`
4. `dotnet ef migrations add InitialCreate --project Booli`
5. `dotnet ef database update --project Booli`
6. `dotnet run`
