using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class TavernManager : MonoBehaviour, IGameManager {

    public int level = 1;
    public TextMeshProUGUI levelText;
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

}
