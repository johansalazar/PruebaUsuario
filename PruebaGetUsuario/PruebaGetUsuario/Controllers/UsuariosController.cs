using ProxyServices.Dto;
using PruebaGetUsuario.BussinesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaGetUsuario.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            List<Usuarios> listUsuarios = new List<Usuarios>();
            try
            {
                BussinesLogic bussinesLogic = new BussinesLogic();
                listUsuarios = bussinesLogic.GetUsuarios();
            }
            catch (Exception ex)
            {
                ViewBag.codeError = "99";
                ViewBag.Message = "Error Listando: " + ex.Message;
                return View(listUsuarios);
            }
            return View(listUsuarios);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            Usuarios Usuario = new Usuarios();
            try
            {
                List<Usuarios> listUsuarios = new List<Usuarios>();
                BussinesLogic bussinesLogic = new BussinesLogic();
                listUsuarios = bussinesLogic.GetUsuarios();
                Usuario = listUsuarios.First(x => x.Id_Usuario == id);

            }
            catch (Exception ex)
            {
                ViewBag.codeError = "99";
                ViewBag.Message = "Error Detalles: " + ex.Message;
                return View(Usuario);
            }
            return View(Usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(FormCollection values)
        {

            Usuarios Result = new Usuarios();
            try
            {
                Usuarios UsuarioNuevo = new Usuarios();
                UsuarioNuevo.Nombre = values["Nombre"];
                UsuarioNuevo.FechaNacimiento = Convert.ToDateTime(values["FechaNacimiento"]);
                UsuarioNuevo.Sexo = values["Sexo"];

                BussinesLogic bussinesLogic = new BussinesLogic();
                Result = bussinesLogic.CreateUsuario(UsuarioNuevo);

            }
            catch (Exception ex)
            {
                ViewBag.codeError = "99";
                ViewBag.Message = "Error Creando: "+ ex.Message;
                return View();
            }

            if (Result.Cod_error == "0")
            {
                ViewBag.codeError = Result.Cod_error;
                ViewBag.Message = Result.Mensaje;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.codeError = Result.Cod_error;
                ViewBag.Message = Result.Mensaje;
                return View();
            }

        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            Usuarios Usuario = new Usuarios();
            try
            {
                List<Usuarios> listUsuarios = new List<Usuarios>();
                BussinesLogic bussinesLogic = new BussinesLogic();
                listUsuarios = bussinesLogic.GetUsuarios();
                Usuario = listUsuarios.First(x => x.Id_Usuario == id);
            }
            catch (Exception ex)
            {
                ViewBag.codeError = "99";
                ViewBag.Message = "Error Editando: " + ex.Message;
            }
            return View(Usuario);

        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection values)
        {
            Usuarios Result = new Usuarios();
            try
            {
                Usuarios UsuarioEditado = new Usuarios();
                UsuarioEditado.Id_Usuario =Convert.ToInt32(values["Id_Usuario"]);
                UsuarioEditado.Nombre = values["Nombre"];
                UsuarioEditado.FechaNacimiento = Convert.ToDateTime(values["FechaNacimiento"]);
                UsuarioEditado.Sexo = values["Sexo"];

                BussinesLogic bussinesLogic = new BussinesLogic();
                Result = bussinesLogic.EditarUsuarios(UsuarioEditado);               
            }
            catch(Exception ex)
            {
                ViewBag.codeError = "99";
                ViewBag.Message = "Error Editando: " + ex.Message;
                return View();
            }

            if (Result.Cod_error == "0")
            {
                ViewBag.codeError = Result.Cod_error;
                ViewBag.Message = Result.Mensaje;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.codeError = Result.Cod_error;
                ViewBag.Message = Result.Mensaje;
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            Usuarios Usuario = new Usuarios();
            try
            {
                List<Usuarios> listUsuarios = new List<Usuarios>();
                BussinesLogic bussinesLogic = new BussinesLogic();
                listUsuarios = bussinesLogic.GetUsuarios();
                Usuario = listUsuarios.First(x => x.Id_Usuario == id);
            }
            catch (Exception ex)
            {
                ViewBag.codeError = "99";
                ViewBag.Message = "Error Eliminando: " + ex.Message;
            }
            return View(Usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(FormCollection values)
        {
            Usuarios Result = new Usuarios();
            try
            {
                Usuarios UsuarioEliminado = new Usuarios();
                UsuarioEliminado.Id_Usuario = Convert.ToInt32(values["Id_Usuario"]);

                BussinesLogic bussinesLogic = new BussinesLogic();
                Result = bussinesLogic.EliminarUsuarios(UsuarioEliminado.Id_Usuario);
               
            }
            catch (Exception ex)
            {
                ViewBag.codeError = "99";
                ViewBag.Message = "Error Eliminando: " + ex.Message;
                return View();
            }

            if (Result.Cod_error == "0")
            {
                ViewBag.codeError = Result.Cod_error;
                ViewBag.Message = Result.Mensaje;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.codeError = Result.Cod_error;
                ViewBag.Message = Result.Mensaje;
                return View();
            }

        }
    }
}
