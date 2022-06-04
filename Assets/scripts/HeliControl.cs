using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliControl : MonoBehaviour
{
    public Animator topAnimator;
    public Animator backAnimator;
    public float speed=0.8f;
    bool _onoff;
    void Start()
    {
        _onoff = false;
        topAnimator.SetBool("onoffbool", _onoff);
        backAnimator.SetBool("onoffbool", _onoff);
    }

    // Update is called once per frame
    void Update()
    {
        Domove();
    }

    void Domove() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(h) > 0.2f || Mathf.Abs(v) > 0.2f)
        {
            _onoff = true;
        }
        else
            _onoff = false;

        topAnimator.SetBool("onoffbool", _onoff);
        backAnimator.SetBool("onoffbool", _onoff);

        gameObject.transform.position = new Vector2(transform.position.x + (h * speed), transform.position.y + (v * speed));
    }
}
