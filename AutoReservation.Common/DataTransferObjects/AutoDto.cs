using System.Runtime.Serialization;
using System.Text;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class AutoDto : DtoBase
    {
        private int id;
        private string marke;
        private int tagestarif;
        private int basistarif;
        private AutoKlasse autoKlasse;

        [DataMember]
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    SendPropertyChanging(() => id);
                    id = value;
                    SendPropertyChanged(() => id);
                }
            }
        }

        [DataMember]
        public string Marke
        {
            get { return marke; }
            set {
                if(marke != value)
                {
                    SendPropertyChanging(() => marke);
                    marke = value;
                    SendPropertyChanged(() => marke);
                }
            }
        }

        [DataMember]
        public int Tagestarif
        {
            get { return tagestarif; }
            set {
                if (tagestarif != value)
                {
                    SendPropertyChanging(() => tagestarif);
                    tagestarif = value;
                    SendPropertyChanged(() => tagestarif);
                }
            }
        }

        [DataMember]
        public int Basistarif
        {
            get { return basistarif; }
            set
            {
                if (basistarif != value)
                {
                    SendPropertyChanging(() => basistarif);
                    basistarif = value;
                    SendPropertyChanged(() => basistarif);
                }
            }
        }

        [DataMember]
        public AutoKlasse AutoKlasse
        {
            get { return autoKlasse; }
            set
            {
                if (autoKlasse != value)
                {
                    SendPropertyChanging(() => autoKlasse);
                    autoKlasse = value;
                    SendPropertyChanged(() => autoKlasse);
                }
            }
        }

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(marke))
            {
                error.AppendLine("- Marke ist nicht gesetzt.");
            }
            if (tagestarif <= 0)
            {
                error.AppendLine("- Tagestarif muss grösser als 0 sein.");
            }
            if (AutoKlasse == AutoKlasse.Luxusklasse && basistarif <= 0)
            {
                error.AppendLine("- Basistarif eines Luxusautos muss grösser als 0 sein.");
            }

            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override object Clone()
        {
            return new AutoDto
            {
                Id = Id,
                Marke = Marke,
                Tagestarif = Tagestarif,
                AutoKlasse = AutoKlasse,
                Basistarif = Basistarif
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}; {4}",
                Id,
                Marke,
                Tagestarif,
                Basistarif,
                AutoKlasse);
        }

	}

    [DataContract]
    public enum AutoKlasse
    {
        [EnumMember]
        Luxusklasse = 0,
        [EnumMember]
        Mittelklasse = 1,
        [EnumMember]
        Standard = 2
    }
}
