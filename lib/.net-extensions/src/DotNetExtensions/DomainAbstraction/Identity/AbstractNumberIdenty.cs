namespace DotNetExtensions.DomainAbstraction.Identity
{
    /// <summary>
    /// Classe base per gli id che sono numerici
    /// </summary>
    /// <remarks>
    /// Non esiste una restrizione corretta per questo caso, ma quella che si avvicina di più è questa:
    /// Unmanaged: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/unmanaged-types</remarks>
    public abstract record class AbstractNumberIdenty<TKey> where TKey : unmanaged
    {
        public TKey Value { get; protected set; }

        public AbstractNumberIdenty(TKey value)
        {
            this.Value = value;

            this.EnsureValidState();
        }

        /// <summary>
        /// Permette di controllare che l'oggetto in questione sia valido, così da assicurare lo stato di validità
        /// </summary>
        private void EnsureValidState()
        {
            switch (this.Value)
            {
                case short value:
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    break;

                case int value:
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    break;

                case long value:
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    break;

                // Tutti gli altri tipi non sono supportati
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
