using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AbstractLawFirm___ServiceDAL.BindingModel;
using AbstractLawFirm___ServiceDAL.Interfaces;

namespace AbstractLawFirm___RestApiWPF.Controllers
{
    public class DocumentsController : ApiController
    {
        private readonly IDocumentsService _service;

        public DocumentsController(IDocumentsService service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }


        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = _service.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }

        [HttpPost]
        public void AddElement(DocumentsBindingModel model)
        {
            _service.AddElement(model);
        }

        [HttpPost]
        public void UpdElement(DocumentsBindingModel model)
        {
            _service.UpdElement(model);
        }

        [HttpPost]
        public void DelElement(DocumentsBindingModel model)
        {
            _service.DelElement(model.Id);
        }
    }
}
