using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Library.Data;

namespace Library.Services
{

    public class InputOutputServices
    {
        public static bool Save(Reader reader, string jsonFileName)
        {
            bool result = true;
            try
            {
                var jsonSettings = new JsonSerializerSettings();
                string jsonContent = JsonConvert.SerializeObject(reader);
                string jsonContentFormatted = jsonContent.FormatJson();
                File.WriteAllText(jsonFileName, jsonContentFormatted);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                result = false;
            }
            return result;
        }
    }
}
