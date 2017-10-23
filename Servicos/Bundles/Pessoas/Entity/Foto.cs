using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Servicos.Bundles.Pessoas.Entity
{
    public class Foto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Bytes { get; set; }
    }
}