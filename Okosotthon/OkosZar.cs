namespace Okosotthon
{
    public class OkosZar: OkosEszkoz, IHangjelzo, IStatisztika
    {
        public bool ZartE { get; private set; } = true;
        private string pinKod;
        private int m_NOpens;

        public OkosZar(string azonosito, string nev, string pinKod)
        : base(azonosito, nev)
        {
            this.pinKod = pinKod;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            var s = parancs.AsSpan();
            if (s.SequenceEqual("ZARAS")) { ZartE = true; return; }
            if (s.StartsWith("NYITAS:")) {
                var pin = s.Slice(s.IndexOf(':') + 1);
                if (pin.SequenceEqual(pinKod))
                {
                    ZartE = false;
                    m_NOpens++;
                    Csipog(100);
                }
                else VeszjelzesInditasa();

            }
        }


        public override string AllapotJelentes()
        {
            return ZartE.ToString();
        }

        protected override bool OnTesztFuttatasa()
        {
            return true;
        }

        public override void GyariBeallitasokVisszaallitasa()
        {
            base.GyariBeallitasokVisszaallitasa();
            pinKod = "0000";
            ZartE = true;
        }

        public string StatisztikatKeszit()
        {
            return m_NOpens.ToString();
        }

        public void Csipog(int hosszu)
        {
            var s = System.Diagnostics.Stopwatch.StartNew();
            while (s.ElapsedMilliseconds <= hosszu) Console.Beep();
        }

        public void VeszjelzesInditasa()
        {
            Csipog(1000);
        }
    }
}
