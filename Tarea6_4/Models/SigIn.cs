﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tarea6_4.Models
{
    public class SigIn
    {
        [Required(ErrorMessage = "El Nombre Es Requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Apellido Es Requerido")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El usuario no debe estar en blanco")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El email no debe estar en blanco")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "El numero de {0} debe ser al menos {2}", MinimumLength = 3)]
        [Required(ErrorMessage = "La Contraseña no debe estar en blanco")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        EmpleadoDBEntities user = new EmpleadoDBEntities();

        User obj = new User();

        public bool Signin()
        {
            var query = from u in user.Users
                        where u.Email == Email ||
                        u.UserName == UserName
                        select u;

            if (query.Count() > 0)
            {
                return false;
            }
            else
            {
                obj.Name = Name;
                obj.LastName = LastName;
                obj.UserName = UserName;
                obj.Email = Email;
                obj.Password = Password;

                user.Users.Add(obj);
                user.SaveChanges();
                return true;
            }

        }
    }
}