using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApi.DataAccess.Dao
{
    [Table("order")]
    class Order
    {
        [Column("id")]
        public int id { get; set; }

        [Column("buyer")]
        public string buyer { get; set; }
        
        [Column("order_date")]
        public DateTime order_date { get; set; }

        [Column("total_price")]
        public int total_price { get; set; }


        [Column("discount")]
        public int discount { get; set; }
    }
}
