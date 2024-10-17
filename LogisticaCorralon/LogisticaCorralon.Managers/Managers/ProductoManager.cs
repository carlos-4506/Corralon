using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using LogisticaCorralon.Managers.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace LogisticaCorralon.Managers.Managers
{
    public class ProductoManager
    {
        private readonly string connectionString;

        public ProductoManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Producto> ObtenerProductos()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Producto>("SELECT * FROM productos").ToList();
            }
        }

        public Producto ObtenerProductoPorId(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.QuerySingleOrDefault<Producto>("SELECT * FROM productos WHERE id = @Id", new { Id = id });
            }
        }

        public void CrearProducto(Producto producto)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO productos (nombre, descripcion, cantidad, precio, estado) VALUES (@Nombre, @Descripcion, @Cantidad, @Precio, @Estado)";
                db.Execute(sql, producto);
            }
        }

        public void ActualizarProducto(int id, Producto producto)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sql = "UPDATE productos SET nombre = @Nombre, descripcion = @Descripcion, cantidad = @Cantidad, precio = @Precio, estado = @Estado WHERE id = @Id";
                db.Execute(sql, new { producto.Nombre, producto.Descripcion, producto.Cantidad, producto.Precio, producto.Estado, Id = id });
            }
        }

        public void EliminarProducto(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute("DELETE FROM productos WHERE id = @Id", new { Id = id });
            }
        }
    }
}
