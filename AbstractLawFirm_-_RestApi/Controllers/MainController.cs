using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AbstractLawFirm___RestApi.Service;
using AbstractLawFirm___ServiceDAL.BindingModel;
using AbstractLawFirm___ServiceDAL.Interfaces;
using AbstractLawFirm___ServiceDAL.ViewModel;

namespace AbstractLawFirm___RestApi.Controllers
{
    public class MainController : ApiController
    {
        private readonly IMainService _service;
        private readonly IImplementerService _serviceImplementer;
        public MainController(IMainService service, IImplementerService serviceImplementer)
        {
            _service = service;
            _serviceImplementer = serviceImplementer;
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
        [HttpPost]
        public void CreateOrder(OrderBindingModel model)
        {
            _service.CreateOrder(model);
        }
        [HttpPost]
        public void TakeOrderInWork(OrderBindingModel model)
        {
            _service.TakeOrderInWork(model);
        }
        [HttpPost]
        public void FinishOrder(OrderBindingModel model)
        {
            _service.FinishOrder(model);
        }
        [HttpPost]
        public void PayOrder(OrderBindingModel model)
        {
            _service.PayOrder(model);
        }
        [HttpPost]
        public void PutComponentOnStock(ArchiveComponentBindingModel model)
        {
            _service.PutComponentsOnArchive(model);
        }
        [HttpPost]
        public void StartWork()
        {
            List<OrderViewModel> orders = _service.GetFreeOrders();
            foreach (var order in orders)
            {
                ImplementerViewModel impl = _serviceImplementer.GetFreeWorker();
                if (impl == null)
                {
                    throw new Exception("Нет сотрудников");
                }
                new WorkImplementer(_service, _serviceImplementer, impl.Id, order.Id);
            }
        }
        [HttpGet]
        public IHttpActionResult GetInfo()
        {
            ReflectionService service = new ReflectionService();
            var list = service.GetInfoByAssembly();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
    }
}
