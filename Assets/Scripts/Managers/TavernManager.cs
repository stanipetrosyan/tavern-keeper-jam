using UnityEngine;

public class TavernManager : MonoBehaviour, IGameManager {
    public ManagerStatus Status { get; set; }
    public void Startup() {
        Status = ManagerStatus.Started;
    }
}
