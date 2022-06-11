﻿namespace Masya.Bot.Enums
{
    public enum UserFlag
    {
        Staff = 1 << 0,
        Partner = 1 << 1,
        HypeSquad = 1 << 2,
        BugHunterLevel1 = 1 << 3,
        HypeSquadBravery = 1 << 6,
        HypeSquadBrilliance = 1 << 7,
        HypeSquadBalance = 1 << 8,
        PremiumEarlySupporter = 1 << 9,
        TeamPseudoUser = 1 << 10,
        BugHunterLevel2 = 1 << 14,
        VerifiedBot = 1 << 16,
        VerifiedDeveloper = 1 << 17,
        CertifiedModerator = 1 << 18,
        BottHttpInteractions = 1 << 19,
    }
}
