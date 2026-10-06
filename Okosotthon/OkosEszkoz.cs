namespace Okosotthon
{
    public abstract class OkosEszkoz
    {
        private string azonosito;
        private string nev;
        private bool onlineE;
        private DateTime utolsoFrissites;

        public string Azonosito { get => azonosito; private set => azonosito = value; }
        public string Nev { get => nev; private set => nev = value; }
        public bool OnlineE { get => onlineE; private set => onlineE = value; }
        public DateTime UtolsoFrissites { get => utolsoFrissites; protected set => utolsoFrissites = value; }

        public OkosEszkoz(string azonosito, string nev)
        {

            this.azonosito = azonosito;
            this.nev = nev;
            OnlineE = false;
            UtolsoFrissites = DateTime.Now;
        }


        public void Csatlakozas()
        {
            OnlineE = true;
        }


        public void KapcsolatBontasa()
        {
            OnlineE = false;
        }
        public bool DiagnosztikaFuttatasa()
        {
            return OnlineE && OnTesztFuttatasa();
        }

        public virtual void GyariBeallitasokVisszaallitasa()
        {
            // noop
        }


        public abstract void ParancsVegrehajtasa(string parancs);
        public abstract string AllapotJelentes();
        protected abstract bool OnTesztFuttatasa();
    }
}
