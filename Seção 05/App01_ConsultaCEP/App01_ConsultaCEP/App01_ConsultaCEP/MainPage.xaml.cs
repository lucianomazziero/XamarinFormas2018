using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultaCEP.Servico.Modelo;
using App01_ConsultaCEP.Servico;


namespace App01_ConsultaCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            //Logo.Opacity = 10;
            BOTAO.Clicked += BuscarCEP;
		}

        private void BuscarCEP(object sender, EventArgs args)
        {// TODO - Lógica do Programa

            
            // TODO - Validações
            string cep = CEP.Text.Trim();
            
            if ( isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep); // CEP vem lá da tela do x:Name="CEP"

                    if ( end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço:{2}, {3}, {0} - {1}", end.localidade, end.uf, end.logradouro, end.bairro);
                        RESULTADO.TextColor = Color.Black;
                    }
                    else
                    {
                        DisplayAlert("ERRO CRITICO", "O Endereço não coi encontrado para o CEP digitado: " + CEP.Text.Trim(), "OK");
                    }

                }
                catch(Exception e) { DisplayAlert("ERRO CRITICO", e.Message, "OK"); }

            }

        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;

            /// validando de tem 8 digitos
            if ( cep.Length != 8)
            {
                /// este mostra uma messagebox:  DisplayAlert("ERRO", "CEP Inválido! O CEP deve conter 8 caractéres.", "OK");
                RESULTADO.Text = "CEP Inválido! O CEP deve conter 8 caractéres.";
                RESULTADO.TextColor = Color.Red;
                valido = false;
            }
            else
            {
                //// validando se é numero inteiro
                int NovoCEP = 0;
                if (!int.TryParse(cep, out NovoCEP))
                {
                    /// este mostra uma messagebox:  DisplayAlert("ERRO", "CEP Inválido! O CEP é formado por apenas numeros.", "OK"); /// retorna mensagem de erro
                    RESULTADO.Text = "O CEP é formado por apenas numeros.";
                    RESULTADO.TextColor = Color.Red;
                    valido = false;
                }
            }



            return valido;
        }
	}
}
