using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppBlazor.Data.Models
{
    public class Cuenta
    {
          public int IDCuenta {get;set;}
        public  int CI {get; set;}
        public virtual Usuario? Usuario {get; set;}
        public double Saldo {get; set;}
    

    }
}

