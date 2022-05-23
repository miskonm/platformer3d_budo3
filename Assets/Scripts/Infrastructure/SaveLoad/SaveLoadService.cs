using Platformer.Game.Services.Factory;
using Platformer.Infrastructure.Persistent;
using Platformer.Infrastructure.Persistent.Data;
using Platformer.Infrastructure.SaveLoad.IO;

namespace Platformer.Infrastructure.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string PersistentData = "PersistentDataKey";
        
        private readonly ISaveLoadIO _saveLoadIO;
        private readonly IPersistentService _persistentService;
        private readonly IGameFactory _gameFactory;

        public SaveLoadService(ISaveLoadIO saveLoadIO, IPersistentService persistentService, IGameFactory gameFactory)
        {
            _saveLoadIO = saveLoadIO;
            _persistentService = persistentService;
            _gameFactory = gameFactory;
        }

        public PersistentData Load()
        {
            PersistentData persistentData = _saveLoadIO.Read<PersistentData>(PersistentData);
            return persistentData ?? new PersistentData();
        }

        public void Save()
        {
            foreach (ISaveLoadWriter saveLoadWriter in _gameFactory.Writers)
                saveLoadWriter.Save(_persistentService.Data);

            _saveLoadIO.Write(_persistentService.Data, PersistentData);
        }
    }
}