using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bag
{
    public class PropertyTypeMap
    {
        public const string FilePath = "PropertyTypeMap.kvp";

        public static Dictionary<string, string> Load(string filePath = null)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                filePath = new FileInfo(Path.Combine(Environment.CurrentDirectory, PropertyTypeMap.FilePath)).FullName;
            }
            string[] lines = File.ReadAllLines(filePath);
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            foreach (string line in lines)
            {
                string[] keyValue = line.Split('=');
                keyValues.Add(keyValue[0].Trim(), keyValue[1].Trim());
            }

            return keyValues;
        }
    }
}
