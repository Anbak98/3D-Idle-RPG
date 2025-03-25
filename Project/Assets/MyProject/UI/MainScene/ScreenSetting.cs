namespace Project.UI
{
    public class ScreenSetting : UIView
    {
        public void OnPressedExitButton()
        {
            _ownerController.ShowView<ScreenTitle>();
        }
    }
}