//
//  MDPConfigurationHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 15/8/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPConfigurationHandlerProtocol_h
#define MDPClient_MDPConfigurationHandlerProtocol_h

#import "MDPConfigurationModel.h"
#import "MDPConfigurationTrustedClientAppModel.h"


#pragma mark  - Response
typedef void (^MDPConfigurationHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPConfigurationHandlerProtocol
@protocol MDPConfigurationHandlerProtocol <NSObject>

/**
 Gets user's configuration for an app.
 */
+ (void)getUserConfigurationByAppWithSetting:(NSString *)setting
                              completionBlock:(MDPConfigurationHandlerResponseBlock)completionBlock;

/**
 Updates user's configuration for an app.
 */
+ (void)putUserConfigurationByAppWithSetting:(NSString *)setting
                             appConfiguration:(NSString *)appConfiguration
                              completionBlock:(void (^)(NSError *error))completionBlock;

/**
 Updates and refreshes user's configuration for an app.
 */
+ (void)putAndGetUserConfigurationByAppWithSetting:(NSString *)setting
                                   appConfiguration:(NSString *)appConfiguration
                                    completionBlock:(MDPConfigurationHandlerResponseBlock)completionBlock;
/*
 Gets user's configuration for a client group.
 */
+ (void)getUserConfigurationGlobalWithSetting:(NSString *)setting
                               completionBlock:(MDPConfigurationHandlerResponseBlock)completionBlock;

/*
 Insert a new user's configuration setting for an app.
 */
+ (void)postUserConfigurationByAppWithSetting:(NSString *)setting
                              appConfiguration:(NSString *)appConfiguration
                               completionBlock:(void (^)(NSError *error))completionBlock;

/*
 Updates user's global configuration setting.
 */
+ (void)putUserConfigurationGlobalWithSetting:(NSString *)setting
                              appConfiguration:(NSString *)appConfiguration
                               completionBlock:(void (^)(NSError *error))completionBlock;

/*
 Insert a new user's configuration setting.
 */
+ (void)postUserConfigurationGlobalWithSetting:(NSString *)setting
                               appConfiguration:(NSString *)appConfiguration
                                completionBlock:(void (^)(NSError *error))completionBlock;

/*
 Get app configuration.
 */
+ (void)getAppConfigurationWithCompletionBlock:(void(^)(NSString *result, NSError *error))completionBlock;

@end

#endif
