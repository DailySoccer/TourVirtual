/*
package com.unusualwonder.tourvirtualBernabeu;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;

import com.microsoft.mdp.sdk.auth.AuthHandler;
import com.microsoft.mdp.sdk.auth.AuthListenerToken;

public class LoginActivity extends Activity implements AuthListenerToken {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        System.out.println("Unity > 1 LoginActivity: ");

        Intent i = getIntent();
        i.putExtra(AuthHandler.SIGN_OPTION, AuthHandler.SIGN_IN_OPTION);
        setResult(RESULT_OK, i);
        finish();
    }
}
*/