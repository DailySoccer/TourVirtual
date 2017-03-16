//
//  MDPNetworkConstantsHandler.h
//  MDPClient
//
//  Created by Javier Ovejero on 2/1/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#import <Foundation/Foundation.h>


#pragma mark - Constants
#define MDPSportTypeByDefault 1
#define MDPNumberOfMatchesByDefault 1


#pragma mark - Environments
typedef NS_ENUM(NSInteger, MDPNetworkConstantsHandlerEnvironment)
{
    MDPNetworkConstantsHandlerEnvironmentMock                            = -1,
    MDPNetworkConstantsHandlerEnvironmentPreproduction                   = 0,
    MDPNetworkConstantsHandlerEnvironmentProduction                      = 1,
    MDPNetworkConstantsHandlerEnvironmentDevelopment                     = 2,
    MDPNetworkConstantsHandlerEnvironmentStagingProductionEU             = 3,
    MDPNetworkConstantsHandlerEnvironmentStagingProductionAM             = 4,
    MDPNetworkConstantsHandlerEnvironmentStagingProductionAS             = 5,
    MDPNetworkConstantsHandlerEnvironmentProductionEU                    = 6,
    MDPNetworkConstantsHandlerEnvironmentProductionAM                    = 7,
    MDPNetworkConstantsHandlerEnvironmentProductionAS                    = 8,
    MDPNetworkConstantsHandlerEnvironmentPreproductionEU                 = 9,
    MDPNetworkConstantsHandlerEnvironmentPreproductionAM                 = 10,
    MDPNetworkConstantsHandlerEnvironmentPreproductionAS                 = 11,
    MDPNetworkConstantsHandlerEnvironmentStagingPreproductionEU          = 12,
    MDPNetworkConstantsHandlerEnvironmentStagingPreproductionAM          = 13,
    MDPNetworkConstantsHandlerEnvironmentStagingPreproductionAS          = 14,
    MDPNetworkConstantsHandlerEnvironmentTestEU                          = 15,
    MDPNetworkConstantsHandlerEnvironmentTestAS                          = 16,
    MDPNetworkConstantsHandlerEnvironmentQA                              = 17,
};


#pragma mark - Constants Network
#define BearerFormat                    @"Bearer %@"

#define HeaderAuthorization             @"Authorization"
#define HeaderMdpSdkVersion             @"Mdp.SDK.Version"
#define HeaderMdpSdkClientId            @"Mdp.SDK.ClientId"


#pragma mark - Interface
@interface MDPNetworkConstantsHandler : NSObject
+ (void)validateReleaseOrDebugWithEnvironment:(NSString *)environment debugMode:(BOOL)debugMode;
+ (void)setEnvironment:(NSString *)environment;
+ (NSString *)environment;
+ (MDPNetworkConstantsHandlerEnvironment)environmentValue;
+ (NSString *)webAPIBaseUrl;
+ (NSString *)webAPIBaseUrlEventHUB;
+ (NSString *)webAPISingleSignOnBaseUrl;
+ (BOOL)mockData;

@end
