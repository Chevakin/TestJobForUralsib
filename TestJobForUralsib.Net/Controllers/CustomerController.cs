using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.IO;
using TestJobForUralsib.Domain.DTOs;
using TestJobForUralsib.Domain.Models.ViewModels;
using TestJobForUralsib.Domain.Services.Interfaces;

namespace TestJobForUralsib.Net.Controllers
{
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService service;
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public CustomerController(ICustomerService service, IOrderService orderService, IMapper mapper)
        {
            this.service = service;
            this.orderService = orderService;
            this.mapper = mapper;
        }

        [Route("")]
        public ActionResult Get()
        {
            return View(service.Get());
        }

        [Route("{id}")]
        public ActionResult Details(int id)
        {
            var dto = service.Get(id);

            return View(mapper.Map<CustomerViewModel>(dto));
        }

        [Route("create")]
        [Route("{id}/edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new CustomerViewModel());
            }

            return View(mapper.Map<CustomerViewModel>(service.Get(id.Value)));
        }

        [Route("create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Не получилось привязать модель
                    var id = int.Parse(collection["ID"]);
                    var name = collection["Name"][0];
                    var surname = collection["Surname"][0];
                    var patronymic = collection["Patronymic"][0];
                    var email = collection["Email"][0];
                    var phone = collection["Phone"][0];
                    var birthdate = DateTime.Parse(collection["Birthdate"][0]);

                    if (id == 0)
                    {
                        service.Create(name, surname, patronymic, email, phone, birthdate);
                    }
                    else
                    {
                        service.Edit(id, name, surname, patronymic, email, phone, birthdate);
                    }

                    return RedirectToAction(nameof(Get));
                }

                throw new Exception();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [Route("{id}/delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            service.Delete(id);

            return RedirectToAction(nameof(Get));
        }

        [Route("{id}/orders")]
        public ActionResult GetOrders(int id)
        {
            return View(orderService.Get(id));
        }

        [Route("{id}/orders/create")]
        public ActionResult AddOrder(int id)
        {
            var dto = new OrderDto
            {
                Customer = new SimpleCustomerDto
                {
                    ID = id
                }
                
            };

            return View(dto);
        }

        [Route("{id}/orders/create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrder(int id, IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
               var amountMoney = decimal.Parse(collection["AmountMoney"][0], NumberStyles.Any, CultureInfo.CurrentCulture);
                var date = DateTime.Parse(collection["Date"][0]);
                var photoFile = collection.Files.GetFile("Photo");
                byte[] photo = null;

                if (photoFile != null)
                {
                    using var memoryStream = new MemoryStream();
                    using var stream = photoFile.OpenReadStream();

                    stream.CopyTo(memoryStream);
                    photo = memoryStream.ToArray();
                }

                orderService.Create(date, amountMoney, photo, id);

                return Redirect($"/api/customers/{id}/orders");
            }

            return View();
        }
    }
}
