using Port;
using TMPro;
using UnityEngine;

namespace Manager{
    public class TavernManager : MonoBehaviour, IGameManager {

        public int level = 1;
        public int money = 0;
        public ManagerStatus Status { get; set; }

        public void Startup() {
            Status = ManagerStatus.Started;
        }

        public void LevelUpTavern() {
            level++;
        }

        public int GetTavernLevel() {
            return level;
        }

        public void AddMoney(int amount){
            money += amount;
        }

        public bool RemoveMoney(int amount){
            if (money - amount > 0) {
                money -= amount;
                return true;
            }

            return false;
        }

        public int GetMoney() {
            return money;
        }
    
    }
}
