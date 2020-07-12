using Booli.ML.Model;
using System;

namespace Booli.ML.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ModelBuilder.CreateModel();

            // Create single instance of sample data from first line of dataset for model input
            ModelInput sampleData = new ModelInput()
            {
                ListPrice = 1695000F,
                Rent = 3627F,
                Floor = @"1",
                LivingArea = @"50",
                Rooms = @"2",
                Published = @"2016-05-21 23:03:24",
                ConstructionYear = 2007F,
                ObjectType = @"Lägenhet",
                SoldPriceSource = @"bid",
                AdditionalArea = @"",
                ApartmentNumber = 1102F,
                PlotArea = @"",
                StreetAddress = @"Viksängsvägen 22",
                MunicipalityName = @"Södertälje",
                CountyName = @"Stockholms län",
                Ocean = 136F,
                IsApproximate = false,
                Name = @"Bo Lundvall & Son",
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