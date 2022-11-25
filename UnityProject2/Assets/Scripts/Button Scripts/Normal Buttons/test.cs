using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : DefaultButton
{
    void Update()
    {
        base.Update();
        if(triggered){
            doThis();
        }
    }

    void doThis(){
        
    }
}
