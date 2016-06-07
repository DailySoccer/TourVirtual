//
//  MDPClientHandler.h
//  MDPClient
//
//  Created by Javier Ovejero on 19/1/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#import <Foundation/Foundation.h>


#pragma mark - Protocols

#import "MDPLanguagesHandlerProtocol.h"
#import "MDPIdentityHandlerProtocol.h"
#import "MDPVirtualGoodsHandlerProtocol.h"
#import "MDPAdvertisementHandlerProtocol.h"
#import "MDPPenyasHandlerProtocol.h"
#import "MDPCalendarHandlerProtocol.h"
#import "MDPTeamHandlerProtocol.h"
#import "MDPNotificationsHandlerProtocol.h"
#import "MDPUserActionsHandlerProtocol.h"
#import "MDPAchievementsHandlerProtocol.h"
#import "MDPPlatformNotificationsHandlerProtocol.h"
#import "MDPContentsHandlerProtocol.h"
#import "MDPConfigurationHandlerProtocol.h"
#import "MDPCountriesHandlerProtocol.h"
#import "MDPCheckInHandlerProtocol.h"
#import "MDPBasketLiveMatchHandlerProtocol.h"
#import "MDPTagsHandlerProtocol.h"
#import "MDPFanHandlerProtocol.h"
#import "MDPFootballLiveMatchHandlerProtocol.h"
#import "MDPVideoHandlerProtocol.h"
#import "MDPExternalChallengesHandlerProtocol.h"
#import "MDPAppsHandlerProtocol.h"
#import "MDPMatchesHandlerProtocol.h"
#import "MDPPlayersHandlerProtocol.h"
#import "MDPResourcesHandlerProtocol.h"
#import "MDPPurchasesHandlerProtocol.h"
#import "MDPFriendsHandlerProtocol.h"
#import "MDPMessagesHandlerProtocol.h"
#import "MDPSubscriptionsHandlerProtocol.h"
#import "MDPInvitationsHandlerProtocol.h"
#import "MDPCommentsHandlerProtocol.h"
#import "MDPGroupsHandlerProtocol.h"
#import "MDPStoreProductsHandlerProtocol.h"
#import "MDPRankingHandlerProtocol.h"
#import "MDPScoreRankingHandlerProtocol.h"
#import "MDPScoresHandlerProtocol.h"
#import "MDPSingleSignOnHandlerProtocol.h"
#import "MDPPaidFansHandlerProtocol.h"
#import "MDPNetworkConstantsHandler.h"


#pragma mark - Environments
extern const struct MDPClientConstantsEnvironments {
    __unsafe_unretained NSString *preproduction;
    __unsafe_unretained NSString *production;
    __unsafe_unretained NSString *development;
    __unsafe_unretained NSString *staging_Production_EU;
    __unsafe_unretained NSString *staging_Production_AM;
    __unsafe_unretained NSString *staging_Production_AS;
    __unsafe_unretained NSString *production_EU;
    __unsafe_unretained NSString *production_AM;
    __unsafe_unretained NSString *production_AS;
    __unsafe_unretained NSString *preproduction_EU;
    __unsafe_unretained NSString *preproduction_AM;
    __unsafe_unretained NSString *preproduction_AS;
    __unsafe_unretained NSString *staging_Preproduction_EU;
    __unsafe_unretained NSString *staging_Preproduction_AM;
    __unsafe_unretained NSString *staging_Preproduction_AS;
    __unsafe_unretained NSString *test_EU;
    __unsafe_unretained NSString *test_AS;
    __unsafe_unretained NSString *mock;
    __unsafe_unretained NSString *qa;
}MDPClientConstantsEnvironments;


#pragma mark - Instrumentation Keys
#define InstrumentationKey_Production           @"7ffc0402-fff0-4484-8a38-d65dc4316916"
#define InstrumentationKey_Preproduction        @"c52a2d43-e19a-4326-8a54-ce89ee8fd18b"
#define InstrumentationKey_Development          @"f092c764-de69-406b-b6a6-00fd8d7ccf3e"
#define InstrumentationKey_QA                   @"f092c764-de69-406b-b6a6-00fd8d7ccf3e"


#pragma mark - Interface
@interface MDPClientHandler : NSObject

#pragma mark Singleton
+ (MDPClientHandler *)sharedInstance;
+ (void)createSharedInstance;
+ (void)destroySharedInstance;
+ (void)resetSharedInstance;


