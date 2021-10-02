using Rhein.Gamemodes;

namespace Rhein.Mods
{
    public class LenientTimingMod : Mod
    {
        public override void Apply(Gamemode gamemode)
        {
            Type = 1;
            Cheat = false;
            gamemode.Windows = TimingWindows.Lenient;
        }
    }
}
