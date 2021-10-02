using Rhein.Gamemodes;

namespace Rhein.Mods
{
    public class ChillTimingMod : Mod
    {
        public override void Apply(Gamemode gamemode)
        {
            Type = 2;
            Cheat = false;
            gamemode.Windows = TimingWindows.Chill;
        }
    }
}
