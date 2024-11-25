using System.Collections.Generic;
using Code.Runtime.Infrastructure.SaveLoad;

namespace Code.Runtime.Infrastructure.SaveLoadRegistry
{
    internal sealed  class SaveLoadRegistryService : ISaveLoadRegistryService
    {
        private readonly List<IReadProgress> _progressReaders = new();
        private readonly List<IWriteProgress> _progressWriter = new();

        public IReadOnlyList<IReadProgress> ProgressReaders => _progressReaders;

        public IReadOnlyList<IWriteProgress> ProgressWriter => _progressWriter;

        public void RegisterAsProgressReader(IReadProgress progressReader)
        {
            _progressReaders.Add(progressReader);
        }
        
        public void RegisterAsProgressWriter(IWriteProgress progressWriter)
        {
            _progressWriter.Add(progressWriter);
        }
    }
}