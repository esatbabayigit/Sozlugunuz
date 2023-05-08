using EntityLayer.Concreate;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x =>x.WriterName ).NotEmpty().WithMessage("İSİM ALANINI BOŞ BIRAKAMAZSINIZ");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("SOYAD ALANINI BOŞ BIRAKAMAZSINIZ");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("UNVAN ALANINI BOŞ BIRAKAMAZSINIZ");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("HAKKINDA ALANINI BOŞ BIRAKAMAZSINIZ");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("LÜTFEN EN AZ 3 KARAKTERLİ İSİM GİRİNİZ");
            RuleFor(x => x.WriterName).MaximumLength(20).WithMessage("LÜTFEN 20 KARAKTERDEN FAZLA İSİM GİRMEYİNİZ");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("LÜTFEN EN AZ 3 KARAKTERLİ SOYAD GİRİNİZ");
            RuleFor(x => x.WriterSurname).MaximumLength(20).WithMessage("LÜTFEN 20 KARAKTERDEN FAZLA SOYAD GİRMEYİNİZ");
        }
    }
}