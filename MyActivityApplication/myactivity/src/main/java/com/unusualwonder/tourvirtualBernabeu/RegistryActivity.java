package com.unusualwonder.tourvirtualBernabeu;

import android.app.Activity;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.os.Bundle;
import com.microsoft.mdp.sdk.*;
import com.microsoft.mdp.sdk.auth.AuthHandler;
import com.microsoft.mdp.sdk.auth.AuthListener;
import com.microsoft.mdp.sdk.base.DigitalPlatformClientException;
import com.unity3d.player.UnityPlayer;

public class RegistryActivity extends Activity implements AuthListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (DigitalPlatformClient.getInstance().getAuthHandler() != null) {
            // Se realiza "login" temporalmente hasta que se pueda seleccionar entre "register" y "login"
            // DigitalPlatformClient.getInstance().getAuthHandler().login(this, this, true);
            DigitalPlatformClient.getInstance().getAuthHandler().login(this, this, false);
        }
    }

    public void onResponse(String token) {
        System.out.println("RegistryActivity:: onResponse: " + token);

        Intent intent = new Intent();
        intent.putExtra("accessToken", token);
        setResult(RESULT_OK, intent);
        finish();
    }

    public void onError(DigitalPlatformClientException e) {
        System.out.println("RegistryActivity:: onError: " + e.getMessage());
    }

    @Override
    public void onBackPressed() {
        // moveTaskToBack(true);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        if (data != null) {
            System.out.println("RegistryActivity:: onActivityResult: " +
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
