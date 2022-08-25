using Newtonsoft.Json;

namespace sistemaAcad.Models
{
    public enum TipoMensagem{
        Informacao,
        Erro
    }
    public class MensagemModels
    {
        public TipoMensagem Tipo{get; set;}

        public string Texto{get; set;}

        public MensagemModels(string mensagem, TipoMensagem tipo = TipoMensagem.Informacao){

            this.Tipo = tipo;
            this.Texto = mensagem;
        }
        public static string Serializar(string mensagem, TipoMensagem tipo = TipoMensagem.Informacao){

            var mensagemModel = new MensagemModels(mensagem, tipo);
            return JsonConvert.SerializeObject(mensagemModel);
        }

        public static MensagemModels Desserializar(string mensagemString){
            return JsonConvert.DeserializeObject<MensagemModels>(mensagemString);
        }
    }
}