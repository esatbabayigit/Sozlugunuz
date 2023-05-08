using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concreate;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("İSİM ALANINI BOŞ BIRAKAMAZSINIZ");
            RuleFor(x=>x.CategoryDescription).NotEmpty().WithMessage("AÇIKLAMA ALANINI BOŞ BIRAKAMAZSINIZ");
            RuleFor(x=>x.CategoryName).MinimumLength(3).WithMessage("LÜTFEN EN AZ 3 KARAKTERLİ İSİM GİRİNİZ");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("LÜTFEN 20 KARAKTERDEN FAZLA İSİM GİRMEYİNİZ");
        }
    }
}
