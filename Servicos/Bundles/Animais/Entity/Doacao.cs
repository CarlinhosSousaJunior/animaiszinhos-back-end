using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Servicos.Bundles.Core.Entity;
using Servicos.Bundles.Pessoas.Entity;

namespace Servicos.Bundles.Animais.Entity
{
    public class Doacao : AbstractEditableEntity
    {
        public Doacao()
        {

        }

        public Doacao(Animal animal)
        {
            this.Animal = animal;
            this.Status = "EM_ANDAMENTO";
            this.DataExpiracao = DateTime.Now.AddDays(30);
        }

        public string Status { get; set; }
        public DateTime DataExpiracao { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual Usuario Usuario { get; set; }

        public override string[] GetIncludeProperties()
        {
            return new string[] { "Animal", "Usuario" };
        }
    }
}