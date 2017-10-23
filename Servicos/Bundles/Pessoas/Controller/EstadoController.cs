using Servicos.Bundles.Core.Repository;
using Servicos.Bundles.Pessoas.Entity;
using Servicos.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Servicos.Bundles.Pessoas.Controller
{
    [Route("api/estados")]
    public class EstadoController : ApiController
    {
        private readonly AbstractRepository _repository;
        public EstadoController(AbstractRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            IEnumerable<Estado> estados = _repository.GetAll<Estado>();
            return Request.CreateResponse(HttpStatusCode.OK, estados);
        }

        [HttpPost]
        public HttpResponseMessage Post(Estado estado)
        {
            _repository.Add<Estado>(estado);
            _repository.Commit();
            return Request.CreateResponse(HttpStatusCode.OK, estado);
        }

        [HttpPut]
        [Route("api/estados/{id}")]
        public HttpResponseMessage Put(int id, Estado estado)
        {
            _repository.Update<Estado>(estado);
            _repository.Commit();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
        [HttpDelete]
        [Route("api/estados/{id}")]
        public HttpResponseMessage Delete(int id, Estado estado)
        {
            _repository.Remove<Estado>(estado);
            _repository.Commit();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}