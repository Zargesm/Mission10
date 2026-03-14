namespace Mission10.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; } = "";
        public int? CaptainID { get; set; }

        public List<Bowler> Bowlers { get; set; } = new();
    }
}