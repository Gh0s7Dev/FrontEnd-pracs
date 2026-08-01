using Microsoft.AspNetCore.Mvc;
using BibliotecaMVC.Models;

namespace BibliotecaMVC.Controllers
{
    public class LibrosController : Controller
    {
        private static List<Libro> _libros = new List<Libro>
        {
            new Libro
            {
                ID = 1,
                Titulo = "Cien años de soledad",
                Autor = "Gabriel García Márquez",
                Categoria = "Novela",
                Precio = 25.00m,
                Disponible = true
            },
            new Libro
            {
                ID = 2,
                Titulo = "El principito",
                Autor = "Antoine de Saint-Exupéry",
                Categoria = "Literatura",
                Precio = 15.50m,
                Disponible = true
            },
            new Libro
            {
                ID = 3,
                Titulo = "1984",
                Autor = "George Orwell",
                Categoria = "Ciencia ficción",
                Precio = 20.00m,
                Disponible = false
            }
        };

        // Listar libros
        public IActionResult Index()
        {
            return View(_libros);
        }

        // Ver detalle
        public IActionResult Details(int id)
        {
            var libro = _libros.FirstOrDefault(l => l.ID == id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // Mostrar formulario para crear
        public IActionResult Create()
        {
            return View();
        }

        // Crear libro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return View(libro);
            }

            if (_libros.Any())
            {
                libro.ID = _libros.Max(l => l.ID) + 1;
            }
            else
            {
                libro.ID = 1;
            }

            _libros.Add(libro);

            return RedirectToAction(nameof(Index));
        }

        // Mostrar formulario para editar
        public IActionResult Edit(int id)
        {
            var libro = _libros.FirstOrDefault(l => l.ID == id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // Editar libro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Libro libro)
        {
            if (id != libro.ID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(libro);
            }

            var libroExistente = _libros.FirstOrDefault(l => l.ID == id);

            if (libroExistente == null)
            {
                return NotFound();
            }

            libroExistente.Titulo = libro.Titulo;
            libroExistente.Autor = libro.Autor;
            libroExistente.Categoria = libro.Categoria;
            libroExistente.Precio = libro.Precio;
            libroExistente.Disponible = libro.Disponible;

            return RedirectToAction(nameof(Index));
        }

        // Confirmar eliminación
        public IActionResult Delete(int id)
        {
            var libro = _libros.FirstOrDefault(l => l.ID == id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // Eliminar libro
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var libro = _libros.FirstOrDefault(l => l.ID == id);

            if (libro == null)
            {
                return NotFound();
            }

            _libros.Remove(libro);

            return RedirectToAction(nameof(Index));
        }
    }
}