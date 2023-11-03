namespace Data
{
    public interface IUnitOfWork : Base.IUnitOfWork
    {
        IApplicationRepository ApplicationRepository { get; }

    }
}
