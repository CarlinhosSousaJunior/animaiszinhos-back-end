using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Servicos.Bundles.Core.Repository;
using Servicos.Bundles.Animais.Entity;
using Servicos.Bundles.Pessoas.Entity;
using System.Web;
using System.IO;

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
        public HttpResponseMessage Post(Animal animal)
        {
            _repository.Add<Animal>(animal);
            _repository.Commit();

            Doacao doacao = new Doacao(animal);
            _repository.Add<Doacao>(doacao);
            _repository.Commit();

            return Request.CreateResponse(HttpStatusCode.OK, doacao);
        }        

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            IEnumerable<Doacao> doacoes = _repository.GetAll<Doacao>();
            return Request.CreateResponse(HttpStatusCode.OK, doacoes);
        }
    }
}
