using EntityLayer.Concreate;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.ContactMail).NotEmpty().WithMessage("MAİL ADRESİNİ BOŞ BIRAKAMAZSINIZ");
            RuleFor(x => x.ContactSubject).NotEmpty().WithMessage("KONU ALANINI BOŞ BIRAKAMAZSINIZ");
            RuleFor(x => x.ContactName).NotEmpty().WithMessage("KULLANICI ADINI BOŞ BIRAKAMAZSINIZ");
            RuleFor(x => x.ContactName).MinimumLength(3).WithMessage("KULLANICI ADI 3 KARAKTERDEN FAZLA OLMALI");
            RuleFor(x => x.ContactSubject).MinimumLength(3).WithMessage("KONU 3 KARAKTERDEN FAZLA OLMALI");
            RuleFor(x => x.ContactSubject).MaximumLength(50).WithMessage("KONU ALANI 50 KARAKTEDEN FAZLA OLMALI");
        }
    }
}