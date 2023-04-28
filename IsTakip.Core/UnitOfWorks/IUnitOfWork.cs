namespace IsTakip.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        void Commit();

        Task CommitAsync();
    }
}
