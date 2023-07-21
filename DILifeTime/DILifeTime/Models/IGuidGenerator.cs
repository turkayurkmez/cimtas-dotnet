namespace DILifeTime.Models
{
    public interface IGuidGenerator
    {
        Guid Guid { get; }
    }
    public interface ISingletonGuid : IGuidGenerator
    {

    }

    public interface ITransientGuid : IGuidGenerator { }
    public interface IScopedGuid : IGuidGenerator { }


    public class SingletonGuid : ISingletonGuid
    {
        public SingletonGuid()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }
    }

    public class TransientGuid : ITransientGuid
    {
        public TransientGuid()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }
    }

    public class ScopedGuid : IScopedGuid
    {
        public ScopedGuid()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }
    }

    public class GuidService
    {
        public ISingletonGuid Singleton { get; set; }
        public ITransientGuid Transient { get; set; }
        public IScopedGuid ScopedGuid { get; set; }

        public GuidService(ISingletonGuid singleton, ITransientGuid transient, IScopedGuid scopedGuid)
        {
            Singleton = singleton;
            Transient = transient;
            ScopedGuid = scopedGuid;
        }
    }
}
