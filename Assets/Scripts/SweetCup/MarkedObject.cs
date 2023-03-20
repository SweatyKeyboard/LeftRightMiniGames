using UnityEngine;

public class MarkedObject : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private float _outlineWidth;
    [SerializeField] private float _trailWidth;

    private Outline _outline;
    private TrailRenderer _trail;

    public Color Color
    {
        get => _color;
        set => _color = value;
    }

    public float OutlineWidth
    {
        get => _outlineWidth;
        set => _outlineWidth = value;
    }

    public float TrailWidth
    {
        get => _trailWidth;
        set => _trailWidth = value;
    }

    public void Initialize()
    {
        CreateOutline();
        CreateTrail();
    }

    private void CreateOutline()
    {
        _outline = gameObject.AddComponent<Outline>();
        _outline.OutlineColor = _color;
        _outline.OutlineWidth = _outlineWidth;
        _outline.OutlineMode = Outline.Mode.OutlineVisible;
    }

    private void CreateTrail()
    {
        _trail = gameObject.GetComponent<TrailRenderer>();
        _trail.enabled = true;
        _trail.startColor = _color;
        _trail.startWidth = _trailWidth;
        _trail.endColor = _color;
        _trail.endWidth = 0;
        _trail.autodestruct = true;
        _trail.time = 0.5f;
    }
}
