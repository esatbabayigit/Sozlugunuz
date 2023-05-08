using EntityLayer.Concreate;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x=>x.MessageReceiverMail).NotEmpty().WithMessage("BU ALANI BOŞ GEÇEMEZSİNİZ");
            RuleFor(x=>x.MessageSubject).NotEmpty().WithMessage("BU ALANI BOŞ GEÇEMEZSİNİZ");
            RuleFor(x=>x.MessageContent).NotEmpty().WithMessage("BU ALANI BOŞ GEÇEMEZSİNİZ");
            RuleFor(x => x.MessageReceiverMail).EmailAddress().WithMessage("LÜTFEN GEÇERLİ E MAİL ADRESİ GİRİNİZ").When(i=>!string.IsNullOrEmpty(i.MessageReceiverMail));
            RuleFor(x => x.MessageSenderMail).EmailAddress().WithMessage("LÜTFEN GEÇERLİ E MAİL ADRESİ GİRİNİZ").When(i=>!string.IsNullOrEmpty(i.MessageSenderMail));
            RuleFor(x => x.MessageSubject).MinimumLength(3).WithMessage("LÜTFEN 3 KARAKTERDEN AZ KONU GİRMEYİNİZ");
            RuleFor(x => x.MessageSubject).MaximumLength(100).WithMessage("LÜTFEN 100 KARAKTERDEN FAZLA KONU GİRMEYİNİZ");
        }
    }
}