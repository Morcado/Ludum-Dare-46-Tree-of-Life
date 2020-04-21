using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public Animator TransitionAnim;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update() {   //ifff

    }

    IEnumerator LoadScene(string name) {
        TransitionAnim.SetTrigger("panel-end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadSceneAsync(name);
    }

    public void load1() {
        StartCoroutine(LoadScene("SampleScene"));
    }
    public void load2() {
        StartCoroutine(LoadScene("SecondStage"));
    }
    public void load3() {
        StartCoroutine(LoadScene("ThirdStage"));
    }
}
