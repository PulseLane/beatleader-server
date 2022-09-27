﻿namespace BeatLeader_Server.Models
{
    public enum ScoreStatus
    {
        normal = 0,
        pinned = 1,
    }

    public class ScoreMetadata 
    {
        public int Id { get; set; }
        public ScoreStatus Status { get; set; }
        public int Priority { get; set; }
        public string? Description { get; set; }

        public string? LinkService { get; set; }
        public string? LinkServiceIcon { get; set; }
        public string? Link { get; set; }
    }

    public class ReplayOffsets
    {
        public int Id { get; set; }
        public int Frames { get; set; }
        public int Notes { get; set; }
        public int Walls { get; set; }
        public int Heights { get; set; }
        public int Pauses { get; set; }
    }

    public class Score
    {
        public int Id { get; set; }
        public int BaseScore { get; set; }
        public int ModifiedScore { get; set; }
        public float Accuracy { get; set; }
        public string PlayerId { get; set; }
        public float Pp { get; set; }
        public float BonusPp { get; set; }
        public bool Qualification { get; set; }
        public float Weight { get; set; }
        public int Rank { get; set; }
        public int CountryRank { get; set; }
        public string Replay { get; set; }
        public string Modifiers { get; set; }
        public int BadCuts { get; set; }
        public int MissedNotes { get; set; }
        public int BombCuts { get; set; }
        public int WallsHit { get; set; }
        public int Pauses { get; set; }
        public bool FullCombo { get; set; }
        public HMD Hmd { get; set; }
        public float AccRight { get; set; }
        public float AccLeft { get; set; }
        public string Timeset { get; set; }
        public int Timepost { get; set; }
        public string Platform { get; set; } = "";
        public Player Player { get; set; }
        public string LeaderboardId { get; set; }
        public Leaderboard Leaderboard { get; set; }
        //public bool AltOnly { get; set; }
        //public ICollection<AltScore>? AltScores { get; set; }
        public ReplayOffsets? ReplayOffsets { get; set; }

        public ScoreImprovement? ScoreImprovement { get; set; }
        public bool Banned { get; set; } = false;
        public RankVoting? RankVoting { get; set; }
        public ScoreMetadata? Metadata { get; set; }
    }

    public class AltScore 
    {
        public int Id { get; set; }
        public int ScoreId { get; set; }
        public float Weight { get; set; }
        public int Rank { get; set; }
        public int BaseScore { get; set; }
        public int ModifiedScore { get; set; }
        public float Accuracy { get; set; }
        public float Pp { get; set; }
        public float BonusPp { get; set; }
        public int? AltBoardId { get; set; }
        public AltBoard? AltBoard { get; set; }
    }

    public class FailedScore
    {
        public int Id { get; set; }
        public int BaseScore { get; set; }
        public int ModifiedScore { get; set; }
        public float Accuracy { get; set; }
        public string PlayerId { get; set; }
        public float Pp { get; set; }
        public float Weight { get; set; }
        public int Rank { get; set; }
        public int CountryRank { get; set; }
        public string Replay { get; set; }
        public string Modifiers { get; set; }
        public int BadCuts { get; set; }
        public int MissedNotes { get; set; }
        public int BombCuts { get; set; }
        public int WallsHit { get; set; }
        public int Pauses { get; set; }
        public bool FullCombo { get; set; }
        public HMD Hmd { get; set; }
        public string Timeset { get; set; }
        public Player Player { get; set; }
        public Leaderboard Leaderboard { get; set; }
        public string Error { get; set; }
    }
}
