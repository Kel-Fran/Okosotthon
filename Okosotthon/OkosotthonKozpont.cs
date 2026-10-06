namespace Okosotthon
{
    public class OkosotthonKozpont
    {
        private readonly List<OkosEszkoz> eszkozok = [];

        public void EszkozHozzaadasa(OkosEszkoz eszkoz)
        {
            eszkozok.Add(eszkoz);
        }

     
        public void OsszesCsatlakoztatasa()
        {
            eszkozok.ForEach(it => it.Csatlakozas());
        }

        public int RendszerDiagnosztikaFuttatasa()
        {
            return eszkozok.Aggregate(0, (acc, r) => r.DiagnosztikaFuttatasa() ? acc + 1 : acc);
        }

    }
}