/** Auth system will ask the client app to show user UI for signIn/signUp
 @warning This method will be removed in the next version
 @deprecated Deprecated*/
 - (void)initWithEnvironment:(NSString *)environment idClient:(NSString *)idClient debugMode:(BOOL)debugMode __deprecated;

/** Auth system will automatically show signIn/signUp UI
*/
 - (void)initWithEnvironment:(NSString *)environment
                    idClient:(NSString *)idClient
                   debugMode:(BOOL)debugMode
extraQueryParametersCombined:(NSString *)extraQueryParametersCombined;

/** Auth system will ask the client app to show user UI for signIn/signUp
 */
- (void)initWithEnvironment:(NSString *)environment idClient:(NSString *)idClient
                  debugMode:(BOOL)debugMode
 extraQueryParametersSignIn:(NSString *)extraQueryParametersSignIn
 extraQueryParametersSignUp:(NSString *)extraQueryParametersSignUp;

- (void)stopSDK;
- (void)removeDataStore;

#pragma Testing
/**
 Use it before calling MDPClientHandlerEnvironmentPREWithManualToken.
 */
- (void)setToken:(NSString *)token;


#pragma mark - Handlers
- (Class <MDPLanguagesHandlerProtocol>)getLanguagesHandler;
- (Class <MDPIdentityHandlerProtocol>)getIdentityHandler;
- (Class <MDPVirtualGoodsHandlerProtocol>)getVirtualGoodsHandler;
- (Class <MDPAdvertisementHandlerProtocol>)getAdvertisementHandler;
- (Class <MDPPenyasHandlerProtocol>)getPenyasHandler;
- (Class <MDPCalendarHandlerProtocol>)getCalendarHandler;
- (Class <MDPTeamHandlerProtocol>)getTeamsHandler;
- (Class <MDPNotificationsHandlerProtocol>)getNotificationsHandler;
- (Class <MDPUserActionsHandlerProtocol>)getUserActionsHandler;
- (Class <MDPAchievementsHandlerProtocol>)getAchivementsHandler;
- (Class <MDPPlatformNotificationsHandlerProtocol>)getPlatformNotificationsHandler;
- (Class <MDPContentsHandlerProtocol>)getContentsHandler;
- (Class <MDPConfigurationHandlerProtocol>)getConfigurationHandler;
- (Class <MDPCountriesHandlerProtocol>)getCountriesHandler;
- (Class <MDPCheckInHandlerProtocol>)getCheckinHandler;
- (Class <MDPBasketLiveMatchHandlerProtocol>)getBasketLiveMatchHandler;
- (Class <MDPTagsHandlerProtocol>)getTagsHandler;
- (Class <MDPFanHandlerProtocol>)getFanHandler;
- (Class <MDPFootballLiveMatchHandlerProtocol>)getFootballLiveMatchHandler;
- (Class <MDPVideoHandlerProtocol>)getVideoHandler;
- (Class <MDPExternalChallengesHandlerProtocol>)getExternalChallengesHandler;
- (Class <MDPAppsHandlerProtocol>)getAppsHandler;
- (Class <MDPMatchesHandlerProtocol>)getMatchesHandler;
- (Class <MDPPlayersHandlerProtocol>)getPlayersHandler;
- (Class <MDPResourcesHandlerProtocol>)getResourcesHandler;
- (Class <MDPPurchasesHandlerProtocol>)getPurchasesHandler;
- (Class <MDPFriendsHandlerProtocol>)getFriendsHandler;
- (Class <MDPMessagesHandlerProtocol>)getMessagesHandler;
- (Class <MDPSubscriptionsHandlerProtocol>)getSubscriptionsHandler;
- (Class <MDPInvitationsHandlerProtocol>)getInvitationsHandler;
- (Class <MDPCommentsHandlerProtocol>)getCommentsHandler;
- (Class <MDPGroupsHandlerProtocol>)getGroupsHandler;
- (Class <MDPStoreProductsHandlerProtocol>)getStoreProductsHandler;
- (Class <MDPRankingHandlerProtocol>)getRankingHandler;
- (Class <MDPScoreRankingHandlerProtocol>)getScoreRankingHandler;
- (Class <MDPScoresHandlerProtocol>)getScoresHandler;
- (Class <MDPSingleSignOnHandlerProtocol>)getSingleSignOnHandler;
- (Class <MDPPaidFansHandlerProtocol>)getPaidFansHandler;

@end
