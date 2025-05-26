using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebInventario.DAL;
using WebInventario.Models;

namespace WebInventario.Controllers
{
    public class InventarioController1 : Controller
    {
        private readonly Inventario_DAL _dal;

        public InventarioController1(Inventario_DAL dal)
        {
            _dal = dal;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Mov_Inventario> inventarios = new List<Mov_Inventario>();

            try
            {
                inventarios = _dal.GetAll();
            }
            catch (System.Exception ex)
            {

                TempData["MensajeError"] = ex.Message;
            }

            return View(inventarios);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Mov_Inventario model)
        {
            if (!ModelState.IsValid)
            {
                TempData["errorMessage"] = "La data es inválida";
            }

            bool result = _dal.Insert(model);

            if (!result)
            {
                TempData["errorMessage"] = "No se puede grabar la información";
                return View();
            }

            TempData["successMessage"] = "Datos de inventario fue Grabado";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(Mov_Inventario model)
        {
            Mov_Inventario inventario = _dal.GetById(model);

            if (inventario.COD_CIA is null )
            {
                TempData["errorMessage"] = "Inventario no ubicado";
                return RedirectToAction("Index");

            }

            return View(inventario);
        }

        [HttpPost]
        public IActionResult Update(Mov_Inventario model)
        {
            Mov_Inventario inventario = _dal.GetById(model);

            if (!ModelState.IsValid)
            {
                TempData["errorMessage"] = "El modelo es inválido";
                return View();

            }

            bool result = _dal.Update(model);

            if (!result)
            {
                TempData["errorMessage"] = "No se pudo actualizar la información";
                return View();
            }

            TempData["successMessage"] = "El inventario se actualizó";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Mov_Inventario model)
        {
            bool result = _dal.Delete(model);

            if (!ModelState.IsValid)
            {
                TempData["errorMessage"] = "El modelo es inválido";
                return View();

            }            

            if (!result)
            {
                TempData["errorMessage"] = "No se pudo eliminar la información";
                return View();
            }

            TempData["successMessage"] = "El inventario se eliminó";

            return RedirectToAction("Index");
        }
    }
}
