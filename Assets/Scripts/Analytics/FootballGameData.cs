using UnityEngine;
using System.Collections;

public class FootballGameData {

    private float _enterTime;

    public float TotalTimeInSeconds {
        get {
            return Time.time - _enterTime;
        }
    }

    public void Start() {
        _enterTime = Time.time;
    }

    public void Stop() {
    }

}
