using System.Reflection;

namespace Crud_Dapper.Data
{
    public class BaseParametros<T> where T : class
    {
        public object ObterParametros(T obj)
        {
            var properties = obj.GetType().GetProperties();
            var parametros = new Dictionary<string, object>();

            foreach (var property in properties)
            {
                var propriedade = obj.GetType()?.GetProperty(property.Name)?.GetCustomAttribute<ColumnAttribute>()?.Name;
                var valor = obj.GetType().GetProperty(property.Name)?.GetValue(obj);

                if (propriedade != null && valor != null) parametros.Add(propriedade, valor);

            }
            return parametros;
        }
    }
}
