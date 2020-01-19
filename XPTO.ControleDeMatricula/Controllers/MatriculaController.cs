using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace XPTO.ControleDeMatricula.Controllers
{
    public class MatriculaController : Controller
    {
        public IActionResult GeracaoDigito()
        {
            return View();
        }
    }
}