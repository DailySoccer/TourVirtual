#if NETFX_CORE
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Microsoft.Mdp.SDK;
using Microsoft.Mdp.SDK.Model.Fans;
using Microsoft.Mdp.SDK.Model.Gamification;
using Microsoft.Mdp.SDK.Model.BackEnd;
using Microsoft.Mdp.SDK.Model.Purchases;
using Windows.UI.Core;

public class WSAAzureInterfaz : AzureInterfaz {
#region Init
    public override void Init(string signin) {
#if PRO
        this.IDClient = "43bb526b-84fc-47f9-822c-2f47aae59529";
        string environment = "production";
#elif PRE
        this.IDClient = "ec6a70f6-27d4-4e99-80fa-34883da0bcd5";
        string environment = "preproduction";
#else
        this.IDClient = "c0c95635-cdfc-447b-bdab-d4a833fc52ca";
        string environment = "development";
#endif
        string guid = Guid.NewGuid().ToString();
        DigitalPlatformClient.Instance.Init(environment, this.IDClient, guid, signin, signin);
    }

    // LogIn
    public async override void SignIn(AzureEvent OnSignInEvent=null) {
        if (OnSignInEvent != null) this.OnSignIn = OnSignInEvent;
        await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () => {
            await Microsoft.Mdp.SDK.DigitalPlatformClient.Instance.LogIn.SignIn();
            bool success = await Microsoft.Mdp.SDK.DigitalPlatformClient.Instance.LogIn.IsLoggedUser();
            if (this.OnSignIn != null) UnityEngine.WSA.Application.InvokeOnAppThread(() => {
                this.OnSignIn(success);
            }, true);
        });
    }

    public override void SignOut() {
        Microsoft.Mdp.SDK.DigitalPlatformClient.Instance.LogIn.SignOut();
    }

    public override void OpenURL(string url) {
        UnityEngine.WSA.Launcher.LaunchUri(url, false);
    }

    public override void CheckDeepLinking() { SetDeepLinking(  UnityEngine.WSA.Application.arguments ); }

#endregion
#region GetFanMe
    async void _GetFanMe(AsyncOperation op) {
        try {
            var res = await Microsoft.Mdp.SDK.DigitalPlatformClient.Instance.Fans.GetFan();
            // Componer el retono a JSON y enviar.
            Dictionary<string, object> jobject = new Dictionary<string, object>();
            if(res!=null){
                jobject.Add("IdUser", res.IdUser);
                jobject.Add("Alias", res.Alias);
                jobject.Add("Language", res.Language);
            }
            AsyncOperation.EndOperation(true, op.Hash + ":" + Newtonsoft.Json.JsonConvert.SerializeObject(jobject));
        } catch {
            AsyncOperation.EndOperation(false, op.Hash + ":KO");
        }
    }

    public override Coroutine GetFanMe(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetFanMe(op);
        return StartCoroutine(op.Wait());
    }
#endregion
#region GetProfileAvatar
    async void _GetProfileAvatar(AsyncOperation op) {
        try {
            var res = await Microsoft.Mdp.SDK.DigitalPlatformClient.Instance.Fans.GetProfileAvatar();
            // Componer el retono a JSON y enviar.
            Dictionary<string, object> jobject = new Dictionary<string, object>();
            if(res!=null){
                jobject.Add("PictureUrl", res.PictureUrl);
                List<object> PhysicalProperties = new List<object>();
                if(res.PhysicalProperties!=null){
                    foreach (var itm in res.PhysicalProperties) {
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        dic.Add("Data", itm.Data);
                        dic.Add("Type", itm.Type);
                        dic.Add("Version", itm.Version);
                        PhysicalProperties.Add(dic);
                    }
                }
                jobject.Add("PhysicalProperties", PhysicalProperties);
                List<object> Accesories = new List<object>();
                if(res.Accesories!=null){
                    foreach (var itm in res.Accesories) {
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        dic.Add("IdVirtualGood", itm.IdVirtualGood.ToString());
                        dic.Add("Data", itm.Data);
                        dic.Add("Type", itm.Type);
                        dic.Add("Version", itm.Version);
                        Accesories.Add(dic);
                    }
                }
                jobject.Add("Accesories", Accesories);
            }
            AsyncOperation.EndOperation(true, op.Hash + ":" + Newtonsoft.Json.JsonConvert.SerializeObject(jobject));
        } catch {
            AsyncOperation.EndOperation(false, op.Hash + ":KO");
        }
    }

    public override Coroutine GetProfileAvatar(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetProfileAvatar(op);
        return StartCoroutine(op.Wait());
    }
