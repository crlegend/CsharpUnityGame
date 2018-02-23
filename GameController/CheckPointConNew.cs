using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointConNew : CheckPointCon {

    public override void SetRoute()
    {
        checkPointData[checkPointNum].route.GetComponent<RouteController>().wayPointNumber = checkPointData[checkPointNum].routeNum;

        checkPointData[checkPointNum].route.GetComponent<RouteController>().ContinueGoing(true);
        checkPointData[checkPointNum].route.GetComponent<RouteController>().MoveToNumPos(checkPointData[checkPointNum].routeNum);
    }


}
