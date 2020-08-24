using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace ApiTest
{
    [Table]
    public class CustomerEmail
    {
        [Column(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [Column]
        public int CustomerId { get; set; }

        [Column]
        public string Email { get; set; }
    }
}
