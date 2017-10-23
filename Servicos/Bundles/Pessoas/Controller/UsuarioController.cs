using Servicos.Bundles.Core;
using Servicos.Bundles.Pessoas.Entity;
using Servicos.Bundles.Pessoas.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Servicos.Bundles.Pessoas.Controller
{
    [Authorize]
    [Route("api/usuarios")]
    public class UsuarioController : ApiController
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public HttpResponseMessage GetAll(string username = "", string password = "", string cpf = "")
        {
            IEnumerable<Usuario> usuarios = _service.GetAll(username, password, cpf);
            return Request.CreateResponse(HttpStatusCode.OK, usuarios);
        }

        [HttpGet]
        [Route("api/usuarios/{id}")]
        public HttpResponseMessage GetOne(int id)
        {
            Usuario usuario = _service.GetOne(id);
            return Request.CreateResponse(HttpStatusCode.OK, usuario);
        }

        [AllowAnonymous]
        [HttpPost]
        public HttpResponseMessage Post(Usuario usuario)
        {
            _service.Add(usuario);
            return Request.CreateResponse(HttpStatusCode.OK, usuario);
        }
    }
}
