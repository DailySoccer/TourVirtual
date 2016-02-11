using UnityEngine;
using System.Collections;

public struct AvatarAPI {
    public enum Property { Sex, Head, Body, Legs, Feet };

    public string Sex;
    public string Head;
    public string Body;
    public string Legs;
    public string Feet;

    public Hashtable GetProperty(Property prop) {
        Hashtable ht = new Hashtable();        
        ht.Add("Type", prop.ToString());
        ht.Add("Version", "1");
        switch (prop){
            case Property.Sex: ht.Add("Data", Sex); break;
            case Property.Head: ht.Add("Data", Head); break;
            case Property.Body: ht.Add("Data", Body); break;
            case Property.Legs: ht.Add("Data", Legs); break;
            case Property.Feet: ht.Add("Data", Feet); break;
        }
        return ht;
    }

    public Hashtable GetProperties() {
        Hashtable avatar = new Hashtable();
        ArrayList array = new ArrayList();
        array.Add(GetProperty(Property.Sex));
        array.Add(GetProperty(Property.Head));
        array.Add(GetProperty(Property.Body));
        array.Add(GetProperty(Property.Legs));
        array.Add(GetProperty(Property.Feet));
        avatar.Add("PhysicalProperties", array);
    return avatar;
    }

    public void SetProperties(ArrayList desc) {
        foreach (var ele in desc) {
            Hashtable part = ele as Hashtable;
            string type = part["Type"] as string;
            string data = part["Data"] as string;
            switch (type) {
                case "Sex": Sex = data; break;
                case "Head": Head = data; break;
                case "Body": Body = data; break;
                case "Legs": Legs = data; break;
                case "Feet": Feet = data; break;
            }
        }
    }

    public override string ToString() { return string.Format("{0}#{1}#{2}#{3}#{4}", Sex, Head,Body,Legs,Feet); }
}
