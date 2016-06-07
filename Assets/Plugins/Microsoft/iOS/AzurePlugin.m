@import MDPClient;

char* cStringCopy(const char* string) {
    if (string == NULL)
        return NULL;
    
    char* res = (char*)malloc(strlen(string) + 1);
    strcpy(res, string);
    return res;
}

NSString* IdUser = nil;
NSString* IdClient = nil;

// This takes a char* you get from Unity and converts it to an NSString* to use in your objective c code. You can mix c++ and objective c all in the same file.
static NSString* CreateNSString(const char* string){
    if (string != NULL)
        return [NSString stringWithUTF8String:string];
    else
        return [NSString stringWithUTF8String:""];
}

void _AzureInit(char* enviroment, char* idclient, char* extraQueryParametersSignIn){
    
    IdClient = CreateNSString(idclient);
    
    [[MDPClientHandler sharedInstance]	initWithEnvironment:CreateNSString(enviroment) idClient:IdClient debugMode:true extraQueryParametersSignIn:CreateNSString(extraQueryParametersSignIn) extraQueryParametersSignUp:CreateNSString(extraQueryParametersSignIn)];
}

void _AzureSignIn(){
    [MDPAuthHandler sharedInstance].showUserSelectionScreenBlock = ^(MDPAuthHandler *authHandler) {
        [[MDPAuthHandler sharedInstance] userSelectedOption:MDPAuthHandlerUserSelectionOptionSignIn];
    };
    
    [[MDPAuthHandler sharedInstance] getAccesTokenWithCompletionBlock:^ void (NSError *error){
        if(error){
            UnitySendMessage("Azure Services", "OnSignInEvent", "KO");
        }else{
            UnitySendMessage("Azure Services", "OnSignInEvent", "OK");
        }
        
    }];
}

void _AzureSignOut(){
    [[MDPAuthHandler sharedInstance] cleanUpKeychain];
    NSHTTPCookieStorage *storage = [NSHTTPCookieStorage sharedHTTPCookieStorage];
    for (NSHTTPCookie *cookie in [storage cookies]) {
        [storage deleteCookie:cookie];
    }
}

void _OpenURL(char* url){
    NSString *customURL = CreateNSString(url);
    
    //if ([[UIApplication sharedApplication] canOpenURL:[NSURL URLWithString:customURL]])
    {
        [[UIApplication sharedApplication] openURL:[NSURL URLWithString:customURL]];
    }
}

NSMutableArray *GetLocalization(NSSet * levelNames){
    NSMutableArray *ret = [[NSMutableArray alloc]init];
    for( MDPLocaleDescriptionModel *loc in levelNames){
        NSMutableDictionary *entry = [[NSMutableDictionary alloc] init];
        [entry setObject:loc.locale forKey:@"Locale"];
        [entry setObject:loc.descriptionLocaleDescription forKey:@"Description"];
        [ret addObject:entry];
    }
    return ret;
}

void _GetFanApps(char* appID, char* deviceID,char* _hash){
}

void _GetFanMe(char* _hash){
    __block NSString* hash = CreateNSString(_hash);
    [[[MDPClientHandler sharedInstance] getFanHandler] getFanWithUseCache:YES completionBlock:^(MDPFanModel *content, NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
            
        } else {
            NSMutableDictionary* jobject = [[NSMutableDictionary alloc] init];
            [jobject setObject:content.idUser forKey:@"IdUser"];
            [jobject setObject:content.alias forKey:@"Alias"];
            [jobject setObject:content.language forKey:@"Language"];
            
            NSError	*error		= nil;
            NSData *jsonData = [NSJSONSerialization dataWithJSONObject:jobject options:0 error:&error];
            NSString *jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
            NSString *res = [NSString stringWithFormat:@"%@:%@", hash, jsonString ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
        }
    }];
}

