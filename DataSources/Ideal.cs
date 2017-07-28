using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace Zulos.DataSources
{
    public class Ideal
    {

        public static List<Zulos.Model.Zulo> GetZulos()
        {

            using (HttpClient client = new HttpClient())
            {
                string page = "https://www.idealista.com/venta-viviendas/cerdanya-francesa/con-precio-hasta_180000,precio-desde_100000,metros-cuadrados-mas-de_40,de-dos-dormitorios,de-tres-dormitorios,de-cuatro-cinco-habitaciones-o-mas/";

                HttpResponseMessage response = client.GetAsync(page).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                response.Dispose();
               
                var allIndexOf = AllIndexOf(stringData, "<article>", StringComparison.OrdinalIgnoreCase);
                Console.WriteLine(string.Join(",", allIndexOf));  // 9,27

            }

            return null;

        }


        public static System.Collections.Generic.IList<int> AllIndexOf(string text, string str, StringComparison comparisonType)
        {
            List<int> allIndexOf = new List<int>();
            int index = text.IndexOf(str, comparisonType);
            while (index != -1)
            {
                allIndexOf.Add(index);
                index = text.IndexOf(str, index + str.Length, comparisonType);
            }
            return allIndexOf;
        }
    }
}
