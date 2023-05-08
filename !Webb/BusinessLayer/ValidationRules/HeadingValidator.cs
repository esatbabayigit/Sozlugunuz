using EntityLayer.Concreate;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("İSİM ALANINI BOŞ BIRAKAMAZSINIZ");
            RuleFor(x => x.Category.CategoryName).NotEmpty().WithMessage("KATEGORİ ALANINI BOŞ BIRAKAMAZSINIZ");
            RuleFor(x => x.Writer.WriterName).NotEmpty().WithMessage("YAZAR ALANINI BOŞ BIRAKAMAZSINIZ");
            
        }
    }
}