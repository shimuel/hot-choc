﻿using System;
using System.Collections.Generic;

namespace DemoDB.Entities
{
    public partial class Region
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        public long RegionId { get; set; }
        public string RegionDescription { get; set; }

        public ICollection<Territory> Territories { get; set; }
    }
}
