namespace Battlefield1.Data;

public class PlayerItem
{
    public int Index { get; set; }
    public long PID { get; set; }
    public string Name { get; set; }
    public long PlayTime { get; set; }
    public int Rank { get; set; }
    public string RankImage { get; set; }
    public string Latency { get; set; }

    public bool IsAdmin { get; set; }
    public bool IsVIP { get; set; }

    public float LifeKD { get; set; }
    public float LifeKPM { get; set; }
    public float LifeTime { get; set; }
}
