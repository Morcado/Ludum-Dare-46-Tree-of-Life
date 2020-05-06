using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage_cntr : MonoBehaviour {
    private int stage_cnt;
    void Start() {
        stage_cnt = 0;
        DontDestroyOnLoad(this.gameObject);
    }

    public int Get_stage() {
        return stage_cnt;
    }
    public void Set_stage(int cnt) {
        stage_cnt = cnt;
    }
}
