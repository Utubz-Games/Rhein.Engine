using Rhein.Gamemodes;

namespace Rhein.Mods
{
    public class StrictTimingMod : Mod
    {
        public override void Apply(Gamemode gamemode)
        {
            Type = 4;
            Cheat = false;
            gamemode.Windows = TimingWindows.Strict;
        }
    }
}
