using Servicos.Bundles.Animais.Entity;
using Servicos.Bundles.Core.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Servicos.Bundles.Core.Repository;

namespace Servicos.Bundles.Animais.Resource
{
    public class DoacaoService : AbstractService<Doacao>
    {
        public DoacaoService(IRepository repository) : base(repository)
        {
        }

        public IEnumerable<Doacao> Get(string status)
        {
            if (!string.IsNullOrWhiteSpace(status))
                base._parameters.Add(d => d.Status.Equals(status));

            return base.GetAll();
        }

        public override void AfterUpdate(Doacao doacao)
        {
            base.AfterUpdate(doacao);
        }
    }
}