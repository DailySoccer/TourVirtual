using UnityEngine;
using System.Collections;

public class HelpData {
    private float _enterTime;

    public float TotalTimeInSeconds {
        get {
            return Time.time - _enterTime;
        }
    }

    public void Enter() {
        // reset necessary data
        _enterTime = Time.time;
    }

}
