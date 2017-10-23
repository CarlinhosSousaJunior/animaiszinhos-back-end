using Servicos.Bundles.Core.Repository;
using Servicos.Bundles.Core.Resource;
using Servicos.Bundles.Pessoas.Entity;
using System.Collections.Generic;

namespace Servicos.Bundles.Pessoas.Resource
{
    public class UsuarioService : AbstractService<Usuario>
    {
        public UsuarioService(IRepository repository)
            : base(repository)
        {

        }

        public IEnumerable<Usuario> GetAll(string login, string senha, string cpf = "") {
            if (!string.IsNullOrWhiteSpace(login))
                _parameters.Add(u => u.CpfCnpj.Equals(login));
            if (!string.IsNullOrWhiteSpace(senha))
                _parameters.Add(u => u.Senha.Equals(senha));
            if (!string.IsNullOrWhiteSpace(cpf))
                _parameters.Add(u => u.CpfCnpj.Equals(cpf));

            IEnumerable<Usuario> usuarios = base.GetAll();            

            return usuarios;
        }
    }
}