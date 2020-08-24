using System.Collections.Generic;
using LinqToDB.Mapping;

namespace ApiTest
{
    [Table]
    public class Customer
    {
        [Column(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Association(ThisKey = nameof(Id), OtherKey = nameof(CustomerEmail.CustomerId))]
        public List<CustomerEmail> Emails { get; set; }
    }
}