namespace Rhein
{
    public readonly struct TimingWindows
    {
        public readonly int Marvelous;
        public readonly int Perfect;
        public readonly int Great;
        public readonly int Good;
        public readonly int Okay;
        public readonly int Miss;
        public readonly bool IsDefault;

        public static readonly int DefaultMarv  =  21;
        public static readonly int DefaultPerf  =  42;
        public static readonly int DefaultGreat =  83;
        public static readonly int DefaultGood  = 104;
        public static readonly int DefaultOkay  = 125;
        public static readonly int DefaultMiss  = 166;

        public static readonly TimingWindows Default = new TimingWindows(DefaultMarv, DefaultPerf, DefaultGreat, DefaultGood, DefaultOkay, DefaultMiss);

        public static readonly TimingWindows Chill   = new TimingWindows(DefaultMarv + 1, DefaultPerf + 2, DefaultGreat + 3, DefaultGood + 4, DefaultOkay + 5,  DefaultMiss + 6);
        public static readonly TimingWindows Lenient = new TimingWindows(DefaultMarv + 2, DefaultPerf + 4, DefaultGreat + 6, DefaultGood + 8, DefaultOkay + 10, DefaultMiss + 12);

        public static readonly TimingWindows Tight  = new TimingWindows(DefaultMarv - 1, DefaultPerf - 2, DefaultGreat - 3, DefaultGood - 4, DefaultOkay - 5,  DefaultMiss - 6);
        public static readonly TimingWindows Strict  = new TimingWindows(DefaultMarv - 2, DefaultPerf - 4, DefaultGreat - 6, DefaultGood - 8, DefaultOkay - 10, DefaultMiss - 12);

        public TimingWindows(int marv, int perf, int great, int good, int okay, int miss)
        {
            Marvelous = marv;
            Perfect = perf;
            Great = great;
            Good = good;
            Okay = okay;
            Miss = miss;

            IsDefault = marv == 21 && perf == 42 && great == 83 && good == 104 && okay == 125 && miss == 166;
        }
    }
}
