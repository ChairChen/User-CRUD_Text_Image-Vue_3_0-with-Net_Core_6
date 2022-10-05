using System;
using System.Collections.Generic;

namespace CRUD.Models
{
    public partial class Image
    {
        public byte Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string DateTime { get; set; } = null!;
    }
}
