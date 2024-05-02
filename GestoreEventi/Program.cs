namespace GestoreEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
      

            try
            {

                Console.WriteLine("inserisci il nome del tuo programma Eventi:");
                string titoloProgramma = Console.ReadLine();

                ProgrammaEventi programmaEventi = new ProgrammaEventi(titoloProgramma);

                Console.WriteLine("");
                Console.WriteLine("Quanti eventi vuoi aggiungere?");
                int numEventi = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");

                for (int i = 0; i < numEventi; i++)
                {
                    try 
                    {
                        Console.WriteLine($"Inserisci il nome dell'evento {i + 1}:");
                        string titoloEvento = Console.ReadLine();

                        Console.WriteLine("Inserisci la data dell'evento (gg/mm/yyyy):");
                        DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                        Console.WriteLine("Inserisci il numero di posti totali:");
                        int capienzaMax = Convert.ToInt32(Console.ReadLine());

                        Evento evento = new Evento(titoloEvento, data, capienzaMax);

                        programmaEventi.AggiungiEvento(evento);

                        Console.WriteLine("");
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        i--;
                    }
                }

                Console.WriteLine($"Numero di eventi nel programma è: {programmaEventi.EventiPresenti()}");

                Console.WriteLine("Lista di eventi nel programma:");
                Console.WriteLine(programmaEventi.ToString());

                Console.WriteLine("Inserisci una data per vedere che eventi ci saranno (gg/mm/yyyy):");
                DateTime dataInput = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                List<Evento> eventiInData = programmaEventi.CercaPerData(dataInput);
                Console.WriteLine($"Eventi in data {dataInput.Date}:");
                Console.WriteLine(ProgrammaEventi.StampaLista(eventiInData));

                programmaEventi.SvuotaLista();
                Console.WriteLine("Lista di eventi nel programma svuotata");
            }
            catch (Exception e)
            { 
                Console.WriteLine(e.Message);
            }
        }
    }
}
