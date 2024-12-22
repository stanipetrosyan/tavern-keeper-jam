using UnityEngine;
using UnityEngine.UI;

namespace UI{
    public class ProgressBarUI: MonoBehaviour{
        
        [SerializeField] private Image barImage;
        private float cookingTimer = 0f;
        private float cookingTime = 0f;
        private bool isCooking = false;

        public void StartProgression(int timeToCook) {
            Show();
            cookingTimer = 0f;
            cookingTime = timeToCook;
            isCooking = true;
        }

        private void Update() {
            if (cookingTime != 0) {
                cookingTimer += Time.deltaTime;

                barImage.fillAmount = cookingTimer / cookingTime;
            }

            if (cookingTimer >= cookingTime && isCooking) {
                cookingTime = 0;
                barImage.fillAmount = 0;
                isCooking = false;
                Hide();
            }
            
        }

        private void Start() {
            barImage.fillAmount = 0f;

            Hide();
        }

        public void Show() {
            gameObject.SetActive(true);
        }

        public void Hide() {
            gameObject.SetActive(false);
        }
    }
}