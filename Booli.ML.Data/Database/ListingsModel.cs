using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booli.ML.Data.Database.ListingsModel
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string streetAddress { get; set; }
    }

    public class Listing
    {
        public double additionalArea { get; set; }
        public int biddingOpen { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int booliId { get; set; }
        public int? constructionYear { get; set; }
        public float floor { get; set; }
        public int? isNewConstruction { get; set; }
        public int? listPrice { get; set; }
        public int? listPriceChange { get; set; }
        public string listPriceChangeDate { get; set; }
        public double livingArea { get; set; }
        public Location location { get; set; }
        public int? mortgageDeed { get; set; }
        public string objectType { get; set; }
        public double? plotArea { get; set; }
        public string published { get; set; }
        public int rent { get; set; }
        public double rooms { get; set; }
        public Source source { get; set; }
        public string url { get; set; }
    }

    public class ListingsQuery
    {
        public int count { get; set; }
        public int limit { get; set; }
        public List<Listing> listings { get; set; }
        public int offset { get; set; }
        public SearchParams searchParams { get; set; }
        public int totalCount { get; set; }
    }

    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public Address address { get; set; }
        public List<string> namedAreas { get; set; }
        public Position position { get; set; }
        public Region region { get; set; }
    }

    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public bool? isApproximate { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Region
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string countyName { get; set; }
        public string municipalityName { get; set; }
    }

    public class SearchParams
    {
        [Key]
        public int areaId { get; set; }
        public int upcomingSale { get; set; }
    }

    public class Source
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }
}