using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    public AnimationClip deathClip;
    public Animation anim;
    float time;
    ScoreCalcutor scoreCalculator;
    //public string animat;
    void Start()
    {
        //deathClip.legacy = true;
        
    }
    void Update()
    {
        time = time + Time.deltaTime;
        if(time>10f)
        {
            Destroy(gameObject);
            time = 0f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Bullet")
        {
            //GetComponent<Animation>().clip=deathClip;//GetClip("Death");//AddClip(clip,"Dead");
            // anim.Play("Death");
            //cp = clip;
            anim.clip = deathClip;
            anim.Play();
            scoreCalculator = GameObject.Find("ScoreManager").GetComponent<ScoreCalcutor>();
            scoreCalculator.Score(5);
            StartCoroutine("Wait"); 
        }


    }
    IEnumerator Wait()
    {
       yield return (new WaitForSeconds(1));
        Destroy(gameObject);
    }
}
