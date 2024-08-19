using System.Globalization;

namespace ArquiVision.Data
{
    public class MetodosReutilzables
    {
        public DateTime obtenerFecha()
        {
            DateTime now = DateTime.Now;

            // Separar los componentes del DateTime
            //  int day = now.Day;
            int hour = now.Hour;
            int minute = now.Minute;
            int second = now.Second;
            int millisecond = now.Millisecond;

            DateTime nowUtc = DateTime.UtcNow.Date;
            // DateTime nowUtc = DateTime.UtcNow;
            nowUtc = nowUtc.AddHours(hour).AddMinutes(minute).AddSeconds(second).AddMilliseconds(millisecond);
            // Convertir DateTime a una cadena en formato ISO 8601
            string fecha = nowUtc.ToString("o");
            DateTime dateTime = DateTime.Parse(fecha, null, DateTimeStyles.RoundtripKind);
            return dateTime;
        }
    }
}
