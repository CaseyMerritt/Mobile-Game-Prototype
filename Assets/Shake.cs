using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Shake : MonoBehaviour {

    public void Shaker(float magn, float roughness, float fin, float fout) {

        CameraShaker.Instance.ShakeOnce(magn, roughness, fin, fout);

    }
}
