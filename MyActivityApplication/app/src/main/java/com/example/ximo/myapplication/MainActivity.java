package com.example.ximo.myapplication;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;

import com.microsoft.mdp.sdk.*;
import com.microsoft.mdp.sdk.auth.*;
import com.microsoft.mdp.sdk.base.*;
import com.microsoft.mdp.sdk.service.*;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        DigitalPlatformClient.init(this, DigitalPlatformClient.DEVELOPMENT, "2ab3fdfb-228f-451d-81b2-bdc4e0cc3115");
        login();
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
        AuthListener listener = new AuthListener() {
            @Override
            public void onResponse(String s) {
                System.out.println("onResponse: " + s);
            }

            @Override
            public void onError(DigitalPlatformClientException e) {
                System.out.println("onError: " + e.getMessage());
            }
        };
        DigitalPlatformClient.getInstance().getAuthHandler().login(this, listener, false);
    }

    protected void onActivityResult(int requestCode, int resultCode, final Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (DigitalPlatformClient.getInstance().getAuthHandler() != null)
            DigitalPlatformClient.getInstance().getAuthHandler().onActivityResult(this, requestCode, resultCode, data);
    }
}
