using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator: AbstractValidator<Product>
    {
        //Ekranlara göre DTO lar için de validator tanımlanabilir.
        public ProductValidator()
        {
            //SOLID 2 uygun olması için kurallar ayrı ayrı yazılmıştır.
            //When caseleri çoğaltılabilir.
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId ==1);
            //Custom kural oluşturma. A ile başlayanlar
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalıdır.");
        }
        // false dönerse kural patlar
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
