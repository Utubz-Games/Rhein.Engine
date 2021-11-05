using Rhein;
using Rhein.Gamemodes;
using Rhein.Gameplay;
using Rhein.Mods;

namespace Rhein.Gamemodes
{
    public abstract class BaseGamemode
    {
        /// <summary>
        /// Gets the current <see cref="Chart{T}"/>.
        /// </summary>
        /// <typeparam name="N">The <see cref="Note"/> type.</typeparam>
        /// <returns>The current <see cref="Chart{T}"/> being used.</returns>
        public abstract Chart<N> GetChart<N>() where N : Note;
        /// <summary>
        /// The current <see cref="TimingWindows"/> being used for this <see cref="Gamemode"/>.
        /// </summary>
        public abstract TimingWindows Windows { get; internal set; }
        /// <summary>
        /// The current <see cref="Mod"/>s being used for this <see cref="Gamemode"/>.
        /// </summary>
        public abstract Mod[] Mods { get; internal set; }
        /// <summary>
        /// The current Name of the song being used for this <see cref="Gamemode"/>.
        /// </summary>
        public abstract string Name { get; internal set; }
        /// <summary>
        /// The current Beats Per Minute of the song being used for this <see cref="Gamemode"/>.
        /// </summary>
        public abstract float Bpm { get; internal set; }
        /// <summary>
        /// The current Speed of the song being used for this <see cref="Gamemode"/>.
        /// </summary>
        public abstract float Speed { get; internal set; }
        /// <summary>
        /// The current Position of the song being used for this <see cref="Gamemode"/>.
        /// </summary>
        public abstract float Position { get; internal set; }
        /// <summary>
        /// The current Beat of the song being used for this <see cref="Gamemode"/>.
        /// </summary>
        public abstract float Beat { get; }
        /// <summary>
        /// The Length of the song being used for this <see cref="Gamemode"/>.
        /// </summary>
        public abstract float Length { get; internal set; }
        /// <summary>
        /// The current Health of the player in this <see cref="Gamemode"/>.
        /// </summary>
        public abstract float Health { get; internal set; }

        internal abstract void ApplyMods();

        internal abstract void Setup(TimingWindows timings, Mod[] mods);

        // Was going to be used to run an update loop automatically, but since the API is
        // currently not multi-threaded this wouldn't make sense, so Gamemode.Process() was
        // exposed instead. Hopefully we can add a Rhein.ThreadSafe namespace so that this
        // can be used again.
        internal abstract void Init();

        internal abstract void Stop();

        internal abstract void Ready();

        /// <summary>
        /// Updates the <see cref="BaseGamemode"/>.
        /// </summary>
        public abstract void Process();
        /// <summary>
        /// Converts the current <see cref="Gamemode{T}"/> to child/base type. This won't convert to other types.
        /// </summary>
        /// <typeparam name="G">The type to convert to.</typeparam>
        /// <returns>The converted <see cref="Gamemode{T}"/>.</returns>
        public abstract G As<G>() where G : BaseGamemode;
    }
}