void _GetProfileAvatar(char* _hash){
    __block NSString* hash = CreateNSString(_hash);
    [[[MDPClientHandler sharedInstance] getFanHandler] getProfileAvatarWithIdUser:IdUser completionBlock:^(MDPProfileAvatarModel *content, NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
        } else {
            NSMutableDictionary*jobject = [[NSMutableDictionary alloc] init];
            
            [jobject setObject:content.pictureUrl forKey:@"PictureUrl"];
            NSMutableArray *jArray = [[NSMutableArray alloc]init];
            for( MDPProfileAvatarItemModel *ent in [content physicalProperties]){
                NSMutableDictionary *entry = [[NSMutableDictionary alloc] init];
                [entry setObject:ent.data forKey:@"Data"];
                [entry setObject:ent.type forKey:@"Type"];
                [entry setObject:ent.version forKey:@"Version"];
                [jArray addObject:entry];
            }
            [jobject setObject:jArray forKey:@"PhysicalProperties"];
            
            jArray = [[NSMutableArray alloc]init];
            for( MDPProfileAvatarAccessoryItemModel *ent in [content accesories]){
                NSMutableDictionary *entry = [[NSMutableDictionary alloc] init];
                [entry setObject:ent.data forKey:@"Data"];
                [entry setObject:ent.type forKey:@"Type"];
                [entry setObject:ent.version forKey:@"Version"];
                [entry setObject:ent.idVirtualGood forKey:@"IdVirtualGood"];
                [jArray addObject:entry];
            }
            [jobject setObject:jArray forKey:@"Accesories"];
            
            NSError	*error		= nil;
            NSData *jsonData = [NSJSONSerialization dataWithJSONObject:jobject options:0 error:&error];
            NSString *jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
            NSString *res = [NSString stringWithFormat:@"%@:%@", hash, jsonString ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
        }
    }];
}

void _SetProfileAvatar(char* json, char* _hash){
    NSError *jsonError;
    NSData *objectData = [CreateNSString(json) dataUsingEncoding:NSUTF8StringEncoding];
    NSDictionary *jDictionary = [NSJSONSerialization JSONObjectWithData:objectData options:NSJSONReadingMutableContainers
                                                                  error:&jsonError];
    __block NSString* hash = CreateNSString(_hash);
    MDPProfileAvatarUpdateableModel* paum = [[MDPProfileAvatarUpdateableModel alloc]init];
    for(NSDictionary *item in jDictionary[@"PhysicalProperties"]){
        [paum addPhysicalPropertyWithType:item[@"Type"] version:item[@"Version"] data:item[@"Data"]];
    }
    
    for(NSDictionary *item in jDictionary[@"Accesories"]){
        [paum addAccesoryWithIdVirtualGood:item[@"IdVirtualGood"] type:item[@"Type"] version:item[@"Version"] data:item[@"Data"]];
    }
    
    [[[MDPClientHandler sharedInstance] getFanHandler] updateProfileAvatarWithProfileAvatarUpdateable:paum completionBlock:^(NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
            
        } else {
            NSString *res = [NSString stringWithFormat:@"%@:ProfileAvatarSeted", hash ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
        }
    }];
}


void _CheckAlias(char* nick, char* _hash){
    __block NSString* hash = CreateNSString(_hash);
    [[[MDPClientHandler sharedInstance] getIdentityHandler] getCheckAliasWithAlias:CreateNSString(nick)                                                                   completionBlock:^(BOOL isAvailable, NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
            
        } else {
            NSString *res = [NSString stringWithFormat:@"%@:%@", hash, isAvailable ? @"true" : @"false" ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
        }
    }];
}

void _UpdateAlias(char* nick, char* _hash){
    __block NSString* hash = CreateNSString(_hash);
    [[[MDPClientHandler sharedInstance] getIdentityHandler] putUpdateAliasWithNewAlias:CreateNSString(nick)                                                                       completionBlock:^(NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
            
        } else {
            NSString *res = [NSString stringWithFormat:@"%@:AliasUpdated", hash ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
        }
    }];
}

void _SendAvatarImage(int length, Byte* array, char* _hash){
    __block NSString* hash = CreateNSString(_hash);
    NSData* data = [NSData dataWithBytes:array length:length];
    UIImage* image = [UIImage imageWithData:data];
    
    [[[MDPClientHandler sharedInstance] getFanHandler] putProfileAvatarPictureWithImage:(UIImage *)image                                                                      completionBlock:^(NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
            
        } else {
            NSString *res = [NSString stringWithFormat:@"%@:AvatarImageSent", hash ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
        }
    }];
}

