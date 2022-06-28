using Rhein.Rulesets;
using Rhein.Mapping;

namespace Rhein.Mods
{
    /// <summary>A list of mods.</summary>
    public class ModList : List<Mod>
    {
        /// <summary>Applies the mods in the list.</summary>
        public void Apply(Ruleset ruleset, IMap map)
        {
            for (int i = 0; i < Count; i++)
                this[i].Apply(ruleset, map);
        }
    }
}
