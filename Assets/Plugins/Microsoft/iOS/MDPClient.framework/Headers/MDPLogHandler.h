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
#define MDPAppVersion                                               @"Mdp.AppVersion"
#define MDPClientId                                                 @"Mdp.ClientId"
#define MDPCurrentSport                                             @"Mdp.CurrentSport"
#define MDPDestinationNavigation                                    @"Mdp.DestinationNavigation"
#define MDPEventLevel                                               @"Mdp.EventLevel"
#define MDPEventMessageEvent                                        @"Mdp.MessageEvent"
#define MDPEventName                                                @"Mdp.Apps.%@.%@"   // Mdp.Apps.{Platform}.<EventName>
#define MDPEventTime                                                @"Mdp.EventTime"
#define MDPEventType                                                @"Mdp.EventType"
#define MDPLanguage                                                 @"Mdp.Language"
#define MDPLineNumber                                               @"Mdp.LineNumber"
#define MDPMethodName                                               @"Mdp.MethodName"
#define MDPModule                                                   @"Mdp.Module"
#define MDPPurchaseId                                               @"Mdp.PurchaseId"
#define MDPPurchaseOrderId                                          @"Mdp.OrderId"
#define MDPPurchaseStep                                             @"Mdp.PurchaseStep"
#define MDPEventSequence                                            @"Mdp.EventSequence"
#define MDPTicks                                                    @"Mdp.Ticks"
#define MDPUserId                                                   @"Mdp.UserId"
#define MDPSessionId                                                @"Mdp.SessionId"


#define MDPCurrentSportFootball                                     @"Football"
#define MDPCurrentSportBasket                                       @"Basket"

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

// NavigationEvent
#define MDPTriggeredBy                                              @"Mdp.TriggeredBy"
#define MDPFromView                                                 @"Mdp.FromView"
#define MDPFromSection                                              @"Mdp.FromSection"
#define MDPFromSubsection                                           @"Mdp.FromSubsection"
#define MDPFromParams                                               @"Mdp.FromParams"
#define MDPFromPosition                                             @"Mdp.FromPosition"
#define MDPToView                                                   @"Mdp.ToView"
#define MDPToSection                                                @"Mdp.ToSection"
#define MDPToSubsection                                             @"Mdp.ToSubsection"
#define MDPToParams                                                 @"Mdp.ToParams"
#define MDPNavigationSection                                        @"Mdp.NavigationSection"

// ADImpresion
#define MDPAdAction                                                 @"Mdp.AdAction"
#define MDPAdType                                                   @"Mdp.AdType"
#define MDPIdAdvertisement                                          @"Mdp.IdAdvertisement"
#define MDPAdPosition                                               @"Mdp.AdPosition"
#define MDPOrderId                                                  @"Mdp.OrderId"
#define MDPView                                                     @"Mdp.View"
#define MDPSection                                                  @"Mdp.Section"
#define MDPSubsection                                               @"Mdp.SubSection"
#define MDPParams                                                   @"Mdp.Params"
#define MDPAdMultipleOrder                                          @"Mdp.AdMultipleOrder"

// Videos
#define MDPVideoAction                                              @"Mdp.VideoAction"
#define MDPVideoType                                                @"Mdp.VideoType"
#define MDPVideoURL                                                 @"Mdp.VideoURL"
#define MDPVideoId                                                  @"Mdp.VideoId"
#define MDPContentVideoType                                         @"Mdp.ContentVideoType"
#define MDPCompetitionType                                          @"Mdp.CompetitionType"
#define MDPIdCompetition                                            @"Mdp.IdCompetition"
#define MDPIdSeason                                                 @"Mdp.IdSeason"
#define MDPIdMatch                                                  @"Mdp.IdMatch"
#define MDPVideoLanguage                                            @"Mdp.VideoLanguage"
#define MDPSeason                                                   @"Mdp.Season"
#define MDPIdMatch                                                  @"Mdp.IdMatch"
#define MDPMainActors                                               @"Mdp.MainActors"
#define MDPMatchEventTypes                                          @"Mdp.MatchEventTypes"
#define MDPCamera                                                   @"Mdp.Camera"
#define MDPIdSubscription                                           @"Mdp.IdSubscription"
#define MDPChannelName                                              @"Mdp.ChannelName"
#define MDPEventId                                                  @"Mdp.EventId"
#define MDPVideoName                                                @"Mdp.VideoName"
#define MDPIdAdvertisement                                          @"Mdp.IdAdvertisement"


#pragma mark - Interface
@interface MDPLogHandler : MDPServiceHandler

@property (nonatomic, strong) NSString *userId;

+ (instancetype)sharedInstance;

#pragma mark - Sequence
// Gets sequence
- (NSInteger)sequenceGenerated;

// Increases sequence in 1
- (void)increaseSequence;

// Generates a new cookie with a randon userId
- (void)generateNewCookie;

// Regenerates a cookie, if the userId is nill, it generates a randon userId
- (void)regenerateCookie;

- (void)changeUserId:(NSString *)userId;
- (NSString *)sessionIdGenerated;

/*
 Returns a cookie that should have the format:
 ai_session={SessionId}|{Session Acquisition}|{Session Expiration};ai_user={UserId}|{User Expiration}
 */
- (NSString *)cookie;
+ (NSString *)cookieName;

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
