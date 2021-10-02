using Rhein.Gamemodes;

namespace Rhein.Mods
{
    public abstract class X000Mod : Mod
    {
        public float Speed { get; internal set; }

        public sealed override void Apply(Gamemode gamemode)
        {
            Cheat = false;
            ApplyDefaults();
            gamemode.Speed = Speed;
        }

        internal abstract void ApplyDefaults();
    }
}
