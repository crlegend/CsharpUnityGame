using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Gesture : MonoBehaviour
{
    static GameObject gestureDrawing;
    public static GameObject GuiText;
    GestureTemplates m_Templates;
	public static string sendGesture;
    public static Vector3 cen;

    ArrayList pointArr;

    List<Vector2> v;
    static int mouseDown;
    private V2toV3 v2v = new V2toV3();


    //public GameObject tr;

    // runs when game starts - main function
    void Start ()
    {
        m_Templates = new GestureTemplates();
	    pointArr = new ArrayList();
        v = new List<Vector2>();
    	
	    gestureDrawing = GameObject.Find("Trail");
	    GuiText = GameObject.Find("GUIText");

        GuiText.GetComponent<Text>().text = "Templates loaded: " + GestureTemplates.Templates.Count;
        //GuiText = GuiText.GetComponent<GUIText>().text + "\n Templates loaded: " + GestureTemplates.Templates.Count;

    }


    IEnumerator worldToScreenCoordinates ()
    {
	    // fix world coordinate to the viewport coordinate
	    Vector3 screenSpace = Camera.main.WorldToScreenPoint(gestureDrawing.transform.position);
    	
	    while (Input.GetMouseButton(1))
	    {
		    Vector3 curScreenSpace = new Vector3(InputManager.MTPosition().x, InputManager.MTPosition().y, screenSpace.z);
		    Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace); 
		    gestureDrawing.transform.position = curPosition;
		    yield return 0;
	    }
    }

    void Update()
    {
		
		if (SkillCaster.readable)
		{
			
			if (InputManager.MTRightButtonDown())
			{
				
				mouseDown = 1;

                //Vector2 p = Camera.main.ScreenToWorldPoint(new Vector2(InputManager.MTPosition().x, InputManager.MTPosition().y));
                //Instantiate(tr, p, Quaternion.identity);
			}
	    	
			if (mouseDown == 1)
			{
				Vector2 p = new Vector2(InputManager.MTPosition().x, InputManager.MTPosition().y);
				pointArr.Add(p);
                v.Add(p);

				StartCoroutine(worldToScreenCoordinates());
			}


			if (InputManager.MTRightButtonUp())
			{
				if (Input.GetKey(KeyCode.LeftControl))
				{
					// if CTRL is held down, the script will record a gesture. 
					mouseDown = 0;
					GestureRecognizer.recordTemplate(pointArr);
	    		
				}
				else
				{
					mouseDown = 0;

					// start recognizing! 
					GestureRecognizer.startRecognizer(pointArr);



					pointArr.Clear();

                    CalCenter(v);
                    v.Clear();
					sendGesture = GestureRecognizer.skillSendOut;
	    		
				}
	    	
			}
		}
		else
		{
			mouseDown = 0;
		}
    } 

    void OnGUI ()
    {
	    if(GestureRecognizer.recordDone == 1)
        { 
		    GUI.Window (0, new Rect (10, 10, 300, 100), DoMyWindow, "Save the template?");
	    }
    }

    void DoMyWindow (int windowID)
    {
        GestureRecognizer.stringToEdit = GUILayout.TextField(GestureRecognizer.stringToEdit);

        if (GUI.Button (new Rect (20,50,50,20), "Save"))
        {
            ArrayList temp = new ArrayList();
            ArrayList a = (ArrayList)GestureTemplates.Templates[GestureTemplates.Templates.Count - 1];

            for (int i = 0; i < GestureRecognizer.newTemplateArr.Count; i++)
                temp.Add(GestureRecognizer.newTemplateArr[i]);

            GestureTemplates.Templates.Add(temp);
            GestureTemplates.TemplateNames.Add(GestureRecognizer.stringToEdit);
            GestureRecognizer.recordDone = 0;
            GestureRecognizer.newTemplateArr.Clear();

            GuiText.GetComponent<GUIText>().text = "TEMPLATE: " + GestureRecognizer.stringToEdit + "\n STATUS: SAVED";
	    }

	    if (GUI.Button (new Rect (150,50,50,20), "Cancel")) 
        {
            GestureRecognizer.recordDone = 0;
	       GuiText.GetComponent<GUIText>().text = "";
	    }
    }

    void CalCenter(List<Vector2> v)
    {
        Vector2 max, min;
        max = v[0];
        min = v[0];


        for (int i = 1; i < v.Count; i++)
        {
            max = Vector2.Max(max, v[i]);
            min = Vector2.Min(min, v[i]);
        }
        cen = v2v.V3Normalize(Camera.main.ScreenToWorldPoint((max+min)/2), 1f);

        //Debug.Log(cen);


    }
}
