﻿using System;
using System.Globalization;
using TemplateApi.Recurso;
using System.Diagnostics.CodeAnalysis;

namespace TemplateApi.Compartilhado.ObjetosDeValor
{
    public class DecimalInput
        : IFormattable, IConvertible, IInputType,
        IEquatable<DecimalInput>, IEquatable<decimal>,
        IEquatable<decimal?>, IEquatable<string>
    {
        public DecimalInput() { }

        public DecimalInput(string input)
        {
            TryParse(input, out DecimalInput output);
            _inptValue = output._inptValue;
            _value = output._value;
            _isValid = output._isValid;
        }

        public DecimalInput(decimal? input)
        {
            _inptValue = input?.ToString();
            _value = input;
            _isValid = !(input is null);
        }

        private string _inptValue;
        private decimal? _value;
        private bool _isValid;

        public static explicit operator string(DecimalInput input)
        {
            return input?.ToString();
        }

        public static explicit operator DecimalInput(string input)
        {
            return input is null ? null : new DecimalInput(input);
        }

        public static explicit operator decimal?(DecimalInput input)
        {
            return input?._value;
        }

        public static explicit operator DecimalInput(decimal? input)
        {
            return input is null ? null : new DecimalInput(input);
        }

        /// <summary>
        /// Return value string.Empty
        /// </summary>
        public static readonly DecimalInput Empty = new DecimalInput(string.Empty);

        public static void Parse(string input, out DecimalInput output)
        {
            if (TryParse(input, out DecimalInput result))
            {
                output = result;
            }
            else
            {
                if (input == null)
                    throw new ArgumentException(
                        nameof(input), AvisosResx.NaoPodeSerNulo);
                else
                    throw new ArgumentException(
                        nameof(input), AvisosResx.FormatoInvalido);
            }
        }

        public static bool TryParse(string input, out DecimalInput output)
        {
            input = input?.Trim();
            NumberStyles style = NumberStyles.Number;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            bool result = decimal.TryParse(input, style, culture, out decimal value);
            output = new DecimalInput
            {
                _isValid = result,
                _inptValue = result ? value.ToString() : input,
                _value = result ? value : (decimal?)null
            };

            return result;
        }

        public bool IsValid()
        {
            return _isValid;
        }

        public override string ToString()
        {
            return ToString(null);
        }

        public string ToString(string format)
        {
            return ToString(format, null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return _inptValue;
        }

        public override int GetHashCode()
        {
            return $"{_inptValue}:{GetType()}".GetHashCode();
        }

        public bool Equals(DecimalInput other)
        {
            return _inptValue == other._inptValue
                && _value == other._value;
        }

        public bool Equals(decimal other)
        {
            return _value == other;
        }

        public bool Equals([AllowNull] decimal? other)
        {
            return _value == other;
        }

        public bool Equals([AllowNull] string other)
        {
            return _inptValue == other;
        }

        public override bool Equals(object obj)
        {
            return (obj is null && _value is null)
                || (obj is DecimalInput typeA && Equals(typeA))
                || (obj is decimal typeB && Equals(typeB))
                || (obj is string typeC && Equals(typeC));
        }

        public static bool operator ==(DecimalInput left, DecimalInput right)
        {
            return (left is null && right is null) ||
                (left is DecimalInput l && right is DecimalInput r && l.Equals(r));
        }

        public static bool operator !=(DecimalInput left, DecimalInput right)
        {
            return !(left == right);
        }

        #region IConvertible implementation

        public TypeCode GetTypeCode()
        {
            return TypeCode.String;
        }

        /// <internalonly/>
        string IConvertible.ToString(IFormatProvider provider)
        {
            return _inptValue;
        }

        /// <internalonly/>
        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(_inptValue);
        }

        /// <internalonly/>
        char IConvertible.ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(_inptValue);
        }

        /// <internalonly/>
        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(_inptValue);
        }

        /// <internalonly/>
        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(_inptValue);
        }

        /// <internalonly/>
        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(_inptValue);
        }

        /// <internalonly/>
        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(_inptValue);
        }

        /// <internalonly/>
        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(_inptValue);
        }

        /// <internalonly/>
        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(_inptValue);
        }

        /// <internalonly/>
        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(_inptValue);
        }

        /// <internalonly/>
        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(_inptValue);
        }

        /// <internalonly/>
        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(_inptValue);
        }

        /// <internalonly/>
        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(_inptValue);
        }

        /// <internalonly/>
        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(_inptValue);
        }

        /// <internalonly/>
        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime(_inptValue);
        }

        /// <internalonly/>
        object IConvertible.ToType(System.Type type, IFormatProvider provider)
        {
            return Convert.ChangeType(this, type, provider);
        }

        #endregion
    }
}