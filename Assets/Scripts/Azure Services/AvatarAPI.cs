using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AvatarAPI {
    public enum Property { Gender, Hair, Hat, Head, Torso, Legs, Feet, Compliment };

    public string Gender;
    public string Hair;
    public string Hat;
    public string Head;
    public string Torso;
    public string Legs;
    public string Feet;
    public string Compliment;
    public string Pack;

    public bool isMan { get { return (Gender == "Man"); } }
    public bool isWoman { get { return (Gender == "Woman"); } }

    public void Random(){
        int idx = UnityEngine.Random.Range(0, 2);
        Gender = idx==1?"Man":"Woman";
        List<object> heads = PlayerManager.Instance.Selector[Gender] as List<object>;
        idx = UnityEngine.Random.Range(0, heads.Count);
        Dictionary<string, object> headesc = heads[idx] as Dictionary<string,object>;
        Hair = headesc["Hair"] as string;
        Head = headesc["Head"] as string;   
    }

    public AvatarAPI Copy()
    {
        return new AvatarAPI()
        {
            Gender = this.Gender,
            Hair = this.Hair,
            Hat = this.Hat,
            Head = this.Head,
            Torso = this.Torso,
            Legs = this.Legs,
            Feet = this.Feet,
            Compliment = this.Compliment,
            Pack = this.Pack
        };
    }

    public void Paste(AvatarAPI other)
    {
        this.Gender = other.Gender;
        this.Hair = other.Hair;
        this.Hat = other.Hat;
        this.Head = other.Head;
        this.Torso = other.Torso;
        this.Legs = other.Legs;
        this.Feet = other.Feet;
        this.Compliment = other.Compliment;
        this.Pack = other.Pack;
    }


    public Dictionary<string, string> GetProperty(Property prop) {
        Dictionary<string, string> ht = new Dictionary<string, string>();
        ht.Add("Type", prop.ToString());
        ht.Add("Version", "1");
        switch (prop) {
            case Property.Gender: ht.Add("Data", Gender); break;
            case Property.Hair: ht.Add("Data", Hair); break;
            case Property.Head: ht.Add("Data", Head); break;
        }
        return ht;
    }

    public Dictionary<string, string> GetVirtualGood(string id) {
        Dictionary<string, string> ht = new Dictionary<string, string>();
        VirtualGoodsAPI.VirtualGood vg = UserAPI.VirtualGoodsDesciptor.GetByGUID(id);
        if (vg != null) {
            ht.Add("IdVirtualGood", vg.GUID);
			ht.Add("Type", vg.GUID);
            ht.Add("Version", "1");
			ht.Add("Data", vg.GUID);
        }
        return ht;
    }

    public Dictionary<string, object> GetProperties() {
        Dictionary<string, object> avatar = new Dictionary<string, object>();
        List<object> array = new List<object>();
        array.Add(GetProperty(Property.Gender));
        array.Add(GetProperty(Property.Hair));
        array.Add(GetProperty(Property.Head));
        avatar.Add("PhysicalProperties", array);
        // No se si con esto descarto todos los VG puestos.
        List<object> array2 = new List<object>();
        if (!string.IsNullOrEmpty(Hat)) array2.Add(GetVirtualGood(Hat));
        if (!string.IsNullOrEmpty(Torso)) array2.Add(GetVirtualGood(Torso));
        if (!string.IsNullOrEmpty(Legs)) array2.Add(GetVirtualGood(Legs));
        if (!string.IsNullOrEmpty(Feet)) array2.Add(GetVirtualGood(Feet));
        if (!string.IsNullOrEmpty(Pack)) array2.Add(GetVirtualGood(Pack));
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
            foreach( Dictionary<string,object> tmp in avatar["Accesories"] as List<object>) {
                VirtualGoodsAPI.VirtualGood vg = UserAPI.VirtualGoodsDesciptor.GetByGUID(tmp["IdVirtualGood"] as string);
                if (vg != null){                    
                    if (vg.IdSubType.Contains("TORSO")) Torso = vg.GUID;
                    else if (vg.IdSubType.Contains("LEG")) Legs = vg.GUID;
                    else if (vg.IdSubType.Contains("SHOE")) Feet = vg.GUID;
                    else if (vg.IdSubType.Contains("COMPLIMENT")) Compliment = vg.GUID;
                    else if (vg.IdSubType.Contains("PACK")) Pack = vg.GUID;
                    else if (vg.IdSubType.Contains("HAT")) Hat = vg.GUID;
                }
            }
        }
    }

	public override string ToString() {
		string tTorso = Torso;
        string tLegs = Legs;
        string tFeet = Feet;

        if (!string.IsNullOrEmpty(Pack)) {
 
            var mypack = PlayerManager.Instance.GetPackDescriptor(Pack);
            if(mypack!=null)
            foreach( var cloth in mypack)
            {
                switch (cloth.Key)
                {
                    case "torso":
                        tTorso = cloth.Value as string;
                        break;
                    case "piernas":
                        tLegs = cloth.Value as string;
                        break;
                }
            }
        }
        return string.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}", Gender, string.IsNullOrEmpty(Hat) ? Hair : Hat, Head, tTorso, tLegs, tFeet, Compliment);
    }
}
