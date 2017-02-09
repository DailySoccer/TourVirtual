//
//  MDPAuthHandler.h
//  MDPClient
//
//  Created by Ernesto Fernández Calles on 23/12/14.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import <Foundation/Foundation.h>


#pragma mark - User Selection
typedef NS_ENUM(NSUInteger, MDPAuthHandlerUserSelectionOption) {
    MDPAuthHandlerUserSelectionOptionSignUp = 0,
    MDPAuthHandlerUserSelectionOptionSignIn
};

@class MDPAuthHandler;
typedef void (^MDPAuthHandlerShowUserSelectionScreenBlock)(MDPAuthHandler *authHandler);


#pragma mark - Interface
@interface MDPAuthHandler : NSObject

#pragma mark Singleton
+ (MDPAuthHandler *)sharedInstance;
+ (void)destroyInstance;

#pragma mark Auth
/*! Block to call when user selection is needed
 */
@property (copy) MDPAuthHandlerShowUserSelectionScreenBlock showUserSelectionScreenBlock;

#pragma mark Token
- (NSString *)getToken;

/*! Method whe user has selected an option
 */
- (void)userSelectedOption:(MDPAuthHandlerUserSelectionOption)userSelectedOption;

/*
  This method gets the token that it authorizes the user the access and it sends the call putActivate
 */
- (void)getAccesTokenWithCompletionBlock:(void (^)(NSError *error))completionBlock;

/*! This method will not show UI for the user to reauthorize resource usage.
 If reauthorization is needed, the method will return an error with code AD_ERROR_USER_INPUT_NEEDED.
 */
// - (void)tokenSilentWithCompletionBlock:(void (^)(NSString *token, NSError *error))completionBlock;

/*! This method will show UI if needed and only if silen fails
 */
- (void)tokenSilentShowingUIIfNeededWithCompletionBlock:(void (^)(NSString *token, NSError *error))completionBlock;


- (void)receivedLoginUrl:(NSURL *)url;

- (void)logout;

#pragma mark Token Cache
- (NSString *)exportTokenCacheStoreWithPassword:(NSString *)password;
- (BOOL)importTokenCacheStore:(NSString *)cache password:(NSString *)password;
- (BOOL)hasCacheItems;
- (void)cleanUpKeychain;

#pragma mark User Information
- (NSString *)userInfoUserId;

#pragma mark Test
@property (nonatomic) BOOL enableTesting;
@property (copy) NSString *testToken;


#pragma mark Store Cache
- (void)importStoredCache;

@end
