using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Core.PolishHeaders
{
    public class PolishHeaders
    {
        public static List<string> GetPolishHeadersOfReports()
        {
            return new List<string>
            {
                "IMEI",
                "Nazwa użytkownika",
                "Nazwa projektu",
                "Numer zamówienia",
                "Model",
                "CCID",
                "Numer seryjny",
                "Wersja oprogramowania",
                "Objętość",
                "Próg ESI kanału 0",
                "Próg ESI kanału 1",
                "Podstawowy poziom ESI afe1 kanał 0",
                "Podstawowy poziom ESI afe1 kanał 1",
                "Podstawowy poziom ESI afe2 kanał 0",
                "Podstawowy poziom ESI afe2 kanał 1",
                "Stały przepływ licznika wody",
                "Średnica licznika wody",
                "Próg alarmu wycieku wody - licznik",
                "Dolny próg alarmu wycieku wody - licznik",
                "Interwał alarmu wycieku wody - licznik",
                "Próg alarmu nagłej utraty wody - licznik",
                "Dolny próg alarmu nagłej utraty wody - licznik",
                "Interwał alarmu nagłej utraty wody - licznik",
                "Rozpoczęty o",
                "Zakończony o",
                "Utworzony o",
                "Próg ESI kanału 2",
                "Podstawowy poziom ESI afe1 kanał 2",
                "Podstawowy poziom ESI afe2 kanał 2"
            };
        }
    }
}
