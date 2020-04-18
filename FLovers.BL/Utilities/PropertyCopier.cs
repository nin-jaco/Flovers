using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FLovers.Log.Services.Logging;
using FLovers.Shared.BaseClasses;

namespace FLovers.BL.Utilities
{
    public class PropertyCopier<TDto, TEntity> where TDto : class, new()
        where TEntity : class, new()
    {
        public static TEntity MapToModel(TDto parent)
        {
            try
            {
                var child = new TEntity();
                var parentProperties = parent.GetType().GetProperties();
                var childProperties = child.GetType().GetProperties();

                foreach (var parentProperty in parentProperties)
                {
                    foreach (var childProperty in childProperties)
                    {
                        if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                        {
                            childProperty.SetValue(child, parentProperty.GetValue(parent));
                            break;
                        }
                    }
                }

                return child;
            }
            catch (System.Exception ex)
            {
                ErrorHandler.LogException(ex);
                return null;
            }
        }

        public static TDto MapToDto(TEntity parent)
        {
            try
            {
                var child = new TDto();
                var parentProperties = parent.GetType().GetProperties();
                var childProperties = child.GetType().GetProperties();

                foreach (var parentProperty in parentProperties)
                {
                    foreach (var childProperty in childProperties)
                    {
                        if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                        {
                            childProperty.SetValue(child, parentProperty.GetValue(parent));
                            break;
                        }
                    }
                }

                return child;
            }
            catch (System.Exception ex)
            {
                ErrorHandler.LogException(ex);
                return null;
            }
        }

    }
}
