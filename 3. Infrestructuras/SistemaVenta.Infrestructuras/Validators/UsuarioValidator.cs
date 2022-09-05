using FluentValidation;
using SistemaVenta.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenta.Infrestructuras.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioDTO>
    {
        public UsuarioValidator()
        {
            RuleSet("Login", () =>
            {
                RuleFor(x => x.Cuenta)
                           .NotNull();

                RuleFor(x => x.Contrasena)
                    .NotNull();
            });
        }

    }
}