#endregion
#region SetProfileAvatar
    async void _SetProfileAvatar(object oprofile, AsyncOperation op) {
        try {
            Dictionary<string, object> profile = (Dictionary<string, object>)oprofile;
            var pau = new ProfileAvatarUpdateable();
            var PhysicalProperties = new List<ProfileAvatarItem>();
            foreach (Dictionary<string, string> item in profile["PhysicalProperties"] as List<object>) {
                PhysicalProperties.Add(new ProfileAvatarItem() {
                    Data = item["Data"],
                    Type = item["Type"],
                    Version = item["Version"]
                });
            }
            pau.PhysicalProperties = PhysicalProperties;

            var Accesories = new List<ProfileAvatarAccessoryItem>();
            foreach (Dictionary<string, string> item in profile["Accesories"] as List<object>) {
                Accesories.Add(new ProfileAvatarAccessoryItem() {
                    IdVirtualGood = new Guid(item["IdVirtualGood"]),
                    Data = item["Data"],
                    Type = item["Type"],
                    Version = item["Version"]
                });
            }
            pau.Accesories = Accesories;

            await Microsoft.Mdp.SDK.DigitalPlatformClient.Instance.Fans.PostProfileAvatar(pau);
            AsyncOperation.EndOperation(true, op.Hash + ":ProfileAvatarSeted");
        } catch {
            AsyncOperation.EndOperation(false, op.Hash + ":KO");
        }
    }

    public override Coroutine SetProfileAvatar(object profile, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _SetProfileAvatar(profile as Dictionary<string, object>, op);
        return StartCoroutine(op.Wait());
    }
#endregion
#region CheckAlias
    async void _CheckAlias(string alias, AsyncOperation op) {
        try {
            bool isAvailable = await Microsoft.Mdp.SDK.DigitalPlatformClient.Instance.Identity.GetCheckAlias(alias);
            AsyncOperation.EndOperation(true, op.Hash + ":" + isAvailable);
        } catch {
            AsyncOperation.EndOperation(false, op.Hash + ":KO");
        }
    }
    public override Coroutine CheckAlias(string nick, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _CheckAlias(nick, op);
        return StartCoroutine(op.Wait());
    }
#endregion
#region UpdateAlias
    async void _UpdateAlias(string alias, AsyncOperation op) {
        try {
            var update = new AliasUpdate();
            update.Alias = alias;
            await Microsoft.Mdp.SDK.DigitalPlatformClient.Instance.Identity.PutUpdateAlias(update);
            AsyncOperation.EndOperation(true, op.Hash + ":AliasUpdated");
        } catch {
            AsyncOperation.EndOperation(false, op.Hash + ":KO");
        }
    }

    public override Coroutine UpdateAlias(string nick, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _UpdateAlias(nick, op);
        return StartCoroutine(op.Wait());
    }
#endregion
#region SendAvatarImage
    async void _SendAvatarImage(byte[] bitmap, AsyncOperation op) {
        try {
            await Microsoft.Mdp.SDK.DigitalPlatformClient.Instance.Fans.PutProfileAvatarPicture(new System.IO.MemoryStream(bitmap));
            AsyncOperation.EndOperation(true, op.Hash + ":AvatarImageSent");
        } catch {
            AsyncOperation.EndOperation(false, op.Hash + ":KO");
        }
    }
    public override Coroutine SendAvatarImage(byte[] bitmap, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _SendAvatarImage(bitmap, op);
        return StartCoroutine(op.Wait());
    }
#endregion

    // Scores
