using System;
using System.IO;
using contestrunner.contract.host;
using contest.submission.contract;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics;

namespace contest.host
{

  public class Dnp1604Host : IHost
  {
    string stopmessage = "";
    
    public void Prüfen(object beitrag, string wettbewerbspfad, string beitragsverzeichnis)
    {
      var stopwatch = new Stopwatch();
      var sut = (IDnp1604Solution)beitrag;

      stopwatch.Start();


      sut.SendResult += x =>
        {
          stopwatch.Stop();
          Console.WriteLine("Anzahl der Magischen Zahlen: " + x);
          Console.WriteLine("Dauer für die Berechnung: " + stopwatch.Elapsed);
        };
      
      var anfang = new Prüfungsanfang { Wettbewerb = Path.GetFileName(wettbewerbspfad), Beitrag = Path.GetFileName(beitragsverzeichnis) };
      Anfang(anfang);
      sut.CalculateCountOfMagicNumbers(3, 2);
      
      Status(new Prüfungsstatus() { Statusmeldung = stopmessage });

      Ende(new Prüfungsende(){  });

    }

    public event Action<Prüfungsanfang> Anfang;
    public event Action<Prüfungsstatus> Status;
    public event Action<Prüfungsende> Ende;
    public event Action<Prüfungsfehler> Fehler;
  }

}
