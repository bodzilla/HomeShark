using System;
using System.Collections.Generic;
using System.Linq;
using HomeShark.Core.Contracts;
using HomeShark.Core.Enums;

namespace HomeShark.Core.Models
{
    public sealed class Property : IEntity
    {
        public Property()
        {
            KeyFeatures = new List<KeyFeature>();
            PropertyStations = new List<PropertyStation>();
            PropertySchools = new List<PropertySchool>();
            Media = new List<Media>();
        }

        public int Id { get; set; }

        public DateTime EntityCreated { get; set; }

        public DateTime? EntityModified { get; set; }

        public bool EntityActive { get; set; }

        public AgentBranch AgentBranch { get; set; }

        public int AgentBranchId { get; set; }

        public string Title => $"{Bedrooms} bedroom {PropertyType} for {AdvertType} in {Location}";

        public string Description { get; set; }

        public int Price { get; set; }

        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }

        public int Receptions { get; set; }

        public string Area { get; set; }

        public string Location { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string GeoLocation => $"{Latitude},{Longitude}";

        public string Postcode { get; set; }

        public int? TotalSizeSqFt { get; set; }

        public bool IsAuction { get; set; }

        public bool IsChainFree { get; set; }

        public bool IsNewBuild { get; set; }

        public bool IsExtended { get; set; }

        public bool IsPromoted { get; set; }

        public bool? HasDrivewayOrGarage { get; set; }

        public StatusType StatusType { get; set; }

        public AdvertType AdvertType { get; set; }

        public TagType TagType { get; set; }

        public PropertyType PropertyType { get; set; }

        public TenureType TenureType { get; set; }

        public PriceType PriceType { get; set; }

        public EpcRatingType EpcRatingType { get; set; }

        public CouncilTaxBandType CouncilTaxBandType { get; set; }

        public ConstructionType ConstructionType { get; set; }

        public IEnumerable<KeyFeature> KeyFeatures { get; set; }

        public IEnumerable<PropertyStation> PropertyStations { get; set; }

        public IEnumerable<PropertySchool> PropertySchools { get; set; }

        public IEnumerable<Media> Media { get; set; }

        public IEnumerable<Media> Images => Media.Where(x => x.MediaType == MediaType.Image);

        public IEnumerable<Media> VirtualTours => Media.Where(x => x.MediaType == MediaType.VirtualTour);

        public IEnumerable<Media> Floorplans => Media.Where(x => x.MediaType == MediaType.Floorplan);

        public IEnumerable<Media> Epcs => Media.Where(x => x.MediaType == MediaType.Epc);

        public IEnumerable<Media> Documents => Media.Where(x => x.MediaType == MediaType.Document);
    }
}
