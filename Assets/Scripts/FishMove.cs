using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public float indexX = 0;
    public float CountDown = 0;
    public float indexY = 0;
    private int Switch = 1;
    public bool IsDead = false;
    public int CanEat = 0;
    public float Speed = 10;
    void Update() {
        if (Switch > 0) {
            CountDown -= Time.deltaTime;
            if (CountDown <= 0) {
                Move();
                CountDown = 4;
            }
        }
    }
    void Move() {
        indexX = Random.Range(-16f, 6.54f);
        indexY = Random.Range(-14.52f, 1.56f);
        Vector3 Scale = transform.localScale;
        if (this.transform.position.x < indexX) {
            Scale.x = Mathf.Abs(Scale.x);
        }
        else {
            Scale.x = -Mathf.Abs(Scale.x);
        }
        transform.localScale = Scale;
        Tweener fish = this.transform.DOMove(new Vector3(indexX, indexY, -2), Speed);
        fish.SetEase(Ease.Linear);
        if (IsDead == false) { fish.OnComplete(Eat); }
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Rubbish" && CanEat > 0) {
            this.GetComponent<BoxCollider2D>().enabled = false;
            IsDead = true;
            GameManager.Instance.FishBody++;
            CanEat = 0;
            Switch = -1;
            Tweener fish = this.transform.DOMove(new Vector3(transform.position.x, 2.48f, -2), 8f);
            transform.rotation = new Quaternion(0, 0, 180f, 0);
            collision.gameObject.transform.DOScale(0f, 0.3f);
            Destroy(collision.gameObject,0.3f);
        }
    }
    void Eat() {
        CanEat = 1;
    }
}
