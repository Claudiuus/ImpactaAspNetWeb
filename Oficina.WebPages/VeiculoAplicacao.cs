using Oficina.Dominio;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Oficina.WebPages
{
    public class VeiculoAplicacao
    {
        private readonly MarcaRepositorio marcaRepositorio = new MarcaRepositorio();
        private readonly CorRepositorio corRepositorio = new CorRepositorio();
        private readonly ModeloRepositorio modeloRepositorio = new ModeloRepositorio();
        private readonly VeiculoRepositorio veiculoRepositorio = new VeiculoRepositorio();

        //ctor
        public VeiculoAplicacao()
        {
            PopularControles();
        }

        public List<Marca> Marcas { get; private set; }
        public string MarcaSelecionada { get; set; }
        public List<Cor> Cores { get; private set; }
        public List<Combustivel> Combustiveis { get; private set; }
        public List<Cambio> Cambios { get; private set; }
        public List<Modelo> Modelos { get; private set; } = new List<Modelo>();

        private void PopularControles()
        {
            Marcas = marcaRepositorio.Selecionar();
            MarcaSelecionada = HttpContext.Current.Request.QueryString["MarcaId"];

            if (!string.IsNullOrEmpty(MarcaSelecionada))
            {
                Modelos = modeloRepositorio.SelecionarPorMarca(Convert.ToInt32(MarcaSelecionada));
            }

            Cores = corRepositorio.Selecionar();
            Combustiveis = Enum.GetValues(typeof(Combustivel)).Cast<Combustivel>().ToList(); //enumeradores
            Cambios = Enum.GetValues(typeof(Cambio)).Cast<Cambio>().ToList(); //enumeradores
        }
        
        public void Inserir()
        {
            try
            {
                var veiculo = new VeiculoPasseio();
                var formulario = HttpContext.Current.Request.Form;

                veiculo.Ano = Convert.ToInt32(formulario["ano"]);
                veiculo.Cambio = (Cambio)Convert.ToInt32(formulario["cambios"]);
                veiculo.Carroceria = Carroceria.Heatch;// Criar combo 
                veiculo.Combustivel = (Combustivel)Convert.ToInt32(formulario["combustivel"]);
                veiculo.Cor = corRepositorio.Selecionar(Convert.ToInt32(formulario["cor"]));
                veiculo.Modelo = modeloRepositorio.Selecionar(Convert.ToInt32(formulario["modelo"]));
                veiculo.Observacao = formulario["observacao"];
                veiculo.Placa = formulario["placa"]/*.ToUpper()*/;


                veiculoRepositorio.Inserir(veiculo);
            }
            catch (FileNotFoundException ex)
            {

                HttpContext.Current.Items.Add("MensagemErro",$"Arquivo {ex.FileName}não encontrado");

                throw;
            }

            catch (DirectoryNotFoundException)
            {

                HttpContext.Current.Items.Add("MensagemErro", $"Diretorio não encontrado");

                throw;
            }
            catch (UnauthorizedAccessException)
            {

                HttpContext.Current.Items.Add("MensagemErro", $"Acesso negado ! ");

                throw;
            }

            catch (Exception)
            {
                HttpContext.Current.Items.Add("MensagemErro", $"Oppppsss Ocorreu um erro ! ");

                //logar de erro 

                throw;


            }

            finally
            {
                //é sempre executado sempre em sucesso ou erro
            }
        }
    }

    
}