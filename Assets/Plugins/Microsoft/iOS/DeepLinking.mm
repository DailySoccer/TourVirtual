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
    NSLog( @"openURL %@", [url absoluteString] );
    _ReceivedUrl(url);
    return [[FBSDKApplicationDelegate sharedInstance] application:application openURL:url sourceApplication:sourceApplication annotation:annotation];}
@end

IMPL_APP_CONTROLLER_SUBCLASS(MyAppController)
