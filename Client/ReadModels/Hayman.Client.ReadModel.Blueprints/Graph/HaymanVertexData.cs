using System;
using System.Runtime.Serialization;

namespace Hayman.Client.ReadModel.Blueprints.Graph
{
    [DataContract]
    public class HaymanVertexData
    {
        public string Value { get; set; }

        public VertexType Type { get; set; }

        public string CultureName { get; set; }
    }
}
