﻿using BitHelp.Core.Validation;

namespace TemplateApi.Dominio.Servicos.Comum
{
    public abstract class BaseServico : ISelfValidation
    {
        public ValidationNotification Notifications { get; protected set; } = new ValidationNotification();

        public bool IsValid(ISelfValidation valor)
        {
            bool resultado = valor.IsValid();
            Notifications.Add(valor);
            return resultado;
        }

        public bool IsValid()
        {
            return Notifications.IsValid();
        }
    }
}