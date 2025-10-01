using Bag;
using Bam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bag
{
    public class FileInput : IInput
    {
        Dictionary<string, string> inputs = new Dictionary<string, string>();
        public FileInput(string path)
        {
            Path = path;
            if(File.Exists(path))
            {
                inputs = path.FromYamlFile<Dictionary<string, string>>();
            }
        }

        public string Path { get; set; }

        public string Get(string name)
        {
            if(inputs.ContainsKey(name))
            {
                return inputs[name];
            }
            else
            {
                return string.Empty;
            }
        }

        public void Add(string name, string value)
        {
            if(inputs.ContainsKey(name))
            {
                inputs[name] = value;
            }
            else
            {
                inputs.Add(name, value);
            }
        }

        public void Save()
        {
            inputs.ToYamlFile(Path);
        }
    }
}
