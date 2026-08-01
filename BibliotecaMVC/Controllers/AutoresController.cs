using Microsoft.AspNetCore.Mvc;
using BibliotecaMVC.Models;

namespace BibliotecaMVC.Controllers
{
    public class AutoresController : Controller
    {
        private static List<Autor> _autores = new List<Autor>
        {
            new Autor
            {
                ID = 1,
                Nombre = "Gabriel",
                Apellido = "García Márquez",
                Nacionalidad = "Colombiana",
                FechaNacimiento = new DateTime(1927, 3, 6),
                Activo = false
            },
            new Autor
            {
                ID = 2,
                Nombre = "Isabel",
                Apellido = "Allende",
                Nacionalidad = "Chilena",
                FechaNacimiento = new DateTime(1942, 8, 2),
                Activo = true
            },
            new Autor
            {
                ID = 3,
                Nombre = "J.K.",
                Apellido = "Rowling",
                Nacionalidad = "Británica",
                FechaNacimiento = new DateTime(1965, 7, 31),
                Activo = true
            },
            new Autor
            {
                ID = 4,
                Nombre = "Haruki",
                Apellido = "Murakami",
                Nacionalidad = "Japonesa",
                FechaNacimiento = new DateTime(1949, 1, 12),
                Activo = true
            },
            new Autor
            {
                ID = 5,
                Nombre = "Chinua",
                Apellido = "Achebe",
                Nacionalidad = "Nigeriana",
                FechaNacimiento = new DateTime(1930, 11, 16),
                Activo = false
            }
        };

        public IActionResult Index()
        {
            // ViewBag.Autores = autores;

            return View(_autores);
        }

        public IActionResult Details(int id)
        {
            var autor = _autores.FirstOrDefault(a => a.ID == id);

            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return View(autor);
            }

            if (_autores.Any())
            {
                autor.ID = _autores.Max(a => a.ID) + 1;
            }
            else
            {
                autor.ID = 1;
            }

            _autores.Add(autor);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var autor = _autores.FirstOrDefault(a => a.ID == id);

            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Autor autor)
        {
            if (id != autor.ID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(autor);
            }

            var autorExistente = _autores.FirstOrDefault(a => a.ID == id);

            if (autorExistente == null)
            {
                return NotFound();
            }

            autorExistente.Nombre = autor.Nombre;
            autorExistente.Apellido = autor.Apellido;
            autorExistente.Nacionalidad = autor.Nacionalidad;
            autorExistente.FechaNacimiento = autor.FechaNacimiento;
            autorExistente.Activo = autor.Activo;

            return RedirectToAction(nameof(Index));
        }

        // GET: Autores/Delete/
        public IActionResult Delete(int id)
        {
            var autor = _autores.FirstOrDefault(a => a.ID == id);

            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: Autores/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var autor = _autores.FirstOrDefault(a => a.ID == id);

            if (autor == null)
            {
                return NotFound();
            }

            _autores.Remove(autor);

            return RedirectToAction(nameof(Index));
        }
    }
}
