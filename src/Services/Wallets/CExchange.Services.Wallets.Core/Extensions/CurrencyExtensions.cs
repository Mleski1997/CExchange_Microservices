using CExchange.Services.Wallets.Core.Attributes;
using System.Reflection;

namespace CExchange.Services.Wallets.Core.Extensions
{
    internal static class CurrencyExtensions
    {
        public static string GetSymbol<TEnum>(this TEnum currencyName) where TEnum : Enum
        {
            FieldInfo fieldinfo = currencyName.GetType().GetField(currencyName.ToString());
            CurrencySymbolAttribute attribute = fieldinfo.GetCustomAttribute<CurrencySymbolAttribute>();

            if(attribute is null)
            {
                throw new InvalidOperationException();
            }

            return attribute.Symbol;
          
        }


    }
}
