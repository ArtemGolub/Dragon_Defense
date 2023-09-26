using UnityEngine;

public class ParabolaMovement
{
    private Transform target;
    private Vector3 startPos;
    private Vector3 endPos;
    private float height;
    private float duration;
    private float startTime;
    private bool isMoving = false;
    
    public delegate void OnCompleteDelegate();
    public event OnCompleteDelegate OnComplete;

    public ParabolaMovement(Transform _target, Vector3 _endPos, float _height, float _duration)
    {
        target = _target;
        startPos = _target.localPosition;
        endPos = _endPos;
        height = _height;
        duration = _duration;
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    public void StartMovement()
    {
        if (!isMoving)
        {
            startPos = target.localPosition;
            startTime = Time.time;
            isMoving = true;
        }
    }

    public void UpdateMovement()
    {
        if (isMoving)
        {
            float t = (Time.time - startTime) / duration;

            if (t >= 1.0f)
            {
                target.localPosition = endPos;
                OnComplete?.Invoke();
                isMoving = false;
            }
            else
            {
                Vector3 currentPos = CalculateBezierPoint(startPos, endPos, height, t);
                target.localPosition = currentPos;
            }
        }
    }
    
    private Vector3 CalculateBezierPoint(Vector3 start, Vector3 end, float height, float t)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = uu * start;
        p += 2 * u * t * (start + (end - start) * 0.5f + Vector3.up * height);
        p += tt * end;

        return p;
    }
}
