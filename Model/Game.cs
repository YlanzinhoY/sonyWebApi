namespace SonyGamesWebAPI.Model
{
    public class Game
    {
        public readonly Guid Uuid;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string Studio { get; set; }
        public string Cover{ get; set; }
    }
}
