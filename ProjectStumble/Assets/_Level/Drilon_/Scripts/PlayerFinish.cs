using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinish : MonoBehaviour
{
   [SerializeField] private GameObject _conffeti;
    //private ParticleSystem _finishParticles;
    private int count;

   public void PlayFinishVFX()
   {
       if (count >= 1) return;
       Instantiate(_conffeti,transform.position,transform.rotation);
       count++;


   }
}
