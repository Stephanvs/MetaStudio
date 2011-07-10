using System;

namespace Hayman.Ncqrs.Domain.Storage
{
    public interface IBranchable
    {
        Guid GetBranchId();
        Guid GetBranchedOnEventSourceId();
    }
}
