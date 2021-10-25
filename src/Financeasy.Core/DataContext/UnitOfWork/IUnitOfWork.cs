using System;

namespace Financeasy.Core
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}