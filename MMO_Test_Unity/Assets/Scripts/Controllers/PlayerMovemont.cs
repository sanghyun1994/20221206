using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 반드시 animator 컴포넌트를 갖고있어야만 한다.
[RequireComponent (typeof(Animator))]
public class PlayerMovemont : MonoBehaviour
{
    protected Animator _anim;

    float _lastAttackTime, lastSkillTime, lastDashTime;

    public bool _attacking = false;
    public bool _dashing = false;
    
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // h : horizontal 방향 컨트롤러 가로
    // v : verctcal 방향컨트롤러 세로
    float h, v;
    float back = 1.0f;

    // 방향 컨트롤러에서 컨트롤러에 변경이 일어날 경우 호출되는 함수

    public void OnstickChanged(Vector2 _stickPos)
    {
        h = _stickPos.x;
        v = _stickPos.y;
    }
    
    void Update()
    {
        if (_anim)
        {
            if (v <0.0f)
                back = -1.0f;


            //_anim.SetFloat("Speed, (h*h+v*v)");

            Rigidbody _rigidbody = GetComponent<Rigidbody>();

            if(_rigidbody)
            {
                Vector3 _speed = _rigidbody.velocity;
                _speed.x = 4.0f * h;
                _speed.y = 4.0f * v;
                _rigidbody.velocity = _speed;

                if(h!= 0.0f && v != 0.0f)
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3(h, 0.0f, v));
                }
            }

        }
    }
}
