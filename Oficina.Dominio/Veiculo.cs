using System;
using System.Collections.Generic;

namespace Oficina.Dominio
{
    //ToDo: OO- Classe(entidade) ou abstração 

    public abstract class Veiculo //: Object
    {
        //public Veiculo()
        //{
        //    Id = Guid.NewGuid();
        //}
        
        public Guid Id { get; set; } = Guid.NewGuid();

        //private string placa;
        //public string Placa
        //{
        //    get
        //    {
        //        return placa.ToUpper();
        //    }   

        //    set
        //    {
        //        placa = value.ToUpper();
        //    }
        //}

        private string placa;
        public string Placa
        {          
            //encapsulamento 
            get { return placa?.ToUpper(); }
            set { placa = value?.ToUpper(); }
         }

        public int Ano { get; set; }
        public string Observacao { get; set; }
        public Modelo Modelo { get; set; }
        public Cor Cor { get; set; }
        public Combustivel Combustivel { get; set; }
        public Cambio Cambio { get; set; }

        public abstract List<string> Validar();//obrigatorio para todos filhos! para Herança.

        protected List<string> ValidarBase()
        {
            var erros = new List<string>();

            if (Ano <= 1980 || Ano> DateTime.Now.Year)//+1
            {

                erros.Add($" O ano informado ({Ano}) não é valido ");
            }
            
            return erros;
        }

        public override string ToString()
        {
          
            return string.Format("{0}{1}{2}", Modelo.Marca.Nome, Modelo.Marca,Placa);
         
        }

        public DateTime agora {
            //ToDo: tempo de execução
            //encapsulamento 
            // inseri sempre o tempo atual.
            get { return DateTime.Now; }
            
        }
    }
}