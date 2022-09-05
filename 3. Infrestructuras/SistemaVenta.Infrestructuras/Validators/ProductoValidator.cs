using FluentValidation;
using SistemaVenta.Core.DTOs;
using SistemaVenta.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenta.Infraestructura.Validations
{
    public class ProductoValidator : AbstractValidator<ProductoDTO>
    {
        public ProductoValidator()
        {
            RuleSet("RegistarProducto", () =>
            {
                RuleFor(x => x.CodigoProducto)
                           .NotNull()
                           .Length(5, 10);

                RuleFor(x => x.NombreProducto)
                    .NotNull()
                    .Length(10, 150);
            });

       
        }
    }
}
