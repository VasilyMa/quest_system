using UnityEngine;
using UnityEngine.UI;

public abstract class SourceSlot : MonoBehaviour
{
    protected Image _icon;
    protected Image _background;
    protected Animation _loading;
    protected SourceLayout _layout;
    protected Button _btnClick;
    public virtual SourceSlot Init(SourceLayout layout)
    {
        _layout = layout;
        _btnClick = gameObject.AddComponent<Button>();
        _btnClick.onClick.AddListener(OnClick);

        _icon = transform.GetChild(0).GetComponent<Image>();
        _icon.enabled = false;

        _background = GetComponent<Image>();

        _loading = GetComponentInChildren<Animation>();
        _loading?.Play();

        return this;
    }
    public virtual T GetSlot<T>() where T : SourceSlot
    {
        return this as T;
    }
    public abstract void OnClick();
    public abstract void UpdateView();
    public abstract void OnClose();
    public virtual void Dispose()
    {
        _btnClick?.onClick.RemoveListener(OnClick);
    }
}
