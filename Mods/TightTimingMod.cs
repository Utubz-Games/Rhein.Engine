using Rhein.Gamemodes;

namespace Rhein.Mods
{
    public class TightTimingMod : Mod
    {
        public override void Apply(Gamemode gamemode)
        {
            Type = 3;
            Cheat = false;
            gamemode.Windows = TimingWindows.Tight;
        }
    }
}
