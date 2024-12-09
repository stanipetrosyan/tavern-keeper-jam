using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class TavernManager : MonoBehaviour, IGameManager {

    public int level = 1;
    public int money = 0;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI moneyText;
    public ManagerStatus Status { get; set; }

    public void Startup() {
        Status = ManagerStatus.Started;
    }

    public void LevelUpTavern() {
        level++;
        UpdateLevelText();
    }

    public void UpdateLevelText() {
        levelText.text = $"Level = {level}";
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

    public void UpdateMoneyText() {
        moneyText.text = $"${money}";
    }
    
    
}
