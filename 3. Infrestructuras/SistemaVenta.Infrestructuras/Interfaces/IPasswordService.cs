using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenta.Infrestructuras.Interfaces
{
    public interface IPasswordService
    {
        string Hash(string password);
        bool check(string hash, string password);

    }
}
