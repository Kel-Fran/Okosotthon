namespace Okosotthon
{
    public class Termosztat : OkosEszkoz
    {
        public double JelenlegiHomerseklet { get; private set; } = 21;
        public double CelHomerseklet { get; private set; }

        public Termosztat(string azonosito, string nev, double celHomerseklet)
        : base(azonosito, nev)
        {
            CelHomerseklet = celHomerseklet;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            const string COMMAND = "BEALLIT_HOMERSEKLET:";
            if (!parancs.StartsWith(COMMAND)) return;
            var arg = parancs.AsSpan().Slice(parancs.IndexOf(':') + 1);
            if (double.TryParse(arg, System.Globalization.CultureInfo.InvariantCulture, out var v)) CelHomerseklet = v;
        }

        public override string AllapotJelentes()
        {
            return $"{JelenlegiHomerseklet}, {CelHomerseklet}";
        }

        protected override bool OnTesztFuttatasa()
        {
            return CelHomerseklet > 5 && CelHomerseklet < 35;
        }

    }
}
