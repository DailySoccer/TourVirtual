package com.unusualwonder.tourvirtualBernabeu;

import android.app.Activity;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.os.Bundle;
import com.microsoft.mdp.sdk.*;

import com.unity3d.player.UnityPlayerActivity;

public class MainActivity extends UnityPlayerActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        boolean isDebuggable =  ( 0 != ( getApplicationInfo().flags & ApplicationInfo.FLAG_DEBUGGABLE ) );
        System.out.println("> DEBUG: " + (isDebuggable ? "TRUE" : "FALSE"));
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        if (data != null) {
            System.out.println("MainActivity:: onActivityResult: " +
                    String.valueOf(requestCode) +
                    "#" +
                    String.valueOf(resultCode) +
                    "#" +
                    data.getDataString());
        }

        if (DigitalPlatformClient.getInstance().getAuthHandler() != null)
            DigitalPlatformClient.getInstance().getAuthHandler().onActivityResult(this, requestCode, resultCode, data);
    }
}
