using TMPro;
using UI;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class TavernStatsPopup : UiPopup
{
    public override void Open() {
        gameObject.SetActive(true);
    }

    public override void Close() {
        gameObject.SetActive(false);
    }
}
