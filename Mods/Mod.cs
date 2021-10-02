using Rhein.Gamemodes;

namespace Rhein.Mods
{
    public abstract class Mod
    {
        public int Type { get; internal set; } = -1;
        public bool Cheat { get; internal set; } = true;

        public abstract void Apply(Gamemode gamemode);
    }
}
