using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct AvatarAPI {
    public enum Property { Gender, Hair, Hat, Head, Body, Legs, Feet, Compliment };

    public string Gender;
    public string Hair;
    public string Hat;
    public string Head;
    public string Body;
    public string Legs;
    public string Feet;
    public string Compliment;

    public Hashtable GetProperty(Property prop)
    {
        Hashtable ht = new Hashtable();
        ht.Add("Type", prop.ToString());
        ht.Add("Version", "1");
        switch (prop)
        {
            case Property.Gender: ht.Add("Data", Gender); break;
            case Property.Hair: ht.Add("Data", Hair); break;
            case Property.Head: ht.Add("Data", Head); break;
        }
        return ht;
    }

    public Hashtable GetVirtualGood(string id) {
        Hashtable ht = new Hashtable();
        VirtualGoodsAPI.VirtualGood vg = UserAPI.VirtualGoodsDesciptor.GetByGUID(id);
        if (vg != null) {
            ht.Add("IdVirtualGood", vg.GUID);
            ht.Add("Type", "Unknow");
            ht.Add("Version", "1");
        }
        return ht;
    }

    public Hashtable GetProperties() {
        Hashtable avatar = new Hashtable();
        ArrayList array = new ArrayList();
        array.Add(GetProperty(Property.Gender));
        array.Add(GetProperty(Property.Hair));
        array.Add(GetProperty(Property.Head));
        avatar.Add("PhysicalProperties", array);
        // No se si con esto descarto todos los VG puestos.
        ArrayList array2 = new ArrayList();
        if (!string.IsNullOrEmpty(Hat)) array2.Add(GetVirtualGood(Hat));
        if (!string.IsNullOrEmpty(Body)) array2.Add(GetVirtualGood(Body));
        if (!string.IsNullOrEmpty(Legs)) array2.Add(GetVirtualGood(Legs));
        if (!string.IsNullOrEmpty(Feet)) array2.Add(GetVirtualGood(Feet));
        if (!string.IsNullOrEmpty(Compliment)) array2.Add(GetVirtualGood(Compliment));
        avatar.Add("Accesories", array2);
        return avatar;
    }

    public void SetProperties(List<object> desc) {
        foreach (Dictionary<string,object> part in desc) {
            string type = part["Type"] as string;
            string data = part["Data"] as string;
            switch (type) {
                case "Gender": Gender = data; break;
                case "Hair": Hair = data; break;
                case "Head": Head = data; break;
            }
        }
    }

    public void Parse(Dictionary<string, object> avatar) {
        // Propiedades fisicas. Sexo, Pelo, Cabeza.
        if (avatar.ContainsKey("PhysicalProperties"))
            SetProperties(avatar["PhysicalProperties"] as List<object>);
        // Otras propiedades.
        if (avatar.ContainsKey("Accesories") && avatar["Accesories"]!=null) {
            foreach( Hashtable tmp in avatar["Accesories"] as List<object>) {
                VirtualGoodsAPI.VirtualGood vg = UserAPI.VirtualGoodsDesciptor.GetByGUID(tmp["IdVirtualGood"] as string);
                if (vg != null)
                {
                    if (vg.IdSubType.Contains("TORSO")) Body = vg.InternalID;
                    else if (vg.IdSubType.Contains("LEG")) Legs = vg.InternalID;
                    else if (vg.IdSubType.Contains("SHOE")) Feet = vg.InternalID;
                    else if (vg.IdSubType.Contains("COMPLIMENT")) Compliment = vg.InternalID;
                }
            }
        }
    }
    public override string ToString() { return string.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}", Gender, string.IsNullOrEmpty(Hat)?Hair:Hat, Head, Body,Legs, Feet, Compliment); }
}
