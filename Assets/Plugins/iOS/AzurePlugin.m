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
    [[MDPClientHandler sharedInstance] initWithEnvironment:CreateNSString(enviroment) idClient:CreateNSString(idclient) debugMode:true extraQueryParametersSignIn:CreateNSString(extraQueryParametersSignIn) extraQueryParametersSignUp:CreateNSString(extraQueryParametersSignUp)];
    
    
}

void _AzureSignUp()
{
    
    // Start Auth Process
    [[MDPAuthHandler sharedInstance] tokenSilentShowingUIIfNeededWithCompletionBlock:^(NSString *token, NSError *error) {
        if(error){
            UnitySendMessage("Azure Services", "OnToken", "Error");
        }else{
            UnitySendMessage("Azure Services", "OnToken", [token UTF8String]);
        }

    }];
    
    [MDPAuthHandler sharedInstance].showUserSelectionScreenBlock = ^(MDPAuthHandler *authHandler) {
        [[MDPAuthHandler sharedInstance] userSelectedOption:MDPAuthHandlerUserSelectionOptionSignUp];
    };
    
}

void _AzureSignIn()
{
    // Start Auth Process
    [[MDPAuthHandler sharedInstance] tokenSilentShowingUIIfNeededWithCompletionBlock:^(NSString *token, NSError *error) {
        if(error){
            UnitySendMessage("Azure Services", "OnToken", "Error");
        }else{
            UnitySendMessage("Azure Services", "OnToken", [token UTF8String]);
        }

    }];
    
    [MDPAuthHandler sharedInstance].showUserSelectionScreenBlock = ^(MDPAuthHandler *authHandler) {
        [[MDPAuthHandler sharedInstance] userSelectedOption:MDPAuthHandlerUserSelectionOptionSignIn];
    };
}

void _AzureSignOut()
{
    
}

char* _helloWorldString()
{
    // We can use NSString and go to the c string that Unity wants
    NSString *helloString = @"Hello World";
    // UTF8String method gets us a c string. Then we have to malloc a copy to give to Unity. I reuse a method below that makes it easy.
    return cStringCopy([helloString UTF8String]);
}
