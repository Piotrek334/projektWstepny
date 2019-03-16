using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace RTVAGD
{
    enum KolorPralki
    {
        brak,
        biały,
        szary,
        niebieski,
        czarny
    }
    enum NazwaProgramyPrania
    {
        Brak,
        Bawełna,
        Wełna,
        Syntetyki,
        PłukanieWirowanie,
        Delikatny,
        Pościel,
        Wirowanie_OdprowadzanieWody,
        CiemneUbrania,
        Dziecięce,
        Odzież_Turystyczna
    }

    class Pralka
    {
        Wymiary WymiaryPralki;
        Zuzycie ZuzycieMedia;
        DaneTechniczne DanePralki;
        private KolorPralki KolorObudowy;
        private int ProgramPracy;
        private NazwaProgramyPrania NazwaProgramu;
        private bool CzyPodlaczonaDoPradu;
        private bool CzyWlaczona;
        private bool CzyOdkreconaWoda;

        class Zuzycie
        {
            private int ZuzycieWody;
            private double ZuzycieEnargii;

            public Zuzycie()
            {
                ZuzycieWody = 0;
                ZuzycieEnargii = 0;
            }

            public Zuzycie(int ZuzyWody, double ZuzyEner)
            {
                ZuzycieWody = ZuzyWody;
                ZuzycieEnargii = ZuzyEner;
            }


            public Zuzycie(Zuzycie CopyZuzycie)
            {
                ZuzycieWody = CopyZuzycie.ZuzycieWody;
                ZuzycieEnargii = CopyZuzycie.ZuzycieEnargii;
            }
        }
        class Wymiary
        {
            private int Wysokosc;
            private int Szerokosc;
            private int Glebokosc;

            public Wymiary()
            {
                Wysokosc = 0;
                Szerokosc = 0;
                Glebokosc = 0;
            }

            public Wymiary(int Wys, int Szer, int Gleb)
            {
                Wysokosc = Wys;
                Szerokosc = Szer;
                Glebokosc = Gleb;
            }

            public Wymiary(Wymiary CopyWymiar)
            {
                Wysokosc = CopyWymiar.Wysokosc;
                Szerokosc = CopyWymiar.Szerokosc;
                Glebokosc = CopyWymiar.Glebokosc;
            }
        }
        class DaneTechniczne
        {
            private int Gwarancja;
            private int MaxPredkoscWirowania;
            private int PojemnoscBebna;


            public DaneTechniczne()
            {
                Gwarancja = 0;
                MaxPredkoscWirowania = 0;
                PojemnoscBebna = 0;
            }

            public DaneTechniczne(int Gwaran, int MaxPredkosc, int PojemnBebna)
            {
                Gwarancja = Gwaran;
                MaxPredkoscWirowania = MaxPredkosc;
                PojemnoscBebna = PojemnBebna;
            }

            public DaneTechniczne(DaneTechniczne CopyDaneTechniczne)
            {
                Gwarancja = CopyDaneTechniczne.Gwarancja;
                MaxPredkoscWirowania = CopyDaneTechniczne.MaxPredkoscWirowania;
                PojemnoscBebna = CopyDaneTechniczne.PojemnoscBebna;
            }
        }


        public Pralka ()
        {
            WymiaryPralki = new Wymiary();
            ZuzycieMedia = new Zuzycie();
            DanePralki = new DaneTechniczne();
            KolorObudowy = 0;
            ProgramPracy = 0;
            NazwaProgramu = 0;
            CzyPodlaczonaDoPradu = false;
            CzyWlaczona = false;
            CzyOdkreconaWoda = false;
        }

        public Pralka(KolorPralki NewKolorPralki, NazwaProgramyPrania NewNazwaProgramyPrania, int wysokosc, int szerokosc, int glebokosc)
        {
            WymiaryPralki = new Wymiary(wysokosc,szerokosc,glebokosc);
            ZuzycieMedia = new Zuzycie(44,0.80);
            DanePralki = new DaneTechniczne(36,1600,10);
            KolorObudowy = NewKolorPralki;
            ProgramPracy = (int)NewNazwaProgramyPrania;
            NazwaProgramu = NewNazwaProgramyPrania;
            CzyPodlaczonaDoPradu = false;
            CzyWlaczona = false;
            CzyOdkreconaWoda = false;
        }
        
        public Pralka ( Pralka CopyPralka)
        {
            WymiaryPralki = new Wymiary(CopyPralka.WymiaryPralki);
            ZuzycieMedia = new Zuzycie(CopyPralka.ZuzycieMedia);
            DanePralki = new DaneTechniczne(CopyPralka.DanePralki);
            KolorObudowy = CopyPralka.KolorObudowy;
            ProgramPracy = CopyPralka.ProgramPracy;
            NazwaProgramu = CopyPralka.NazwaProgramu;
            CzyPodlaczonaDoPradu = CopyPralka.CzyPodlaczonaDoPradu;
            CzyWlaczona = CopyPralka.CzyWlaczona;
            CzyOdkreconaWoda = CopyPralka.CzyOdkreconaWoda;
        }

        public void PytanieGniazdko()
        {
            string ODPCzyGniadko;

            Console.WriteLine("Czy pralka jest podlaczony do gniazdka Wpisz t - tak lub n - nie");
            ODPCzyGniadko = Console.ReadLine();

            if (ODPCzyGniadko == "t" || ODPCzyGniadko == "T")
            {
                CzyPodlaczonaDoPradu = true;
            }

            else
            {
                CzyPodlaczonaDoPradu = false;
            }
        }

        public void PytanieCzyWlaczone()
        {
            string ODPCzyWlaczone;

            Console.WriteLine("Czy pralka jest podlaczony do gniazdka Wpisz t - tak lub n - nie");
            ODPCzyWlaczone = Console.ReadLine();

            if (ODPCzyWlaczone == "t" || ODPCzyWlaczone == "T")
            {
                CzyWlaczona = true;
            }
            else 
            {
                CzyWlaczona = false;
            }
        }

        public void PodczasPrania()
        {
            Console.WriteLine("Pralka pierze....");
            TimeSpan t = new TimeSpan(0, 0, 15);
            while (t != new TimeSpan(0, 0, 0))
            {
                Console.WriteLine("Wtrakcie Prania. Progam :  nr " + ProgramPracy + " " + NazwaProgramu);
                t -= new TimeSpan(0, 0, 1);
                Console.Write("Do zakonczenia zostalo: " + t.ToString());
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        public void CzyWylaczycPrzyciskiem()
        {
            string tmp;
            Console.WriteLine("Czy wyłączyć pralke przyciskiem ? TAK - T lub NIE - N");
            tmp = Console.ReadLine();
            if (tmp == "t" || tmp == "T")
            {
                CzyWlaczona = false;
            }
            Console.WriteLine(" ");
        }

        public void MenuPralka()
        {
            PytanieGniazdko();
            PytanieCzyWlaczone();

            int wybor = 1;
            while (wybor != 0)
            {
                Console.WriteLine("Wybierz co chcesz zrobić z pralka:");
                Console.WriteLine("0 - Wyjście");
                Console.WriteLine("1- Pokaż pralke w obecnym statusie");
                Console.WriteLine("2- Podłącz kabel pralki do gniazdka");
                Console.WriteLine("3- Włącz pralke przyciskiem");
                Console.WriteLine("4- Wyciagnij kabel pralki z gniazdka");
                Console.WriteLine("5- Wyłącz pralke przyciskiem");
                wybor = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (wybor)
                {
                    case 1:
                        {
                            if (CzyPodlaczonaDoPradu == false)
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Pralka jest odlaczony od gniazdka, przycisk wylaczony");
                                Console.WriteLine(" ");
                            }
                            else if (CzyPodlaczonaDoPradu == true && CzyWlaczona == false)
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Pralka jest podłączony do gniazdka oraz ma wylaczony przycisk!");
                                Console.WriteLine(" ");
                            }
                            else if (CzyPodlaczonaDoPradu == true && CzyWlaczona == true)
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Pralka jest podłączony do gniazdka oraz przycisk jest wlaczony!");
                                string tmp;
                                Console.WriteLine("Czy chcesz rozpocząć pranie? TAK to wpisz: T lub NIE to wbisz: N");
                                tmp = Console.ReadLine();
                                if (tmp == "t" || tmp == "T")
                                {
                                    if (CzyOdkreconaWoda == false)
                                    {
                                        Console.WriteLine("Pralka ma zakrecony zawor z wodą !! \n");
                                        Console.WriteLine("Czy odkrecic wode ? TAK - T lub NIE - N");
                                        tmp = Console.ReadLine();
                                        if (tmp == "t" || tmp == "T")
                                        {
                                            CzyOdkreconaWoda = true;
                                            var outer = Task.Factory.StartNew(() =>
                                            {
                                                PodczasPrania();
                                                var child = Task.Factory.StartNew(() =>
                                                {
                                                    CzyWylaczycPrzyciskiem();
                                                });
                                            });
                                        }
                                        else
                                        {
                                            CzyWylaczycPrzyciskiem();
                                        }
                                    }
                                }
                                CzyOdkreconaWoda = false;
                            }
                            break;
                        };
                    case 2:
                        {
                            if (CzyPodlaczonaDoPradu == false )
                            {
                                Console.Clear();
                                CzyPodlaczonaDoPradu = true;
                                Console.WriteLine(" ");
                                Console.WriteLine("Pralka został podłaczona do gniazdka");
                                Console.WriteLine(" ");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(" ");
                                Console.WriteLine("Pralka jest już podłączony do gniazdka, nie możesz ponownie jej podłączyć !!");
                                Console.WriteLine(" ");
                            }
                            break;
                        };
                    case 3:
                        {
                            if (CzyPodlaczonaDoPradu == true && CzyWlaczona == false)
                            {
                                Console.Clear();
                                CzyWlaczona = true;
                                Console.WriteLine(" ");
                                Console.WriteLine("Pralka została właczona przyciskiem \n ");
                                string tmp;
                                Console.WriteLine("Czy chcesz rozpocząć pranie? TAK to wpisz: T lub NIE to wbisz: N");
                                tmp = Console.ReadLine();
                                if (tmp == "t" || tmp == "T")
                                {
                                    if (CzyOdkreconaWoda == false)
                                    {
                                        Console.WriteLine("Pralka ma zakrecony zawor z wodą !! \n");
                                        Console.WriteLine("Czy odkrecic wode ? TAK - T lub NIE - N");
                                        tmp = Console.ReadLine();
                                        if (tmp == "t" || tmp == "T")
                                        {
                                            CzyOdkreconaWoda = true;

                                            PodczasPrania();
                                            CzyWylaczycPrzyciskiem();
                                        }
                                        else
                                        {
                                            CzyWylaczycPrzyciskiem();
                                        }
                                    }
                                }
                                CzyOdkreconaWoda = false;
                                Console.WriteLine(" ");
                            }
                            else if (CzyPodlaczonaDoPradu == false && CzyWlaczona == false)
                            {
                                Console.Clear();
                                Console.WriteLine(" ");
                                Console.WriteLine("Musisz najpierw pralke podłączyć do gniazdka !");
                                Console.WriteLine(" ");

                            }
                            else if (CzyPodlaczonaDoPradu == true && CzyWlaczona == true)
                            {
                                Console.Clear();
                                Console.WriteLine(" ");
                                Console.WriteLine("Pralka jest już właczona przyciskiem , nie możesz jej ponownie właczyć !");
                                string tmp;
                                Console.WriteLine("Czy chcesz rozpocząć pranie? TAK to wpisz: T lub NIE to wbisz: N");
                                tmp = Console.ReadLine();
                                if (tmp == "t" || tmp == "T")
                                {
                                    if (CzyOdkreconaWoda == false)
                                    {
                                        Console.WriteLine("Pralka ma zakrecony zawor z wodą !! \n");
                                        Console.WriteLine("Czy odkrecic wode ? TAK - T lub NIE - N");
                                        tmp = Console.ReadLine();
                                        if (tmp == "t" || tmp == "T")
                                        {
                                            CzyOdkreconaWoda = true;

                                            PodczasPrania();
                                            CzyWylaczycPrzyciskiem();
                                        }
                                        else
                                        {
                                            CzyWylaczycPrzyciskiem();
                                        }
                                    }
                                }
                                Console.WriteLine(" ");
                                CzyOdkreconaWoda = false;
                            }
                            break;
                        };
                    case 4:
                        {

                            if (CzyPodlaczonaDoPradu == true && CzyWlaczona == false)
                            {
                                Console.Clear();
                                CzyPodlaczonaDoPradu = false;
                                Console.WriteLine(" ");
                                Console.WriteLine("Pralka został odłączony od gniazdka");
                                Console.WriteLine(" ");
                            }
                            else if (CzyPodlaczonaDoPradu == true && CzyWlaczona == true)

                            {
                                Console.Clear();
                                CzyPodlaczonaDoPradu = false;
                                CzyWlaczona = false;
                                Console.WriteLine(" ");
                                Console.WriteLine("Pralka została odłączona od gniazdka");
                                Console.WriteLine(" ");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(" ");
                                Console.WriteLine("Pralka nie byla  podłaczona do gniazdka");
                                Console.WriteLine(" ");
                            }
                            break;
                        };
                    case 5:
                        {
                            if (CzyPodlaczonaDoPradu == true && CzyWlaczona == true)
                            {
                                Console.Clear();
                                CzyWlaczona = false;
                                Console.WriteLine(" ");
                                Console.WriteLine("Pralka został wyłaczony przyciskiem");
                                Console.WriteLine(" ");

                            }
                            else if (CzyPodlaczonaDoPradu == false )
                            {
                                Console.Clear();
                                Console.WriteLine(" ");
                                Console.WriteLine("Pralka nie jest podłączona do gniazdka ");
                                Console.WriteLine(" ");

                            }
                            else if (CzyPodlaczonaDoPradu == true && CzyWlaczona == false)
                            {
                                Console.Clear();
                                Console.WriteLine(" ");
                                Console.WriteLine("Pralka jest już wyłaczona przyciskiem");
                                Console.WriteLine(" ");
                            }
                            break;
                        };
                    
                }

            }
        }

    }

    enum KolorTelewizora
    {
        Brak,
        Bialy,
        Czarny,
        Szary,
        Srebrny
    }
    enum NazwaKanaluTelewizora
    {
        Brak,
        Polsat,
        TVN,
        TVP1,
        TVP2,
        TV_Puls
    }

    class Telewizor
    {
        Podstawka DanePodstawki;
        Wyswietlacz DaneWyswietlacz;
        Glosnik DaneGlosnik;
        PanelKlawiszy StatusKlawiszy;
        private KolorTelewizora KolorObudowy;
        private NazwaKanaluTelewizora NazwaProgramu;
        private int Program;
        private int PoziomGlosnosci;
        private int Wysokosc;
        private int Szerokosc;
        private int Glebokosc;
        private bool CzyPodlaczonaDoPradu;
        private bool CzyObraz3D;

        class Podstawka
        {
            private int WysokoscPods;
            private int SzerokoscPods;

            public Podstawka()
            {
                
                WysokoscPods = 0;
                SzerokoscPods = 0;
            }

            public Podstawka(int NewWysokoscPods, int NewSzerokoscPods)
            { 
                WysokoscPods = NewWysokoscPods;
                SzerokoscPods = NewSzerokoscPods;
            }

            public Podstawka(Podstawka CopyPodstawka)
            {
                WysokoscPods = CopyPodstawka.WysokoscPods;
                SzerokoscPods = CopyPodstawka.SzerokoscPods;
            }
        }

        class Wyswietlacz
        {
            private int Szerokosc;
            private int Wysokosc;
            private int PrzekatnaEkranuCAL;
            private bool CzyZakrzywionyEkran;

            public Wyswietlacz()
            {
                Szerokosc = 0;
                Wysokosc = 0;
                PrzekatnaEkranuCAL = 0;
                CzyZakrzywionyEkran = false;
            }

            public Wyswietlacz(int NewSzerokosc, int NewWysokosc, int NewPrzekatnaEkranuCAL, bool NewCzyZakrzywionyEkran)
            {
                Szerokosc = NewSzerokosc;
                Wysokosc = NewWysokosc;
                PrzekatnaEkranuCAL = NewPrzekatnaEkranuCAL;
                CzyZakrzywionyEkran = NewCzyZakrzywionyEkran;
            }

            public Wyswietlacz(Wyswietlacz CopyWyswietlacz)
            {
                Szerokosc = CopyWyswietlacz.Szerokosc;
                Wysokosc = CopyWyswietlacz.Wysokosc;
                PrzekatnaEkranuCAL = CopyWyswietlacz.PrzekatnaEkranuCAL;
                CzyZakrzywionyEkran = CopyWyswietlacz.CzyZakrzywionyEkran;
            }

        }

        class Glosnik
        {
            private int IloscGlosnikow;
            private int MocGlosnikow;

            public Glosnik()
            {

                IloscGlosnikow = 0;
                MocGlosnikow = 0;
            }

            public Glosnik(int NewIloscGlosnikow, int NewMocGlosnikow)
            {
                IloscGlosnikow = NewIloscGlosnikow;
                MocGlosnikow = NewMocGlosnikow;
            }

            public Glosnik(Glosnik CopyGlosnik)
            {
                IloscGlosnikow = CopyGlosnik.IloscGlosnikow;
                MocGlosnikow = CopyGlosnik.MocGlosnikow;
            }
        }

        class PanelKlawiszy
        {
            private bool Glosniej;
            private bool Ciszej;
            private bool ProgPlus;
            private bool ProgMinus;
            private bool CzyWlaczony;
            private int PoziomGlosnosci;
            private int Program;

            public PanelKlawiszy()
            {
                Glosniej = false;
                Ciszej = false;
                ProgPlus = false;
                ProgMinus = false;
                CzyWlaczony = false;
            }

            public PanelKlawiszy(bool NewGlosniej, bool NewCiszej, bool NewProgPlus, bool NewProgMinus, bool NewCzyWlaczony)
            {
                Glosniej = NewGlosniej;
                Ciszej = NewCiszej;
                ProgPlus = NewProgPlus;
                ProgMinus = NewProgMinus;
                CzyWlaczony = NewCzyWlaczony;
            }

            public PanelKlawiszy(PanelKlawiszy CopyPanelKlawiszy)
            {
                Glosniej = CopyPanelKlawiszy.Glosniej;
                Ciszej = CopyPanelKlawiszy.Ciszej;
                ProgPlus = CopyPanelKlawiszy.ProgPlus;
                ProgMinus = CopyPanelKlawiszy.ProgMinus;
                CzyWlaczony = CopyPanelKlawiszy.CzyWlaczony;
            }

            public void PytanieGlosniej()
            {

                string ODPCzyGlosniej;
                Console.Clear();
                Console.WriteLine("Czy chcesz dac głośniej? Wpisz t - TAK lub n - NIE");
                ODPCzyGlosniej = Console.ReadLine();
                if (ODPCzyGlosniej == "t" || ODPCzyGlosniej == "T")
                {
                    Glosniej = true;
                }
                else
                {
                    Console.WriteLine("A moze chcesz ciszej? Wpisz t - TAK lub n - NIE");
                    ODPCzyGlosniej = Console.ReadLine();
                    if (ODPCzyGlosniej == "T" || ODPCzyGlosniej == "t")
                    {
                        Ciszej = true;
                    }
                }

                if (Glosniej == true)
                {
                    Console.WriteLine("O ile kresek podglosnic ?  od 1 do 5 !");
                    int tmpile = 0;
                    tmpile = int.Parse(Console.ReadLine());
                    PoziomGlosnosci = PoziomGlosnosci + tmpile;
                }
                else if (Ciszej == true && PoziomGlosnosci >= 4)
                {
                    Console.WriteLine("O ile kresek przyciszyc ?  od 1 do 5 !");
                    int tmpile = 0;
                    tmpile = int.Parse(Console.ReadLine());
                    PoziomGlosnosci = PoziomGlosnosci - tmpile;
                }
            }
            public int WyswGlosniej
            {
                get
                {
                    return PoziomGlosnosci;
                }
            }

            public void PytaniePrzelaczyc()
            {
                string ODPCzyPrzelaczyc;

                Console.Clear();
                Console.WriteLine("Czy chcesz dac kolejny kanal? Wpisz t - TAK lub n - NIE");
                ODPCzyPrzelaczyc = Console.ReadLine();
                if (ODPCzyPrzelaczyc == "t" || ODPCzyPrzelaczyc == "T")
                {
                    ProgPlus = true;
                }
                else
                {
                    Console.WriteLine("A moze chcesz dac poprzedni kanal? Wpisz t - TAK lub n - NIE");
                    ODPCzyPrzelaczyc = Console.ReadLine();
                    if (ODPCzyPrzelaczyc == "T" || ODPCzyPrzelaczyc == "t")
                    {
                        ProgMinus = true;
                    }
                }
                if (ProgPlus == true)
                {
                    Console.WriteLine("O ile kanalow dalej przelaczyc  ?  od 1 do 4 !");
                    int tmpile = 0;
                    tmpile = int.Parse(Console.ReadLine());
                    Program = Program + tmpile;
                }
                else if (ProgMinus == true && Program >= 3)
                {
                    Console.WriteLine("O ile kanalow wstecz przelaczyc ?  od 1 do 3 !");
                    int tmpile = 0;
                    tmpile = int.Parse(Console.ReadLine());
                    Program = Program - tmpile;
                }
            }
            public int WyswProg
            {
                get
                {
                    return Program;
                }
            }

            public void PytanieCzyWlaczyc()
            {
                string ODPCzyGniadko;
                Console.WriteLine("Czy telewizor jest podlaczony do gniazdka Wpisz t - tak lub n - nie");
                ODPCzyGniadko = Console.ReadLine();

                if (ODPCzyGniadko == "t" || ODPCzyGniadko == "T")
                {
                    CzyWlaczony = true;
                }
                else
                {
                    CzyWlaczony = false;
                }
            }
            public bool WyswCzyWlacz
            {
                get
                {
                    return CzyWlaczony;
                }
            }
            public bool ZmienCzyWlacz
            {
                set
                {
                    CzyWlaczony = value;
                }
            }
        }

        public Telewizor()
        {
            DanePodstawki = new Podstawka();
            DaneWyswietlacz = new Wyswietlacz();
            DaneGlosnik = new Glosnik();
            StatusKlawiszy = new PanelKlawiszy();
            Wysokosc = 0;
            Szerokosc = 0;
            Glebokosc = 0;
            KolorObudowy = 0;
            Program = 0;
            PoziomGlosnosci = 0;
            NazwaProgramu = 0;
            CzyPodlaczonaDoPradu = false;
            CzyObraz3D = false;
        }

        public Telewizor(KolorTelewizora NewKolorObudowy, NazwaKanaluTelewizora NewNazwaProgramu,int NewWysokosc, int NewSzerokosc, int NewGlebokosc,  bool NewCzyObraz3D)
        {
            DanePodstawki = new Podstawka(15,50);
            DaneWyswietlacz = new Wyswietlacz(75, 45, 42, false);
            DaneGlosnik = new Glosnik(3, 55);
            StatusKlawiszy = new PanelKlawiszy(false, false, false, false, false);
            KolorObudowy = NewKolorObudowy;
            NazwaProgramu = NewNazwaProgramu;
            Wysokosc = NewWysokosc;
            Szerokosc = NewSzerokosc;
            Glebokosc = NewGlebokosc;
            Program = (int)NewNazwaProgramu;
            PoziomGlosnosci = StatusKlawiszy.WyswGlosniej;
            CzyPodlaczonaDoPradu = false;
            CzyObraz3D = NewCzyObraz3D;
        }

        public Telewizor(Telewizor CopyTelewizor)
        {
            DanePodstawki = new Podstawka(CopyTelewizor.DanePodstawki);
            DaneWyswietlacz = new Wyswietlacz(CopyTelewizor.DaneWyswietlacz);
            DaneGlosnik = new Glosnik(CopyTelewizor.DaneGlosnik);
            StatusKlawiszy = new PanelKlawiszy(CopyTelewizor.StatusKlawiszy);
            KolorObudowy = CopyTelewizor.KolorObudowy;
            NazwaProgramu = CopyTelewizor.NazwaProgramu;
            Wysokosc = CopyTelewizor.Wysokosc;
            Szerokosc = CopyTelewizor.Szerokosc;
            Glebokosc = CopyTelewizor.Glebokosc;
            Program = CopyTelewizor.Program;
            PoziomGlosnosci = CopyTelewizor.PoziomGlosnosci;
            CzyPodlaczonaDoPradu = CopyTelewizor.CzyPodlaczonaDoPradu;
            CzyObraz3D = CopyTelewizor.CzyObraz3D;
        }

        public void PytanieGniazdko()
        {
            string ODPCzyGniadko;

            Console.WriteLine("Czy telewizor jest podlaczony do gniazdka Wpisz t - tak lub n - nie");
            ODPCzyGniadko = Console.ReadLine();

            if (ODPCzyGniadko == "t" || ODPCzyGniadko == "T")
            {
                CzyPodlaczonaDoPradu = true;
            }
            else
            {
                CzyPodlaczonaDoPradu = false;
            }
        }

        public void WlaczonyTelewizor()
        {
            Console.WriteLine("rozpoczynam ogladanie prog : nr " + Program+1 + " " + NazwaProgramu);
            TimeSpan t = new TimeSpan(0, 0, 15);
            while (t != new TimeSpan(0, 0, 0))
            {
                Console.WriteLine("Wtrakcie ogladania : nr " + Program+1 + " " + NazwaProgramu);
                t -= new TimeSpan(0, 0, 1);
                Console.Write("Do zakonczenia zostalo: " + t.ToString());
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        public void CzyWylaczycPrzyciskiem()
        {
            string tmp;
            Console.WriteLine("Czy wyłączyć telewizor przyciskiem ? TAK - T lub NIE - N");
            tmp = Console.ReadLine();
            if (tmp == "t" || tmp == "T")
            {
                StatusKlawiszy.ZmienCzyWlacz = false;
            }
            Console.WriteLine(" ");
        }
        
        public void MenuTelewizor()
        {
            PytanieGniazdko();
            StatusKlawiszy.PytanieCzyWlaczyc();

            int wybor = 1;
            while (wybor != 0)
            {
                Console.WriteLine("Wybierz co chcesz zrobić z telewizorem:");
                Console.WriteLine("0 - Wyjście");
                Console.WriteLine("1- Pokaż telewizor w obecnym statusie");
                Console.WriteLine("2- Podłącz kabel telewizora do gniazdka");
                Console.WriteLine("3- Włącz telewizor przyciskiem");
                Console.WriteLine("4- Wyciagnij kabel telewizora z gniazdka");
                Console.WriteLine("5- Wyłącz telewizor przyciskiem");
                wybor = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (wybor)
                {
                    case 1:
                        {
                            if (CzyPodlaczonaDoPradu == false)
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Telewizor jest odlaczony od gniazdka, przycisk wylaczony");
                                Console.WriteLine(" ");
                            }
                            else if (CzyPodlaczonaDoPradu == true && StatusKlawiszy.WyswCzyWlacz == false)
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Telewizor jest podłączony do gniazdka oraz ma wylaczony przycisk!");
                                Console.WriteLine(" ");
                            }
                            else if (CzyPodlaczonaDoPradu == true && StatusKlawiszy.WyswCzyWlacz == true)
                            {
                                string tmp;
                                bool tmpGosniej = false, tmpProgram = false;
                                Console.WriteLine(" ");
                                Console.WriteLine("Telewizor jest podłączony do gniazdka oraz przycisk jest wlaczony!");
                                Console.WriteLine("Czy chcesz rozpocząć ogladanie? TAK to wpisz: T lub NIE to wbisz: N");
                                tmp = Console.ReadLine();
                                if (tmp == "t" || tmp == "T")
                                {
                                    Console.WriteLine("Aktualny poziom glosnosci : " + StatusKlawiszy.WyswGlosniej);
                                    Console.WriteLine("Czy chcesz zmienic glosnosc telewizora? TAK - T lub NIE - N");
                                    tmp = Console.ReadLine();
                                    if (tmp == "t"  || tmp == "T")
                                    {
                                        tmpGosniej = true;
                                    }
                                    Console.WriteLine("Aktualny program : nr " + Program+1 + " " + NazwaProgramu);
                                    Console.WriteLine("Czy chcesz zmienic program ? TAK - T lub NIE - N");
                                    tmp = Console.ReadLine();
                                    if (tmp == "t" || tmp == "T")
                                    {
                                        tmpProgram = true;
                                    }

                                    if (tmpGosniej == true && tmpProgram == true)
                                    {
                                        StatusKlawiszy.PytanieGlosniej();
                                        StatusKlawiszy.PytaniePrzelaczyc();
                                        Program = StatusKlawiszy.WyswProg;
                                        NazwaProgramu = NazwaProgramu + Program;

                                        WlaczonyTelewizor();
                                        CzyWylaczycPrzyciskiem();
                                    }
                                    else if (tmpGosniej == false && tmpProgram == true)
                                    {
                                        StatusKlawiszy.PytaniePrzelaczyc();
                                        Program = StatusKlawiszy.WyswProg;
                                        NazwaProgramu = NazwaProgramu + Program;

                                        WlaczonyTelewizor();
                                        CzyWylaczycPrzyciskiem();
                                    }
                                    else if (tmpGosniej == true && tmpProgram == false)
                                    {
                                        StatusKlawiszy.PytanieGlosniej();

                                        WlaczonyTelewizor();
                                        CzyWylaczycPrzyciskiem();
                                    }
                                    else
                                    {
                                        WlaczonyTelewizor();
                                        CzyWylaczycPrzyciskiem();
                                    }
                                }
                                else
                                {
                                    CzyWylaczycPrzyciskiem();
                                }
                            }
                            break;
                        };
                    case 2:
                        {
                            if (CzyPodlaczonaDoPradu == false)
                            {
                                Console.Clear();
                                CzyPodlaczonaDoPradu = true;
                                Console.WriteLine(" ");
                                Console.WriteLine("Telewizor został podłaczony do gniazdka");
                                Console.WriteLine(" ");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(" ");
                                Console.WriteLine("Telewizor jest już podłączony do gniazdka, nie możesz ponownie go podłączyć !!");
                                Console.WriteLine(" ");
                            }
                            break;
                        };
                    case 3:
                        {
                            if (CzyPodlaczonaDoPradu == true && StatusKlawiszy.WyswCzyWlacz == false)
                            {
                                Console.Clear();
                                StatusKlawiszy.ZmienCzyWlacz = true;
                                Console.WriteLine(" ");
                                Console.WriteLine("telewizor został właczona przyciskiem \n ");
                                string tmp;
                                bool tmpGosniej = false, tmpProgram = false;
                                Console.WriteLine("Czy chcesz rozpocząć ogladanie? TAK to wpisz: T lub NIE to wbisz: N");
                                tmp = Console.ReadLine();
                                if (tmp == "t" || tmp == "T")
                                {
                                    Console.WriteLine("Aktualny poziom glosnosci : " + StatusKlawiszy.WyswGlosniej);
                                    Console.WriteLine("Czy chcesz podglosnic telewizor ? TAK - T lub NIE - N");
                                    tmp = Console.ReadLine();
                                    if (tmp == "t" || tmp == "T")
                                    {
                                        tmpGosniej = true;
                                    }
                                    Console.WriteLine("Aktualny program : nr " + Program+1 + " " + NazwaProgramu);
                                    Console.WriteLine("Czy chcesz zmienic program ? TAK - T lub NIE - N");
                                    tmp = Console.ReadLine();
                                    if (tmp == "t" || tmp == "T")
                                    {
                                        tmpProgram = true;
                                    }
                                    if (tmpGosniej == true && tmpProgram == true)
                                    {
                                        StatusKlawiszy.PytanieGlosniej();
                                        StatusKlawiszy.PytaniePrzelaczyc();
                                        Program = StatusKlawiszy.WyswProg;
                                        NazwaProgramu = NazwaProgramu + Program;

                                        WlaczonyTelewizor();
                                        CzyWylaczycPrzyciskiem();

                                    }
                                    else if (tmpGosniej == false && tmpProgram == true)
                                    {
                                        StatusKlawiszy.PytaniePrzelaczyc();
                                        Program = StatusKlawiszy.WyswProg;
                                        NazwaProgramu = NazwaProgramu + Program;

                                        WlaczonyTelewizor();
                                        CzyWylaczycPrzyciskiem();
                                    }
                                    else if (tmpGosniej == true && tmpProgram == false)
                                    {
                                        StatusKlawiszy.PytanieGlosniej();

                                        WlaczonyTelewizor();
                                        CzyWylaczycPrzyciskiem();
                                    }
                                    else
                                    {
                                        WlaczonyTelewizor();
                                        CzyWylaczycPrzyciskiem();
                                    }
                                }
                                else
                                {
                                    CzyWylaczycPrzyciskiem();
                                }
                            }
                            else if (CzyPodlaczonaDoPradu == false && StatusKlawiszy.WyswCzyWlacz == false)
                            {
                                Console.Clear();
                                Console.WriteLine(" ");
                                Console.WriteLine("Musisz najpierw telewizor podłączyć do gniazdka !");
                                Console.WriteLine(" ");

                            }
                            else if (CzyPodlaczonaDoPradu == true && StatusKlawiszy.WyswCzyWlacz == true)
                            {
                                Console.Clear();
                                Console.WriteLine(" ");
                                Console.WriteLine("Telewizor jest już właczony przyciskiem , nie możesz jej ponownie właczyć !");
                                string tmp;
                                bool tmpGosniej = false, tmpProgram = false;
                                Console.WriteLine("Czy chcesz rozpocząć ogladanie? TAK to wpisz: T lub NIE to wbisz: N");
                                tmp = Console.ReadLine();
                                if (tmp == "t" || tmp == "T")
                                {
                                    Console.WriteLine("Aktualny poziom glosnosci : " + StatusKlawiszy.WyswGlosniej);
                                    Console.WriteLine("Czy chcesz podglosnic telewizor ? TAK - T lub NIE - N");
                                    tmp = Console.ReadLine();
                                    if (tmp == "t" || tmp == "T")
                                    {
                                        tmpGosniej = true;
                                    }
                                    Console.WriteLine("Aktualny program : nr " + Program+1 + " " + NazwaProgramu);
                                    Console.WriteLine("Czy chcesz zmienic program ? TAK - T lub NIE - N");
                                    tmp = Console.ReadLine();
                                    if (tmp == "t" || tmp == "T")
                                    {
                                        tmpProgram = true;
                                    }
                                    if (tmpGosniej == true && tmpProgram == true)
                                    {
                                        StatusKlawiszy.PytanieGlosniej();
                                        StatusKlawiszy.PytaniePrzelaczyc();
                                        Program = StatusKlawiszy.WyswProg;
                                        NazwaProgramu = NazwaProgramu + Program;

                                        WlaczonyTelewizor();
                                        CzyWylaczycPrzyciskiem();
                                    }
                                    else if (tmpGosniej == false && tmpProgram == true)
                                    {
                                        StatusKlawiszy.PytaniePrzelaczyc();
                                        Program = StatusKlawiszy.WyswProg;
                                        NazwaProgramu = NazwaProgramu + Program;

                                        WlaczonyTelewizor();
                                        CzyWylaczycPrzyciskiem();
                                    }
                                    else if (tmpGosniej == true && tmpProgram == false)
                                    {
                                        StatusKlawiszy.PytanieGlosniej();

                                        WlaczonyTelewizor();
                                        CzyWylaczycPrzyciskiem();
                                    }
                                    else
                                    {
                                        WlaczonyTelewizor();
                                        CzyWylaczycPrzyciskiem();
                                    }
                                }
                                else
                                {
                                    CzyWylaczycPrzyciskiem();
                                }
                            }
                            break;
                        };
                    case 4:
                        {

                            if (CzyPodlaczonaDoPradu == true && StatusKlawiszy.WyswCzyWlacz == false)
                            {
                                Console.Clear();
                                CzyPodlaczonaDoPradu = false;
                                Console.WriteLine(" ");
                                Console.WriteLine("Telewizor został odłączony od gniazdka");
                                Console.WriteLine(" ");
                            }
                            else if (CzyPodlaczonaDoPradu == true && StatusKlawiszy.WyswCzyWlacz == true)

                            {
                                Console.Clear();
                                CzyPodlaczonaDoPradu = false;
                                StatusKlawiszy.ZmienCzyWlacz = false;
                                Console.WriteLine(" ");
                                Console.WriteLine("Telewizor został odłączony od gniazdka");
                                Console.WriteLine(" ");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(" ");
                                Console.WriteLine("Telewizor nie byl  podłaczony do gniazdka");
                                Console.WriteLine(" ");
                            }
                            break;
                        };
                    case 5:
                        {
                            if (CzyPodlaczonaDoPradu == true && StatusKlawiszy.WyswCzyWlacz == true)
                            {
                                Console.Clear();
                                StatusKlawiszy.ZmienCzyWlacz = false;
                                Console.WriteLine(" ");
                                Console.WriteLine("Telewizor został wyłaczon przyciskiem");
                                Console.WriteLine(" ");

                            }
                            else if (CzyPodlaczonaDoPradu == false)
                            {
                                Console.Clear();
                                Console.WriteLine(" ");
                                Console.WriteLine("Telewizor nie jest podłączony do gniazdka ");
                                Console.WriteLine(" ");

                            }
                            else if (CzyPodlaczonaDoPradu == true && StatusKlawiszy.WyswCzyWlacz == false)
                            {
                                Console.Clear();
                                Console.WriteLine(" ");
                                Console.WriteLine("Telewizor jest już wyłaczony przyciskiem");
                                Console.WriteLine(" ");
                            }
                            break;
                        };

                }

            }
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            
            Pralka NowaPralka = new Pralka();
            Pralka NowaPralka1 = new Pralka(KolorPralki.niebieski, NazwaProgramyPrania.CiemneUbrania,50,23,14);
            Pralka NowaPralka2 = new Pralka(KolorPralki.czarny, NazwaProgramyPrania.PłukanieWirowanie,60,40,18);
            Pralka NowaPralka3 = new Pralka(NowaPralka2);
            NowaPralka2.MenuPralka();
            Console.ReadKey();

            Telewizor NowyTelewizor = new Telewizor();
            Telewizor NowyTelewizor1 = new Telewizor(KolorTelewizora.Brak, NazwaKanaluTelewizora.Polsat, 55, 120, 10, false) ;
            Telewizor NowyTelewizor2 = new Telewizor(KolorTelewizora.Czarny, NazwaKanaluTelewizora.TVN, 60,132,15,true);
            Telewizor NowyTelewizor3 = new Telewizor(NowyTelewizor2);
            NowyTelewizor2.MenuTelewizor();
            Console.ReadKey();
            

        }
    }
}
