using Microsoft.ML.Data;

namespace Booli.ML.Model
{
    public class ModelInput
    {
        [ColumnName("listPrice"), LoadColumn(0)]
        public float ListPrice { get; set; }

        [ColumnName("rent"), LoadColumn(1)]
        public float Rent { get; set; }

        [ColumnName("floor"), LoadColumn(2)]
        public string Floor { get; set; }

        [ColumnName("livingArea"), LoadColumn(3)]
        public string LivingArea { get; set; }

        [ColumnName("rooms"), LoadColumn(4)]
        public string Rooms { get; set; }

        [ColumnName("published"), LoadColumn(5)]
        public string Published { get; set; }

        [ColumnName("constructionYear"), LoadColumn(6)]
        public float ConstructionYear { get; set; }

        [ColumnName("objectType"), LoadColumn(7)]
        public string ObjectType { get; set; }

        [ColumnName("soldDate"), LoadColumn(8)]
        public string SoldDate { get; set; }

        [ColumnName("soldPrice"), LoadColumn(9)]
        public float SoldPrice { get; set; }

        [ColumnName("soldPriceSource"), LoadColumn(10)]
        public string SoldPriceSource { get; set; }

        [ColumnName("additionalArea"), LoadColumn(11)]
        public string AdditionalArea { get; set; }

        [ColumnName("apartmentNumber"), LoadColumn(12)]
        public float ApartmentNumber { get; set; }

        [ColumnName("plotArea"), LoadColumn(13)]
        public string PlotArea { get; set; }

        [ColumnName("streetAddress"), LoadColumn(14)]
        public string StreetAddress { get; set; }

        [ColumnName("municipalityName"), LoadColumn(15)]
        public string MunicipalityName { get; set; }

        [ColumnName("countyName"), LoadColumn(16)]
        public string CountyName { get; set; }

        [ColumnName("ocean"), LoadColumn(17)]
        public float Ocean { get; set; }

        [ColumnName("latitude"), LoadColumn(18)]
        public string Latitude { get; set; }

        [ColumnName("longitude"), LoadColumn(19)]
        public string Longitude { get; set; }

        [ColumnName("isApproximate"), LoadColumn(20)]
        public bool IsApproximate { get; set; }

        [ColumnName("name"), LoadColumn(21)]
        public string Name { get; set; }

        [ColumnName("type"), LoadColumn(22)]
        public string Type { get; set; }
    }
}