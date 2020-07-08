![Booli logo](https://bcdn.se/images/resources/booli_logo.png)

# Property valuation app using ML.NET powered by [Booli](https://www.booli.se)

## Build
1. `git clone https://github.com/johanpettersson1/BooliAPI.git`
2. `dotnet restore`
3. `dotnet build`
4. `dotnet ef migrations add InitialCreate --project Booli`
5. `dotnet ef database update --project Booli`
6. `dotnet run`
## Create view in SQL
`CREATE VIEW ML AS SELECT listPrice,rent,[floor],livingArea,rooms,published,constructionYear,objectType,soldDate,soldPrice,soldPriceSource,additionalArea,apartmentNumber,plotArea, streetAddress,municipalityName,countyName,ocean,latitude,longitude,isApproximate,[name],[type] FROM Sold 
join Location on Location.Id=Sold.locationId
join Address on Location.addressId=Address.Id
join Region on Location.regionId=Region.Id
join Distance on  Location.distanceId=Distance.Id
join Position on Location.positionId=Position.Id
join Sources on Sold.sourceid = Sources.id;`
