﻿using System;
using System.Threading.Tasks;
using BitHelp.Core.Type.pt_BR;
using TemplateApi.Recurso;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TemplateApi.Api.Extensions;

namespace TemplateApi.Api.App_Start.ModelBinders
{
    public class PhoneTypeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;

            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            var value = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }

            if (PhoneType.TryParse(value, out PhoneType result))
            {
                bindingContext.Result = ModelBindingResult.Success(result);
            }
            else if (!bindingContext.ModelState.ContainsKey(bindingContext.ModelName))
            {
                bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
                bindingContext.ModelState.AddModelError(
                bindingContext.ModelName,
                string.Format(AvisosResx.XNaoEhValido,
                bindingContext.DisplayName()));
            }

            return Task.CompletedTask;
        }
    }
}