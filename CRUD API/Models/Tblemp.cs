using System;
using System.Collections.Generic;

#nullable disable

namespace CRUD_API.Models
{
    public partial class Tblemp
    {
        public Tblemp()
        {
            TblAddresses = new HashSet<TblAddress>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<TblAddress> TblAddresses { get; set; }
    }
}
