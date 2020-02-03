using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public int indexX = 0;
    public float CountDown = 0;
    public float indexY = 0;
    private int Switch = 1;
    public bool IsDead = false;
    public int CanEat = 0;

    public float Speed = 8;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
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

        indexX = Random.Range(-5, 4);
        indexY = Random.Range(0.4f, -5.8f);
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
