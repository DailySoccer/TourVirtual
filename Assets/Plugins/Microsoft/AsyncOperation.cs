using System.Collections;
using System.Collections.Generic;

public class AsyncOperation{
    public delegate void RequestEvent(string response);

    static int counter = 0;
    static Dictionary<string, AsyncOperation> Operations = new Dictionary<string, AsyncOperation>();

    public static AsyncOperation Create(RequestEvent OnSucess = null, RequestEvent OnError = null) {
        var op = new AsyncOperation((counter++).ToString("X8"), OnSucess, OnError);
        Operations.Add(op.Hash, op);
        return op;
    }

    public static void EndOperation(bool success, string result) {
        int idx = result.IndexOf(':');
        string hash = result.Substring(0, idx);
        if (Operations.ContainsKey(hash))
        {
            var op = Operations[hash];
            string rest = result.Substring(idx + 1);
            if (success && op.OnSuccess != null) op.OnSuccess(rest);
            else if (!success && op.OnError != null) op.OnError(rest);
            //
            op.pending = false;
            Operations.Remove(hash);
        }
    }


    public AsyncOperation(string Hash, RequestEvent OnSucess, RequestEvent OnError) {
        this.Hash = Hash;
        this.OnSuccess = OnSucess;
        this.OnError = OnError;
        pending = true;
    }

    public RequestEvent OnSuccess;
    public RequestEvent OnError;
    public string Hash;

    public bool pending { get; set; }

    public IEnumerator Wait()
    {
        while (pending) yield return null;
    }
}

