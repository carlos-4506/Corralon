using Microsoft.AspNetCore.Mvc;
using LogisticaCorralon.Models;
using LogisticaCorralon.Managers.Managers;
using LogisticaCorralon.Managers.ModelFactories;

namespace LogisticaCorralon.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductoManager _productoManager;
        private readonly IProductoModelFactory _productoModelFactory;

        public ProductosController(IProductoManager productoManager, IProductoModelFactory productoModelFactory)
        {
            _productoManager = productoManager;
            _productoModelFactory = productoModelFactory;
        }

        public IActionResult Index()
        {
            var productos = _productoManager.ObtenerProductos();
            var productoModels = new List<ProductoModel>();

            foreach (var producto in productos)
            {
                productoModels.Add(_productoModelFactory.CrearProductoModel(producto));
            }

            return View(productoModels);
        }

        public IActionResult Details(int id)
        {
            var producto = _productoManager.ObtenerProductoPorId(id);
            if (producto == null)
            {
                return NotFound();
            }

            var productoModel = _productoModelFactory.CrearProductoModel(producto);
            return View(productoModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductoModel productoModel)
        {
            if (ModelState.IsValid)
            {
                var producto = _productoModelFactory.CrearProducto(productoModel);
                _productoManager.CrearProducto(producto);

                return RedirectToAction(nameof(Index));
            }

            return View(productoModel);
        }

        public IActionResult Edit(int id)
        {
            var producto = _productoManager.ObtenerProductoPorId(id);
            if (producto == null)
            {
                return NotFound();
            }

            var productoModel = _productoModelFactory.CrearProductoModel(producto);
            return View(productoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProductoModel productoModel)
        {
            if (id != productoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var producto = _productoModelFactory.CrearProducto(productoModel);
                _productoManager.ActualizarProducto(id, producto);

                return RedirectToAction(nameof(Index));
            }

            return View(productoModel);
        }

        public IActionResult Delete(int id)
        {
            var producto = _productoManager.ObtenerProductoPorId(id);
            if (producto == null)
            {
                return NotFound();
            }

            var productoModel = _productoModelFactory.CrearProductoModel(producto);
            return View(productoModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _productoManager.EliminarProducto(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
