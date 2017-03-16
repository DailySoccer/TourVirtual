//
//  MDPIdentityHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 29/1/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_RMIdentityHandlerProtocol_h
#define MDPClient_RMIdentityHandlerProtocol_h

#import "MDPExternalIdentityModel.h"


#pragma mark  - Response
typedef void (^MDPIdentityHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPIdentityHandlerProtocol
@protocol MDPIdentityHandlerProtocol <NSObject>

/*
 Add an external identity (FaceBook, twitter, etc.) info related to a user
 */
+ (void)postExternalIdentityWithIdentityProvider:(MDPExternalIdentityModelIdentityProviderType)identityProvider
                                      identityId:(NSString *)identityId
                                   identityAlias:(NSString *)identityAlias
                               identityUserToken:(NSString *)identityUserToken
                                 completionBlock:(void(^)(MDPExternalIdentityModel *content, NSError *error))completionBlock;


/*
 Update current user's alias
 */
+ (void)putUpdateAliasWithNewAlias:(NSString *)newAlias
                   completionBlock:(void(^)(NSError *error))completionBlock;


/*
 Retrieved all social identites for the logged user
 */
+ (void)getExternalIdentitesWithCompletionBlock:(MDPIdentityHandlerResponseBlock)completionBlock;


/*
 Check is an alias is unique
 */
+ (void)getCheckAliasWithAlias:(NSString *)alias
               completionBlock:(void(^)(BOOL isAvailable, NSError *error))completionBlock;

/*
 Updates the identity user token.
 */
+ (void)putIdentityUserTokenWithIdentityProvider:(MDPExternalIdentityModelIdentityProviderType)identityProvider
                               identityUserToken:(NSString *)identityUserToken
                                 completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Search an external identity (FaceBook, twitter, etc.) based on identity alias.
 */
+ (void)searchExternalIdentitiesWithIdentityProvide:(NSInteger)identityProvider
                                      identityAlias:(NSArray *)identityAlias
                                    completionBlock:(MDPIdentityHandlerResponseBlock)completionBlock;

@end


#endif
