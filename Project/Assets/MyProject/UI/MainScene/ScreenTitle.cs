namespace Project.UI
{
    public class ScreenTitle : UIView
    {
        public void OnPressedSettingButton()
        {
            _ownerController.ShowView<ScreenSetting>();
        }
    }
}