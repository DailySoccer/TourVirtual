using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class OtherUserProfileData {
    private float _enterTime;
    private string[] _dataModel;
    public string Gender;

    public float TotalTimeInSeconds {
        get {
            return Time.time - _enterTime;
        }
    }

    public void Enter(string[] dataModel) {
        _dataModel = dataModel;

        Gender = "Man";
        foreach(string field in _dataModel) {
            if (field.Contains("Cabeza")) {
                Gender = field.StartsWith("H") ? "Man" : "Woman";
                // Debug.Log("OtherUserProfileData: Gender: " + Gender);
                break;
            }
        }

        // reset necessary data
        _enterTime = Time.time;
    }

}
