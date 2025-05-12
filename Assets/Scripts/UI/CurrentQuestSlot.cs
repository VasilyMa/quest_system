using DG.Tweening;

using UnityEngine;
using UnityEngine.UI;

public class CurrentQuestSlot : SourceSlot
{
    [SerializeField] Text _description;
    [SerializeField] Image _sliderValue;
    public SourceQuest Data;
    private Tweener _currentTween;

    public override SourceSlot Init(SourceLayout layout)
    {
        base.Init(layout);
        _btnClick.interactable = false;
        gameObject.SetActive(false);
        return this;
    }

    public override void OnClick()
    {
        //todo something
    }

    public override void UpdateView()
    {
        if (Data != null)
        {
            gameObject.SetActive(true);

            Data.OnProgressChanged += onProgressChange;
            Data.OnCompleted += onComplete;

            _sliderValue.fillAmount = Data.CurrentProgress;
            _icon.enabled = true;
            _icon.sprite = Data.Icon;

            _description.text = $"{Data.Description} осталось {Data.Progress}/{Data.TargetProgress}";

            if (Data.IsCompleted)
            {
                onComplete();
            }

        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public override void OnClose()
    {
        Data.OnProgressChanged -= onProgressChange;
        Data = null;
    }

    void onComplete()
    {
        var ui = ConfigModule.GetConfig<InterfaceConfig>();
        _description.text = $"Завершено";
        _sliderValue.sprite = ui.CompleteSliderIcon;
        _sliderValue.fillAmount = 1f;
    }

    void onProgressChange()
    {
        float value = Data.CurrentProgress;

        FillAnimation(value);

        _description.text = $"{Data.Description} осталось {Data.Progress}/{Data.TargetProgress}";
    }

    public void FillAnimation(float value)
    {
        // Если анимация уже идет - убиваем её
        if (_currentTween != null && _currentTween.IsActive())
        {
            _currentTween.Kill();
        }

        _currentTween = _sliderValue.DOFillAmount(value, 0.15f)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                _currentTween = null; // Обнуляем ссылку
            });
    }
}
