using System;
using System.Collections.Generic;

#nullable disable

namespace CRUD_API.Models
{
    public partial class TblAddress
    {
        public int Addressid { get; set; }
        public int? Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public virtual Tblemp IdNavigation { get; set; }
    }
}