void _SendScore(char* IDMinigame, int score, char* _hash){
    __block NSString* hash = CreateNSString(_hash);
    [[[MDPClientHandler sharedInstance] getScoreRankingHandler] postScoreWithIdGame:CreateNSString(IDMinigame) idScore:score completionBlock:^(NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
            
        } else {
            NSString *res = [NSString stringWithFormat:@"%@:ScoreSent", hash ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
        }
    }];
}

void _GetMaxScore(char* IDMinigame, char* _hash){
    __block NSString* hash = CreateNSString(_hash);
    [[[MDPClientHandler sharedInstance] getScoresHandler] getFanMaxScoreWithIdGame:CreateNSString(IDMinigame) completionBlock:^(MDPFanMaxScoreModel *content, NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
            
        } else {
			NSMutableDictionary *jobject = [[NSMutableDictionary alloc] init];
            [jobject setObject:content.score forKey:@"Score"];
			NSError	*error		= nil;
            NSData *jsonData = [NSJSONSerialization dataWithJSONObject:jobject options:0 error:&error];
            NSString *jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
            NSString *res = [NSString stringWithFormat:@"%@:%@", hash, jsonString ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
        }
    }];
}

void _GetRanking(char* IDMinigame, char* _hash){
    NSLog(@"_GetRanking >>[%@]",CreateNSString(IDMinigame));
    __block NSString* hash = CreateNSString(_hash);
    [[[MDPClientHandler sharedInstance] getScoreRankingHandler] getTopScoresWithIdGame:CreateNSString(IDMinigame) completionBlock:^(NSArray *response, NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
            
        } else {
            NSLog(@"_GetRanking >>[%@]", response);
            /*
             NSMutableArray *jobject = [[NSMutableArray alloc] init];
             for(MDPVirtualGoodModel *entry in content.results ){
             NSMutableDictionary* jent = [[NSMutableDictionary alloc] init];
             [jent setObject:entry.p forKey:<#(nonnull id<NSCopying>)#>.Add("Position", entry.Position);
             ele.Add("Alias", entry.Alias);
             ele.Add("Score", entry.Score);
             ele.Add("AvatarUrl", entry.AvatarUrl);
             ele.Add("IsCurrentUser", entry.IsCurrentUser);
             jobject.Add(ele);
             }
             */
        }
    }];
    
}


// Virtual Goods ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void _GetVirtualGoods(char*  type, char*  language, int page, char*  subtype, bool onlyPurchasables, char*  _hash){
    __block NSString* hash = CreateNSString(_hash);
    [[[MDPClientHandler sharedInstance] getVirtualGoodsHandler] getVirtualGoodsByTypeWithIdType:CreateNSString(type) ct:page language:CreateNSString(language) idSubType:nil onlyPurchasables:onlyPurchasables completionBlock:^(MDPPagedVirtualGoodModel *content, NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
            
        } else {
            NSMutableDictionary*jobject = [[NSMutableDictionary alloc] init];
            NSMutableArray *jreponse = [[NSMutableArray alloc] init];
            for(MDPVirtualGoodModel *entry in content.results ){
                NSMutableDictionary *jentry = [[NSMutableDictionary alloc] init];
                [jentry setObject:entry.enabled forKey:@"Enabled"];
                [jentry setObject:entry.idVirtualGood forKey:@"IdVirtualGood"];
                [jentry setObject:entry.idSubType forKey:@"IdSubType"];
                [jentry setObject:entry.thumbnailUrl forKey:@"ThumbnailUrl"];
                [jentry setObject:entry.pictureUrl forKey:@"PictureUrl"];
                [jentry setObject:GetLocalization([entry descriptionVirtualGood]) forKey:@"Description"];
                
                NSMutableArray *ma = [[NSMutableArray alloc]init];
                for( MDPProductPriceModel *ent in [entry price]){
                    NSMutableDictionary *entry = [[NSMutableDictionary alloc] init];
                    [entry setObject:ent.userType forKey:@"UserType"];
                    [entry setObject:ent.coinType forKey:@"CoinType"];
                    [entry setObject:ent.price forKey:@"Price"];
                    [ma addObject:entry];
                }
                [jentry setObject:ma forKey:@"Price"];
                [jreponse addObject:jentry];
            }
            [jobject setObject:content.currentPage forKey:@"CurrentPage"];
            [jobject setObject:[NSNumber numberWithBool:[content.hasMoreResults intValue]==1] forKey:@"HasMoreResults"];
            [jobject setObject:content.pageCount forKey:@"PageCount"];
            [jobject setObject:content.pageSize forKey:@"PageSize"];
            [jobject setObject:content.totalItems forKey:@"TotalItems"];
            [jobject setObject:jreponse forKey:@"Results"];
            NSError	*error		= nil;
            NSData *jsonData = [NSJSONSerialization dataWithJSONObject:jobject options:0 error:&error];
            NSString *jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
            NSString *res = [NSString stringWithFormat:@"%@:%@", hash, jsonString ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
            
        }
    }];
}

