using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Formulario1.NewFolder4
{
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nombre { get; set; }

        [MaxLength(200)]
        public string Apellido { get; set; }
        [MaxLength(10)]
        public String FechaNacimiento { get; set; }
        [MaxLength(200), Unique]
        public string Correo { get; set; }
    }
}
