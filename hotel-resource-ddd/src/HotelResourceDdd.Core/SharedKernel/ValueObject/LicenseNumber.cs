namespace HotelResourceDdd.Core.SharedKernel.ValueObject
{
    public sealed record class LicenseNumber
    {
        public int Value { get; private set; }

        public LicenseNumber(int value)
        {
            this.Value = value;

            this.EnsureValidState();
        }

        /// <summary>
        /// Permette di controllare che l'oggetto in questione sia valido, così da assicurare lo stato di validità
        /// </summary>
        private void EnsureValidState()
        {
            if (this.Value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
