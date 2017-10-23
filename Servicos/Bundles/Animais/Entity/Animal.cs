using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Servicos.Bundles.Core.Entity;
using Servicos.Bundles.Pessoas.Entity;

namespace Servicos.Bundles.Animais.Entity
{
    public class Animal : AbstractEditableEntity
    {
        public string Nome { get; set; }
        public string Filo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual List<Foto> Fotos { get; set; }
    }
}