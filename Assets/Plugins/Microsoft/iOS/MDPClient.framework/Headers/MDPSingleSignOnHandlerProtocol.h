//
//  MDPSingleSignOnHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 21/4/16.
//  Copyright © 2016 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPSingleSignOnHandlerProtocol_h
#define MDPClient_MDPSingleSignOnHandlerProtocol_h


#pragma mark - Response
typedef void (^MDPSingleSignOnHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - Error
extern const struct MDPSingleSignOnHandlerErrorStrings {
    __unsafe_unretained NSString *importTokenCache;
    __unsafe_unretained NSString *exportTokenCache;
} MDPSingleSignOnHandlerErrorStrings;

typedef NS_ENUM(NSUInteger, MDPSingleSignOnHandlerErrorCode){
    MDPSingleSignOnHandlerErrorCodeImportTokenCache = 0,
    MDPSingleSignOnHandlerErrorCodeExportTokenCache,
};



#pragma mark - MDPSingleSignOnHandlerProtocol
@protocol MDPSingleSignOnHandlerProtocol <NSObject>

/*
 Gets a token cache by an authorization code
 */
+ (void)getTokenCacheByAuthorizationCodeWithAuthorizationCode:(NSString *)authorizationCode
                                                     password:(NSString *)password
                                              completionBlock:(void (^)(NSError *))completionBlock;

/*
 Stores a token cache for an user and an App which user has granted to access his token. The token cache is loaded from request's body.
 */
+ (void)postTokenWithPassword:(NSString *)password
           idClientThirdParty:(NSString *)idClientThirdParty
              completionBlock:(void(^)(NSString *identifier, NSError *error))completionBlock;

/*
 Indicates if user has granted to an app to access to his token cache
 */
+ (void)getCheckGrantedPermissionsWithIdClientThirdParty:(NSString *)idClientThirdParty
                                         completionBlock:(void(^)(BOOL permisionGranted, NSError *error))completionBlock;

@end

#endif /* MDPSingleSignOnHandlerProtocol_h */
