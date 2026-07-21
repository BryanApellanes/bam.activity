using Bam;
using Bam.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bag
{
    public class PromptInput : IInput
    {
        Dictionary<string, string> _prompts = new Dictionary<string, string>();
        Dictionary<string, string> _defaults = new Dictionary<string, string>();
        public PromptInput() { }
        public void SetPrompt(string name, string prompt, string defaultValue = "")
        {
            _prompts[name] = prompt;
            _defaults[name] = defaultValue;
        }

        public string Get(string name)
        {
            if(!_prompts.ContainsKey(name))
            {
                throw new ArgumentException($"No prompt configured for '{name}'");
            }
            return Prompt.Show(_prompts[name]).Or(_defaults[name]);
        }
    }
}
