using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BusinessRules
{
    public class ProductsValidators : AbstractValidator<Product>
    {
        public ProductsValidators()
        {
            RuleFor(product => product.Price)
                .InclusiveBetween(1,1000)
                .WithMessage("The price has to be between $1 and $1000");

            RuleFor(product => product.AgeRestriction)
                .InclusiveBetween(0, 100)
                .WithMessage("The age restriction has to be between 0 and 100");
        }
    }
}
