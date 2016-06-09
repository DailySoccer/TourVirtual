//
//  MDPLogHandler.h
//  MDPClient
//
//  Created by Javier Ovejero on 16/2/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MDPServiceHandler.h"
#import "MDPFanModel.h"


#pragma mark - Constants
#define expirationCookieBetweenBackgroundAndForeground              30*60   // 30 minutes in seconds

// Properties: custom events
#define MDPUserId                                                   @"Mdp.UserId"
#define MDPClientId                                                 @"Mdp.ClientId"
#define MDPAppVersion                                               @"Mdp.AppVersion"
#define MDPLanguage                                                 @"Mdp.Language"
#define MDPCurrentSport                                             @"Mdp.CurrentSport"
#define MDPEventTime                                                @"Mdp.EventTime"
#define MDPEventName                                                @"Mdp.Apps.%@.%@"   // Mdp.Apps.{Platform}.<EventName>
#define MDPEventLevel                                               @"Mdp.EventLevel"
#define MDPEventType                                                @"Mdp.EventType"
#define MDPEventMessageEvent                                        @"Mdp.MessageEvent"
#define MDPNavigationSection                                        @"Mdp.NavigationSection"
#define MDPNavigationSubSection                                     @"Mdp.NavigationSubSection"
#define MDPModule                                                   @"Mdp.Module"
#define MDPMethodName                                               @"Mdp.MethodName"
#define MDPLineNumber                                               @"Mdp.LineNumber"
#define MDPDestinationNavigation                                    @"Mdp.DestinationNavigation"
#define MDPPurchaseStep                                             @"Mdp.PurchaseStep"
#define MDPPurchaseOrderId                                          @"Mdp.OrderId"
#define MDPPurchaseId                                               @"Mdp.PurchaseId"

#define MDPCurrentSportFootball                                     @"Football"
#define MDPCurrentSportBasketBall                                   @"Basketball"

// Event level
#define MDPEventLevelVerbose                                        @"Verbose"
#define MDPEventLevelInformation                                    @"Information"
#define MDPEventLevelWarning                                        @"Warning"
#define MDPEventLevelBusiness                                       @"Business"
#define MDPEventLevelError                                          @"Error"
#define MDPEventLevelCritical                                       @"Critical"

// Event type
#define MDPEventTypeBusiness                                        @"Business"
#define MDPEventTypeTechnical                                       @"Technical"


#pragma mark - Interface
@interface MDPLogHandler : MDPServiceHandler

@property (nonatomic, strong) NSString *userId;

+ (instancetype)sharedInstance;

/*
 Returns a cookie that should have the format:
 ai_session={SessionId}|{Session Acquisition}|{Session Expiration};ai_user={UserId}|{User Expiration}
 */
- (NSString *)cookie;
+ (NSString *)cookieName;
- (void)generateNewCookie;
- (void)changeUserId:(NSString *)userId;


/*
 Send messages, custom events: AppInsights
 */
+ (void)trackActionSignsUpWithCompletionBlock:(void(^)(NSError *error))completionBlock;

+ (void)trackActionUserParticipatesExternalChallengeWithIdExternalChallenge:(NSString *)idExternalChallenge
                                                            completionBlock:(void(^)(NSError *error))completionBlock;

+ (void)trackActionAppStartsWithEnabledPushNotifications:(BOOL)enabledPushNotifications
                                 pushNotificationHandler:(NSString *)pushNotificationHandler
                                         platformVersion:(NSString *)platformVersion
                                              deviceType:(MDPFanModelDeviceType)deviceType
                                         completionBlock:(void(^)(NSError *error))completionBlock;

+ (void)trackActionOpenAppConsecutivesDaysWithCompletionBlock:(void(^)(NSError *error))completionBlock;

+ (void)trackActionLoginAppWithCompletionBlock:(void(^)(NSError *error))completionBlock;

+ (void)trackActionWithActionId:(NSString *)actionId
                    contextData:(NSString *)contextData
                completionBlock:(void(^)(NSError *error))completionBlock;

+ (void)startLoggingWithInstrumentationKey:(NSString *)instrumentationKey;

- (void)setCommonPropertiesWithUserId:(NSString *)userId
                             clientId:(NSString *)clientId
                           appVersion:(NSString *)appVersion
                             language:(NSString *)language
                         currentSport:(NSString *)currentSport;

+ (void)trackEventWithName:(NSString *)eventName
                properties:(NSDictionary *)properties;

+ (void)trackEventWithName:(NSString *)eventName
                properties:(NSDictionary *)properties
               mesurements:(NSDictionary *)measurements;

+ (void)trackTraceWithMessage:(NSString *)message
                   properties:(NSDictionary *)properties;
+ (void)trackPageView:(NSString *)pageName
             duration:(long)duration
           properties:(NSDictionary *)properties;

+ (void)trackMetricWithName:(NSString *)metricName
                      value:(double)value
                 properties:(NSDictionary *)properties;

+ (NSString *)deviceIdentifier;

@end
