using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApi.DataAccess.Dao
{
    [Table("order_detail")]
    class OrderDetail
    {
        [Column("id")]
        public int id { get; set; }
        [Column("order_id")]
        public int order_id { get; set; }

        [Column("item")]
        public string item { get; set; }
        
        [Column("price")]
        public int price { get; set; }
        
        [Column("category")]
        public string category { get; set; }
    }
}
