using Servicos.Bundles.Core.Repository;
using Servicos.Bundles.Pessoas.Entity;
using Servicos.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Servicos.Bundles.Pessoas.Controller
{
    [Route("api/fotos")]
    public class FotoController : ApiController
    {
        private readonly AbstractEntityRepository _repository;

        public FotoController()
        {            
            _repository = new AbstractEntityRepository(new ServicosContext());
        }
        
        [HttpGet]
        [Route("api/fotos/{id}")]
        public HttpResponseMessage GetOne(int id)
        {
            Foto foto = _repository.GetOne<Foto>(id);
            if (!foto.Ativo || foto == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new ByteArrayContent(foto.Bytes);
            response.Content.LoadIntoBufferAsync(foto.Bytes.Length).Wait();
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(foto.Tipo);
            return response;
        }

        [HttpPost]
        public HttpResponseMessage UploadImage()
        {
            List<int> ids = new List<int>();
            var files = HttpContext.Current.Request.Files;
            if (files.Count == 0)
                return Request.CreateResponse(HttpStatusCode.NoContent, "Nenhum arquivo foi enviado");
            for (int i = 0; i < files.Count; i++)
            {                
                MemoryStream ms = new MemoryStream();
                files[i].InputStream.CopyTo(ms);
                Foto foto = new Foto(ms.ToArray(), files[i].ContentType);
                _repository.Add<Foto>(foto);
                _repository.Commit();
                ids.Add(foto.Id);
            }
            return Request.CreateResponse(HttpStatusCode.OK, ids);
        }

        [HttpDelete]
        [Route("api/fotos/{id}")]
        public void Delete(int id)
        {
            _repository.Remove<Foto>(id);
            _repository.Commit();
        }
    }
}
