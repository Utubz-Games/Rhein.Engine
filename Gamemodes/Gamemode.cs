using Rhein.Mods;

namespace Rhein.Gamemodes
{
    public abstract class Gamemode
    {
        public TimingWindows Windows { get; internal set; }
        public Mod[] Mods { get; internal set; }
        public string Name { get; internal set; } = "Unknown Song";
        public float Bpm { get; internal set; } = 120f;
        public float Speed { get; internal set; } = 1f;
        public float Position { get; internal set; } = 0f;
        public float Length { get; internal set; } = 1f;
        public float Health { get; internal set; } = 1f;

        private void ApplyMods()
        {
            foreach (Mod mod in Mods)
            {
                mod.Apply(this);
            }
        }

        protected void Setup(TimingWindows timings, Mod[] mods)
        {
            Windows = timings;
            Mods = mods;
            ApplyMods();
        }

        internal abstract void Init();

        public Gamemode()
        {

        }

        public Gamemode(TimingWindows timings)
        {
            Windows = timings;
        }

        public Gamemode(params Mod[] mods)
        {
            Mods = mods;
            ApplyMods();
        }

        public Gamemode(TimingWindows timings, params Mod[] mods)
        {
            Windows = timings;
            Mods = mods;
            ApplyMods();
        }
    }
}
