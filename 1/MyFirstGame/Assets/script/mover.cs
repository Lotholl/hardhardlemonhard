using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class mover: MonoBehaviour {
  public Vector3 direction;
  public float x = 0;
  public float y = 0;
  public float z = 0;
  public static int framesCount = 25;
  public string clipName = "anim1";
  public static float AnimationTime = 3;
  public static float lineLength = 2f;
  public static float lineScaleX = 5f;
  public static float lineScaleY = 5f;
  public static float lineScaleZ = 5f;
  public static float frequency = 1f;

  public static float sineWave = Mathf.PI * lineLength;
  public static float angleOffset = sineWave / (framesCount - 1);

  float moveX(float angle, float scale, float time) {
    x = scale * Mathf.Cos(angle + time * frequency) * lineScaleX;
    return x;
  }

  float moveY(float angle, float scale, float time) {
    y = scale * Mathf.Sin(2 * (angle + time * frequency)) / 2 * lineScaleY;
    return y;
  }

  float moveZ(float angle, float scale, float time) {
    z = Mathf.Cos(angle) * lineScaleZ;
    return z;
  }

  Keyframe[] keysX = new Keyframe[framesCount];
  Keyframe[] keysY = new Keyframe[framesCount];
  Keyframe[] keysZ = new Keyframe[framesCount];
  AnimationCurve curveX;
  AnimationCurve curveY;
  AnimationCurve curveZ;
  // create a new AnimationClip
  AnimationClip clip;
  Animation anim;

  
  // Start is called before the first frame update
  void Start() {
    anim = GetComponent < Animation > ();
    clip = new AnimationClip();
    clip.legacy = true;
	clip.name = clipName;
	
    for (int i = framesCount; i-->0;) {
      float t = Mathf.Lerp(0,AnimationTime, i/framesCount);
      float angle = angleOffset * i;
      float scale = 2 / (3 - Mathf.Cos(2 * (angle + t * frequency)));
      keysX[i] = (new Keyframe(AnimationTime/framesCount*i, moveX(angle, scale, t)));
      keysY[i] = (new Keyframe(AnimationTime/framesCount*i, moveY(angle, scale, t)));
      keysZ[i] = (new Keyframe(AnimationTime/framesCount*i, moveZ(angle, scale, t)));
    }
    curveX = new AnimationCurve(keysX);
    curveY = new AnimationCurve(keysY);
    curveZ = new AnimationCurve(keysZ);
    clip.SetCurve("", typeof(Transform), "localPosition.x", curveX);
    clip.SetCurve("", typeof(Transform), "localPosition.y", curveY);
    clip.SetCurve("", typeof(Transform), "localPosition.z", curveZ);
    anim.AddClip(clip, clipName);
  }

  void FixedUpdate() {

    //manual
    if (Input.GetKey(KeyCode.DownArrow)) {
      for (int i = framesCount; i-->0;) {
        float t = Time.time;
        float angle = angleOffset * i;
        float scale = 2 / (3 - Mathf.Cos(2 * (angle + t * frequency)));
        transform.position = new Vector3(moveX(angle, scale, t), moveY(angle, scale, t), moveZ(angle, scale, t));
      }
    }

    if (Input.GetKey(KeyCode.RightArrow)) {
      // animate the GameObject
      anim[clip.name].speed = 10f;
      anim.Play(clipName);
    }

  }
  
  public void cubeAction(){
      anim.Play(clipName);
  }
}
