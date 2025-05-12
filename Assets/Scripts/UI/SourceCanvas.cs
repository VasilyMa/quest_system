using System.Collections.Generic;

using UnityEngine;

public abstract class SourceCanvas : MonoBehaviour
{
    protected Canvas _canvas;
    protected List<SourcePanel> _panels;
    public bool isInited { get; protected set; }

    public bool IsOpenOnStart;

    public virtual void Init()
    {
        _canvas = GetComponent<Canvas>();

        _panels = new List<SourcePanel>();

        var panels = GetComponentsInChildren<SourcePanel>();

        foreach (var panel in panels) _panels.Add(panel);

        _panels.ForEach(panel => panel.Init(this));

        _canvas.enabled = IsOpenOnStart;

        isInited = true;
    }
    public virtual void InvokeCanvas()
    {
        _canvas.enabled = true;
    }
    public virtual void CloseCanvas()
    {
        _canvas.enabled = false;

        _panels.ForEach(panel => panel.OnCLose());
    }
    public virtual void Dispose()
    {
        _panels.ForEach(panel => panel.OnDipose());

    }

    public virtual T ClosePanel<T>() where T : SourcePanel
    {
        SourcePanel returnedPanel = null;

        foreach (var sourcePanel in _panels)
        {
            if (sourcePanel.isAlwaysOpen)
            {
                sourcePanel.OnOpen();
                continue;
            }

            if (sourcePanel is T panel)
            {
                returnedPanel = panel;
            }
        }

        returnedPanel.OnCLose();

        return returnedPanel as T;
    }

    public virtual T OpenPanel<T>() where T : SourcePanel
    {
        SourcePanel returnedPanel = null;

        foreach (var sourcePanel in _panels)
        {
            if (sourcePanel.isAlwaysOpen)
            {
                sourcePanel.OnOpen();
                continue;
            }

            if (sourcePanel is T panel)
            {
                returnedPanel = panel;
            }
            else
            {
                sourcePanel.OnCLose();
            }
        }

        returnedPanel.OnOpen();

        return returnedPanel as T;
    }
    public virtual T GetPanel<T>() where T : SourcePanel
    {
        SourcePanel returnedPanel = null;

        foreach (var sourcePanel in _panels)
        {
            if (sourcePanel is T panel)
            {
                returnedPanel = panel;
            }
        }

        return returnedPanel as T;
    }
}
