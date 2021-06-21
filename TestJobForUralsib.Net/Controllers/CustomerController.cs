using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TestJobForUralsib.Domain.Models.ViewModels;
using TestJobForUralsib.Domain.Services.Interfaces;

namespace TestJobForUralsib.Net.Controllers
{
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService service;
        private readonly IMapper mapper;

        public CustomerController(ICustomerService service, IMapper mapper)
        {
            this.service = service;
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
                        //TO DO: edit
                    }

                    return RedirectToAction(nameof(Get));
                }

                throw new Exception();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        //// GET: CustomerController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: CustomerController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: CustomerController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: CustomerController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
