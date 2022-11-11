using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //Aspect ->metodun başında sonunda hata verdiğinde çalışacak yapı.
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType) 
        {
            //defensive coding -> savunma odaklı kodlama.
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//validatortype IValidator sınıfı mı kontrol edecek ve değilse hata verecek yer.
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // Çalışma anında Instance oluştuır.( Reflection)
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // örnek:ProductVAlidator'un çalışma tipini bul.(Generic çalışma tipini)(AbstractValidator<Product>)
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);// ve metotların argumanlarını gez. ve entityType a eşit argüman varsa validate'e gönder.  Add(Product product) gibi veya Add(Product product,Product product2) burada ikisini de foreach ie VAlidate edecek.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity); //VAlidate et
            }
        }
    }
}
