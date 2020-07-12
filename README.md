![Booli logo](https://bcdn.se/images/resources/booli_logo.png)

# Property valuation app using ML.NET powered by [Booli](https://www.booli.se)

### Example output
![Example output](https://user-images.githubusercontent.com/47982356/87089151-3fa4aa00-c236-11ea-8aaf-c8620809b455.png)

## Build
1. `git clone https://github.com/johanpettersson1/BooliML.git`
2. `dotnet restore`
3. `dotnet build`
4. `dotnet ef migrations add InitialCreate --project Booli.ML.Data --context BooliMLSoldContext`
5. `dotnet ef migrations add InitialCreate --project Booli.ML.Data --context BooliMLListingsContext`
6. `dotnet ef database update --project Booli.ML.Data --context BooliMLSoldContext`
7. `dotnet ef database update --project Booli.ML.Data --context BooliMLListingsContext`
8. `dotnet run --project Booli.ML.Data`

## Create ML view in SQL
`CREATE VIEW ML AS SELECT listPrice,rent,[floor],livingArea,rooms,published,constructionYear,objectType,soldDate,soldPrice,soldPriceSource,additionalArea,apartmentNumber,plotArea,streetAddress,municipalityName,countyName,ocean,latitude,longitude,isApproximate,[name],[type] FROM Sold
JOIN Location ON Location.Id=Sold.locationId
JOIN Address ON Location.addressId=Address.Id
JOIN Region ON Location.regionId=Region.Id
JOIN Distance ON  Location.distanceId=Distance.Id
JOIN Position ON Location.positionId=Position.Id
JOIN Sources ON Sold.sourceid=Sources.id;`
