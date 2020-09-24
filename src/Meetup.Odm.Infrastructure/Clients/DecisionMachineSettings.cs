using System.ComponentModel;
using System;

namespace Meetup.Odm.Infrastructure.Clients
{
    public class Rules 
    {
        public string Pode_Cadastrar_Url { get; set; }
    }

    public class DecisionMachineSettings
    {
        public string Url { get; set; }
        public string ApiKey { get; set; }

        public Rules Rules { get; set; }
    }
}
