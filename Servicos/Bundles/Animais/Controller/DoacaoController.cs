using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Servicos.Bundles.Core.Repository;
using Servicos.Bundles.Animais.Entity;

namespace Servicos.Bundles.Animais.Controller
{
    [Route("api/doacoes")]
    public class DoacaoController : ApiController
    {
        private readonly IRepository _repository;

        public DoacaoController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public HttpResponseMessage Post(Doacao doacao)
        {
            Animal animal = doacao.Animal;
            _repository.Add<Animal>(animal);
            _repository.Commit();

            Doacao novaDoacao = new Doacao(animal, doacao.Usuario);
            _repository.Add<Doacao>(doacao);
            _repository.Commit();

            return Request.CreateResponse(HttpStatusCode.OK, novaDoacao);
        }        

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            IEnumerable<Doacao> doacoes = _repository.GetAll<Doacao>();
            return Request.CreateResponse(HttpStatusCode.OK, doacoes);
        }
        
        [HttpGet]
        [Route("api/doacoes/{id}")]
        public HttpResponseMessage GetOne(int id)
        {
            Doacao doacao = _repository.GetOne<Doacao>(id);
            if (doacao == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Nenhum usuário encontrado");
            else
                return Request.CreateResponse(HttpStatusCode.OK, doacao);
        }        
    }
}
