using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3PistoliaGinoSemanaUNO
{
    internal class Usuarios
    {
        public string Titulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Prioridad { get; set; }
        public string Tarea { get; set; }
        public string Estado { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Completada { get; set; }

        public Usuarios(string Titulo, string Nombre, string Descripcion, string Prioridad, string Tarea, string Estado, DateTime FechaVencimiento)
        {

            this.Titulo = Titulo;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.Prioridad = Prioridad;
            this.Tarea = Tarea;
            this.Estado = Estado;
            this.FechaVencimiento = FechaVencimiento;
            this.Completada = false;

        }
    }
}
