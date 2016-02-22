////////////////////////////////////////////////////////////////////////////////
//  
// @module Android DeepLink Plugin for Unity
// @author CausalLink Assets
// @support causallink.assets@gmail.com
//
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

public class main : MonoBehaviour {

    public GUIText uri_text;
    public GUIText left_text;
    public GUIText right_text;
    public GUIText string_text;
    public GUITexture cube;
	// Use this for initialization






    
    int color_red = 0;
    int color_green = 0;
    int color_blue= 0;

    int intvalue = 0;
    float floatvalue = 0.0f;
    string stringvalue = "";
    int increment_intvalue = 0;
    float increment_floatvalue = 0.0f;
	void Start () {

        //How uri should be defined
        //myapp://com.deeplink.testf?r=128&g=22&b=2&intvalue=323&floatvalue=10.234&svalue=HelloWorld

        color_red = AndroidDeepLink.GetValueInInt("r");
        color_green = AndroidDeepLink.GetValueInInt("g");
        color_blue = AndroidDeepLink.GetValueInInt("b");

        intvalue = AndroidDeepLink.GetValueInInt("intvalue");
        floatvalue = AndroidDeepLink.GetValueInInt("floatvalue");

        stringvalue = AndroidDeepLink.GetValueInString("svalue");
    
        increment_intvalue=intvalue;
        increment_floatvalue = floatvalue;

        uri_text.text = AndroidDeepLink.GetURL();
        left_text.text = color_red + "\n\n\n\n" + color_green + "\n\n\n\n" + color_blue;
        right_text.text = intvalue + "                 " + increment_intvalue + "\n\n\n\n" + floatvalue + "              " + increment_floatvalue;
        string_text.text = stringvalue;

        cube.color = new Color(color_red / 255.0f,color_green / 255.0f,color_blue / 255.0f);
	}

    
	void Update () {
        if (Time.frameCount % 20 == 0)
        {
            increment_intvalue += 1;
            
            increment_floatvalue += 0.05f;

            right_text.text = intvalue + "                 " + increment_intvalue + "\n\n\n\n" + floatvalue + "              " + increment_floatvalue;
            left_text.text = color_red + "\n\n\n\n" + color_green + "\n\n\n\n" + color_blue;
        
        }
	}
}

