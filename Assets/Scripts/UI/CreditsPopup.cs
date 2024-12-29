using System;

namespace UI{
    public class CreditsPopup: UiPopup {

        public override void Open() {
            gameObject.SetActive(true);
        }

        public override void Close() {
            gameObject.SetActive(false);
        }
    }
}