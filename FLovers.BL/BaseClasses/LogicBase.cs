using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using FLovers.BL.Interfaces;
using FLovers.BL.Utilities;
using FLovers.DAL.Repository.BaseClasses;
using FLovers.DAL.Repository.Interfaces;
using FLovers.Log.Services.Logging;
using FLovers.Shared.Enums;
using FLovers.Shared.Extensions;
using FLovers.Shared.RequestObjects;
using FLovers.Shared.ResponseObjects;

namespace FLovers.BL.BaseClasses
{
    /// <summary>
    /// Generic Logic Class that can be used for most crud operations
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public class LogicBase<TDto, TEntity> : ILogicBase<TDto, TEntity> where TDto : class, new() where TEntity : class, new()
    {
        private IRepository<TEntity> _repository; 

        public LogicBase(IRepository<TEntity> repository = null)
        {
            _repository = repository ?? new Repository<TEntity>();
        }

        public virtual CreateResponse<TDto> Create(CreateRequest<TDto> request)
        {
            var response = new CreateResponse<TDto>();
            try
            {
                var result = _repository.Add(new CreateRequest<TEntity>(MapToModel(request.Item), request.RequestBase));
                if (result != null)
                {
                    response.Item = MapToDto(result);
                    response.IsSuccess = true;
                    return response;
                }

                response.Item = new TDto();
                response.IsSuccess = false;
                return response;
            }
            catch (DbEntityValidationException dbx)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = dbx.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(dbx.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new System.Exception(exceptionMessage);
            }
            catch (System.Exception ex)
            {
                ErrorHandler.LogException(ex);
                response.ErrorMessage = ErrorsEnum.ExceptionEncountered.FriendlyErrorMessage();
                response.IsSuccess = false;
                response.ErrorCode = (int)ErrorsEnum.ExceptionEncountered;
                return response;
            }
        }

        public virtual DeleteResponse<TDto> Delete(DeleteRequest<TDto> request)
        {
            var response = new DeleteResponse<TDto>();
            try
            {
                var result = _repository.Remove(new DeleteRequest<TEntity>(MapToModel(request.Item), request.RequestBase));
                if (result != null)
                {
                    response.Item = MapToDto(result);
                    response.IsSuccess = true;
                    return response;
                }

                response.Item = new TDto();
                response.IsSuccess = false;
                return response;
            }
            catch (DbEntityValidationException dbx)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = dbx.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(dbx.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new System.Exception(exceptionMessage);
            }
            catch (System.Exception ex)
            {
                ErrorHandler.LogException(ex);
                response.ErrorMessage = ErrorsEnum.ExceptionEncountered.FriendlyErrorMessage();
                response.IsSuccess = false;
                response.ErrorCode = (int)ErrorsEnum.ExceptionEncountered;
                return response;
            }
        }

        public virtual UpdateResponse<TDto> Update(UpdateRequest<TDto> request)
        {
            var response = new UpdateResponse<TDto>();
            try
            {
                var result = _repository.Update(new UpdateRequest<TEntity>(request.Key, MapToModel(request.Item)));
                if (result != null)
                {
                    response.Item = MapToDto(result);
                    response.IsSuccess = true;
                    return response;
                }

                response.Item = new TDto();
                response.IsSuccess = false;
                return response;
            }
            catch (DbEntityValidationException dbx)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = dbx.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(dbx.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new System.Exception(exceptionMessage);
            }
            catch (System.Exception ex)
            {
                ErrorHandler.LogException(ex);
                response.ErrorMessage = ErrorsEnum.ExceptionEncountered.FriendlyErrorMessage();
                response.IsSuccess = false;
                response.ErrorCode = (int)ErrorsEnum.ExceptionEncountered;
                return response;
            }
        }

        public virtual GetAllResponse<TDto> GetAll(GetAllRequest request)
        {
            var response = new GetAllResponse<TDto> { IsSuccess = false, ItemList = null };
            try
            {
                var results = new List<TDto>();
                var models = _repository.GetAll(request);
                if (models.Any())
                {
                    foreach (var model in models)
                    {
                        results.Add(MapToDto(model));
                    }
                    response.ItemList = results;
                    response.IsSuccess = true;
                    return response;
                }

                response.ErrorMessage = "Search yielded no results.";
                response.ItemList = new List<TDto>();
                return response;
            }
            catch (DbEntityValidationException dbx)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = dbx.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(dbx.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new System.Exception(exceptionMessage);
            }
            catch (System.Exception ex)
            {
                ErrorHandler.LogException(ex);
                response.ErrorMessage = ErrorsEnum.ExceptionEncountered.FriendlyErrorMessage();
                response.IsSuccess = false;
                response.ErrorCode = (int)ErrorsEnum.ExceptionEncountered;
                return response;
            }

        }

        public GetByIdResponse<TDto> GetById(GetByIdRequest<TDto> request)
        {
            var response = new GetByIdResponse<TDto>();
            try
            {
                var result = _repository.Get(new GetByIdRequest<TEntity>(request.Key));
                if (result != null)
                {
                    response.Item = MapToDto(result);
                    response.IsSuccess = true;
                    return response;
                }

                response.Item = new TDto();
                response.IsSuccess = false;
                return response;
            }
            catch (DbEntityValidationException dbx)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = dbx.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(dbx.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new System.Exception(exceptionMessage);
            }
            catch (System.Exception ex)
            {
                ErrorHandler.LogException(ex);
                response.ErrorMessage = ErrorsEnum.ExceptionEncountered.FriendlyErrorMessage();
                response.IsSuccess = false;
                response.ErrorCode = (int)ErrorsEnum.ExceptionEncountered;
                return response;
            }
        }

        public virtual SearchFirstResponse<TDto> SearchFirst(SearchFirstRequest<TDto> request)
        {
            var response = new SearchFirstResponse<TDto> { IsSuccess = false, Item = null };
            try
            {
                if (_repository != null)
                {
                    response.Item = MapToDto(
                        _repository.SearchFirst(new SearchFirstRequest<TEntity>(request.Predicate, request.RequestBase)));
                    response.IsSuccess = true;
                    return response;
                }

                response.ErrorMessage = "Response returned no results.";
                response.Item = new TDto();
                return response;
            }
            catch (DbEntityValidationException dbx)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = dbx.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(dbx.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new System.Exception(exceptionMessage);
            }
            catch (System.Exception ex)
            {
                ErrorHandler.LogException(ex);
                response.ErrorMessage = ErrorsEnum.ExceptionEncountered.FriendlyErrorMessage();
                response.IsSuccess = false;
                response.ErrorCode = (int)ErrorsEnum.ExceptionEncountered;
                return response;
            }
        }

        public virtual SearchForResponse<TDto> SearchFor(SearchForRequest<TDto> request)
        {
            var response = new SearchForResponse<TDto> { IsSuccess = false, ItemList = null };
            try
            {
                var results = new List<TDto>();
                var models = _repository.SearchFor(new SearchForRequest<TEntity>(request.Predicate, request.RequestBase)).ToList();
                if (models.Any())
                {
                    results.AddRange(models.Select(model => MapToDto(model)));
                    response.ItemList = results;
                }

                response.ErrorMessage = "Search yielded no results.";
                response.ItemList = new List<TDto>();
                return response;
            }
            catch (DbEntityValidationException dbx)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = dbx.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(dbx.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new System.Exception(exceptionMessage);
            }
            catch (System.Exception ex)
            {
                ErrorHandler.LogException(ex);
                response.ErrorMessage = ErrorsEnum.ExceptionEncountered.FriendlyErrorMessage();
                response.IsSuccess = false;
                response.ErrorCode = (int)ErrorsEnum.ExceptionEncountered;
                response.ItemList = null;
                return response;
            }
        }

        public virtual GetAllPagedResponse<TDto> GetAllPaged(GetAllPagedRequest<TDto> request)
        {
            throw new NotImplementedException();
        }

        public virtual GetAllPagedAndFilteredResponse<TDto> GetAllPagedAndFiltered(GetAllPagedAndFilteredRequest<TDto> request)
        {
            throw new NotImplementedException();
        }


        public TEntity MapToModel(TDto dto) => PropertyCopier<TDto, TEntity>.MapToModel(dto);
        public TDto MapToDto(TEntity model) => PropertyCopier<TDto, TEntity>.MapToDto(model);

    }
}