#region SendScore
    async void _SendScore(string IDMinigame, int score, AsyncOperation op) {
        try {
            var ranking = await Microsoft.Mdp.SDK.DigitalPlatformClient.Instance.Scores.PostScore(new Guid(IDMinigame), score);
            var jobject = new List<object>();
            if(ranking!=null){
                Dictionary<string, object> ele;
                foreach (ScoreRanking entry in ranking) {
                    ele = new Dictionary<string, object>();
                    ele.Add("Position", entry.Position);
                    ele.Add("Alias", entry.Alias);
                    ele.Add("Score", entry.Score);
                    ele.Add("AvatarUrl", entry.AvatarUrl);
                    ele.Add("IsCurrentUser", entry.IsCurrentUser);
                    jobject.Add(ele);

                }
            }
            AsyncOperation.EndOperation(true, op.Hash + ":" + Newtonsoft.Json.JsonConvert.SerializeObject(jobject));
        } catch {
            AsyncOperation.EndOperation(false, op.Hash + ":KO");
        }
    }

    public override Coroutine SendScore(string IDMinigame, int score, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _SendScore(IDMinigame, score, op);
        return StartCoroutine(op.Wait());
    }
#endregion
#region GetMaxScore
    async void _GetMaxScore(string IDMinigame, AsyncOperation op) {
        try {
            FanMaxScore score = await DigitalPlatformClient.Instance.Scores.GetFanMaxScore(new Guid(IDMinigame));
            Dictionary<string, object> jobject = new Dictionary<string, object>();
            if(score!=null) jobject.Add("Score", score.Score);
            else jobject.Add("Score", 0);
            AsyncOperation.EndOperation(true, op.Hash + ":" + Newtonsoft.Json.JsonConvert.SerializeObject(jobject));
        } catch {
            AsyncOperation.EndOperation(false, op.Hash + ":KO");
        }
    }
    public override Coroutine GetMaxScore(string IDMinigame, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetMaxScore(IDMinigame, op);
        return StartCoroutine(op.Wait());
    }
#endregion
#region GetRanking
    async void _GetRanking(string IDMinigame, AsyncOperation op) {
        try {
            var ranking = await DigitalPlatformClient.Instance.Scores.GetTopScores(new Guid(IDMinigame));
            var jobject = new List<object>();
            if(ranking!=null) {
                Dictionary<string, object> ele;
                foreach (ScoreRanking entry in ranking) {
                    ele = new Dictionary<string, object>();
                    ele.Add("Position", entry.Position);
                    ele.Add("Alias", entry.Alias);
                    ele.Add("Score", entry.Score);
                    ele.Add("AvatarUrl", entry.AvatarUrl);
                    ele.Add("IsCurrentUser", entry.IsCurrentUser);
                    jobject.Add(ele);
                }
            }
            AsyncOperation.EndOperation(true, op.Hash + ":" + Newtonsoft.Json.JsonConvert.SerializeObject(jobject));
        } catch {
            AsyncOperation.EndOperation(false, op.Hash + ":KO");
        }
    }

    public override Coroutine GetRanking(string IDMinigame, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetRanking(IDMinigame, op);
        return StartCoroutine(op.Wait());
    }
#endregion

    // Virtual Goods
#region GetVirtualGoods
    async void _GetVirtualGoods(string type, int page, string subtype, bool onlyPurchasables, AsyncOperation op) {
        try {
            var res = await DigitalPlatformClient.Instance.VirtualGoods.GetVirtualGoodsByType(type, page, MainLanguage, subtype, onlyPurchasables);
            var jobject = new Dictionary<string, object>();
            if(res!=null) {
                var results = new List<object>();                
                if(res.Results!=null) {
                    Dictionary<string, object> ele;
                    foreach (VirtualGood entry in res.Results) {
                        ele = new Dictionary<string, object>();
                        ele.Add("Enabled", entry.Enabled);
                        ele.Add("IdVirtualGood", entry.IdVirtualGood);
                        ele.Add("IdSubType", entry.IdSubType);
                        ele.Add("ThumbnailUrl", entry.ThumbnailUrl);
                        ele.Add("PictureUrl", entry.PictureUrl);
                        List<object> tmpList = new List<object>();
                        if(entry.Description!=null) {
                            Dictionary<string, object> tmpDict = new Dictionary<string, object>();
                            foreach (var des in entry.Description) {
                                tmpDict = new Dictionary<string, object>();
                                tmpDict.Add("Locale", des.Locale);
                                tmpDict.Add("Description", des.Description);
                                tmpList.Add(tmpDict);
                            }
                        }
                        ele.Add("Description", tmpList);

                        tmpList = new List<object>();
                        if(entry.Description!=null) {
                            foreach (var des in entry.Price) {
                                tmpDict = new Dictionary<string, object>();
                                tmpDict.Add("UserType", des.UserType);
                                tmpDict.Add("CoinType", des.CoinType);
                                tmpDict.Add("Price", des.Price);
                                tmpList.Add(tmpDict);
                            }
                        }
                        ele.Add("Price", tmpList);
                        results.Add(ele);
                    }
                }
                jobject.Add("CurrentPage", res.CurrentPage);
                jobject.Add("HasMoreResults", res.HasMoreResults);
                jobject.Add("PageCount", res.PageCount);
                jobject.Add("PageSize", res.PageSize);
                jobject.Add("TotalItems", res.TotalItems);
                jobject.Add("Results", results);
            }
            AsyncOperation.EndOperation(true, op.Hash + ":" + Newtonsoft.Json.JsonConvert.SerializeObject(jobject));
        } catch {
            AsyncOperation.EndOperation(false, op.Hash + ":KO");
        }
    }
    public override Coroutine GetVirtualGoods(string type, int page, string subtype = null, bool onlyPurchasables = false, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetVirtualGoods(type, page, subtype, onlyPurchasables, op);
        return StartCoroutine(op.Wait());
    }
