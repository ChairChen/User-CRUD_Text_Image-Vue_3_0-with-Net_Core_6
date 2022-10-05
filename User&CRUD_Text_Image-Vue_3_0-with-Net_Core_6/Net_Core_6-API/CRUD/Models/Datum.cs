using System;
using System.Collections.Generic;

namespace CRUD.Models
{
    public partial class Datum
    {
        public byte Id { get; set; }
        public string Data { get; set; } = null!;
        public string DateTime { get; set; } = null!;
    }
}
