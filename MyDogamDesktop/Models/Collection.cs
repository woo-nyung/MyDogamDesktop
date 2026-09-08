namespace MyDogamDesktop.Models
{
    public class Collection // 바인더 DB 구조
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public int TotalItems { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CollectionItem> Items { get; set; } = new List<CollectionItem>();
    }
}
