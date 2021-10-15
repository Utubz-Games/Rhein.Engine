using StringBuilder = System.Text.StringBuilder;

using Rhein;
using Rhein.Gameplay;

namespace Rhein.Charting
{
    /// <summary>
    /// Used to parse <see cref="Chart"/>s.
    /// </summary>
    public static class ChartParser
    {
        /// <summary>
        /// Converts the <see cref="Chart"/> to a string that can be saved to a file.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Chart"/> to parse.</typeparam>
        /// <param name="chart">The <see cref="Chart"/> to parse.</param>
        /// <returns>A <see cref="Chart"/> in string form.</returns>
        public static string ToString<T>(T chart) where T : Chart
        {
            StringBuilder builder = new StringBuilder();

            return builder.ToString();
        }
    }
}
