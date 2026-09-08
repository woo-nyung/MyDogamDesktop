namespace MyDogamDesktop.Models
{
    public class CollectionItem // 바인더 아이템 DB 구조
    {
        public int Id { get; set; }
        public int CollectionId { get; set; }
        public string ItemId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }
        public string MetadataJson { get; set; } = "{}";
        public Collection Collection { get; set; } = null!;
    }
}
