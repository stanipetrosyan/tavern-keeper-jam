namespace UI{
    public class KitchenPopup : UiPopup{
        public override void Open() {
            gameObject.SetActive(true);
        }

        public override void Close() {
            gameObject.SetActive(false);
        }
    }
}