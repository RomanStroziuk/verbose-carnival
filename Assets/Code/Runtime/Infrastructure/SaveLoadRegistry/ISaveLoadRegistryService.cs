 using System.Collections.Generic;
using Code.Runtime.Infrastructure.SaveLoad;

namespace Code.Runtime.Infrastructure.SaveLoadRegistry
{
    public interface ISaveLoadRegistryService
    {
        IReadOnlyList<IReadProgress> ProgressReaders { get; }
        IReadOnlyList<IWriteProgress> ProgressWriter { get; }
        void RegisterAsProgressReader(IReadProgress progressReader);
        void RegisterAsProgressWriter(IWriteProgress progressWriter);
    }
}