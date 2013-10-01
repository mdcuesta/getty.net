﻿using System.Collections.Generic;

namespace Api.Getty.Models
{
    public class Filter
    {
        public Collections Collections { get; set; }

        public List<string> EditorialSegments { get; set; }

        public EditorialSources EditorialSources { get; set; }

        public List<string> FileTypes { get; set; }

        public List<string> GraphicStyles { get; set; }

        public List<string> ImageFamilies { get; set; }

        public List<string> LicensingModels { get; set; }

        public List<string> Orientations { get; set; }

        public List<string> ProductOfferings { get; set; }

        public List<Refinement> Refinements { get; set; }        
    }

    public class Collections
    {
        public List<string> Ids { get; set; }

        public string Mode { get; set; }
    }

    public class EditorialSources
    {
        public List<string> Ids { get; set; }

        public string Mode { get; set; }    
    }

    public class Refinement
    {
        public string Category { get; set; }

        public string Id { get; set; }
    }
}
