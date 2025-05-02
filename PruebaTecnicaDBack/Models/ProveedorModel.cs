using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaDBack.Models
{
    public class ProveedorModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required]
        [BsonElement("nit")]
        public string Nit { get; set; }

        [Required]
        [BsonElement("razonSocial")]
        public string RazonSocial { get; set; }

        [Required]
        [BsonElement("direccion")]
        public string Direccion { get; set; }

        [Required]
        [BsonElement("ciudad")]
        public string Ciudad { get; set; }

        [Required]
        [BsonElement("departamento")]
        public string Departamento { get; set; }

        [Required]
        [BsonElement("correo")]
        public string Correo { get; set; }

        [Required]
        [BsonElement("activo")]
        public bool Activo { get; set; }

        [Required]
        [BsonElement("fechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [Required]
        [BsonElement("nombreContacto")]
        public string NombreContacto { get; set; }

        [Required]
        [BsonElement("correoContacto")]
        public string CorreoContacto { get; set; }
    }
}
