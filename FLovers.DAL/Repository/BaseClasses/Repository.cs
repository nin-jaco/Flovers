using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FLovers.DAL.Extensions;
using FLovers.DAL.Repository.Interfaces;
using FLovers.Log.Services.Logging;
using FLovers.Shared.BaseClasses;
using FLovers.Shared.RequestObjects;

namespace FLovers.DAL.Repository.BaseClasses
{
    public class Repository<TModel> : IRepository<TModel> where TModel : class, IDisposable, new()
    {
        public IContext<TModel> Context { get; protected set; }
        protected DbSet<TModel> DbSet;
        public DbContextTransaction Transaction { get; set; }

        public Repository()
        {
            Context = new Context<TModel>();
            Context.DbContext.Database.CommandTimeout = 300;
            DbSet = Context.DbContext.Set<TModel>();

        }

        public Repository(IContext<TModel> context)
        {
            Context = context;
        }

        public virtual TModel Get(GetByIdRequest<TModel> request)
        {
            return DbSet.Find(request.Key);
        }

        public virtual IQueryable<TModel> GetAll(GetAllRequest request)
        {
            return DbSet;
        }

        public TModel SearchFirst(SearchFirstRequest<TModel> request)
        {
            var expression = request.Predicate.ToBooleanExpression<TModel>();
            return DbSet.FirstOrDefault(expression);
        }

        public IQueryable<TModel> SearchFor(SearchForRequest<TModel> request)
        {
            var expression = request.Predicate.ToBooleanExpression<TModel>();
            return DbSet.Where(expression);
        }

        public virtual TModel Add(CreateRequest<TModel> request)
        {
            Context.DbSet.Add(request.Item);
            SaveChanges(request.RequestBase);
            return request.Item;
        }

        public virtual TModel Remove(DeleteRequest<TModel> request)
        {
            Context.DbSet.Attach(request.Item);
            Context.DbSet.Remove(request.Item);
            SaveChanges(request.RequestBase);
            return request.Item;
        }

        public virtual TModel Update(UpdateRequest<TModel> request)
        {
            var target = Get(new GetByIdRequest<TModel>(request.Key));
            UpdateIfDifferent(target, request.Item);
            SaveChanges(request.RequestBase);
            return request.Item;
        }

        public virtual void SaveChanges(RequestBase request)
        {
            try
            {
                Context.DbContext.AddAuditCustomField("IdChangedBy", request.IdUser);
                Context.DbContext.AddAuditCustomField("Username", request.Username);
                Context.DbContext.AddAuditCustomField("IdDealer", request.IdBranch);
                Context.DbContext.AddAuditCustomField("DealerName", request.BranchName);
                Context.DbContext.AddAuditCustomField("IpAddress", request.Ip);
                Context.DbContext.AddAuditCustomField("UserAgent", request.UserAgent);
                Context.DbContext.AddAuditCustomField("Browser", request.Browser);
                Context.DbContext.AddAuditCustomField("BrowserVersion", request.BrowserVersion);

                Context.DbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex);
            }
        }

        public void UpdateIfDifferent(TModel target, TModel source)
        {
            PropertyInfo property = null;
            object targetValue = null;
            object sourceValue = null;

            try
            {
                foreach (var prop in target.GetType().GetProperties())
                {
                    property = prop;
                    if (Context.DbContext.Entry(target).Member(prop.Name) is DbReferenceEntry) continue;
                    if (prop.IsNonStringEnumerable()) continue;

                    targetValue = GetPropValue(target, prop.Name);
                    sourceValue = GetPropValue(source, prop.Name);

                    if (targetValue == null && sourceValue == null) continue;

                    if (targetValue == null || !targetValue.Equals(sourceValue))
                    {
                        SetPropertyValue(target, prop.Name, sourceValue);
                        Context.DbContext.Entry(target).Property(prop.Name).IsModified = true;
                    }
                }
            }
            catch (Exception e)
            {
                var errorMessage = e.Message + $@"Exception caught in UpdateIfDifferent, Repository.cs. Property name {property?.Name}, targetValue {targetValue?.ToString()}, sourceValue {sourceValue?.ToString()}";
                ErrorHandler.LogException(new Exception(errorMessage));
            }

        }

        public static object GetPropValue(object src, string propName)
        {
            object result = null;
            try
            {
                return result = src.GetType().GetProperty(propName)?.GetValue(src, null);
            }
            catch (Exception e)
            {
                var errorMessage = e.Message + $@"Exception caught in GetPropValue, In Repository.cs. Property name {propName}, Value is null {result}";
                ErrorHandler.LogException(new Exception(errorMessage));
                return null;
            }
        }

        public static void SetPropertyValue(object obj, string propName, object value)
        {
            try
            {
                obj.GetType().GetProperty(propName)?.SetValue(obj, value, null);
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex);
            }
        }


        public Repository<TModel> SaveAndContinue(RequestBase request)
        {
            try
            {
                SaveChanges(request);
            }
            catch (DbEntityValidationException dbEx)
            {
                ThrowNewEntityException(dbEx);
            }
            return this;
        }

        public void ThrowNewEntityException(DbEntityValidationException dbEx)
        {
            // Retrieve the error messages as a list of strings.
            var errorMessages = dbEx.EntityValidationErrors
                .SelectMany(x => x.ValidationErrors)
                .Select(x => x.ErrorMessage);

            // Join the list to a single string.
            var fullErrorMessage = string.Join("; ", errorMessages);

            // Combine the original exception message with the new one.
            var exceptionMessage = string.Concat(dbEx.Message, " The validation errors are: ", fullErrorMessage);

            // Throw a new DbEntityValidationException with the improved exception message.
            ErrorHandler.LogException(new DbEntityValidationException(exceptionMessage, dbEx.EntityValidationErrors));
        }

        public Repository<TModel> BeginTransaction()
        {
            Transaction = Context.DbContext.Database.BeginTransaction();
            return this;
        }

        public bool EndTransaction(RequestBase request)
        {
            SaveChanges(request);
            Transaction.Commit();
            return true;
        }

        public void RollBack()
        {
            Transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            Transaction?.Dispose();
            Context?.Dispose();
        }

        /*
     var status = BeginTransaction()
                // First Part
                .DoInsert(entity1)
                .DoInsert(entity2)
                .DoInsert(entity3)
                .DoInsert(entity4)
                .SaveAndContinue()
                // Second Part
                .DoInsert(statusMessage.SetPropertyValue(message => message.Message, $"Just got new message {entity1.Name}"))
            .EndTransaction();
         */

        public virtual void SetValues(int id, TModel newObject, RequestBase requestBase)
        {
            var existingObject = Get(new GetByIdRequest<TModel>(id));
            Context.DbContext.Entry(existingObject).CurrentValues.SetValues(newObject);
            SaveChanges(requestBase);
        }


    }

}
