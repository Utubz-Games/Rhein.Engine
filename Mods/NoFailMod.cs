using Rhein.Gamemodes;

namespace Rhein.Mods
{
    public class NoFailMod : Mod
    {
        public override void Apply(Gamemode gamemode)
        {
            Type = 0;
            Cheat = true;
            gamemode.Health = -1f;
        }
    }
}
