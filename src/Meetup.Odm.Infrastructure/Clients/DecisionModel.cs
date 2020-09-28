using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Meetup.Odm.Infrastructure.Clients
{
    public class DecisionResultModel
    {
        [JsonProperty("sucesso")]
        public bool Sucesso { get; set; }   

        [JsonProperty("mensagens")]
        public List<string> Mensagens { get; set; } = new List<string>();
    }

    public abstract class DecisionModel
    {
        [JsonProperty("__DecisionID__")]
        public string DecisionId { get; set; }
    }
}
