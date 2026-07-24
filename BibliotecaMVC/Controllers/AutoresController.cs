using Microsoft.AspNetCore.Mvc;
using BibliotecaMVC.Models;

namespace BibliotecaMVC.Controllers
{
    public class AutoresController : Controller
    {
        public IActionResult Index()
        {
            List<Autor> autores = new List<Autor>()
            {
                new Autor
                {
                    ID = 1,
                    Nombre = "Gabriel",
                    Apellido = "García Márquez",
                    Nacionalidad = "Colombiana",
                    FechadeNacimiento = new DateTime(1927, 3, 6),
                    Activo = false
                },
                new Autor
                {
                    ID = 2,
                    Nombre = "Isabel",
                    Apellido = "Allende",
                    Nacionalidad = "Chilena",
                    FechadeNacimiento = new DateTime(1942, 8, 2),
                    Activo = true
                },
                new Autor
                {
                    ID = 3,
                    Nombre = "J.K.",
                    Apellido = "Rowling",
                    Nacionalidad = "Británica",
                    FechadeNacimiento = new DateTime(1965, 7, 31),
                    Activo = true
                },
                new Autor
                {
                    ID = 4,
                    Nombre = "Haruki",
                    Apellido = "Murakami",
                    Nacionalidad = "Japonesa",
                    FechadeNacimiento = new DateTime(1949, 1, 12),
                    Activo = true
                },
                new Autor
                {
                    ID = 5,
                    Nombre = "Chinua",
                    Apellido = "Achebe",
                    Nacionalidad = "Nigeriana",
                    FechadeNacimiento = new DateTime(1930, 11, 16),
                    Activo = false
                }
            };

            ViewBag.Autores = autores;

            return View();
        }
    }
}
