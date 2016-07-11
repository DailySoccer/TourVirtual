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
    
    // SDK Enviroment
    BOOL debugMode = YES;
    
#ifdef DEBUG
    debugMode = YES;
#endif
    
    [[MDPClientHandler sharedInstance] initWithEnvironment:CreateNSString(enviroment) idClient:IdClient debugMode:debugMode extraQueryParametersCombined:CreateNSString(extraQueryParametersSignIn)];
}

void _AzureSignIn(){
//    NSURL *url = [NSURL URLWithString:[[NSString stringWithFormat:@"rmapp://single_sign_on?Parameters={\"ClientId\":\"%@\",\"TemporaryHash\":\"12345\"}",IdClient] stringByAddingPercentEscapesUsingEncoding:NSUTF8StringEncoding]];
  
        NSURL *url = [NSURL URLWithString:[@"rmapp://single_sign_on?Parameters={\"ClientId\":\"f5ac1331-0476-4844-b7de-34faab315d7d\",\"TemporaryHash\":\"12345\"}" stringByAddingPercentEscapesUsingEncoding:NSUTF8StringEncoding]];
    if ([[UIApplication sharedApplication] canOpenURL:url]) {
        [[UIApplication sharedApplication] openURL:url];
    } else {
        NSLog(@"Cannot open url");
    }
}

NSMutableDictionary *_DictionaryOfResult(NSURL *url)
{
    NSArray *subComponents = [[url absoluteString] componentsSeparatedByString:@"?"];
    
    NSString *urlString = subComponents.lastObject;
    
    NSMutableDictionary *queryStringDictionary = [[NSMutableDictionary alloc] init];
    NSArray *urlComponents = [urlString componentsSeparatedByString:@"&"];
    
    for (NSString *keyValuePair in urlComponents)
    {
        NSArray *pairComponents = [keyValuePair componentsSeparatedByString:@"="];
        NSString *key = [[pairComponents firstObject] stringByRemovingPercentEncoding];
        NSString *value = [[pairComponents lastObject] stringByRemovingPercentEncoding];
        
        value = [value stringByReplacingOccurrencesOfString:@"\"" withString:@""];
        
        [queryStringDictionary setObject:value forKey:key];
    }
    
    return queryStringDictionary;
}

void _ReceivedUrl(NSURL *url)
{
    NSDictionary *parameters = _DictionaryOfResult(url);
    
    NSString *errorMessage = parameters[@"ErrorMessage"];
    NSNumber *allowed = parameters[@"Allowed"];
    
    if (errorMessage.length) {
        UnitySendMessage("Azure Services", "OnSignInEvent", "KO");
    } else {
        
        
        if (!allowed.boolValue) {
            UnitySendMessage("Azure Services", "OnSignInEvent", "KO");
        } else {
            [[[MDPClientHandler sharedInstance] getSingleSignOnHandler] getTokenCacheByAuthorizationCodeWithAuthorizationCode:parameters[@"AuthorizationCode"] password:@"12345" completionBlock:^(NSError *error){
                if (error) {
                    UnitySendMessage("Azure Services", "OnSignInEvent", "KO");
                } else {
                    UnitySendMessage("Azure Services", "OnSignInEvent", "OK");
                }
            }];
        }
    }
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
    __block NSString* hash = CreateNSString(_hash);
    NSString *res = [NSString stringWithFormat:@"%@:OK", hash ];
    UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
}

