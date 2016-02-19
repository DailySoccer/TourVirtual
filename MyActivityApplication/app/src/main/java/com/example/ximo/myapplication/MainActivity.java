package com.example.ximo.myapplication;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;

import com.microsoft.mdp.sdk.*;
import com.microsoft.mdp.sdk.auth.*;
import com.microsoft.mdp.sdk.base.*;
import com.microsoft.mdp.sdk.service.ApplicationContext;
import java.util.logging.*;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Logger.getLogger(getClass().getName()).log( Level.INFO, "Mensaje informativo..." );
//        DigitalPlatformClient.init(this, DigitalPlatformClient.DEVELOPMENT, "a9ae3ecc-765e-45f3-96dd-e367a936dda9");
//        login();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    public void login() {
        AuthListenerToken token = new AuthListenerToken(){
            @Override
            public void onResponse(String var1){

            }
            @Override
            public void onError(DigitalPlatformClientException var1){

            }
        };

        DigitalPlatformClient.getInstance().getAuthHandler().login(this, token, false);
    }

    protected void onActivityResult(int requestCode, int resultCode, final Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (DigitalPlatformClient.getInstance().getAuthHandler() != null)
            DigitalPlatformClient.getInstance().getAuthHandler().onActivityResult(this, requestCode, resultCode, data);
    }
}
