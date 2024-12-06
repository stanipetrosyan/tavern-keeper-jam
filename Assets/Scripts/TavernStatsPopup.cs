using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class TavernStatsPopup : MonoBehaviour
{
    public void Open() {
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
    }
}
