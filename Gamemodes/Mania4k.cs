using Rhein.Mods;

namespace Rhein.Gamemodes
{
    public class Mania4k : Mania
    {
        public override int Keys => 4;

        
        public Mania4k(TimingWindows timings, Mod[] mods)
        {
            Setup(timings, mods);
        }
    }
}