void _GetVirtualGoodsPurchased(char* type, char* language, char* token, char* _hash){
    __block NSString* hash = CreateNSString(_hash);
    [[[MDPClientHandler sharedInstance] getFanHandler] getFanVirtualGoodsByTypeWithType:CreateNSString(type) ct:token!=NULL?CreateNSString(token):nil language:CreateNSString(language)  completionBlock:^(MDPPagedFanVirtualGoodsModel *content, NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
            
        } else {
            NSMutableDictionary*jobject = [[NSMutableDictionary alloc] init];
            NSMutableArray *jreponse = [[NSMutableArray alloc] init];
            for(MDPFanVirtualGoodModel *entry in content.results ){
                NSMutableDictionary *jentry = [[NSMutableDictionary alloc] init];
                [jentry setObject:entry.idVirtualGood forKey:@"IdVirtualGood"];
                [jentry setObject:entry.thumbnailUrl forKey:@"ThumbnailUrl"];
                [jentry setObject:entry.pictureUrl forKey:@"PictureUrl"];
                [jreponse addObject:jentry];
            }
            //[jobject setObject:content.continuationToken forKey:@"ContinuationToken"];
            [jobject setObject:content.continuationTokenB64 forKey:@"ContinuationTokenB64"];
            [jobject setObject:[NSNumber numberWithBool:[content.hasMoreResults intValue]==1] forKey:@"HasMoreResults"];
            [jobject setObject:jreponse forKey:@"Results"];
            NSError	*error		= nil;
            NSData *jsonData = [NSJSONSerialization dataWithJSONObject:jobject options:0 error:&error];
            NSString *jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
            NSString *res = [NSString stringWithFormat:@"%@:%@", hash, jsonString ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
        }
    }];
}

void _PurchaseVirtualGood(char* IDVirtualGood, char* _hash){
    __block NSString* hash = CreateNSString(_hash);
    NSArray* array = [[NSArray alloc] initWithObjects: CreateNSString(IDVirtualGood),nil];
    [[[MDPClientHandler sharedInstance] getPurchasesHandler] postRedeemVirtualGoodsWithArrayIdVirtualGoods: array completionBlock:^(NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
            
        } else {
            NSString *res = [NSString stringWithFormat:@"%@:VirtualGoodPurchased", hash ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
        }
    }];
}

// Achievements ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void _GetAchievements(char* type, char* language, char* _hash){
    __block NSString* hash = CreateNSString(_hash);
    
    [[[MDPClientHandler sharedInstance] getAchivementsHandler] getAchivementsWithAchievementConfigurationType: CreateNSString(type) language:CreateNSString(language) completionBlock:^(NSArray *response, NSError *error){
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
            
        } else {
            NSMutableArray *jobject = [[NSMutableArray alloc] init];
            for(MDPAchievementConfigurationModel *entry in response ){
                NSMutableDictionary *jentry = [[NSMutableDictionary alloc] init];
                [jentry setObject:entry.idAchievement forKey:@"IdAchievement"];
                [jentry setObject:entry.name forKey:@"Name"];
                [jentry setObject:entry.points forKey:@"Points"];
                [jentry setObject:entry.level forKey:@"Level"];
                [jentry setObject:entry.imageUrl forKey:@"ImageUrl"];
                [jentry setObject:GetLocalization([entry descriptionAchievementConfiguration]) forKey:@"Description"];
                [jentry setObject:GetLocalization([entry levelName]) forKey:@"LevelName"];
                [jobject addObject:jentry];
            }
            NSError	*error		= nil;
            NSData *jsonData = [NSJSONSerialization dataWithJSONObject:jobject options:0 error:&error];
            NSString *jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
            NSString *res = [NSString stringWithFormat:@"%@:%@", hash, jsonString ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
        }
    }];
}

