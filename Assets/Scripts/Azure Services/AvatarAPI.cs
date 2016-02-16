using UnityEngine;
using System.Collections;

public struct AvatarAPI {
    public enum Property { Sex, Hair, Head, Body, Legs, Feet, Compliment };

    public string Sex;
    public string Hair;
    public string Head;
    public string Body;
    public string Legs;
    public string Feet;
    public string Compliment;

    public Hashtable GetProperty(Property prop) {
        Hashtable ht = new Hashtable();        
        ht.Add("Type", prop.ToString());
        ht.Add("Version", "1");
        switch (prop){
            case Property.Sex: ht.Add("Data", Sex); break;
            case Property.Hair: ht.Add("Data", Hair); break;
            case Property.Head: ht.Add("Data", Head); break;
            case Property.Body: ht.Add("Data", Body); break;
            case Property.Legs: ht.Add("Data", Legs); break;
            case Property.Feet: ht.Add("Data", Feet); break;
            case Property.Compliment: ht.Add("Data", Compliment); break;

        }
        return ht;
    }

    public Hashtable GetProperties() {
        Hashtable avatar = new Hashtable();
        ArrayList array = new ArrayList();
        array.Add(GetProperty(Property.Sex));
        array.Add(GetProperty(Property.Hair));
        array.Add(GetProperty(Property.Head));
        array.Add(GetProperty(Property.Body));
        array.Add(GetProperty(Property.Legs));
        array.Add(GetProperty(Property.Feet));
        array.Add(GetProperty(Property.Compliment));
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
                case "Hair": Hair = data; break;
                case "Head": Head = data; break;
                case "Body": Body = data; break;
                case "Legs": Legs = data; break;
                case "Feet": Feet = data; break;
                case "Compliment": Feet = data; break;
            }
        }
    }

    public override string ToString() { return string.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}", Sex, Hair, Head,Body,Legs, Feet, Compliment); }
}
