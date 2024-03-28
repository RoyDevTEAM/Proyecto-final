using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Producto
    {
        public int id_producto {  get; set; }
        public Unidad_Medida oUnidad_Medida { get; set; }
        public Subcategoria oSubcategoria {  get; set; }
        public string nombre_producto { get; set; }
        public string precio_producto { get; set; }
        public string descripcion_producto {  get; set; }
        public string stock {  get; set; }
    }
}
