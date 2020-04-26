using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TreeController : MonoBehaviour
{

    [SerializeField] private int hp = 25;
    private int[] fertilizer = { 5, 10, 15 };
    private Animator animator;
    private Animator lifeBarAnimator;

    private enum Stage { stage1, stage2, stage3 };
    private enum State { normal, damaged, death, hit };

    private Stage stage = Stage.stage1;
    private State state = State.normal;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        lifeBarAnimator = GameObject.FindWithTag("Lifebar").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("state", (int)state);
        animator.SetInteger("stage", (int)stage);
        lifeBarAnimator.SetInteger("hp", hp);

        if (state != State.hit)
        {

            if (hp >= 15)
            {
                state = State.normal;

            }
            else
            {
                state = State.damaged;

            }
        }
    }

    // This is called every time the zombie animation it's in the middle. It
    // reduces the tree life by one. This can be changed later in game to increase difficulty
    public void ReduceLife(int monster)
    {
        state = State.hit;
        if (hp > 1)
        {
            switch (monster)
            {
                case 0: //zombie
                    hp -= 2;
                    break;
                case 1: //skeleton
                    hp--;
                    break;
                case 2: //firespirit
                    hp -= 2;
                    break;
            }
        }
        else
        {
            state = State.death;
            switch (SceneManager.GetActiveScene().name)
            {
                case "SampleScene":

                    GameObject.FindWithTag("Scenes").GetComponent<Scenes>().load1();
                    break;
                case "SecondStage":

                    GameObject.FindWithTag("Scenes").GetComponent<Scenes>().load2();
                    break;
                case "ThirdStage":

                    GameObject.FindWithTag("Scenes").GetComponent<Scenes>().load3();
                    break;
            }
        }
    }

    /* Called after the player picks up a watering can. Add 5 to life- This can be changed 
    later in game increase difficulty*/
    public void AddLife()
    {
        hp += 5;
        if (hp > 25)
        {
            hp = 25;
        }
    }

    public void GrowTree(int numFertilizer)
    {
        if (numFertilizer <= 5)
        {
            stage = Stage.stage1;
        }
        else if (numFertilizer == 10)
        {
            stage = Stage.stage2;
        }
        else if (numFertilizer == 15)
        {
            stage = Stage.stage3;
        }
        else
            switch (SceneManager.GetActiveScene().name)
            {
                case "SampleScene":
                    GameObject.FindWithTag("Scenes").GetComponent<Scenes>().load2();
                    break;
                case "SecondStage":
                    GameObject.FindWithTag("Scenes").GetComponent<Scenes>().load3();
                    break;
                case "ThirdStage":

                    break;
            }
    }

    private void BackToNormal()
    {
        Debug.Log("aatacking");
        state = State.normal;
    }

    private void BackToDamaged()
    {
        Debug.Log("aatackin2");
        state = State.damaged;

    }
}