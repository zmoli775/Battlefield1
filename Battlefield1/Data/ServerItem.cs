﻿namespace Battlefield1.Data;

public class ServerItem
{
    public int Index { get; set; }
    public string GameId { get; set; }
    public string Guid { get; set; }
    public string Country { get; set; }
    public string CountryImage { get; set; }
    public string Region { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Soldier { get; set; }
    public int MaxSoldier { get; set; }
    public int Queue { get; set; }
    public int Spectator { get; set; }
    public string MapMode { get; set; }
    public string MapName { get; set; }
    public string MapImage { get; set; }
    public string MapImage2 { get; set; }
    public string MapImage3 { get; set; }
    public bool IsCustom { get; set; }
    public bool IsOfficial { get; set; }
    public int TickRate { get; set; }
    public string PingImage { get; set; }
    public int PingNumber { get; set; }

    public string Team1Image { get; set; }
    public string Team1Key { get; set; }
    public string Team1Name { get; set; }
    public string Team2Image { get; set; }
    public string Team2Key { get; set; }
    public string Team2Name { get; set; }
}
