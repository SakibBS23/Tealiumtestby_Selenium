using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Tealium_test.Models;

namespace Tealium_test.Utility
{
    public static class JSONReader
    {
        public static T ReadJsonFile<T>(string jsonFilepath)
        {
            if (!File.Exists(jsonFilepath))
            {
                throw new FileNotFoundException($"The file at {jsonFilepath} was not found.");
            }

            try
            {
                string jsonString = File.ReadAllText(jsonFilepath);
                return JsonSerializer.Deserialize<T>(jsonString);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to read or deserialize JSON file.", ex);
            }
        }

    }
}
