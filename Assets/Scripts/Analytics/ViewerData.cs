using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class ViewerData {
    public int ViewersOpened;
    public string LastOpenViewerId = "";
    public HashSet<string> ViewersOpenedList;
    public HashSet<string> ViewersStepedList;

    private float _enterTime;
    public float TotalTime {
        get {
            return Time.time - _enterTime;
        }
    }

    public string ViewersOpenedListToString() {
        return String.Join(" | ", ViewersOpenedList.ToArray());
    }

    public void Reset() {
        // reset necessary data
        ViewersOpenedList = new HashSet<string>();
        ViewersStepedList = new HashSet<string>();
        ViewersOpened = 0;
    }

    public void OpenViewer(string viewerId) {
        _enterTime = Time.time;

        ViewersOpened++;
        LastOpenViewerId = viewerId;
        ViewersOpenedList.Add(viewerId);
    }

    public void StepOnViewer(string viewerId) {
        ViewersStepedList.Add(viewerId);
    }
}
