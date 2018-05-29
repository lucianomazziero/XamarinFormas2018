using System;
using System.Collections.Generic;
using System.Text;
using System.Net;   /// incluida para pegar o Webclient
using App01_ConsultaCEP.Servico.Modelo;
using Newtonsoft.Json;



namespace App01_ConsultaCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public object end2;

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEndereoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NovoEndereoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);
            
            if (end.cep == null) { return null; }

            return end;
        }




    }
}
