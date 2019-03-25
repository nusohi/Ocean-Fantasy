using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {
    
    public float NormalStep = 0.02f;    // 每关键帧 正常可移动步长
    public float DashStep = 0.10f;      // 每关键帧 加速时可移动步长

    public float ReduceSpeed = 0.25f;      // 加速时蓄力值减少速度
    public float RecoverSpeed = 0.10f;     // 蓄力值恢复的速度

    public Slider PowerSlider;
    public JoyStick joyStick;
    public SpaceButton spaceButton;


    private float _ReduceSpeed_PerFrame_;
    private float _RecoverSpeed_PerFrame_;
    private float _Step_;

    private bool Dashing = false; 
    private float Power = 1f;   // 蓄力值，范围0-1

    private Rigidbody2D rigidbody;



	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        _ReduceSpeed_PerFrame_ = ReduceSpeed * Time.deltaTime;
        _RecoverSpeed_PerFrame_ = RecoverSpeed * Time.deltaTime;
        _Step_ = NormalStep;
    }

    void Update() {
        bool getSpaceKey = spaceButton.BtnPressed();
        // 加速
        if (getSpaceKey && Power > 0f) {
            Dashing = true;
            _Step_ = DashStep;
        }
        else {
            Dashing = false;
            _Step_ = NormalStep;
        }

        // 蓄力值减少
        if (Dashing) {
            Power -= _ReduceSpeed_PerFrame_;
        }

        // 蓄力值恢复
        if (!Dashing && Power < 1f && !getSpaceKey) {
            Power += _RecoverSpeed_PerFrame_;
        }
        else if (Power > 1f) {
            Power = 1f;
        }

        // 显示蓄力值
        if (PowerSlider != null) {
            PowerSlider.value = Power;
        }

    }

    void FixedUpdate() {
        // 基本移动 WASD
        float h = joyStick.Horizontal();
        float v = joyStick.Vertical();

        if (Mathf.Abs(h) > 0.0001 || Mathf.Abs(v) > 0.0001) {
            rigidbody.transform.position += new Vector3(h * _Step_, v * _Step_, 0);
        }

        // 人物朝向角度调整
        float angle = Vector2.SignedAngle(new Vector2(1, 0), new Vector2(h, v));
        transform.localRotation = Quaternion.Euler(0, 0, angle);

        // 左右移动变换时修正上下
        Vector3 scale = transform.localScale;
        if (h < 0 && scale.y > 0) {
            scale.y *= -1;
        }
        else if (h > 0 && scale.y < 0) {
            scale.y *= -1;
        }
        else if (h == 0 && v == 0) {
            scale.x = Mathf.Abs(scale.x);
            scale.y = Mathf.Abs(scale.y);
        }
        transform.localScale = scale;
    }
}
