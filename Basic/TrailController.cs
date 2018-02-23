using UnityEngine;
using System.Collections;

public class TrailController : MonoBehaviour {

    public static Vector3 startPos;
    public static Vector3 endPos;

    
    public LayerMask skillDetectLayer;

    private bool mDown = false;
    


    private V2toV3 vtv;

    

    

	void Start()
	{
        GetComponent<TrailRenderer>().sortingLayerName = "UI";
        GetComponent<TrailRenderer>().sortingOrder = 4;
        vtv = new V2toV3();
       
	}

	void Update () 
	{
        transform.position = vtv.V3Normalize(Camera.main.ScreenToWorldPoint(InputManager.MTPosition()), 1000f);


        if (SkillCaster.readable)
		{

            

            if (InputManager.MTRightButtonDown())
			{
                
                //startPos = gamMan.ScreenWorldPosition(InputManager.MTPosition(), skillDetectLayer, 100f);

                /*Ray camRay = Camera.main.ScreenPointToRay (InputManager.MTPosition());
                RaycastHit floorHit;
                if (Physics.Raycast(camRay, out floorHit, 100f, floorMask))
                {
                    startPos = vtv.V3Normalize(floorHit.point);
                }*/

                //startPos =vtv.V3Normalize(Camera.main.ScreenToWorldPoint(InputManager.MTPosition()), 1f);
               
				mDown = true;

                //DrawTrail(); // make sure transform.position is renewed!

                startPos = vtv.V3Normalize(Camera.main.ScreenToWorldPoint(InputManager.MTPosition()), 1f);
               


			}

			else if (InputManager.MTRightButtonUp())
			{
                

                //endPos = gamMan.ScreenWorldPosition(InputManager.MTPosition(), skillDetectLayer, 100f);

                //endPos = vtv.V3Normalize(Camera.main.ScreenToWorldPoint(InputManager.MTPosition()), 1f);
               

                mDown = false;
                endPos = vtv.V3Normalize(Camera.main.ScreenToWorldPoint(InputManager.MTPosition()), 1f);
               


            }			

		}
		else
		{
			mDown = false;
		}
	}

    void LateUpdate()
    {
        if (mDown)
        {

            DrawTrail();
        }
    }


	void DrawTrail()
	{


        transform.position = vtv.V3Normalize(Camera.main.ScreenToWorldPoint(InputManager.MTPosition()), 20f);

       
        
	}

    


}