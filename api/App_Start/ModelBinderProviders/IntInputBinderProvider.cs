﻿using System;
using TemplateApi.Compartilhado.ObjetosDeValor;
using TemplateApi.Api.App_Start.ModelBinders;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace TemplateApi.Api.App_Start.ModelBinderProviders
{
    public class IntInputBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(IntInput))
            {
                return new BinderTypeModelBinder(typeof(IntInputModelBinder));
            }

            return null;
        }
    }
}
