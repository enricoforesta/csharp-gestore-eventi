namespace GestoreEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("inserisci il nome dell'evento:");
                string titolo = Console.ReadLine();

                Console.WriteLine("inserisci la data dell'evento (gg/mm/yyyy):");
                DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                Console.WriteLine("inserisci il numero di posti totali:");
                int capienzaMax = Convert.ToInt32(Console.ReadLine());

                // Istanzio evento
                Evento eventoProva = new Evento(titolo,data,capienzaMax);

                Console.WriteLine();
                Console.WriteLine("Quanti posti desideri prenotare?");
                int posti = Convert.ToInt32(Console.ReadLine());
                eventoProva.PrenotaPosti(posti);
                int postiPrenotati = eventoProva.PostiPrenotati;
                int postiDisponibili = capienzaMax - postiPrenotati;
                Console.WriteLine();
                Console.WriteLine($"Numero di posti prenotati: {postiPrenotati}");
                Console.WriteLine($"Numero di posti disponibili:{postiDisponibili}");
                Console.WriteLine(); 

                bool loop = true;
                while (loop)
                {
                    Console.WriteLine("Vuoi disdire i posti? (si/no)");
                    string check = Console.ReadLine();
                    if (check == "si")
                    {
                        Console.WriteLine("indica il numero di posti da disdire:");
                        int posto = Convert.ToInt32(Console.ReadLine());
                        eventoProva.Disdiciposti(posto);
                        postiPrenotati = eventoProva.PostiPrenotati;
                        postiDisponibili = capienzaMax - postiPrenotati;
                        Console.WriteLine();
                        Console.WriteLine($"Numero di posti prenotati: {postiPrenotati}");
                        Console.WriteLine($"Numero di posti disponibili:{postiDisponibili}");
                        Console.WriteLine();

                    }
                    else if (check == "no")
                    {
                        loop = false;
                        Console.WriteLine();
                        Console.WriteLine("Ok; Va bene!"); 
                        Console.WriteLine($"Numero di posti prenotati: {postiPrenotati}");
                        Console.WriteLine($"Numero di posti disponibili:{postiDisponibili}");
                        Console.WriteLine();
                    }
                    else
                    {
                        throw new Exception("Inserisci una risposta valida");
                    }
                }
            }
            catch (Exception e)
            { 
               Console.WriteLine(e.Message);
            }
        }
    }
}
