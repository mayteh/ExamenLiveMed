using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult GetUser()
        {
            ML.Usuario usuario= new ML.Usuario();
            ML.Result result = BL.Usuario.GetAll();

            if(result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = "Error al cargar la informacion";
            }


            return View(usuario);
        }

    }
}
