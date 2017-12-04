using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Servicos.Bundles.Core.Entity;
using Servicos.Bundles.Pessoas.Entity;
using System.ComponentModel;

namespace Servicos.Bundles.Animais.Entity
{
    public enum DoacaoStatus
    {
        [Description("EM_ANDAMENTO")]
        EM_ANDAMENTO,
        [Description("FINALIZADO")]
        FINALIZADO,
        [Description("CANCELADO")]
        CANCELADO
    }
    public class Doacao : AbstractEditableEntity
    {
        public Doacao()
        {
            this.Status = DoacaoStatus.EM_ANDAMENTO;
            this.DataExpiracao = DateTime.Now.AddDays(30);
        }

        public Doacao(Animal animal, Usuario usuario)
        {
            this.Usuario = usuario;
            this.Animal = animal;
            this.Status = DoacaoStatus.EM_ANDAMENTO;
            this.DataExpiracao = DateTime.Now.AddDays(30);
        }

        public DoacaoStatus Status { get; set; }
        public DateTime DataExpiracao { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual Usuario Usuario { get; set; }

        public override string[] GetIncludeProperties()
        {
            return new string[] { "Animal", "Usuario" };
        }
    }
}