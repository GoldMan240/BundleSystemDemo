namespace Code
{
    public class ItemModel
    {
        public ItemId Id { get; }
        public string Name { get; }
        public int Amount { get; }
        
        public ItemModel(ItemId id, string name, int amount)
        {
            Id = id;
            Name = name;
            Amount = amount;
        }
    }
}