package com.unusualwonder.tourvirtualBernabeu;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Bundle;
//import android.content.pm.PackageManager;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import com.microsoft.applicationinsights.library.ApplicationInsights;
import com.microsoft.applicationinsights.contracts.User;
import com.microsoft.mdp.sdk.*;

import com.microsoft.mdp.sdk.auth.AuthListener;
import com.microsoft.mdp.sdk.auth.AuthListenerToken;
import com.microsoft.mdp.sdk.base.DigitalPlatformClientException;
import com.microsoft.mdp.sdk.model.BaseObject;
import com.microsoft.mdp.sdk.model.achievements.Achievement;
import com.microsoft.mdp.sdk.model.achievements.AchievementConfiguration;
import com.microsoft.mdp.sdk.model.achievements.PagedAchievements;
import com.microsoft.mdp.sdk.model.apps.App;
import com.microsoft.mdp.sdk.model.apps.AppItem;
import com.microsoft.mdp.sdk.model.contents.Asset;
import com.microsoft.mdp.sdk.model.contents.CompactContent;
import com.microsoft.mdp.sdk.model.contents.Content;
import com.microsoft.mdp.sdk.model.contents.ContentLink;
import com.microsoft.mdp.sdk.model.contents.ContentParagraph;
import com.microsoft.mdp.sdk.model.contents.PagedCompactContent;
import com.microsoft.mdp.sdk.model.fan.Fan;
import com.microsoft.mdp.sdk.model.fan.FanVirtualGood;
import com.microsoft.mdp.sdk.model.fan.GamificationStatus;
import com.microsoft.mdp.sdk.model.fan.PagedFanVirtualGoods;
import com.microsoft.mdp.sdk.model.fan.PagedVirtualGood;
import com.microsoft.mdp.sdk.model.fan.ProfileAvatar;
import com.microsoft.mdp.sdk.model.fan.ProfileAvatarAccessoryItem;
import com.microsoft.mdp.sdk.model.fan.ProfileAvatarItem;
import com.microsoft.mdp.sdk.model.fan.ProfileAvatarUpdateable;
import com.microsoft.mdp.sdk.model.fan.VirtualGood;
import com.microsoft.mdp.sdk.model.identities.AliasUpdate;
import com.microsoft.mdp.sdk.model.purchases.Purchase;
import com.microsoft.mdp.sdk.model.rankings.ExperienceRanking;
import com.microsoft.mdp.sdk.model.scores.FanMaxScore;
import com.microsoft.mdp.sdk.model.scores.ScoreRanking;
import com.microsoft.mdp.sdk.model.subscriptions.ProductPrice;
import com.microsoft.mdp.sdk.model.team.LocaleDescription;
import com.microsoft.mdp.sdk.service.ServiceResponseListener;
import com.unity3d.player.UnityPlayerActivity;
import com.unity3d.player.UnityPlayer;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;

