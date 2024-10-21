using LogisticaCorralon.Managers.Entidades;
using LogisticaCorralon.Models;

namespace LogisticaCorralon.Managers.ModelFactories
{
    public static class ProductoModelFactory
    {
        // Convierte un Producto (lógica de negocio) a ProductoModel (modelo de vista)
        public static ProductoModel CrearProductoModel(Producto producto)
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
        public static Producto CrearProducto(ProductoModel productoModel)
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
