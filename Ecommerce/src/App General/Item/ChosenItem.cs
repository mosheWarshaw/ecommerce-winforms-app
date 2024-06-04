namespace ProjectNS.ItemNS
{
    public class ChosenItem
    {
        public readonly Item TheItem;
        public readonly int QuantityToBuy;

        public ChosenItem(Item item, int quantityToBuy)
        {
            TheItem = item;
            QuantityToBuy = quantityToBuy;
        }
    }
}
