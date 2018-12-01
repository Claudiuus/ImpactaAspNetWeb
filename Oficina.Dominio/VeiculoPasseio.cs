using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Dominio
{
    public class VeiculoPasseio:Veiculo
    {
        public Carroceria Carroceria { get; set; }

        public override List<string> Validar()
        {
            //chama direto sem precisar colococar Base.
            var erros = ValidarBase();
            //validando Tipo ENU<
            if (!Enum.IsDefined(typeof(Carroceria),Carroceria))
            {
                erros.Add($"a Correceria informada({Carroceria}) não é valida");
            }

            return erros;
        }
    }
}
