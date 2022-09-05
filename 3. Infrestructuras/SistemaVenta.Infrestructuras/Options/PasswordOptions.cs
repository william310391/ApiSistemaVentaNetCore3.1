using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenta.Infrestructuras.Options
{
    public class PasswordOptions
    {
        public int SaltSize { get; set; }
        public int keySize { get; set; }
        public int Iterations { get; set; }
    }
}
