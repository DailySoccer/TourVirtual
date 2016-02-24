package com.unusualwonder.tourvirtualBernabeu;

import android.app.Activity;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.os.Bundle;
import com.microsoft.mdp.sdk.*;

import com.microsoft.mdp.sdk.auth.AuthListener;
import com.microsoft.mdp.sdk.auth.AuthListenerToken;
import com.microsoft.mdp.sdk.base.DigitalPlatformClientException;
import com.unity3d.player.UnityPlayerActivity;
import com.unity3d.player.UnityPlayer;

public class MainActivity extends UnityPlayerActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (data != null) {
            System.out.println("Unity > 1 onActivityResult: " + resultCode);
            System.out.println("Unity MainActivity:: onActivityResult: " +
                    String.valueOf(requestCode) +
                    "#" +
                    String.valueOf(resultCode) +
                    "#" +
                    data.getDataString());
        }

        if (DigitalPlatformClient.getInstance().getAuthHandler() != null)
            DigitalPlatformClient.getInstance().getAuthHandler().onActivityResult(this, requestCode, resultCode, data);
    }

    public void Init(String enviroment, String idUser, String signin, String signup){
        String env;
        if( enviroment.equals("development") ) env= DigitalPlatformClient.DEVELOPMENT;
        else env=DigitalPlatformClient.PRODUCTION;
        DigitalPlatformClient.init(this, env, idUser, signin, signup);
    }

    public void Login(boolean mode) {
        /*
        AuthListenerToken token = new AuthListenerToken() {
            @Override
            public void onResponse(String var1) {
                UnityPlayer.UnitySendMessage("Azure Services", "OnToken", var1);
            }
            @Override
            public void onError(DigitalPlatformClientException var1) {
                UnityPlayer.UnitySendMessage("Azure Services", "OnToken", "Error");
            }
        };
        DigitalPlatformClient.getInstance().getAuthHandler().login(this, token, mode);
        */
        AuthListener listener = new AuthListener(){
            @Override
            public void onResponse() {
                UnityPlayer.UnitySendMessage("Azure Services", "OnToken", "Ok");
            }
            @Override
            public void onError(DigitalPlatformClientException error){
                UnityPlayer.UnitySendMessage("Azure Services", "OnToken", "Error");
            }
        };
        DigitalPlatformClient.getInstance().getAuthHandler().loginInitial(this, listener, false);
    }

    public void GetToken(){
        AuthListenerToken token = new AuthListenerToken() {
            @Override
            public void onResponse(String var1) {
                UnityPlayer.UnitySendMessage("Azure Services", "OnTokenReceive", var1);
            }
            @Override
            public void onError(DigitalPlatformClientException var1) {
                UnityPlayer.UnitySendMessage("Azure Services", "OnTokenReceive", "Error");
            }
        };
        DigitalPlatformClient.getInstance().getAuthHandler().getToken(token);
    }
}