import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class MainActivity extends UnityPlayerActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        /*
        Intent intent = getIntent();
        deeplinking = "";
        if( intent!=null) {
            String action = intent.getAction();
            Uri data = intent.getData();
            System.out.println("Unity > MainActivity.onCreate "+action+" "+data);
            if( data!=null) deeplinking = data.toString();
        }
        */
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


    String deeplinking = "";

    @Override
    protected void onNewIntent(Intent intent) {
        super.onNewIntent(intent);
        deeplinking = "";
        if (intent != null) {
            String action = intent.getAction();
            Uri data = intent.getData();
            if (data != null) {
                if (data.getScheme().equals("rmvt")) {
                    if( data.getHost().equals("editavatar")) {
                        deeplinking = data.toString();
                        System.out.println("Unity MainActivity:: onNewIntent " + deeplinking);
                    }
                    else {
                        String authCode = data.getQueryParameter("AuthorizationCode");
                        Boolean allowed = Boolean.valueOf(data.getQueryParameter("Allowed"));
                        if(allowed){
                            DigitalPlatformClient.getInstance().getSingleSignOnHandler().getSSOTokenWithAuthorizationCode(this, authCode, new ServiceResponseListener<String>() {
                                            @Override
                                            public void onResponse(String response) {
                                                DigitalPlatformClient.getInstance().getAuthHandler().loginWithAuthorizationCode(MainActivity.this, "RMTV12345", response, new ServiceResponseListener<Boolean>() {
                                                    @Override
                                        public void onResponse(Boolean response) {
                                            if(response){
                                                UnityPlayer.UnitySendMessage("Azure Services", "OnSignInEvent", "OK");
                                            }else{
                                                UnityPlayer.UnitySendMessage("Azure Services", "OnSignInEvent", "KO");
                                            }
                                        }
                                        @Override
                                        public void onError(DigitalPlatformClientException e) {
                                            UnityPlayer.UnitySendMessage("Azure Services", "OnSignInEvent", "KO");

                                        }
                                    });
                                }
                                @Override
                                public void onError(DigitalPlatformClientException e) {
                                    UnityPlayer.UnitySendMessage("Azure Services", "OnSignInEvent", "KO");
                                }
                            });
                        }else {
                            UnityPlayer.UnitySendMessage("Azure Services", "OnSignInEvent", "KO");
                        }
                    }
                }
            }
        }
    }

    public String GetDeepLinking() {
        return deeplinking;
    }

    static Gson gson = new Gson();
    static String IDClient;

    public void Init(String enviroment, String idClient, String signin) {

        System.out.println("Unity MainActivity:: Init " + enviroment+" "+idClient);
        String env;
        MainActivity.IDClient = idClient;
        if (enviroment.equals("development")) env = DigitalPlatformClient.DEVELOPMENT;
        else if (enviroment.equals("preproduction")) env = DigitalPlatformClient.PREPRODUCTION;
        else env = DigitalPlatformClient.PRODUCTION;
        DigitalPlatformClient.init(this, env, MainActivity.IDClient, signin);
    }

    public void Login(boolean mode) {
        System.out.println("Unity MainActivity:: Login");
        Intent myintent=new Intent(Intent.ACTION_VIEW, Uri.parse("rmapp://single_sign_on?Parameters={\"ClientId\":\""+ MainActivity.IDClient +"\", \"TemporaryHash\":\"RMTV12345\"} "));

        if(!getPackageManager().queryIntentActivities(myintent,0).isEmpty())
            startActivity(myintent);
        else
            UnityPlayer.UnitySendMessage("Azure Services", "OnSignInEvent", "NOAPP");
    }

    public void OpenURL(String url){
        Intent myintent=new Intent(Intent.ACTION_VIEW, Uri.parse(url));
        if(!getPackageManager().queryIntentActivities(myintent,0).isEmpty())
            startActivity(myintent);
    }

    public void Logout() {
        DigitalPlatformClient.getInstance().getAuthHandler().logout(this);
    }

    void SendOkResponse(String hash, String res) {
        UnityPlayer.UnitySendMessage("Azure Services", "OnResponseOK", hash + ":" + res);
    }

    void SendErrorResponse(String hash, DigitalPlatformClientException err) {
        UnityPlayer.UnitySendMessage("Azure Services", "OnResponseKO", hash + ":" + err.getCode() + ":" + err.getMessage());
    }

    public void PostFanApps(String deviceID, final String hash) {
        ServiceResponseListener<String> callback = new ServiceResponseListener<String>() {
            @Override
            public void onResponse(String res) {
                SendOkResponse(hash, res);
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };

        AppItem appItem = new AppItem();
        appItem.setEnaBlePushNotifications(false);
        appItem.setPushNotificationHandler("");
        appItem.setType(0);
        appItem.setPlatformVersion("1.0.6");
        DigitalPlatformClient.getInstance().getFanHandler().postApps(this, deviceID,appItem, callback);
    }


    public void GetFanMe(final String hash) {
        ServiceResponseListener<Fan> callback = new ServiceResponseListener<Fan>() {
            @Override
            public void onResponse(Fan res) {
                Map jobject = new HashMap();
                if (res != null) {
                    jobject.put("IdUser", res.getIdUser());
                    jobject.put("Alias", res.getAlias()!=null?res.getAlias():"");
                    jobject.put("Language", res.getLanguage());
                }
                SendOkResponse(hash, gson.toJson(jobject));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        DigitalPlatformClient.getInstance().getFanHandler().getFan(this, callback, false);
    }

    public void GetProfileAvatar(final String hash) {
        ServiceResponseListener<ProfileAvatar> callback = new ServiceResponseListener<ProfileAvatar>() {
            @Override
            public void onResponse(ProfileAvatar res) {
                Map jobject = new HashMap();
                if (res != null) {
                    jobject.put("PictureUrl", res.getPictureUrl());
                    ArrayList PhysicalProperties = new ArrayList();
                    if (res.getPhysicalProperties() != null) {
                        for (ProfileAvatarItem itm : res.getPhysicalProperties()) {
                            Map jitem = new HashMap();
                            jitem.put("Data", itm.getData());
                            jitem.put("Type", itm.getType());
                            jitem.put("Version", itm.getVersion());
                            PhysicalProperties.add(jitem);
                        }
                    }
                    jobject.put("PhysicalProperties", PhysicalProperties);
                    ArrayList Accesories = new ArrayList();
                    if (res.getAccesories() != null) {
                        for (ProfileAvatarAccessoryItem itm : res.getAccesories()) {
                            Map jitem = new HashMap();
                            jitem.put("IdVirtualGood", itm.getIdVirtualGood());
                            jitem.put("Data", itm.getData());
                            jitem.put("Type", itm.getType());
                            jitem.put("Version", itm.getVersion());
                            Accesories.add(jitem);
                        }
                    }
                    jobject.put("Accesories", Accesories);
                }
                SendOkResponse(hash, gson.toJson(jobject));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        DigitalPlatformClient.getInstance().getFanHandler().getProfileAvatar(this, callback);
    }

    public void CreateProfileAvatar(String profile, final String hash) {
        ServiceResponseListener<String> callback = new ServiceResponseListener<String>() {
            @Override
            public void onResponse(String res) {
                SendOkResponse(hash, gson.toJson(res));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        ObjectMapper mapper = new ObjectMapper();
        try {
            Map<String, Object> map = mapper.readValue(profile, new TypeReference<Map<String, Object> >() { });
            ArrayList<HashMap<String, Object>> PhysicalProperties = (ArrayList) map.get("PhysicalProperties");
            ArrayList<ProfileAvatarItem> lPhysicalProperties = new ArrayList<ProfileAvatarItem>();
            for (HashMap<String, Object> itm : PhysicalProperties) {
                ProfileAvatarItem lItm = new ProfileAvatarItem();
                lItm.setData((String) itm.get("Data"));
                lItm.setType((String) itm.get("Type"));
                lItm.setVersion((String) itm.get("Version"));
                lPhysicalProperties.add(lItm);
            }

            ArrayList<HashMap<String, Object>> Accesories = (ArrayList) map.get("Accesories");
            ArrayList<ProfileAvatarAccessoryItem> lAccesories = new ArrayList<ProfileAvatarAccessoryItem>();
            for (HashMap<String, Object> itm : Accesories) {
                ProfileAvatarAccessoryItem lItm = new ProfileAvatarAccessoryItem();
                lItm.setIdVirtualGood((String) itm.get("IdVirtualGood"));
                lItm.setData((String) itm.get("Data"));
                lItm.setType((String) itm.get("Type"));
                lItm.setVersion((String) itm.get("Version"));
                lAccesories.add(lItm);
            }

            ProfileAvatarUpdateable pau = new ProfileAvatarUpdateable();
            pau.setPhysicalProperties(lPhysicalProperties);
            pau.setAccesories(lAccesories);
            DigitalPlatformClient.getInstance().getFanHandler().createProfileAvatar(this, pau, callback);

        } catch (IOException e) {
        }
    }

    public void SetProfileAvatar(String profile, final String hash) {
        ServiceResponseListener<String> callback = new ServiceResponseListener<String>() {
            @Override
            public void onResponse(String res) {
                SendOkResponse(hash, gson.toJson(res));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        ObjectMapper mapper = new ObjectMapper();
        try {
            Map<String, Object> map = mapper.readValue(profile, new TypeReference<Map<String, Object> >() { });
            ArrayList<HashMap<String, Object>> PhysicalProperties = (ArrayList) map.get("PhysicalProperties");
            ArrayList<ProfileAvatarItem> lPhysicalProperties = new ArrayList<ProfileAvatarItem>();
            for (HashMap<String, Object> itm : PhysicalProperties) {
                ProfileAvatarItem lItm = new ProfileAvatarItem();
                lItm.setData((String) itm.get("Data"));
                lItm.setType((String) itm.get("Type"));
                lItm.setVersion((String) itm.get("Version"));
                lPhysicalProperties.add(lItm);
            }

            ArrayList<HashMap<String, Object>> Accesories = (ArrayList) map.get("Accesories");
            ArrayList<ProfileAvatarAccessoryItem> lAccesories = new ArrayList<ProfileAvatarAccessoryItem>();
            for (HashMap<String, Object> itm : Accesories) {
                ProfileAvatarAccessoryItem lItm = new ProfileAvatarAccessoryItem();
                lItm.setIdVirtualGood((String) itm.get("IdVirtualGood"));
                lItm.setData((String) itm.get("Data"));
                lItm.setType((String) itm.get("Type"));
                lItm.setVersion((String) itm.get("Version"));
                lAccesories.add(lItm);
            }

            ProfileAvatarUpdateable pau = new ProfileAvatarUpdateable();
            pau.setPhysicalProperties(lPhysicalProperties);
            pau.setAccesories(lAccesories);
            DigitalPlatformClient.getInstance().getFanHandler().updateProfileAvatar(this, pau, callback);

        } catch (IOException e) {
            System.out.println("Unity > SetProfileAvatar.IOException ");
        }
    }

    public void CheckAlias(String alias, final String hash) {
        ServiceResponseListener<Boolean> callback = new ServiceResponseListener<Boolean>() {
            @Override
            public void onResponse(Boolean res) {
                SendOkResponse(hash, gson.toJson(res));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        DigitalPlatformClient.getInstance().getIdentityHandler().getCheckAlias(this, alias, callback);
    }

    public void UpdateAlias(String alias, final String hash) {
        ServiceResponseListener<String> callback = new ServiceResponseListener<String>() {
            @Override
            public void onResponse(String res) {
                SendOkResponse(hash, gson.toJson(res));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        AliasUpdate au = new AliasUpdate();
        au.setAlias(alias);
        DigitalPlatformClient.getInstance().getIdentityHandler().putUpdateAlias(this, au, callback);
    }

    public void SendAvatarImage(byte[] data, final String hash) {
        ServiceResponseListener<String> callback = new ServiceResponseListener<String>() {
            @Override
            public void onResponse(String res) {
                SendOkResponse(hash, gson.toJson(res));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        Bitmap bm = BitmapFactory.decodeByteArray(data, 0, data.length);
        DigitalPlatformClient.getInstance().getFanHandler().putProfileAvatarPicture(this, bm, callback);
    }

    // Scores.
    public void SendScore(String IDMinigame, int score, final String hash) {
        ServiceResponseListener<ArrayList<ScoreRanking>> callback = new ServiceResponseListener<ArrayList<ScoreRanking>>() {
            @Override
            public void onResponse(ArrayList<ScoreRanking> res) {
                ArrayList jobject = new ArrayList();
                if (res != null) {
                    for (ScoreRanking itm : res) {
                        Map jitem = new HashMap();
                        jitem.put("Position", itm.getPosition());
                        jitem.put("Alias", itm.getAlias());
                        jitem.put("Score", itm.getScore());
                        jitem.put("AvatarUrl", itm.getAvatarUrl());
                        jitem.put("IsCurrentUser", itm.isCurrentUser());
                        jobject.add(jitem);
                    }
                }
                SendOkResponse(hash, gson.toJson(jobject));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        DigitalPlatformClient.getInstance().getScoreRankingHandler().postScore(this, IDMinigame, score, callback);
    }

    public void GetMaxScore(String IDMiniGame, final String hash) {
        ServiceResponseListener<FanMaxScore> callback = new ServiceResponseListener<FanMaxScore>() {
            @Override
            public void onResponse(FanMaxScore res) {
                Map jobject = new HashMap();
                if (res != null) jobject.put("Score", res.getScore());
                else jobject.put("Score", 0);
                SendOkResponse(hash, gson.toJson(jobject));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        DigitalPlatformClient.getInstance().getScoreRankingHandler().getFanMaxScore(this, IDMiniGame, callback);
    }

    public void GetRanking(String IDMiniGame, final String hash) {
        ServiceResponseListener<ArrayList<ScoreRanking>> callback = new ServiceResponseListener<ArrayList<ScoreRanking>>() {
            @Override
            public void onResponse(ArrayList<ScoreRanking> res) {
                ArrayList jobject = new ArrayList();
                if (res != null) {
                    for (ScoreRanking itm : res) {
                        Map jitem = new HashMap();
                        jitem.put("Position", itm.getPosition());
                        jitem.put("Alias", itm.getAlias());
                        jitem.put("Score", itm.getScore());
                        jitem.put("AvatarUrl", itm.getAvatarUrl());
                        jitem.put("IsCurrentUser", itm.isCurrentUser());
                        jobject.add(jitem);
                    }
                }
                SendOkResponse(hash, gson.toJson(jobject));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        DigitalPlatformClient.getInstance().getScoreRankingHandler().getTopScores(this, IDMiniGame, callback);
    }

    public void GetFanRanking(final String hash) {
        ServiceResponseListener<ArrayList<ExperienceRanking>> callback = new ServiceResponseListener<ArrayList<ExperienceRanking>>() {
            @Override
            public void onResponse(ArrayList<ExperienceRanking> res) {
                ArrayList jobject = new ArrayList();
                if (res != null) {
                    for (ExperienceRanking itm : res) {
                        Map jitem = new HashMap();
                        jitem.put("Alias", itm.getAlias());
                        jitem.put("AvatarUrl", itm.getAvatarUrl());
                        jitem.put("Position", itm.getPosition());
                        jitem.put("GamingScore", itm.getGamingScore());
                        jitem.put("IsCurrentUser", itm.getIsCurrentUser());
                        jobject.add(jitem);
                    }
                }
                SendOkResponse(hash, gson.toJson(jobject));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        DigitalPlatformClient.getInstance().getRankingHandler().getCurrentUserRanking(this, callback);
    }

    // Virtual Goods
    public void GetVirtualGoods(String type, int page, String language, String subtype, boolean onlyPurchasables, final String hash) {
        ServiceResponseListener<PagedVirtualGood> callback = new ServiceResponseListener<PagedVirtualGood>() {
            @Override
            public void onResponse(PagedVirtualGood res) {
                Map jobject = new HashMap();
                if (res != null) {
                    ArrayList results = new ArrayList();
                    if (res.getResults() != null) {
                        for (VirtualGood itm : res.getResults()) {
                            Map jitem = new HashMap();
                            jitem.put("Enabled", itm.getEnabled());
                            jitem.put("IdVirtualGood", itm.getIdVirtualGood());
                            jitem.put("IdSubType", itm.getIdSubType());
                            jitem.put("ThumbnailUrl", itm.getThumbnailUrl());
                            jitem.put("PictureUrl", itm.getPictureUrl());
                            ArrayList description = new ArrayList();
                            if (itm.getDescription() != null) {
                                for (LocaleDescription des : itm.getDescription()) {
                                    Map jdes = new HashMap();
                                    jdes.put("Locale", des.getLocale());
                                    jdes.put("Description", des.getDescription());
                                    description.add(jdes);
                                }
                            }
                            jitem.put("Description", description);

                            ArrayList price = new ArrayList();
                            if (itm.getPrice() != null) {
                                for (ProductPrice des : itm.getPrice()) {
                                    Map jdes = new HashMap();
                                    jdes.put("UserType", des.getUserType());
                                    jdes.put("CoinType", des.getCoinType());
                                    jdes.put("Price", des.getPrice());
                                    price.add(jdes);
                                }
                            }
                            jitem.put("Price", price);
                            results.add(jitem);
                        }
                    }

                    jobject.put("CurrentPage", res.getCurrentPage());
                    jobject.put("HasMoreResults", res.getHasMoreResults());
                    jobject.put("PageCount", res.getPageCount());
                    jobject.put("PageSize", res.getPageSize());
                    jobject.put("TotalItems", res.getTotalItems());
                    jobject.put("Results", results);
                }
                SendOkResponse(hash, gson.toJson(jobject));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        DigitalPlatformClient.getInstance().getVirtualGoodsHandler().getVirtualGoodsByType(this, type, page, language, subtype, onlyPurchasables, callback);
    }

    public void GetVirtualGoodsPurchased(String type, String language, String token, final String hash) {
        ServiceResponseListener<PagedFanVirtualGoods> callback = new ServiceResponseListener<PagedFanVirtualGoods>() {
            @Override
            public void onResponse(PagedFanVirtualGoods res) {
                Map jobject = new HashMap();
                if (res != null) {
                    ArrayList results = new ArrayList();
                    if (res.getResults() != null) {
                        for (FanVirtualGood itm : res.getResults()) {
                            Map jitem = new HashMap();
                            jitem.put("IdVirtualGood", itm.getIdVirtualGood());
                            jitem.put("ThumbnailUrl", itm.getThumbnailUrl());
                            jitem.put("PictureUrl", itm.getPictureUrl());
                            results.add(jitem);
                        }
                    }
                    jobject.put("Results", results);
                    jobject.put("ContinuationTokenB64", res.getContinuationTokenB64());
                    jobject.put("HasMoreResults", res.getHasMoreResults());
                }
                SendOkResponse(hash, gson.toJson(jobject));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        DigitalPlatformClient.getInstance().getFanHandler().getFanVirtualGoodsByType(this, type, token, language, callback);
    }

    public void PurchaseVirtualGood(String IDVirtualGood, final String hash) {
        ServiceResponseListener<String> callback = new ServiceResponseListener<String>() {
            @Override
            public void onResponse(String res) {
                SendOkResponse(hash, gson.toJson(res));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        ArrayList<String> arr = new ArrayList<String>();
        arr.add(IDVirtualGood);
        DigitalPlatformClient.getInstance().getPurchasesServiceHandler().postRedeemVirtualGoods(this, arr, callback);
    }

    // Achievements
    public void GetAchievements(String type, String language, final String hash) {
        ServiceResponseListener<ArrayList<AchievementConfiguration>> callback = new ServiceResponseListener<ArrayList<AchievementConfiguration>>() {
            @Override
            public void onResponse(ArrayList<AchievementConfiguration> res) {
                ArrayList jobject = new ArrayList();
                if (res != null) {
                    for (AchievementConfiguration itm : res) {
                        Map jitm = new HashMap();
                        jitm.put("IdAchievement", itm.getIdAchievement());
                        jitm.put("Name", itm.getName());
                        jitm.put("Points", itm.getPoints());
                        jitm.put("Level", itm.getLevel());
                        jitm.put("ImageUrl", itm.getImageUrl());

                        ArrayList description = new ArrayList();
                        if (itm.getDescription() != null) {
                            for (LocaleDescription des : itm.getDescription()) {
                                Map jdes = new HashMap();
                                jdes.put("Locale", des.getLocale());
                                jdes.put("Description", des.getDescription());
                                description.add(jdes);
                            }
                        }
                        jitm.put("Description", description);

                        ArrayList levelName = new ArrayList();
                        if (itm.getLevelName() != null) {
                            for (LocaleDescription des : itm.getLevelName()) {
                                Map jdes = new HashMap();
                                jdes.put("Locale", des.getLocale());
                                jdes.put("Description", des.getDescription());
                                levelName.add(jdes);
                            }
                        }
                        jitm.put("LevelName", levelName);
                        jobject.add(jitm);
                    }
                }
                SendOkResponse(hash, gson.toJson(jobject));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        DigitalPlatformClient.getInstance().getAchievementsHandler().getAchievements(this, type, language, callback);
    }

    public void GetAchievementsEarned(String type, String language, String token, final String hash) {
        ServiceResponseListener<PagedAchievements> callback = new ServiceResponseListener<PagedAchievements>() {
            @Override
            public void onResponse(PagedAchievements res) {
                Map jobject = new HashMap();
                if (res != null) {
                    ArrayList results = new ArrayList();
                    if (res.getResults() != null) {
                        for (Achievement itm : res.getResults()) {
                            Map jitem = new HashMap();
                            jitem.put("IdAchievement", itm.getIdAchievement());
                            jitem.put("Level", itm.getLevel());
                            results.add(jitem);
                        }
                    }
                    jobject.put("ContinuationTokenB64", res.getContinuationTokenB64());
                    jobject.put("HasMoreResults", res.getHasMoreResults());
                    jobject.put("Results", results);
                }
                SendOkResponse(hash, gson.toJson(jobject));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        DigitalPlatformClient.getInstance().getFanHandler().getFanAchievementsByType(this, type, token, language, callback);
    }

    // Contents
    public void GetContents(String type, int page, String language, final String hash) {
        ServiceResponseListener<PagedCompactContent> callback = new ServiceResponseListener<PagedCompactContent>() {
            @Override
            public void onResponse(PagedCompactContent res) {
                Map jobject = new HashMap();
                if (res != null) {
                    ArrayList results = new ArrayList();
                    if (res.getResults() != null) {
                        for (CompactContent itm : res.getResults()) {
                            Map jitem = new HashMap();
                            jitem.put("IdContent", itm.getIdContent());
                            jitem.put("Title", itm.getTitle());
                            jitem.put("Description", itm.getDescription());

                            ArrayList links = new ArrayList();
                            if (itm.getLinks() != null) {
                                for (ContentLink des : itm.getLinks()) {
                                    Map jdes = new HashMap();
                                    jdes.put("Text", des.getText());
                                    jdes.put("Url", des.getUrl());
                                    links.add(jdes);
                                }
                            }
                            jitem.put("Links", links);
                            Asset asset = itm.getAsset();
                            if (asset != null) {
                                Map jdes = new HashMap();
                                jdes.put("AssetUrl", asset.getAssetUrl());
                                jdes.put("ThumbnailUrl", asset.getThumbnailUrl());
                                jdes.put("Type", asset.getType());
                                jitem.put("Asset", jdes);
                            }
                            results.add(jitem);
                        }
                    }
                    jobject.put("CurrentPage", res.getCurrentPage());
                    jobject.put("HasMoreResults", res.getHasMoreResults());
                    jobject.put("PageCount", res.getPageCount());
                    jobject.put("PageSize", res.getPageSize());
                    jobject.put("TotalItems", res.getTotalItems());
                    jobject.put("Results", results);
                }
                SendOkResponse(hash, gson.toJson(jobject));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        DigitalPlatformClient.getInstance().getContentsHandler().getContentItemsByType(this, type, language, page, callback, false); // !!!!!
    }

    public void GetContent(String IDContent, final String hash) {
        ServiceResponseListener<Content> callback = new ServiceResponseListener<Content>() {
            @Override
            public void onResponse(Content res) {
                Map jobject = new HashMap();
                if (res != null) {
                    jobject.put("SourceId", res.getSourceId());
                    ArrayList assets = new ArrayList();
                    if (res.getAssets() != null) {
                        for (Asset itm : res.getAssets()) {
                            Map jitem = new HashMap();
                            jitem.put("Type", itm.getType());
                            jitem.put("AssetUrl", itm.getAssetUrl());
                            assets.add(jitem);
                        }
                    }
                    jobject.put("Assets", assets);

                    ArrayList body = new ArrayList();
                    if (res.getBody() != null) {
                        for (ContentParagraph itm : res.getBody()) {
                            Map jitem = new HashMap();
                            jitem.put("Title", itm.getTitle());
                            jitem.put("Body", itm.getBody());
                            body.add(jitem);
                        }
                    }
                    jobject.put("Body", body);
                }
                SendOkResponse(hash, gson.toJson(jobject));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        DigitalPlatformClient.getInstance().getContentsHandler().getContentItem( this, IDContent, callback, true); // !!!!!
    }

    // Gamificación
    public void GamificationStatus(String language, final String hash) {
        ServiceResponseListener<GamificationStatus> callback = new ServiceResponseListener<GamificationStatus>() {
            @Override
            public void onResponse(GamificationStatus res) {
                Map jobject = new HashMap();
                if (res != null) {
                    jobject.put("GamingScore", res.getGamingScore());
                    jobject.put("Points", res.getPoints());
                    jobject.put("LevelNumber", res.getLevelNumber());
                }
                SendOkResponse(hash, gson.toJson(jobject));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        DigitalPlatformClient.getInstance().getFanHandler().getGamificationStatus(this, language, callback);
    }

    public void SendAction(String IDAction, final String hash) {
        ServiceResponseListener<String> callback = new ServiceResponseListener<String>() {
            @Override
            public void onResponse(String res) {
                SendOkResponse(hash, gson.toJson(res));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        DigitalPlatformClient.getInstance().getUserActionsHandler().postUserAction(this, null, IDAction, callback); // Esta al reves que en REST.
    }

    // InApp Purchases
    public void InAppPurchase(String IDProduct, String receipt, final String hash) {
        ServiceResponseListener<String> callback = new ServiceResponseListener<String>() {
            @Override
            public void onResponse(String res) {
                SendOkResponse(hash, gson.toJson(res));
            }

            @Override
            public void onError(DigitalPlatformClientException err) {
                SendErrorResponse(hash, err);
            }
        };
        Purchase p = new Purchase();
        p.setIdClient(MainActivity.IDClient);
        p.setIdProduct(IDProduct);
        p.setReceipt(receipt);
        DigitalPlatformClient.getInstance().getPurchasesServiceHandler().postPurchase(this, p, callback);
    }
}
