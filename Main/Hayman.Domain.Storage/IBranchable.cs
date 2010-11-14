using System;

namespace Hayman.Domain.Storage
{
    public interface IBranchable
    {
        Guid GetBranchId();
        Guid GetBranchedOnEventSourceId();
    }
}
