using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class ChatsData {

    public int TotalPrivateMessages;
    private HashSet<string> _users;

    public int TotalUsers {
        get {
            return _users.Count;
        }
    }

    public void Reset() {
        TotalPrivateMessages = 0;
        _users = new HashSet<string>();
    }

    public void PrivateMessage(string userId) {
        TotalPrivateMessages++;
        _users.Add(userId);
    }
}
