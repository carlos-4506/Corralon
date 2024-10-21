using LogisticaCorralon.Managers.Entidades;
using LogisticaCorralon.Models;

namespace LogisticaCorralon.Managers.ModelFactories
{
    public interface IProductoModelFactory
    {
        Producto CrearProducto(ProductoModel productoModel);
        ProductoModel CrearProductoModel(Producto producto);
    }

    public class ProductoModelFactory : IProductoModelFactory
    {
        // Convierte un Producto (lógica de negocio) a ProductoModel (modelo de vista)
        public ProductoModel CrearProductoModel(Producto producto)
        {
            return new ProductoModel
            {
                Id = producto.IdProducto,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Cantidad = producto.Cantidad,
                Precio = producto.Precio,
                Estado = producto.Estado
            };
        }

        // Convierte un ProductoModel (modelo de vista) a Producto (lógica de negocio)
        public Producto CrearProducto(ProductoModel productoModel)
        {
            return new Producto
            {
                IdProducto = productoModel.Id,
                Nombre = productoModel.Nombre,
                Descripcion = productoModel.Descripcion,
                Cantidad = productoModel.Cantidad,
                Precio = productoModel.Precio,
                Estado = productoModel.Estado
            };
        }
    }
}
