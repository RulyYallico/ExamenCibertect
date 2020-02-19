using System;
using System.Collections.Generic;
using System.Text;

namespace SlnVivero.Core.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int DNI { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Addres { get; set; }
        public int CellPhone { get; set; }
        public bool State { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public List<Venta> Ventas { get; set; }
    }

    public class Rol
    {
        public int RolId { get; set; }
        public string NameRol { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public List<User> Users { get; set; }
    }
}
