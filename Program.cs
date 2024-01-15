

using System.Net;
using System.Numerics;

FantasyTeam mojfantasyTeam = new FantasyTeam("Prvi", "Partizan");

mojfantasyTeam.DodajIgraca("Pera", "Peric", Pozicija.GK);
mojfantasyTeam.DodajIgraca("Mika", "Mikic", Pozicija.MID);

mojfantasyTeam.SetCaptain("Pera", "Peric");

Console.WriteLine($"Team: {mojfantasyTeam.Naziv}");
Console.WriteLine($"Favorite Club: {mojfantasyTeam.NazivOmiljenogKluba}");
Console.WriteLine($"Captain: {mojfantasyTeam.Kapiten.Ime} {mojfantasyTeam.Kapiten.Prezime}");

string odgovor = "da";
Console.WriteLine("Da li zelite da dodate igraca ?");
odgovor=Console.ReadLine();
if (odgovor=="da")
{
    Console.WriteLine("Unesite ime: ");
    string ime = Console.ReadLine();

    Console.WriteLine("Unesite prezime: ");
    string prezime = Console.ReadLine();

    Console.WriteLine("Unesite poziciju 1-4: ");
    int ppozicija = int.Parse(Console.ReadLine());

    while (ppozicija < 0 && ppozicija >= 4)
    {
        Console.WriteLine("Ponovo");
        ppozicija = int.Parse(Console.ReadLine());
    }
    Pozicija unetapoz = (Pozicija)ppozicija;

    mojfantasyTeam.DodajIgraca(ime, prezime, unetapoz);
    Console.WriteLine($"dodat je igrac {ime} {prezime} {unetapoz}");
    mojfantasyTeam.IspisiIgrace();
}
else
{
    mojfantasyTeam.IspisiIgrace();
}


Console.ReadLine();
public class FantasyTeam
{
    public string Naziv { get; set; }
    public string NazivOmiljenogKluba { get; set; }
    public int BrojPoena { get; set; }
    public List<Igrac> Igraci { get; set; }
    public Igrac Kapiten { get; set; }

    public FantasyTeam(string naziv, string nazivOmiljenog)
    {
        Naziv = naziv;
        NazivOmiljenogKluba = nazivOmiljenog;
        BrojPoena = 0;
        Igraci = new List<Igrac>();
    }

    public void DodajIgraca(string ime, string prezime, Pozicija pozicija)
    {
        Igrac noviIgrac = new Igrac()
        {
            Ime = ime,
            Prezime = prezime,
            Pozicija = pozicija
        };
        Igraci.Add(noviIgrac);
    }
    public void IspisiIgrace()
    {
        Console.WriteLine("Svi igraci u timu:");

        foreach (Igrac igrac in Igraci)
        {
            Console.WriteLine($"{igrac.Ime} {igrac.Prezime} - {igrac.Pozicija}");
        }
    }
    public void SetCaptain(string ime, string prezime)
    {
        Igrac captain = Igraci.Find(player => player.Ime == ime && player.Prezime == prezime);

        if (captain != null)
        {
            Kapiten = captain;
            Console.WriteLine($"Postavljen je kapiten: {captain.Ime} {captain.Prezime}");
        }
        else
        {
            Console.WriteLine("Player not found.");
        }
    }
}
public class Igrac
{
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public Pozicija Pozicija { get; set; }

}

public enum Pozicija
{
    GK=1,
    DEF,
    MID,
    FWD
}

