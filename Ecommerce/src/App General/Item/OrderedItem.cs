using System;

namespace ProjectNS.ItemNS
{
    public class OrderedItem
    {
        public DateTime date { get; set; }
        public Item item { get; set; }
        public int quantity { get; set; }
        public int orderPk { get; set; }
        public int userId { get; set; }
    }
}
