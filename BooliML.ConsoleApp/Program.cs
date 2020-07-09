using BooliML.Model;
using System;

namespace BooliML.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create single instance of sample data from first line of dataset for model input
            ModelInput sampleData = new ModelInput()
            {
                ListPrice = 2190000F,
                Rent = 3000F,
                Floor = @"7,5",
                LivingArea = @"57",
                Rooms = @"2",
                Published = @"2019-08-30 13:37:48",
                ConstructionYear = 1952F,
                ObjectType = @"Lägenhet",
                SoldPriceSource = @"bobot",
                AdditionalArea = @"0",
                ApartmentNumber = 1704F,
                PlotArea = 0F,
                StreetAddress = @"Björnsonsgatan 142",
                MunicipalityName = @"Stockholm",
                CountyName = @"Stockholms län",
                Ocean = 8859F,
                IsApproximate = false,
                Name = @"Notar",
                Type = @"Broker",
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = ConsumeModel.Predict(sampleData);

            Console.WriteLine("Using model to make single prediction -- Comparing actual SoldPrice with predicted SoldPrice from sample data...\n\n");
            Console.WriteLine($"ListPrice: {sampleData.ListPrice}");
            Console.WriteLine($"Rent: {sampleData.Rent}");
            Console.WriteLine($"Floor: {sampleData.Floor}");
            Console.WriteLine($"LivingArea: {sampleData.LivingArea}");
            Console.WriteLine($"Rooms: {sampleData.Rooms}");
            Console.WriteLine($"Published: {sampleData.Published}");
            Console.WriteLine($"ConstructionYear: {sampleData.ConstructionYear}");
            Console.WriteLine($"ObjectType: {sampleData.ObjectType}");
            Console.WriteLine($"SoldPriceSource: {sampleData.SoldPriceSource}");
            Console.WriteLine($"AdditionalArea: {sampleData.AdditionalArea}");
            Console.WriteLine($"ApartmentNumber: {sampleData.ApartmentNumber}");
            Console.WriteLine($"PlotArea: {sampleData.PlotArea}");
            Console.WriteLine($"StreetAddress: {sampleData.StreetAddress}");
            Console.WriteLine($"MunicipalityName: {sampleData.MunicipalityName}");
            Console.WriteLine($"CountyName: {sampleData.CountyName}");
            Console.WriteLine($"Ocean: {sampleData.Ocean}");
            Console.WriteLine($"IsApproximate: {sampleData.IsApproximate}");
            Console.WriteLine($"Name: {sampleData.Name}");
            Console.WriteLine($"Type: {sampleData.Type}");
            Console.WriteLine($"\n\nPredicted SoldPrice: {predictionResult.Score}\n\n");
            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }
    }
}
