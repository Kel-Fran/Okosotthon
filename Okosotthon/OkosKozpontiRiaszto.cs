namespace Okosotthon;

public class OkosKozpontiRiaszto : OkosEszkoz, IIdozitheto, IHangjelzo, IStatisztika
{
    private bool m_Alerting;
    public OkosKozpontiRiaszto(string azonosito, string nev) : base(azonosito, nev)
    {
    }

    public int MaradtIdo => m_Alerting ? 0 : int.MaxValue;

    public override string AllapotJelentes()
    {
        return m_Alerting.ToString();
    }

    public void Csipog(int hosszu)
    {
        var s = System.Diagnostics.Stopwatch.StartNew();
        while (s.ElapsedMilliseconds < hosszu) Console.Beep();
    }

    public void IdozitestBeallit(int perc)
    {
        // noop
    }

    public override void ParancsVegrehajtasa(string parancs)
    {
        switch (parancs) {
            case "START_ALERT": m_Alerting = true; break;
            case "STOP_ALERT" : m_Alerting = false; break;
        }
    }

    public string StatisztikatKeszit()
    {
        return AllapotJelentes();
    }

    public void VeszjelzesInditasa()
    {
        m_Alerting = true;
    }

    protected override bool OnTesztFuttatasa()
    {
        return true;
    }
}
