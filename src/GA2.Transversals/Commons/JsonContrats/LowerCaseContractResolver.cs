using Newtonsoft.Json.Serialization;

namespace GA2.Transversals.Commons
{
    /// <summary>
    /// Lowercase contract 
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>23/8/2021</date>
    public class LowerCaseContractResolverpublic :DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.Substring(0, 1).ToLower() + propertyName.Substring(1, propertyName.Length-1);
        }
    }
}
