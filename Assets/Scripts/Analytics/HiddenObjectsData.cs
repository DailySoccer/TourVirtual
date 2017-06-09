using UnityEngine;
using UnityEngine.Analytics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HiddenObjectsData {
    public int TotalVisitedRooms;
    public int TotalFindedObjects;

    private HashSet<string> _differentRooms;
    private float _enterTime;

    private bool _started = false;

    public float TotalTimeInSeconds {
        get {
            return Time.time - _enterTime;
        }
    }

    public float TotalDifferentRooms {
        get {
            return _differentRooms.Count;
        }
    }

    public void Start() {
        _enterTime = Time.time;
        _differentRooms = new HashSet<string>();
        _started = true;

        TotalVisitedRooms = 0;
        TotalFindedObjects = 0;
    }

    public void Stop() {
        _started = false;
    }

    public void EnterRoom(string roomId) {
        if (_started) {
            _differentRooms.Add(roomId);
            TotalVisitedRooms++;
        }
    }
}
