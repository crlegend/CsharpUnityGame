using UnityEngine;
using System.Collections;

public class Counter
{

    int counter = 0;
    bool c = FireBarCon.counter;
   
       
	
    public void CheckCounter()
    {
        if (c != FireBarCon.counter)
        {
            counter++;
            c = FireBarCon.counter;


        }
    }

    public int Count()
    {
        return (counter);
    }

    public void CountReset()
    {
        counter = 0;
    }


}
