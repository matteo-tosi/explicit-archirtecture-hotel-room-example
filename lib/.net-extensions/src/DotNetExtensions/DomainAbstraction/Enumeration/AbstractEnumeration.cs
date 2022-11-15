using System.Reflection;

namespace DotNetExtensions.DomainAbstraction.Enumeration
{
    /// <summary>
    /// Classe base le enumerazioni
    /// </summary>
    /// <remarks>
    /// Non esiste una restrizione corretta per questo caso, ma quella che si avvicina di più è questa:
    /// Unmanaged: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/unmanaged-types</remarks>
    public abstract record class AbstractEnumeration<TEnumeration, TValue>
        where TEnumeration : AbstractEnumeration<TEnumeration, TValue>
        where TValue : unmanaged
    {
        public string Name { get; private set; }
        public TValue Value { get; private set; }

        private static readonly IEnumerable<TEnumeration> _enumerations = GetEnumerations();

        protected AbstractEnumeration(TValue value, string name)
        {
            this.Name = name;
            this.Value = value;

            this.EnsureValidState();
        }

        public static IEnumerable<TEnumeration> GetAll() => _enumerations;

        public static TEnumeration FromValue(TValue value)
            => Parse(value, description: "value", item => item.Value.Equals(value));

        public static TEnumeration Parse(string name)
            => Parse(name, description: "name", item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        public static bool TryParse(TValue value, out TEnumeration? result)
            => TryParse(x => x.Value.Equals(value), out result);

        public static bool TryParse(string name, out TEnumeration? result)
            => TryParse(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase), out result);

        public override sealed string ToString() => this.Name;

        public virtual bool Equals(AbstractEnumeration<TEnumeration, TValue>? other)
            => other != null && other.Value.Equals(this.Value);

        public override int GetHashCode() => this.Value.GetHashCode();

        private static TEnumeration Parse(object value, string description, Func<TEnumeration, bool> predicate)
        {
            if (!TryParse(predicate, out var result))
            {
                throw new ArgumentException($"'{value}' is not a valid {description} in {typeof(TEnumeration)}", nameof(value));
            }

            return result;
        }

        private static bool TryParse(Func<TEnumeration, bool> predicate, out TEnumeration? result)
        {
            result = GetAll().FirstOrDefault(predicate);

            return result != null;
        }

        private static IEnumerable<TEnumeration> GetEnumerations()
        {
            var enumerationType = typeof(TEnumeration);

            return enumerationType
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(info => enumerationType.IsAssignableFrom(info.FieldType))
                .Select(info => info.GetValue(null))
                .Cast<TEnumeration>();
        }

        /// <summary>
        /// Permette di controllare che l'oggetto in questione sia valido, così da assicurare lo stato di validità
        /// </summary>
        private void EnsureValidState()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                throw new ArgumentNullException();
            }

            if (!_enumerations.Any())
            {
                throw new ArgumentNullException();
            }

            // Se vengono dichiarati due valori uguali deve dare errore
            if (_enumerations.Where(e => e != null && e == this)
                .Any())
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