void _GetAchievementsEarned(char* type, char* language, char* token, char* _hash){
    __block NSString* hash = CreateNSString(_hash);
    [[[MDPClientHandler sharedInstance] getFanHandler] getFanAchievementsByTypeWithType:CreateNSString(type) ct:token!=NULL?CreateNSString(token):nil language:CreateNSString(language) completionBlock:^(MDPPagedAchievementsModel *content, NSError *error){
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
            
        } else {
            NSMutableDictionary*jobject = [[NSMutableDictionary alloc] init];
            NSMutableArray *jreponse = [[NSMutableArray alloc] init];
            for(MDPAchievementModel *entry in content.results ){
                NSMutableDictionary *jentry = [[NSMutableDictionary alloc] init];
                [jentry setObject:entry.idAchievement forKey:@"IdAchievement"];
                [jentry setObject:entry.level forKey:@"Level"];
                [jreponse addObject:jentry];
            }
            //[jobject setObject:content.continuationToken forKey:@"ContinuationToken"];
            [jobject setObject:content.continuationTokenB64 forKey:@"ContinuationTokenB64"];
            [jobject setObject:[NSNumber numberWithBool:[content.hasMoreResults intValue]==1] forKey:@"HasMoreResults"];
            [jobject setObject:jreponse forKey:@"Results"];
            NSError	*error		= nil;
            NSData *jsonData = [NSJSONSerialization dataWithJSONObject:jobject options:0 error:&error];
            NSString *jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
            NSString *res = [NSString stringWithFormat:@"%@:%@", hash, jsonString ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
        }
    }];
}

// Contents ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void _GetContents(char* type, int page, char* language, char* _hash){
    __block NSString* hash = CreateNSString(_hash);
    [[[MDPClientHandler sharedInstance] getContentsHandler] getContentItemsByTypeWithUseCache:NO type:MDPContentModelContentTypeUseAlternativeIfAny alternativeType:CreateNSString(type) language:CreateNSString(language) ct:page completionBlock:^(MDPPagedCompactContentModel *content, NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
        } else {
            NSMutableDictionary* jobject = [[NSMutableDictionary alloc] init];
            NSMutableArray* jresults = [[NSMutableArray alloc] init];
            NSMutableDictionary* jentry;
            for(MDPCompactContentModel *entry in content.results ){
                jentry = [[NSMutableDictionary alloc] init];
                [jentry setObject:entry.idContent  forKey:@"IdContent"];
                [jentry setObject:entry.title  forKey:@"Title"];
                [jentry setObject:entry.descriptionCompactContent  forKey:@"Description"];
                
                NSMutableArray *ma = [[NSMutableArray alloc]init];
                NSMutableDictionary *jtemp;
                for( MDPContentLinkModel *ent in [entry links ]){
                    jtemp = [[NSMutableDictionary alloc] init];
                    [jtemp setObject:ent.text forKey:@"Text"];
                    [jtemp setObject:ent.url forKey:@"Url"];
                    [ma addObject:jtemp];
                }
                [jentry setObject:ma forKey:@"Links"];
                MDPAssetModel* asset =[entry asset];
                if( asset!=nil){
                    jtemp = [[NSMutableDictionary alloc] init];
                    [jtemp setObject:asset.assetUrl forKey:@"AssetUrl"];
                    [jtemp setObject:asset.thumbnailUrl forKey:@"ThumbnailUrl"];
                    [jtemp setObject:asset.typeAsset forKey:@"Type"];
                    [jentry setObject:jtemp forKey:@"Asset"];
                    
                }
                [jresults addObject:jentry];
            }
            [jobject setObject:content.currentPage forKey:@"CurrentPage"];
            [jobject setObject:[NSNumber numberWithBool:[content.hasMoreResults intValue]==1] forKey:@"HasMoreResults"];
            [jobject setObject:content.pageCount forKey:@"PageCount"];
            [jobject setObject:content.pageSize forKey:@"PageSize"];
            [jobject setObject:content.totalItems forKey:@"TotalItems"];
            [jobject setObject:jresults forKey:@"Results"];
            NSError	*error		= nil;
            NSData *jsonData = [NSJSONSerialization dataWithJSONObject:jobject options:0 error:&error];
            NSString *jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
            NSString *res = [NSString stringWithFormat:@"%@:%@", hash, jsonString ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
        }
    }];
}

