using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    int ran = 0; //collected number
    void Start()
    {
        Animator anim=GetComponent<Animator>();
        ran = Random.Range(0,3);
        anim.SetInteger("STATE",ran);
    }
}