void _GetFanMe(char* _hash){
    __block NSString* hash = CreateNSString(_hash);
    [[[MDPClientHandler sharedInstance] getFanHandler] getFanWithUseCache:YES completionBlock:^(MDPFanModel *content, NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
            
        } else {
            NSMutableDictionary* jobject = [[NSMutableDictionary alloc] init];
            if(content!=nil){
                [jobject setObject:content.idUser forKey:@"IdUser"];
                [jobject setObject:content.alias forKey:@"Alias"];
                [jobject setObject:content.language forKey:@"Language"];
            }
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
            if(content!=nil){
                [jobject setObject:content.pictureUrl forKey:@"PictureUrl"];
                NSMutableArray *jArray = [[NSMutableArray alloc]init];
                if([content physicalProperties]!=nil){
                    for( MDPProfileAvatarItemModel *ent in [content physicalProperties]){
                        NSMutableDictionary *entry = [[NSMutableDictionary alloc] init];
                        [entry setObject:ent.data forKey:@"Data"];
                        [entry setObject:ent.type forKey:@"Type"];
                        [entry setObject:ent.version forKey:@"Version"];
                        [jArray addObject:entry];
                    }
                }
                [jobject setObject:jArray forKey:@"PhysicalProperties"];
                
                jArray = [[NSMutableArray alloc]init];
                if([content accesories]!=nil){
                    for( MDPProfileAvatarAccessoryItemModel *ent in [content accesories]){
                        NSMutableDictionary *entry = [[NSMutableDictionary alloc] init];
                        [entry setObject:ent.data forKey:@"Data"];
                        [entry setObject:ent.type forKey:@"Type"];
                        [entry setObject:ent.version forKey:@"Version"];
                        [entry setObject:ent.idVirtualGood forKey:@"IdVirtualGood"];
                        [jArray addObject:entry];
                    }
                }
                [jobject setObject:jArray forKey:@"Accesories"];
            }
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

void _CreateProfileAvatar(char* json, char* _hash){
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
    
    [[[MDPClientHandler sharedInstance] getFanHandler] createProfileAvatarWithProfileAvatarUpdateable:paum completionBlock:^(NSError *error) {
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
    [[[MDPClientHandler sharedInstance] getScoreRankingHandler] postScoreWithIdGame:CreateNSString(IDMinigame) idScore:score completionBlock:^(NSArray *response, NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
        } else {
            NSMutableArray *jobject = [[NSMutableArray alloc] init];
            if(response!=nil){
                for(MDPScoreRankingModel *entry in response ){
                    NSMutableDictionary* jent = [[NSMutableDictionary alloc] init];
                    [jent setObject:entry.position forKey:@"Position"];
                    [jent setObject:entry.alias forKey:@"Alias"];
                    [jent setObject:entry.score forKey:@"Score"];
                    [jent setObject:[NSNumber numberWithBool:[entry.isCurrentUser intValue]==1] forKey:@"IsCurrentUser"];
                    [jobject addObject:jent];
                }
            }
            NSError	*error		= nil;
            NSData *jsonData = [NSJSONSerialization dataWithJSONObject:jobject options:0 error:&error];
            NSString *jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
            NSString *res = [NSString stringWithFormat:@"%@:%@", hash, jsonString ];
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
            if(content!=nil) [jobject setObject:content.score forKey:@"Score"];
            else [jobject setObject: (NSInteger) 0 forKey:@"Score"];
            NSError	*error		= nil;
            NSData *jsonData = [NSJSONSerialization dataWithJSONObject:jobject options:0 error:&error];
            NSString *jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
            NSString *res = [NSString stringWithFormat:@"%@:%@", hash, jsonString ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
        }
    }];
}

void _GetRanking(char* IDMinigame, char* _hash){
    __block NSString* hash = CreateNSString(_hash);
    [[[MDPClientHandler sharedInstance] getScoreRankingHandler] getTopScoresWithIdGame:CreateNSString(IDMinigame) completionBlock:^(NSArray *response, NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
            
        } else {
            NSMutableArray *jobject = [[NSMutableArray alloc] init];
            if(response!=nil){
                for(MDPScoreRankingModel *entry in response ){
                    NSMutableDictionary* jent = [[NSMutableDictionary alloc] init];
                    [jent setObject:entry.position forKey:@"Position"];
                    [jent setObject:entry.alias forKey:@"Alias"];
                    [jent setObject:entry.score forKey:@"Score"];
                    [jent setObject:[NSNumber numberWithBool:[entry.isCurrentUser intValue]==1] forKey:@"IsCurrentUser"];
                    [jobject addObject:jent];
                }
            }
            NSError	*error		= nil;
            NSData *jsonData = [NSJSONSerialization dataWithJSONObject:jobject options:0 error:&error];
            NSString *jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
            NSString *res = [NSString stringWithFormat:@"%@:%@", hash, jsonString ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
        }
    }];
}

void _GetFanRanking(char* _hash){
    __block NSString* hash = CreateNSString(_hash);
    [[[MDPClientHandler sharedInstance] getRankingHandler] getCurrentUserRankingWithCompletionBlock:^(NSArray *response, NSError *error) {
        if (error) {
            NSString *res = [NSString stringWithFormat:@"%@:%d:%@", hash, [error code], [error localizedDescription ] ];
            UnitySendMessage("Azure Services", "OnResponseKO", [res UTF8String] );
            
        } else {
            NSMutableArray *jobject = [[NSMutableArray alloc] init];
            if(response!=nil){
                for(MDPExperienceRankingModel *entry in response ){
                    NSMutableDictionary* jent = [[NSMutableDictionary alloc] init];
                    [jent setObject:entry.position forKey:@"Position"];
                    [jent setObject:entry.alias forKey:@"Alias"];
                    [jent setObject:entry.gamingScore forKey:@"GamingScore"];
                    [jent setObject:[NSNumber numberWithBool:[entry.isCurrentUser intValue]==1] forKey:@"IsCurrentUser"];
                    [jobject addObject:jent];
                }
            }
            NSError	*error		= nil;
            NSData *jsonData = [NSJSONSerialization dataWithJSONObject:jobject options:0 error:&error];
            NSString *jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
            NSString *res = [NSString stringWithFormat:@"%@:%@", hash, jsonString ];
            UnitySendMessage("Azure Services", "OnResponseOK", [res UTF8String] );
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
            if(content!=nil){
                NSMutableArray *results = [[NSMutableArray alloc] init];
                if(content.results!=nil){
                    for(MDPVirtualGoodModel *entry in content.results ){
                        NSMutableDictionary *jentry = [[NSMutableDictionary alloc] init];
                        [jentry setObject:[NSNumber numberWithBool:[entry.enabled intValue]==1] forKey:@"Enabled"];
                        [jentry setObject:entry.idVirtualGood forKey:@"IdVirtualGood"];
                        [jentry setObject:entry.idSubType forKey:@"IdSubType"];
                        [jentry setObject:entry.thumbnailUrl forKey:@"ThumbnailUrl"];
                        [jentry setObject:entry.pictureUrl forKey:@"PictureUrl"];
                        
                        NSMutableArray *description = [[NSMutableArray alloc]init];
                        if([entry descriptionVirtualGood]!=nil){
                            for( MDPLocaleDescriptionModel *loc in [entry descriptionVirtualGood]){
                                NSMutableDictionary *entry = [[NSMutableDictionary alloc] init];
                                [entry setObject:loc.locale forKey:@"Locale"];
                                [entry setObject:loc.descriptionLocaleDescription forKey:@"Description"];
                                [description addObject:entry];
                            }
                        }
                        [jentry setObject:description forKey:@"Description"];
                        
                        NSMutableArray *price = [[NSMutableArray alloc]init];
                        if([entry price]!=nil){
                            for( MDPProductPriceModel *ent in [entry price]){
                                NSMutableDictionary *entry = [[NSMutableDictionary alloc] init];
                                [entry setObject:ent.userType forKey:@"UserType"];
                                [entry setObject:ent.coinType forKey:@"CoinType"];
                                [entry setObject:ent.price forKey:@"Price"];
                                [price addObject:entry];
                            }
                        }
                        [jentry setObject:price forKey:@"Price"];
                        [results addObject:jentry];
                    }
                }
                [jobject setObject:content.currentPage forKey:@"CurrentPage"];
                [jobject setObject:[NSNumber numberWithBool:[content.hasMoreResults intValue]==1] forKey:@"HasMoreResults"];
                [jobject setObject:content.pageCount forKey:@"PageCount"];
                [jobject setObject:content.pageSize forKey:@"PageSize"];
                [jobject setObject:content.totalItems forKey:@"TotalItems"];
                [jobject setObject:results forKey:@"Results"];
            }
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
            if(content!=nil){
                NSMutableArray *results = [[NSMutableArray alloc] init];
                if(content.results!=nil){
                    for(MDPFanVirtualGoodModel *entry in content.results ){
                        NSMutableDictionary *jentry = [[NSMutableDictionary alloc] init];
                        [jentry setObject:entry.idVirtualGood forKey:@"IdVirtualGood"];
                        [jentry setObject:entry.thumbnailUrl forKey:@"ThumbnailUrl"];
                        [jentry setObject:entry.pictureUrl forKey:@"PictureUrl"];
                        [results addObject:jentry];
                    }
                }
                //[jobject setObject:content.continuationToken forKey:@"ContinuationToken"];ç
                if(content.continuationTokenB64!=nil) [jobject setObject:content.continuationTokenB64 forKey:@"ContinuationTokenB64"];
                else [jobject setObject:@"" forKey:@"ContinuationTokenB64"];
                [jobject setObject:[NSNumber numberWithBool:[content.hasMoreResults intValue]==1] forKey:@"HasMoreResults"];
                [jobject setObject:results forKey:@"Results"];
            }
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
            if(response!=nil){
                for(MDPAchievementConfigurationModel *entry in response ){
                    NSMutableDictionary *jentry = [[NSMutableDictionary alloc] init];
                    [jentry setObject:entry.idAchievement forKey:@"IdAchievement"];
                    [jentry setObject:entry.name forKey:@"Name"];
                    [jentry setObject:entry.points forKey:@"Points"];
                    [jentry setObject:entry.level forKey:@"Level"];
                    [jentry setObject:entry.imageUrl forKey:@"ImageUrl"];
                    
                    NSMutableArray *description = [[NSMutableArray alloc]init];
                    if([entry descriptionAchievementConfiguration]!=nil){
                        for( MDPLocaleDescriptionModel *loc in [entry descriptionAchievementConfiguration]){
                            NSMutableDictionary *entry = [[NSMutableDictionary alloc] init];
                            [entry setObject:loc.locale forKey:@"Locale"];
                            [entry setObject:loc.descriptionLocaleDescription forKey:@"Description"];
                            [description addObject:entry];
                        }
                    }
                    [jentry setObject:description forKey:@"Description"];
                    
                    NSMutableArray *levelName = [[NSMutableArray alloc]init];
                    if([entry levelName]!=nil){
                        for( MDPLocaleDescriptionModel *loc in [entry levelName]){
                            NSMutableDictionary *entry = [[NSMutableDictionary alloc] init];
                            [entry setObject:loc.locale forKey:@"Locale"];
                            [entry setObject:loc.descriptionLocaleDescription forKey:@"Description"];
                            [levelName addObject:entry];
                        }
                    }
                    [jentry setObject:levelName forKey:@"LevelName"];
                    [jobject addObject:jentry];
                }
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
            if(content!=nil){
                NSMutableArray *jreponse = [[NSMutableArray alloc] init];
                if(content.results!=nil){
                    for(MDPAchievementModel *entry in content.results ){
                        NSMutableDictionary *jentry = [[NSMutableDictionary alloc] init];
                        [jentry setObject:entry.idAchievement forKey:@"IdAchievement"];
                        [jentry setObject:entry.level forKey:@"Level"];
                        [jreponse addObject:jentry];
                    }
                }
                //[jobject setObject:content.continuationToken forKey:@"ContinuationToken"];
                if(content.continuationTokenB64!=nil) [jobject setObject:content.continuationTokenB64 forKey:@"ContinuationTokenB64"];
                else [jobject setObject:@"" forKey:@"ContinuationTokenB64"];
                [jobject setObject:[NSNumber numberWithBool:[content.hasMoreResults intValue]==1] forKey:@"HasMoreResults"];
                [jobject setObject:jreponse forKey:@"Results"];
            }
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
            if(content!=nil){
                NSMutableArray* jresults = [[NSMutableArray alloc] init];
                if(content.results!=nil){
                    NSMutableDictionary* jentry;
                    for(MDPCompactContentModel *entry in content.results ){
                        jentry = [[NSMutableDictionary alloc] init];
                        [jentry setObject:entry.idContent  forKey:@"IdContent"];
                        [jentry setObject:entry.title  forKey:@"Title"];
                        [jentry setObject:entry.descriptionCompactContent  forKey:@"Description"];
                        
                        NSMutableArray *links = [[NSMutableArray alloc]init];
                        if([entry links]!=nil){
                            NSMutableDictionary *jtemp;
                            for( MDPContentLinkModel *ent in [entry links]){
                                jtemp = [[NSMutableDictionary alloc] init];
                                [jtemp setObject:ent.text forKey:@"Text"];
                                [jtemp setObject:ent.url forKey:@"Url"];
                                [links addObject:jtemp];
                            }
                        }
                        [jentry setObject:links forKey:@"Links"];
                        
                        MDPAssetModel* asset =[entry asset];
                        if( asset!=nil){
                            NSMutableDictionary *jtemp;
                            jtemp = [[NSMutableDictionary alloc] init];
                            [jtemp setObject:asset.assetUrl forKey:@"AssetUrl"];
                            [jtemp setObject:asset.thumbnailUrl forKey:@"ThumbnailUrl"];
                            [jtemp setObject:asset.typeAsset forKey:@"Type"];
                            [jentry setObject:jtemp forKey:@"Asset"];
                            
                        }
                        [jresults addObject:jentry];
                    }
                }
                [jobject setObject:content.currentPage forKey:@"CurrentPage"];
                [jobject setObject:[NSNumber numberWithBool:[content.hasMoreResults intValue]==1] forKey:@"HasMoreResults"];
                [jobject setObject:content.pageCount forKey:@"PageCount"];
                [jobject setObject:content.pageSize forKey:@"PageSize"];
                [jobject setObject:content.totalItems forKey:@"TotalItems"];
                [jobject setObject:jresults forKey:@"Results"];
            }
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
            if(content!=nil){
                NSMutableDictionary *jtemp;
                [jobject setObject:content.sourceId forKey:@"SourceId"];
                NSMutableArray *assets = [[NSMutableArray alloc]init];
                if([content assets]!=nil){
                    for( MDPAssetModel *ent in [content assets]){
                        jtemp = [[NSMutableDictionary alloc] init];
                        [jtemp setObject:ent.typeAsset forKey:@"Type"];
                        [jtemp setObject:ent.assetUrl forKey:@"AssetUrl"];
                        [assets addObject:jtemp];
                    }
                }
                [jobject setObject:assets forKey:@"Assets"];
                
                NSMutableArray *body = [[NSMutableArray alloc]init];
                if([content body]!=nil){
                    for( MDPContentParagraphModel *ent in [content body]){
                        jtemp = [[NSMutableDictionary alloc] init];
                        [jtemp setObject:ent.title forKey:@"Title"];
                        [jtemp setObject:ent.body forKey:@"Body"];
                        [body addObject:jtemp];
                    }
                }
                [jobject setObject:body forKey:@"Body"];
            }
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
            if(content!=nil){
                [jobject setObject:content.points forKey:@"Points"];
                [jobject setObject:content.gamingScore forKey:@"GamingScore"];
                [jobject setObject:content.levelNumber forKey:@"LevelNumber"];
            }
            
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