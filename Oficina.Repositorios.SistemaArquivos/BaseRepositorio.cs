using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using static System.Configuration.ConfigurationManager;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class BaseRepositorio
    {
        protected string ObterCaminhoCompleto(string caminho)
        {
            
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                AppSettings[caminho]);
        }


    }
}