namespace Code
{
    public class ItemStackModel
    {
        public ItemModel ItemModel { get; }
        public int Amount { get; }
        
        public ItemStackModel(ItemModel itemModel, int amount)
        {
            ItemModel = itemModel;
            Amount = amount;
        }

    }
}