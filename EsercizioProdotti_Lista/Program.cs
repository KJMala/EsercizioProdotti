using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioProdotti_Lista
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Ecommerce e = new Ecommerce();
            e.CreaListaEcommerce();
            e.Start();
        }

        public class Ecommerce
        {
            
            public List<Utente> UtenteList { get; set; } = new List<Utente>();
            public List<Ordine> OrdineList { get; set; } = new List<Ordine>();
            public List<Prodotto> ProdottoList { get; set; } = new List<Prodotto>();
            public Ecommerce() 
            { 

            }
            public void Start()
            {
                int scelta = 0;
                Console.WriteLine("Scegli una opzione: \n1. Elenco Clienti \n2. Importo totale ordini \n3. Elenco ordini sotto certo importo \n4. Elenco prodotti cui giacenza è inferiore \n5. Elenco articoli \n");
                scelta = Convert.ToInt32(Console.ReadLine());
                if (scelta == 1)
                {
                    ElencoClienti();
                    Console.Clear();
                    Start();
                }
                else if (scelta == 2)
                {
                    ImportoTotaleOrdini();

                    Console.Clear();
                    Start();
                }
                else if (scelta == 3)
                {
                    ControlloImportoOrdini();

                    Console.Clear();
                    Start();
                }
                else if (scelta == 4)
                {
                    ElencoProdottiGiacenza();

                    Console.Clear();
                    Start();
                }
                else if (scelta == 5)
                {
                    ElencoArticoli();
                    Console.Clear();
                    Start();
                }
                else
                {
                    Console.WriteLine("Opzione non disponibile\n");
                    Console.Clear();
                    Start();
                }
            }
            public void ElencoClienti()
            {
                Console.WriteLine("Ecco l'elenco dei clienti che hanno effettuato un ordine:\n");
                foreach (Utente item in UtenteList)
                {
                    if (item.Nome != null)
                    {
                        Console.WriteLine($"\nNome: {item.Nome} | Cognome: {item.Cognome}");
                        foreach (IndirizzoUtente i in item.IndirizzoUtente)
                        {
                            Console.WriteLine($"Indirizzo: {i.Indirizzo}");
                            foreach (MetodoPagamento m in item.MetodoPagamento)
                            {
                                Console.WriteLine($"Metodo di pagamento: {m.Pagamento}");
                            }
                            
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine("\nPremi invio per continuare");
                Console.ReadLine();
            }

            public void ImportoTotaleOrdini()
            {
                double Totale = 0;
                foreach (Ordine item in OrdineList)
                {
                     Totale += item.ImportoTotaleOrdine;
                }
                Console.WriteLine($"\nl'importo totale di tutti gli ordini effettuati è {Totale} euro");
                Console.WriteLine("\nPremi invio per continuare");
                Console.ReadLine();
            }

            public void ControlloImportoOrdini()
            {
                int scelta = 0;
                Console.WriteLine("Selezionare sopra quale importo vedere l'ordine");
                scelta = Convert.ToInt32(Console.ReadLine());
                foreach (Ordine item in OrdineList)
                {
                    if (item.ImportoTotaleOrdine > scelta)
                    {
                        Console.WriteLine($"l'ordine che ha superato i {scelta} euro ha ID: {item.ID} con importo {item.ImportoTotaleOrdine} fatto in data: {item.DataOrdine} pagato con: {item.MetodoPagamento.Pagamento}");
                    }
                    else
                    {
                        Console.WriteLine($"l'ordine che NON ha superato i {scelta} euro ha ID: {item.ID} con importo {item.ImportoTotaleOrdine} fatto in data: {item.DataOrdine} pagato con: {item.MetodoPagamento.Pagamento}");
                    }
                }
                Console.WriteLine("\nPremi invio per continuare");
                Console.ReadLine();
            }

            public void ElencoProdottiGiacenza()
            {
                int scelta = 0;
                Console.WriteLine("\nIl numero che inserirai controllerà quanti prodotti sono inferiori al numero scelto");
                scelta = Convert.ToInt32(Console.ReadLine());
                foreach (Prodotto item in ProdottoList)
                {
                        if (item.Quantità < scelta)
                        {
                            Console.WriteLine($"\n L'ordine che ha meno di {scelta} quantità in giacenza è: {item.NomeProdotto}");
                        }
                }
                Console.WriteLine("\nPremi invio per continuare");
                Console.ReadLine();
            }

            public void ElencoArticoli()
            {
                int id = 0;
                Console.WriteLine("Inserisci l'id dell'ordine");
                id = Convert.ToInt32(Console.ReadLine());
                foreach (Ordine item in OrdineList)
                {
                        if (id == item.ID)
                        {
                        Console.WriteLine($"Elenco degli articoli nell'ordine {item.ID}:");

                        foreach (Prodotto p in item.Prodotti)
                        {
                            Console.WriteLine($"Nome Prodotto: {p.NomeProdotto}");
                        }
                           
                }
                    
            }
                Console.WriteLine("\nPremi invio per continuare");
                Console.ReadLine();
        }
            public void CreaListaEcommerce()
            {
                //Creazione Utente//
                Utente utente1 = new Utente();
                utente1.Nome = "Andrea";
                utente1.Cognome = "Malavasi";
                Utente utente2 = new Utente();
                utente2.Nome = "Mario";
                utente2.Cognome = "Rossi";
                Utente utente3 = new Utente();
                utente3.Nome = "Marco";
                utente3.Cognome = "Gialli";
                Utente utente4 = new Utente();
                utente4.Nome = "Alex";
                utente4.Cognome = "Grigio";
                Utente utente5 = new Utente();
                utente5.Nome = "Giacomo";
                utente5.Cognome = "Neri";

                MetodoPagamento metodopagamento1= new MetodoPagamento();
                metodopagamento1.Pagamento = "Contanti";
                MetodoPagamento metodopagamento2 = new MetodoPagamento();
                metodopagamento2.Pagamento = "Bonifico";
                MetodoPagamento metodopagamento3 = new MetodoPagamento();
                metodopagamento3.Pagamento = "Carta di credito";

                IndirizzoUtente indirizzoutente1 = new IndirizzoUtente();
                indirizzoutente1.Indirizzo = "Piazza Italia, 20";
                IndirizzoUtente indirizzoutente2 = new IndirizzoUtente();
                indirizzoutente2.Indirizzo = "Via Leopardi, 55";
                IndirizzoUtente indirizzoutente3 = new IndirizzoUtente();
                indirizzoutente3.Indirizzo = "Viale Italia 80";

                utente1.MetodoPagamento.Add(metodopagamento1);
                utente1.IndirizzoUtente.Add(indirizzoutente1);

                utente2.MetodoPagamento.Add(metodopagamento2);
                utente2.IndirizzoUtente.Add(indirizzoutente2);

                utente3.MetodoPagamento.Add(metodopagamento3);
                utente3.IndirizzoUtente.Add(indirizzoutente3);

                utente4.MetodoPagamento.Add(metodopagamento1);
                utente4.IndirizzoUtente.Add(indirizzoutente3);
                utente4.MetodoPagamento.Add(metodopagamento2);

                utente5.MetodoPagamento.Add(metodopagamento2);
                utente5.MetodoPagamento.Add(metodopagamento1);
                utente5.IndirizzoUtente.Add(indirizzoutente1);
                // FINE Creazione Utente//

                //INIZIO Creazione Prodotti//

                Prodotto prodotto1 = new Prodotto();
                prodotto1.NomeProdotto = "CD";
                prodotto1.Prezzo = 10;
                prodotto1.Descrizione = "CD Musicale";
                prodotto1.Brand = "Maneskin";
                prodotto1.Quantità = 1;

                Prodotto prodotto2 = new Prodotto();
                prodotto2.NomeProdotto = "Console";
                prodotto2.Prezzo = 125;
                prodotto2.Descrizione = "Switch";
                prodotto2.Brand = "Nintendo";
                prodotto2.Quantità = 2;

                Prodotto prodotto3 = new Prodotto();
                prodotto3.NomeProdotto = "Cuffie";
                prodotto3.Prezzo = 25;
                prodotto3.Descrizione = "Cuffie generiche";
                prodotto3.Brand = "AirPods";
                prodotto3.Quantità = 3;

                Prodotto prodotto4 = new Prodotto();
                prodotto4.NomeProdotto = "Telefono";
                prodotto4.Prezzo = 50;
                prodotto4.Descrizione = "Smartphone";
                prodotto4.Brand = "Oppo";
                prodotto4.Quantità = 4;

                Prodotto prodotto5 = new Prodotto();
                prodotto5.NomeProdotto = "Alexa";
                prodotto5.Prezzo = 75;
                prodotto5.Descrizione = "Amazon";
                prodotto5.Brand = "Amazon";
                prodotto5.Quantità = 5;

                //FINE Creazione Prodotti//

                //INIZIO Creazione DatiSpedizione//

                DatiSpedizione spedizione1 = new DatiSpedizione();
                spedizione1.Destinazione = "Modena";
                spedizione1.NomeCorriere = "DHL";
                DatiSpedizione spedizione2 = new DatiSpedizione();
                spedizione2.Destinazione = "Roma";
                spedizione2.NomeCorriere = "Bartolini";
                DatiSpedizione spedizione3 = new DatiSpedizione();
                spedizione3.Destinazione = "Brescia";
                spedizione3.NomeCorriere = "Poste Italiane";

                //INIZIO Creazione Ordini//

                Ordine ordine1 = new Ordine();
                ordine1.ID = 1;
                ordine1.DataOrdine = new DateTime(2023, 04, 01);
                ordine1.DataOrdine.ToString("d");
                ordine1.ImportoTotaleOrdine = prodotto1.Prezzo * prodotto1.Quantità;
                ordine1.MetodoPagamento = metodopagamento1;
                ordine1.DatiSpedizione = spedizione1;
                ordine1.Prodotti.Add(prodotto1);

                Ordine ordine2 = new Ordine();
                ordine2.ID = 2;
                ordine2.DataOrdine = new DateTime(2023, 06, 02);
                ordine2.DataOrdine.ToString("d");
                ordine2.ImportoTotaleOrdine = prodotto2.Prezzo * prodotto2.Quantità + prodotto4.Prezzo * prodotto4.Quantità;
                ordine2.DatiSpedizione = spedizione2;
                ordine2.MetodoPagamento = metodopagamento2;
                ordine2.Prodotti.Add(prodotto2);
                ordine2.Prodotti.Add(prodotto4);


                Ordine ordine3 = new Ordine();
                ordine3.ID = 3;
                ordine3.DataOrdine = new DateTime(2023, 08, 21);
                ordine3.DataOrdine.ToString("d");
                ordine3.ImportoTotaleOrdine = prodotto3.Prezzo * prodotto3.Quantità + prodotto5.Prezzo * prodotto5.Quantità;
                ordine3.DatiSpedizione = spedizione3;
                ordine3.MetodoPagamento = metodopagamento3;
                ordine3.Prodotti.Add(prodotto3);
                ordine3.Prodotti.Add(prodotto5);

                //FINE Creazione Ordini//

                //Aggiunta Liste//
                UtenteList.Add(utente1);
                UtenteList.Add(utente2);
                UtenteList.Add(utente3);
                UtenteList.Add(utente4);
                UtenteList.Add(utente5);

                ProdottoList.Add(prodotto1);
                ProdottoList.Add(prodotto2);
                ProdottoList.Add(prodotto3);
                ProdottoList.Add(prodotto4);
                ProdottoList.Add(prodotto5);

                OrdineList.Add(ordine1);
                OrdineList.Add(ordine2);
                OrdineList.Add(ordine3);

            }
        }

        public class Utente
        {
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public List<IndirizzoUtente> IndirizzoUtente { get; set; } = new List<IndirizzoUtente>();
            public List<MetodoPagamento> MetodoPagamento { get; set; } = new List<MetodoPagamento>();

        }

        public class MetodoPagamento
        {
            public string Pagamento { get; set; }
        }
        public class IndirizzoUtente
        {
            public string Indirizzo { get; set; }
        }

            public class Prodotto
            {
                public string NomeProdotto { get; set; }
                public double Prezzo { get; set; }
                public string Descrizione { get; set; }
                public string Brand { get; set; }
                public int Quantità { get; set; }
            }

            public class Ordine
            {
                public int ID { get; set; }
                public DateTime DataOrdine { get; set; }
                public double ImportoTotaleOrdine { get; set; }
                public List<Prodotto> Prodotti { get; set; } = new List<Prodotto>();
                public MetodoPagamento MetodoPagamento { get; set; }
                public DatiSpedizione DatiSpedizione { get; set; }
            }

            public class DatiSpedizione
            {
                public string NomeCorriere { get; set; }
                public string Destinazione { get; set; }
            }
    }
}

