namespace Battlefield1.Data;

public class PlayerItem
{
    public int Index { get; set; }

    public int TeamId { get; set; }
    public long PID { get; set; }
    public string Name { get; set; }
    public long PlayTime { get; set; }
    public int Rank { get; set; }
    public string RankImage { get; set; }
    public int Latency { get; set; }

    public long LOC { get; set; }
    public string Language { get; set; }

    public bool IsAdmin { get; set; }
    public bool IsVIP { get; set; }

    public bool Is150 { get; set; }
    public bool Is100Plus { get; set; }

    public string LifeWinPer { get; set; }
    public string LifeKD { get; set; }
    public string LifeKPM { get; set; }
    public string LifeTime { get; set; }
    public string LifeSkill { get; set; }
}