#endregion
#region GetVirtualGoodsPurchased
    async void _GetVirtualGoodsPurchased(string type, string token, AsyncOperation op) {
        try {
            var res = await DigitalPlatformClient.Instance.Fans.GetFanVirtualGoodsByType(type, token, MainLanguage);
            var jobject = new Dictionary<string, object>();
            if(res!=null) {
                var results = new List<object>();                
                if(res.Results!=null) {
                    Dictionary<string, object> ele;
                    foreach (FanVirtualGood entry in res.Results) {
                        ele = new Dictionary<string, object>();
                        ele.Add("IdVirtualGood", entry.IdVirtualGood);
                        ele.Add("ThumbnailUrl", entry.ThumbnailUrl);
                        ele.Add("PictureUrl", entry.PictureUrl);
                        results.Add(ele);
                    }
                jobject.Add("ContinuationToken", res.ContinuationToken);
                jobject.Add("ContinuationTokenB64", res.ContinuationTokenB64);
                jobject.Add("HasMoreResults", res.HasMoreResults);
                jobject.Add("Results", results);
            }
            AsyncOperation.EndOperation(true, op.Hash + ":" + Newtonsoft.Json.JsonConvert.SerializeObject(jobject));
        } catch {
            AsyncOperation.EndOperation(false, op.Hash + ":KO");
        }
    }
    public override Coroutine GetVirtualGoodsPurchased(string type, string token = null, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetVirtualGoodsPurchased(type, token, op);
        return StartCoroutine(op.Wait());
    }
#endregion
#region PurchaseVirtualGood
    async void _PurchaseVirtualGood(string IDVirtualGood, AsyncOperation op) {
        try {
            List<Guid> vgs = new List<Guid>();
            vgs.Add(new Guid(IDVirtualGood));
            await Microsoft.Mdp.SDK.DigitalPlatformClient.Instance.Purchases.PostRedeemVirtualGood(vgs, new Guid(this.IDClient));
            AsyncOperation.EndOperation(true, op.Hash + ":VirtualGoodPurchased");
        } catch {
            AsyncOperation.EndOperation(false, op.Hash + ":KO");
        }
    }
    public override Coroutine PurchaseVirtualGood(string IDVirtualGood, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _PurchaseVirtualGood(IDVirtualGood, op);
        return StartCoroutine(op.Wait());
    }
#endregion

    // Achievements
#region GetAchievements
    async void _GetAchievements(string type, AsyncOperation op) {
        try {
            var res = await DigitalPlatformClient.Instance.Achievements.GetAchievements(type, new Guid(this.IDClient), MainLanguage);
            var jobject = new List<object>();
            if(res!=null) {
                Dictionary<string, object> ele;
                foreach (AchievementConfiguration entry in res) {
                    ele = new Dictionary<string, object>();
                    ele.Add("IdAchievement", entry.IdAchievement);
                    ele.Add("Name", entry.Name);
                    ele.Add("Points", entry.Points);
                    ele.Add("Level", entry.Level);
                    ele.Add("ImageUrl", entry.ImageUrl);
                    List<object> tmpList = new List<object>();
                    if(entry.Description!=null) {
                        Dictionary<string, object> tmpDict;
                        foreach (var des in entry.Description) {
                            tmpDict = new Dictionary<string, object>();
                            tmpDict.Add("Locale", des.Locale);
                            tmpDict.Add("Description", des.Description);
                            tmpList.Add(tmpDict);
                        }
                    }
                    ele.Add("Description", tmpList);

                    tmpList = new List<object>();
                    if(entry.LevelName!=null) {
                        foreach (var des in entry.LevelName) {
                            tmpDict = new Dictionary<string, object>();
                            tmpDict.Add("Locale", des.Locale);
                            tmpDict.Add("Description", des.Description);
                            tmpList.Add(tmpDict);
                        }
                    }
                    ele.Add("LevelName", tmpList);
                }
                jobject.Add(ele);
            }

            AsyncOperation.EndOperation(true, op.Hash + ":" + Newtonsoft.Json.JsonConvert.SerializeObject(jobject));
        } catch {
            AsyncOperation.EndOperation(false, op.Hash + ":KO");
        }
    }
    public override Coroutine GetAchievements(string type, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetAchievements(type, op);
        return StartCoroutine(op.Wait());
    }
#endregion
#region GetAchievementsEarned
    async void _GetAchievementsEarned(string type, string token, AsyncOperation op) {
        try {
            var res = await DigitalPlatformClient.Instance.Fans.GetFanAchievementsByType(type, token, MainLanguage);
            var jobject = new Dictionary<string, object>();
            if(res!=null){
                var results = new List<object>();
                if(res.Results!=null){
                    Dictionary<string, object> ele;
                    foreach (Achievement entry in res.Results) {
                        ele = new Dictionary<string, object>();
                        ele.Add("IdAchievement", entry.IdAchievement);
                        ele.Add("Level", entry.Level);
                        results.Add(ele);
                    }
                }
                jobject.Add("ContinuationToken", res.ContinuationToken);
                jobject.Add("ContinuationTokenB64", res.ContinuationTokenB64);
                jobject.Add("HasMoreResults", res.HasMoreResults);
                jobject.Add("Results", results);
            }
            AsyncOperation.EndOperation(true, op.Hash + ":" + Newtonsoft.Json.JsonConvert.SerializeObject(jobject));
        } catch {
            AsyncOperation.EndOperation(false, op.Hash + ":KO");
        }
    }
    public override Coroutine GetAchievementsEarned(string type, string token = null, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetAchievementsEarned(type, token, op);
        return StartCoroutine(op.Wait());
    }
#endregion

    // Contents
#region GetContents
    async void _GetContents(string type, int page, AsyncOperation op) {
        try {
            var res = await DigitalPlatformClient.Instance.Contents.GetContentItemsByType(type, MainLanguage, page);
            var jobject = new Dictionary<string, object>();
            if(res!=null){
                var results = new List<object>();
                if(res!=null){
                    Dictionary<string, object> ele;
                    foreach (CompactContent entry in res.Results) {
                        ele = new Dictionary<string, object>();
                        ele.Add("IdContent", entry.IdContent);
                        ele.Add("Title", entry.Title);
                        ele.Add("Description", entry.Description);
                        List<object> tmpList = new List<object>();
                        if(entry.Links!=null){
                            Dictionary<string, object> tmpDict;
                            foreach (var des in entry.Links) {
                                tmpDict = new Dictionary<string, object>();
                                tmpDict.Add("Text", des.Text);
                                tmpDict.Add("Url", des.Url);
                                tmpList.Add(tmpDict);
                            }
                        }
                        ele.Add("Links", tmpList);

                        if (entry.Asset != null) {
                            tmpDict = new Dictionary<string, object>();
                            tmpDict.Add("AssetUrl", entry.Asset.AssetUrl);
                            tmpDict.Add("ThumbnailUrl", entry.Asset.ThumbnailUrl);
                            tmpDict.Add("Type", entry.Asset.Type);
                            ele.Add("Asset", tmpDict);
                        }

                        results.Add(ele);
                    }
                }
                jobject.Add("CurrentPage", res.CurrentPage);
                jobject.Add("HasMoreResults", res.HasMoreResults);
                jobject.Add("PageCount", res.PageCount);
                jobject.Add("PageSize", res.PageSize);
                jobject.Add("TotalItems", res.TotalItems);
                jobject.Add("Results", results);
            }
            AsyncOperation.EndOperation(true, op.Hash + ":" + Newtonsoft.Json.JsonConvert.SerializeObject(jobject));
        } catch(System.Exception e) {
            AsyncOperation.EndOperation(false, op.Hash + ":"+e.Message);
        }
    }
    public override Coroutine GetContents(string type, int page, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetContents(type, page, op);
        return StartCoroutine(op.Wait());
    }
#endregion
#region GetContent
    async void _GetContent(string IDContent, AsyncOperation op) {
        try {
            Content res = await DigitalPlatformClient.Instance.Contents.GetContentItem(new Guid(IDContent));
            var jobject = new Dictionary<string, object>();
            if(res!=null){
                jobject.Add("SourceId", res.SourceId);

                List<object> tmpList = new List<object>();
                if(res.Assets!=null){
                    Dictionary<string, object> tmpDict;
                    foreach (var des in res.Assets) {
                        tmpDict = new Dictionary<string, object>();
                        tmpDict.Add("Type", des.Type);
                        tmpDict.Add("AssetUrl", des.AssetUrl);
                        tmpList.Add(tmpDict);
                    }
                }
                jobject.Add("Assets", tmpList);

                tmpList = new List<object>();
                if(res.Body!=null){
                    foreach (var des in res.Body) {
                        tmpDict = new Dictionary<string, object>();
                        tmpDict.Add("Title", des.Title);
                        tmpDict.Add("Body", des.Body);
                        tmpList.Add(tmpDict);
                    }
                }
                jobject.Add("Body", tmpList);
            }
            AsyncOperation.EndOperation(true, op.Hash + ":" + Newtonsoft.Json.JsonConvert.SerializeObject(jobject));
        } catch {
            AsyncOperation.EndOperation(false, op.Hash + ":KO");
        }
    }
    public override Coroutine GetContent(string IDContent, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetContent(IDContent, op);
        return StartCoroutine(op.Wait());
    }
#endregion

    // Gamificación
#region GamificationStatus
    async void _GamificationStatus(AsyncOperation op) {
        try {
            var res = await Microsoft.Mdp.SDK.DigitalPlatformClient.Instance.Fans.GetGamificationStatus();
            // Componer el retono a JSON y enviar.
            Dictionary<string, object> jobject = new Dictionary<string, object>();
            if(res!=null){
                jobject.Add("GamingScore", res.GamingScore);
                jobject.Add("Points", res.Points);
                jobject.Add("LevelNumber", res.LevelNumber);
            }
            AsyncOperation.EndOperation(true, op.Hash + ":" + Newtonsoft.Json.JsonConvert.SerializeObject(jobject));
        } catch {
            AsyncOperation.EndOperation(false, op.Hash + ":KO");
        }
    }
    public override Coroutine GamificationStatus(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GamificationStatus(op);
        return StartCoroutine(op.Wait());
    }
#endregion
#region SendAction
    async void _SendAction(string IDAction, AsyncOperation op) {
        try {
            RegisterUserAction userAction = new RegisterUserAction() {
                ActionId = IDAction,
                ClientId = new Guid(this.IDClient)
            };
            await Microsoft.Mdp.SDK.DigitalPlatformClient.Instance.UserActions.PostUserAction(userAction);
            AsyncOperation.EndOperation(true, op.Hash + ":UserActionPosted");
        } catch {
            AsyncOperation.EndOperation(false, op.Hash + ":KO");
        }
    }
    public override Coroutine SendAction(string IDAction, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => {
            _SendAction(IDAction, op);
        });
        return StartCoroutine(op.Wait());
    }
#endregion

    // InApp Purchases
#region InAppPurchase
    async void _InAppPurchase(string IdProduct, string Receipt, AsyncOperation op) {
        try {
            Purchase purchase = new Purchase() {
                IdClient = new Guid(this.IDClient),
                IdProduct = IdProduct,
                Receipt = Receipt,
            };
            await Microsoft.Mdp.SDK.DigitalPlatformClient.Instance.Purchases.PostPurchase(purchase);
            AsyncOperation.EndOperation(true, op.Hash + ":PurchasePosted");
        } catch {
            AsyncOperation.EndOperation(false, op.Hash + ":KO");
        }
    }
    public override Coroutine InAppPurchase(string IdProduct, string Receipt, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _InAppPurchase(IdProduct, Receipt, op);
        return StartCoroutine(op.Wait());
    }
#endregion
}

#endif