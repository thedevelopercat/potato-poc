namespace Potato.Domain.Models
{
    public sealed class Vegetable
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = null!;

        private Vegetable()
        {

        }

        internal static Vegetable Create(string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(name);

            return new Vegetable
            {
                Id = 0,
                Name = name
            };
        }
    }
}
