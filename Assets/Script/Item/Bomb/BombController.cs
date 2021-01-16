﻿using System;
using UnityEngine;
//Playerに踏まれた際の処理とAnimationの遷移状態によってBombを起爆させる処理
public class BombController : MonoBehaviour, ISteponable
{
    public GameObject bombBlast;
    private BombAnimation _bombAnimation;

    private void Awake()
    {
        _bombAnimation = new BombAnimation(GetComponent<Animator>());
    }
    
    //踏まれた時にFlagをtrueにする
    public void StepedOn(UnityChan2DController player)
    {
        _bombAnimation.StepedOnFlag();
    }
    //Flagがtrueの時に爆発処理実行
    private void Update()
    {
        if (_bombAnimation.DestroyJudge())
        {
            Instantiate(bombBlast, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
