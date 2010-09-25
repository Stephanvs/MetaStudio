using System;
using System.Diagnostics;

namespace Hayman.Client.DomainModelVisualizerModule.ViewModels
{
    [DebuggerDisplay("{Name}")]
    public class Vertex
    {
        public string Name { get; set; }

        public Vertex(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
