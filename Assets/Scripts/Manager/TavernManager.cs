using System.Collections.Generic;
using Port;
using TMPro;
using UnityEngine;

namespace Manager{
    public class TavernManager : MonoBehaviour, IGameManager {

        public int level = 1;
        public int money = 0;
        
        [SerializeField] private GameObject chairsParent;
        [SerializeField] private Transform[] chairs;
        private readonly List<Transform> _occupiedChairs = new();
        public ManagerStatus Status { get; set; }

        public void Startup() {
            Status = ManagerStatus.Started;
        }

        public void LevelUpTavern() {
            if (RemoveMoney(GetLevelUpCost())) {
                level++;
            }
        }

        public int GetTavernLevel() {
            return level;
        }

        public void AddMoney(int amount){
            money += amount;
        }

        public bool RemoveMoney(int amount){
            if (money - amount <= 0) return false;
            
            money -= amount;
            return true;

        }

        public int GetMoney() {
            return money;
        }

        public int GetLevelUpCost() {
            switch (level) {
                case 1 : return 100;
                case 2 : return 200;
                case 3 : return 300;
                default: return 0;
            }
        }

        public Transform[] GetChairs() {
            return chairs;
        }

        public bool ChairIsFree(Transform chair) {
            return !_occupiedChairs.Contains(chair);
        }

        public void OccupyChair(Transform chair) {
            _occupiedChairs.Add(chair);
        }

        public void FreeChair(Transform chair) {
            _occupiedChairs.Remove(chair);
        }
    }
}
