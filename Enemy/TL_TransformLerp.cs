using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TL_TransformLerp : PlayableBehaviour
{
    public ExposedReference<GameObject> ObjectToMove;
    public bool byTransform;
    public ExposedReference<Transform> LerpMoveTo;
    public bool byValue;
    public Vector3 targetPos;
    public Vector3 targetRotation;
    public Vector3 targetScale;


    private GameObject _gameObject;
    private Transform _lerpMoveTo;

    private Vector3 _originalPosition;
    private Quaternion _originalRotation;
    private Vector3 _originalScale;

    public override void OnGraphStart(Playable playable)
    {
        _gameObject = ObjectToMove.Resolve(playable.GetGraph().GetResolver());
        _lerpMoveTo = LerpMoveTo.Resolve(playable.GetGraph().GetResolver());

    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if (playable.GetTime() <= 0)
            return;
        if (byTransform)
        {
            _gameObject.transform.position = Vector3.Lerp(_originalPosition, _lerpMoveTo.position, (float)(playable.GetTime() / playable.GetDuration()));
            _gameObject.transform.rotation = Quaternion.Lerp(_originalRotation, _lerpMoveTo.rotation, (float)(playable.GetTime() / playable.GetDuration()));
            _gameObject.transform.localScale = Vector3.Lerp(_originalScale, _lerpMoveTo.localScale, (float)(playable.GetTime() / playable.GetDuration()));
        }
        
        if (byValue)
        {
            _gameObject.transform.localPosition = Vector3.Lerp(_originalPosition, targetPos, (float)(playable.GetTime() / playable.GetDuration()));
            _gameObject.transform.localRotation = Quaternion.Lerp(_originalRotation, Quaternion.Euler(targetRotation), (float)(playable.GetTime() / playable.GetDuration()));
            _gameObject.transform.localScale = Vector3.Lerp(_originalScale, targetScale, (float)(playable.GetTime() / playable.GetDuration()));
        }
        
    }

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        if (_gameObject != null)
        {
            _originalPosition = _gameObject.transform.position;
            _originalRotation = _gameObject.transform.rotation;
            _originalScale = _gameObject.transform.localScale;
        }
    }
    public override void OnBehaviourPause(Playable playable, FrameData info) 
    {
        if (_gameObject != null)
        {
            _originalPosition = _gameObject.transform.position;
            _originalRotation = _gameObject.transform.rotation;
            _originalScale = _gameObject.transform.localScale;
        }
	}
}
