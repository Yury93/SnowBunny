using UnityEngine;

public class TapToScreen : SingletonBase<TapToScreen>
{
    public delegate void ClickToScreen();
    public event ClickToScreen OnTap;

    public void OnClick()
    {
        OnTap();
    }
}
