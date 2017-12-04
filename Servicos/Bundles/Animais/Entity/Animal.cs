using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Servicos.Bundles.Core.Entity;
using Servicos.Bundles.Pessoas.Entity;
using System.ComponentModel;

namespace Servicos.Bundles.Animais.Entity
{
    public enum Filo
    {
        [Description("MAMIFERO")]
        MAMIFERO,
        [Description("AVE")]
        AVE,
        [Description("REPTIL")]
        REPTIL,
        [Description("ANFIBIO")]
        ANFIBIO,
        [Description("PEIXE")]
        PEIXE
    }
    public class Animal : AbstractEditableEntity
    {
        public String Nome { get; set; }
        public Filo Filo { get; set; }
        public String Especie { get; set; }
        public float Peso { get; set; }
        public String Descricao { get; set; }
        public DateTime DataNascimento { get; set; }        
        public virtual List<int> Fotos { get; set; }
    }
}