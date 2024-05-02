using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class Evento
    {
        //Titolo
        private string _Titolo = String.Empty;
        public string Titolo
        {
            get
            {
                return _Titolo;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Il Titolo non può essere vuoto");
                }

                this._Titolo = value;
            }
        }
        // Data
        private DateTime _Data;
        public DateTime Data
        {
            get
            {
                return _Data;
            }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new Exception("La Data non è valida, inserire una data valida");
                }
                this._Data = value;
            }
        }

        // CapienzaMax
        private int _CapienzaMax;
        public int CapienzaMax
        {
            get
            {
                return _CapienzaMax;
            }
            private set
            {
                if(value < 0)
                {
                    throw new Exception("Inserire Un numero Positivo");

                }
                this._CapienzaMax = value;
            }
        }
        
        // PostiPrenotati
        private int _PostiPrenotati;
        public int PostiPrenotati
        {
            get
            {
                return _PostiPrenotati;
            }
            private set
            {
                this._PostiPrenotati = value;
            }
        }
        
        // Costruttore

        public Evento(string titolo, DateTime data, int capienzaMax, int postiPrenotati = 0)
        {
            this.Titolo = titolo;
            this.Data = data;
            this.CapienzaMax = capienzaMax;
        }

        public int PrenotaPosti(int posto)
        {
            if(this.Data < DateTime.Now)
            {
                throw new Exception("Impossibile prenotare, Evento Passato");

            }
            if((this.PostiPrenotati + posto) >= this.CapienzaMax)
            {
                throw new Exception("Impossibile prenotare, SOLD OUT");
            }
           return this.PostiPrenotati += posto;
        }

        public int Disdiciposti(int posto)
        {
            if(this.Data < DateTime.Now)
            {
                throw new Exception("Impossibile disdire, Evento Passato");
            }
            if((this.PostiPrenotati - posto) < 0)
            {
                throw new Exception("Impossibile prenotare, Posti insufficenti da disdire");
            }
            return this.PostiPrenotati -= posto;
        }

        public override string ToString()
        {
            string DataFormattata = this.Data.ToString("dd/MM/yyyy");
            return $"{DataFormattata} - {this.Titolo}" ;
        }
    }
}
