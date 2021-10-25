using System.Linq;
using System;
using FluentValidation;

namespace Financeasy.Core
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        public DateTime Created { get; protected set; }
        public DateTime? Updated { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
        }

        public void SetLastUpdate()
        {
            Updated = DateTime.Now;
        }

        protected abstract void ValidateBase();

        protected static void Validate<TV, TE>(TV validation, TE entity)
            where TV : AbstractValidator<TE>
            where TE : Entity
        {
            var validator = validation.Validate(entity);
            if (!validator.IsValid)
            {
                var message = validator.Errors.FirstOrDefault()?.ErrorMessage;
                throw new BusinessException(message);
            }
        }
    }
}