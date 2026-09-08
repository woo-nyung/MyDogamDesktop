namespace MyDogamDesktop.Models
{
    public class ParsedItem // 바인더 아이템 파싱 구조
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();
    }
}
