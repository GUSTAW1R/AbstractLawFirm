using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AbstractLawFirm___ServiceDAL.BindingModel;
using AbstractLawFirm___ServiceDAL.Interfaces;

namespace AbstractLawFirm___RestApi.Controllers
{
    public class ReportController : ApiController
    {
        private readonly IReportService _service;
        public ReportController(IReportService service)
        {
            _service = service;
        }
        [HttpGet]
        public IHttpActionResult GetArchivesLoad()
        {
            var list = _service.GetArchivesLoad();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public IHttpActionResult GetCustomerOrders(ReportBindingModel model)
        {
            var list = _service.GetCustomerOrders(model);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public void SaveDocumentsPrice(ReportBindingModel model)
        {
            _service.SaveDocumentPrice(model);
        }
        [HttpPost]
        public void SaveArchivesLoad(ReportBindingModel model)
        {
            _service.SaveArchivesLoad(model);
        }
        [HttpPost]
        public void SaveCustomerOrders(ReportBindingModel model)
        {
            _service.SaveCustomerOrders(model);
        }
    }
}
