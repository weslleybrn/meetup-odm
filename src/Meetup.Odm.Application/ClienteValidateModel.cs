using System;
using System.Collections.Generic;

namespace Meetup.Odm.Application
{
    public class ClienteValidateModelList
    {
        //Falar sobre case sensitive
        public string nome { get; set; }
        public string documento { get; set; }
        public int idade { get; set; }
    }

    public class ClienteValidateModel
    {
        public string Documento { get; set; }
        public int Idade { get; set; }
        public List<ClienteValidateModelList> Clientes { get; set; } = new List<ClienteValidateModelList>();
    }
}
