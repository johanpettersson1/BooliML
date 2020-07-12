using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booli.ML.Data.Database.SoldModel
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string streetAddress { get; set; }
    }

    public class Distance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public int ocean { get; set; }
    }

    public class Location
    {
        public Address address { get; set; }
        public Distance distance { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public List<string> namedAreas { get; set; }
        public Position position { get; set; }
        public Region region { get; set; }
    }

    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public bool isApproximate { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Region
    {
        public string countyName { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string municipalityName { get; set; }
    }

    public class SearchParams
    {
        [Key]
        public int areaId { get; set; }
    }

    public class Sold
    {
        public double? additionalArea { get; set; }
        public string apartmentNumber { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long booliId { get; set; }
        public int constructionYear { get; set; }
        public double floor { get; set; }
        public int listPrice { get; set; }
        public double livingArea { get; set; }
        public Location location { get; set; }
        public string objectType { get; set; }
        public double? plotArea { get; set; }
        public string published { get; set; }
        public int rent { get; set; }
        public double rooms { get; set; }
        public string soldDate { get; set; }
        public int soldPrice { get; set; }
        public string soldPriceSource { get; set; }
        public Source source { get; set; }
        public string url { get; set; }
    }

    public class SoldQuery
    {
        public int count { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public SearchParams searchParams { get; set; }
        public List<Sold> sold { get; set; }
        public int totalCount { get; set; }
    }

    public class Source
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        public string name { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }
}