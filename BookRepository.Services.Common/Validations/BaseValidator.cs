using BookRepository.Services.Common.DataServices.Interfaces;
using BookRepository.Services.Common.Enumerations;
using FluentValidation;

using static BookRepository.Services.Common.GlobalConstants.ErrorMessages;

namespace BookRepository.Services.Common.Validations
{
    public abstract class BaseModelValidator<TModel, TId> : AbstractValidator<TModel>
        where TModel : BaseModel<TId>
    {
        protected void AddIdValidation<TEntity>(IDataService<TEntity> dataService)
            where TEntity : class
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            ClassLevelCascadeMode = CascadeMode.Stop;

            if (typeof(TId) == typeof(int) || typeof(TId) == typeof(int?))
            {
                RuleFor(model => model.Id as int?)
                    .GreaterThan(0)
                    .WithMessage(IdModelIdValidationMessage)
                    .MustAsync(async (id, _) => await dataService.ExistsById(id!))
                    .WithMessage(EntityDoesNotExistMessage)
                    .When(model => model.OperationType == CrudOperationType.Read ||
                                   model.OperationType == CrudOperationType.Update ||
                                   model.OperationType == CrudOperationType.Delete);
            }

            if (typeof(TId) == typeof(string))
            {
                RuleFor(model => model.Id)
                    .NotEmpty()
                    .WithMessage(IdModelIdValidationMessage)
                    .MustAsync(async (id, _) => await dataService.ExistsById(id!))
                    .WithMessage(EntityDoesNotExistMessage)
                    .When(model => model.OperationType == CrudOperationType.Read ||
                                   model.OperationType == CrudOperationType.Update ||
                                   model.OperationType == CrudOperationType.Delete);
            }
        }
    }
}