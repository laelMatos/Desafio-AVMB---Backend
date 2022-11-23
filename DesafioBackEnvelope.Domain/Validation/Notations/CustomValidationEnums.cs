﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioBackEnvelope.Domain.Validation
{
    /// <summary>
    /// Validação customizada para enums
    /// </summary>
    public class CustomValidationEnums : ValidationAttribute
    {
        /// <summary>
        /// Validação customizada para enums
        /// </summary>
        /// <param name="type">Tipo do enum 'typeof(enum_verificar)'</param>
        public CustomValidationEnums(Type type) 
        {
            this.type = type;
        }
         public Type type { get; private set; }

        public override bool IsValid(object value)
        {
            //Se não tiver valor ignora a validação
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return true;

            bool valido = Enum.IsDefined(this.type, value);
            return valido;
        }

    }
}
