using Rhein.Gamemodes;

namespace Rhein.Mods
{
    public class X999Mod : X000Mod
    {
        internal override void ApplyDefaults()
        {
            Type = 25;
        }

        public X999Mod(float speed)
        {
            Speed = speed;
        }
    }
}