void _GetContent(char* IDContent, char* _hash){
    __block NSString* hash = CreateNSString(_hash);
    [[[MDPClientHandler sharedInstance] getContentsHandler] getContentItemWithIdContent:CreateNSString(IDContent) completionBlock:^(MDPContentModel *content, NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
        } else {
            NSMutableDictionary* jobject = [[NSMutableDictionary alloc] init];
            [jobject setObject:content.sourceId forKey:@"SourceId"];
            NSMutableArray *ma = [[NSMutableArray alloc]init];
            NSMutableDictionary *jtemp;
            for( MDPAssetModel *ent in [content assets ]){
                jtemp = [[NSMutableDictionary alloc] init];
                [jtemp setObject:ent.typeAsset forKey:@"Type"];
                [jtemp setObject:ent.assetUrl forKey:@"AssetUrl"];
                [ma addObject:jtemp];
            }
            [jobject setObject:ma forKey:@"Assets"];
            
            for( MDPContentParagraphModel *ent in [content body ]){
                jtemp = [[NSMutableDictionary alloc] init];
                [jtemp setObject:ent.title forKey:@"Title"];
                [jtemp setObject:ent.body forKey:@"Body"];
                [ma addObject:jtemp];
            }
            [jobject setObject:ma forKey:@"Body"];
            NSError	*error		= nil;
            NSData *jsonData = [NSJSONSerialization dataWithJSONObject:jobject options:0 error:&error];
            NSString *jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
            NSString *res = [NSString stringWithFormat:@"%@:%@", hash, jsonString ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
        }
    }];
}

// Gamificación ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void _GamificationStatus(char* language, char* _hash){
    __block NSString* hash = CreateNSString(_hash);
    [[[MDPClientHandler sharedInstance] getFanHandler] getFanGamificationStatusWithLanguage: CreateNSString(language) completionBlock:^(MDPGamificationStatusModel *content, NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
        } else {
            NSMutableDictionary* jobject = [[NSMutableDictionary alloc] init];
            [jobject setObject:content.points forKey:@"Points"];
            [jobject setObject:content.gamingScore forKey:@"GamingScore"];
            [jobject setObject:content.levelNumber forKey:@"LevelNumber"];
            
            NSError	*error		= nil;
            NSData *jsonData = [NSJSONSerialization dataWithJSONObject:jobject options:0 error:&error];
            NSString *jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
            NSString *res = [NSString stringWithFormat:@"%@:%@", hash, jsonString ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
        }
    }];
}

void _SendAction(char* IDAction, char* _hash){
    __block NSString* hash = CreateNSString(_hash);
    [[[MDPClientHandler sharedInstance] getUserActionsHandler] postUserActionWithActionId:CreateNSString(IDAction) contextData:nil completionBlock:^(NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
            
        } else {
            NSString *res = [NSString stringWithFormat:@"%@:ActionSent", hash ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
        }
    }];
}

// InApp Purchases ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void _InAppPurchase(char* IDProduct, char* Receipt, char* _hash){
    __block NSString* hash = CreateNSString(_hash);
    
    [[[MDPClientHandler sharedInstance] getPurchasesHandler] postPurchaseWithIdProduct:CreateNSString(IDProduct) receipt:CreateNSString(Receipt) useVirtualGoods:NO completionBlock:^(NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
            
        } else {
            NSString *res = [NSString stringWithFormat:@"%@:PurchasePosted", hash ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
        }
    }];
}