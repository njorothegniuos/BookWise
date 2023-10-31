namespace Domain.Common
{
    public abstract class Entity
    {
        protected Entity(Guid id) => Id = id;

        protected Entity()
        {
        }

        public Guid Id { get; protected set; }

        public byte RecordStatus { get; set; }
        public DateTime createdAt { get; set; }
    }
}
