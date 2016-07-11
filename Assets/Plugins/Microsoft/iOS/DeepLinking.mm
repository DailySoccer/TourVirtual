#import <UIKit/UIKit.h>
#import "UnityAppController.h"
#import "UI/UnityView.h"

#import <FBSDKCoreKit/FBSDKCoreKit.h>

extern "C" {
 void _ReceivedUrl(NSURL *url);   
}


@interface MyAppController : UnityAppController
{
}
@end

@implementation MyAppController

-(BOOL)application:(UIApplication *)application openURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication annotation:(id)annotation{
    // OJO que llegara el tema del SS.
    if( [[url scheme] isEqualToString:@"rmvt"] ){
        UnitySendMessage("Azure Services", "SetDeepLinking", [[url absoluteString] cStringUsingEncoding:[NSString defaultCStringEncoding]] );
        return YES;
    }else
    if( [[url scheme] isEqualToString:@"testsso"] ){
        _ReceivedUrl(url);
        return YES;
    }
    
    return [[FBSDKApplicationDelegate sharedInstance] application:application openURL:url sourceApplication:sourceApplication annotation:annotation];}
@end

IMPL_APP_CONTROLLER_SUBCLASS(MyAppController)