using System;
using System.Collections.Generic;

namespace Meetup.Odm.Infrastructure.Clients
{
    public class DecisionResultModel
    {
        //Falar sobre o case sensitive
        public bool sucesso { get; set; }   
        public List<string> mensagens { get; set; } = new List<string>();
    }

    public abstract class DecisionModel
    {
        public string __DecisionID__ { get; set; }
    }
}
