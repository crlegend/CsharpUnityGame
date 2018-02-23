using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class DestroyGameObject : PlayableBehaviour
{
    
    public ExposedReference<GameObject> ObjectToDestroy;

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        
            GameObject.Destroy(ObjectToDestroy.Resolve(playable.GetGraph().GetResolver()));
        
        
    }
}
