using Manager;

namespace Port{
    public interface IGameManager {
        ManagerStatus Status {get; set;}

        void Startup();
    }
}