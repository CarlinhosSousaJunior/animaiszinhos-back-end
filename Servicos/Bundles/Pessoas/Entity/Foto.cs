using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Servicos.Bundles.Core.Entity;
using System.Linq;
using System.Web;

namespace Servicos.Bundles.Pessoas.Entity
{
    public class Foto : AbstractEntity
    {
        public Foto() { }
        public Foto(byte[] bytes, string tipo)
        {
            this.Bytes = bytes;
            this.Tipo = tipo;
        }
        public string Tipo { get; set; }
        public byte[] Bytes { get; set; }
    }
}