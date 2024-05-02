using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class ProgrammaEventi
    {
        private string _TitoloProgramma = String.Empty;
        public string TitoloProgramma
        {
            get
            { return this._TitoloProgramma; }

            set
            { this._TitoloProgramma = value; }
        }
        List<Evento> NuovoEvento;

        public ProgrammaEventi(string titoloProgramma)

        {
            this.TitoloProgramma = titoloProgramma;
            this.NuovoEvento = new List<Evento>();
        }

        public void AggiungiEvento(Evento evento)
        {
            NuovoEvento.Add(evento);
        }
        public List<Evento> CercaPerData(DateTime dataInput)
        {
            List<Evento> Lista = new();
            foreach (Evento evento in NuovoEvento)
            {
                if (evento.Data.Date == dataInput.Date) Lista.Add(evento);
            }
            return Lista;
        }
        public static string StampaLista(List<Evento> Lista)
        {
            string result = "";
            foreach(Evento evento in Lista)
            {
                result += evento.ToString() + "\n";
            }
            return result;
        }
        public int EventiPresenti() {  return NuovoEvento.Count + 1; }

        public void SvuotaLista()
        {
            NuovoEvento.Clear();
        }
        public override string ToString()
        {
            string result = $"Nome programma evento: {TitoloProgramma}\n";
            result += StampaLista(NuovoEvento);
            return result;
        }
    }
}
