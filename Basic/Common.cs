using UnityEngine;
using System.Collections;

[System.Serializable]
public class Common {


    public Transform gameCon;
    
    

    public float CalDegree(Vector3 targetPos, Vector3 originalPos)
    {
        Vector3 direction = originalPos-targetPos;
        float angle = Mathf.Atan2(direction.z, direction.x);
        float degree = angle * Mathf.Rad2Deg;
        return (degree);
    }

    public Transform[] CalDistance(Vector3 cen)
    {
        gameCon = GameObject.Find("GameCon").transform;
        Transform[] skp = gameCon.GetComponentsInChildren<Transform>();

        float[] sort = new float[skp.Length];
        Transform[] sorted = new Transform[skp.Length];
        float[] dis = new float[skp.Length];
       

        for (int i = 0; i < skp.Length; i++)
        {
            
            dis[i] = Vector3.Distance(cen, skp[i].position);
            sort[i] = dis[i];



        }       

        System.Array.Sort(sort);

        for (int i = 0; i < skp.Length; i++)
        {
            sorted[i] = skp[System.Array.IndexOf(dis, sort[i])];

            //Debug.Log(System.Array.IndexOf(dis, sort[i]));
        }
        return (sorted);  //find the index of the Min distance and return the transform!!!!         

    }

    public Transform CalShortestDistance(Vector3 cen)
    {
        gameCon = GameObject.Find("GameCon").transform;

        Transform[] skp = gameCon.FindTransformsWithTag("SkillPos");//only return activate object
        float[] dis = new float[skp.Length];
        for (int i = 0; i < skp.Length; i++)
        {            
            dis[i] = Vector3.Distance(cen, skp[i].position);
        }


        return (skp[System.Array.IndexOf(dis, Mathf.Min(dis))]);  //find the index of the Min distance and return the transform!!!!         

    }

    public Transform CalDistanceImproved(Vector3 cen)
    {

        GameObject[] g = GameObject.FindGameObjectsWithTag("Enemy");


        float[] dis = new float[g.Length];

        for (int i = 1; i <= g.Length; i++)
        {
            dis[i - 1] = Vector3.Distance(cen, g[i - 1].transform.position);
        }
        return (g[System.Array.IndexOf(dis, Mathf.Min(dis))].transform);

    }

    public void ReduceRange(Transform range)
    {
        range.position = Vector3.zero;
        range.localScale = Vector3.zero;
    }

    public Vector3 RandomPosition(Camera cam)
    {
        float x = Random.Range(0f, cam.pixelWidth);
        float y = Random.Range(0f, cam.pixelHeight);
        return(cam.ScreenToWorldPoint(new Vector3(x, y, 20f)));
    }

    public Vector3 RandomPositionOutside(Camera cam)
    {
        float x,y;
        int t =0;
        while (t < 3 && t > -3)
        {
            t = Random.Range(-6, 6);
        }

        float bigT = t * 100;
        if (t > 0)
        {
            x = cam.pixelWidth + bigT;
        }
        else
        {
            x = 0 + bigT;
        }

        t = Random.Range(-10, 10);

        if (t > 0)
        {
            y = cam.pixelHeight + bigT;
        }
        else
        {
            y = 0 + bigT;
        }
        return (cam.ScreenToWorldPoint(new Vector3(x, y, 20f)));
    }

    public void SwitchCamera(Camera cam)
    {
        Camera[] oldCam = Camera.allCameras;
        for (int i =0;i<oldCam.Length;i++)
        {
            oldCam[i].enabled = false;
            oldCam[i].gameObject.tag = "DeactiveCamera";
        }
        cam.enabled = true;
        cam.gameObject.tag = "MainCamera";

    }

    public GameObject[] GetAllChildren(Transform gObject)
    {
        GameObject[] members = new GameObject[gObject.childCount];

        for (int i = 0; i< gObject.childCount; i++)
        {
            members[i] = gObject.GetChild(i).gameObject;
        }
        
        return (members);
    }

    public GameObject[] GetChildrenWithTag(Transform gObject, string tag)
    {
        int tagCount = 0;
        int memberCount = 0;

        for (int i = 0; i < gObject.childCount; i++)
        {
            if (gObject.GetChild(i).tag == tag)
            {
                tagCount++;
            }
        }
        GameObject[] members = new GameObject[tagCount];

        for (int i = 0; i < gObject.childCount; i++)
        {
            if (gObject.GetChild(i).tag == tag)
            {
                members[memberCount] = gObject.GetChild(i).gameObject;
                memberCount++; 
            }
        }

        return (members);
    }

    
}