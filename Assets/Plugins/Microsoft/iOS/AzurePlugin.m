@import MDPClient;

char* cStringCopy(const char* string)
{
    if (string == NULL)
        return NULL;
    
    char* res = (char*)malloc(strlen(string) + 1);
    strcpy(res, string);
    
    return res;
}

// This takes a char* you get from Unity and converts it to an NSString* to use in your objective c code. You can mix c++ and objective c all in the same file.
static NSString* CreateNSString(const char* string)
{
    if (string != NULL)
        return [NSString stringWithUTF8String:string];
    else
        return [NSString stringWithUTF8String:""];
}


void _AzureInit(char* enviroment, char* idclient, char* extraQueryParametersSignIn, char* extraQueryParametersSignUp){
    [[MDPClientHandler sharedInstance]	initWithEnvironment:CreateNSString(enviroment)
                                                  idClient:CreateNSString(idclient)
                                                 debugMode:true
                                extraQueryParametersSignIn:CreateNSString(extraQueryParametersSignIn)
                                extraQueryParametersSignUp:CreateNSString(extraQueryParametersSignUp)];
}

void _AzureSignUp()
{
    [MDPAuthHandler sharedInstance].showUserSelectionScreenBlock = ^(MDPAuthHandler *authHandler) {
        [[MDPAuthHandler sharedInstance] userSelectedOption:MDPAuthHandlerUserSelectionOptionSignUp];
    };
    
    [[MDPAuthHandler sharedInstance] getAccesTokenWithCompletionBlock:^ void (NSError *error){
        if(error){
            UnitySendMessage("Azure Services", "OnToken", "Error");
        }else{
            UnitySendMessage("Azure Services", "OnToken", [[[MDPAuthHandler sharedInstance] getToken] UTF8String]);
        }
    }];
}

void _AzureSignIn()
{
    [MDPAuthHandler sharedInstance].showUserSelectionScreenBlock = ^(MDPAuthHandler *authHandler) {
        [[MDPAuthHandler sharedInstance] userSelectedOption:MDPAuthHandlerUserSelectionOptionSignIn];
    };
    
    [[MDPAuthHandler sharedInstance] getAccesTokenWithCompletionBlock:^ void (NSError *error){
        if(error){
            UnitySendMessage("Azure Services", "OnToken", "Error");
        }else{
            UnitySendMessage("Azure Services", "OnToken", [[[MDPAuthHandler sharedInstance] getToken] UTF8String]);
        }
        
    }];
}

void _AzureSignOut()
{
    
    [[MDPAuthHandler sharedInstance] cleanUpKeychain];
    NSHTTPCookieStorage *storage = [NSHTTPCookieStorage sharedHTTPCookieStorage];
    for (NSHTTPCookie *cookie in [storage cookies]) {
        [storage deleteCookie:cookie];
    }
}

void _AzureGetToken(){
    
    [[MDPAuthHandler sharedInstance] tokenSilentShowingUIIfNeededWithCompletionBlock:^(NSString *token, NSError *error) {
        if(error){
            UnitySendMessage("Azure Services", "OnTokenReceive", "Error");
        }else{
            UnitySendMessage("Azure Services", "OnTokenReceive", [token UTF8String]);
        }
        
    }];
}

void _OpenURL(char* url){
    NSString *customURL = CreateNSString(url);
    
    //if ([[UIApplication sharedApplication] canOpenURL:[NSURL URLWithString:customURL]])
    {
        [[UIApplication sharedApplication] openURL:[NSURL URLWithString:customURL]];
    }
}

char* _helloWorldString()
{
    // We can use NSString and go to the c string that Unity wants
    NSString *helloString = @"Hello World";
    // UTF8String method gets us a c string. Then we have to malloc a copy to give to Unity. I reuse a method below that makes it easy.
    return cStringCopy([helloString UTF8String]);
}
