//
//  MDPFanHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 26/1/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPFanHandlerProtocol_h
#define MDPClient_MDPFanHandlerProtocol_h

@import UIKit;

#import "MDPFanModel.h"
#import "MDPGamificationStatusModel.h"
#import "MDPPagedFanVirtualGoodsModel.h"
#import "MDPPagedPointsTransactionsModel.h"
#import "MDPPagedAchievementsModel.h"
#import "MDPAppModel.h"
#import "MDPProfileAvatarModel.h"
#import "MDPProfileAvatarUpdateableModel.h"
#import "MDPPartialUpdateModel.h"
#import "MDPFanContactModel.h"
#import "MDPFanOfferModel.h"
#import "MDPPagedFanOffersModel.h"


#pragma mark  - Response
typedef void (^MDPFanHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPFanHandlerProtocol
@protocol MDPFanHandlerProtocol <NSObject>

/**
 Gets current user profile.
 */
+ (void)getFanWithUseCache:(BOOL)useCache
           completionBlock:(void(^)(MDPFanModel *content, NSError *error))completionBlock;

/**
 Updates current user profile. This method updates the entire profile to update a specific field use PATCH verb
 Parameters NSDate have a locale en_US
 */
+ (void)putFanWithName:(NSString *)name
               surname:(NSString *)surname
            secondName:(NSString *)secondName
                gender:(int)gender
             birthDate:(NSDate *)birthDate
               country:(NSString *)country
              language:(NSString *)language
          documentType:(int)documentType
        documentNumber:(NSString *)documentNumber
          mobileNumber:(NSString *)mobileNumber
            homeNumber:(NSString *)homeNumber
               address:(NSString *)address
                   zip:(NSString *)zip
                  city:(NSString *)city
                 state:(NSString *)state
             stateCode:(NSString *)stateCode
                 title:(int)title
        preferredSport:(int)preferredSport
                 penya:(NSString *)penya
       sendInfoToStore:(BOOL)sendInfoToStore
noCommunications:(BOOL)noCommunications
         noInfo2Thirds:(BOOL)noInfo2Thirds
            lastUpdate:(NSDate *)lastUpdate
       completionBlock:(void(^)(NSError *error))completionBlock;


/*
 Updates and gets current user profile
 Parameters NSDate have a locale en_US
 */
+ (void)putAndGetFanWithName:(NSString *)name
                     surname:(NSString *)surname
                  secondName:(NSString *)secondName
                      gender:(MDPFanModelGender)gender
                   birthDate:(NSDate *)birthDate
                     country:(NSString *)country
                    language:(NSString *)language
                documentType:(MDPFanModelDocumentType)documentType
              documentNumber:(NSString *)documentNumber
                mobileNumber:(NSString *)mobileNumber
                  homeNumber:(NSString *)homeNumber
                     address:(NSString *)address
                         zip:(NSString *)zip
                        city:(NSString *)city
                       state:(NSString *)state
                   stateCode:(NSString *)stateCode
                       title:(MDPFanModelTitle)title
              preferredSport:(MDPFanModelPreferredSport)preferredSport
                       penya:(NSString *)penya
             sendInfoToStore:(BOOL)sendInfoToStore
  noCommunications:(BOOL)noCommunications
               noInfo2Thirds:(BOOL)noInfo2Thirds
                  lastUpdate:(NSDate *)lastUpdate
             completionBlock:(void(^)(MDPFanModel *content, NSError *error))completionBlock;


/**
 Deletes current user profile.
 */
+ (void)deleteFanWithCompletionBlock:(void(^)(NSError *error))completionBlock;


/**
 Deletes and refreshes current user profile.
 */
+ (void)deleteAndGetFanWithCompletionBlock:(void(^)(NSError *error))completionBlock;


/**
 Updates current user profile. This method updates only the fields recieved
 @param partialUpdateJSON
 {
 "Items": [
 {
 "OperationType": 0,
 "Path": "sample string 1",
 "Value": {},
 "SearchPath": "sample string 3",
 "SearchValue": {},
 "ChangePath": "sample string 5",
 "RemovePath": "sample string 6"
 },
 {
 "OperationType": 0,
 "Path": "sample string 1",
 "Value": {},
 "SearchPath": "sample string 3",
 "SearchValue": {},
 "ChangePath": "sample string 5",
 "RemovePath": "sample string 6"
 }
 ]
 }
 */

+ (void)patchFanWithPartialUpdate:(MDPPartialUpdateModel *)partialUpdate
                  completionBlock:(void(^)(NSError *error))completionBlock;

/**
 Updates and gets current user profile. This method updates only the fields recieved
 @param partialUpdateJSON
 {
 "Items": [
 {
 "OperationType": 0,
 "Path": "sample string 1",
 "Value": {},
 "SearchPath": "sample string 3",
 "SearchValue": {},
 "ChangePath": "sample string 5",
 "RemovePath": "sample string 6"
 },
 {
 "OperationType": 0,
 "Path": "sample string 1",
 "Value": {},
 "SearchPath": "sample string 3",
 "SearchValue": {},
 "ChangePath": "sample string 5",
 "RemovePath": "sample string 6"
 }
 ]
 }
 */
+ (void)patchAndGetFanWithPartialUpdate:(MDPPartialUpdateModel *)partialUpdate
                        completionBlock:(void(^)(MDPFanModel *content, NSError *error))completionBlock;

/**
 Gets current user gamification status (num points, num achievements, num virtual goods, etc).
 */
+ (void)getFanGamificationStatusWithLanguage:(NSString *)language
                             completionBlock:(void(^)(MDPGamificationStatusModel *content, NSError *error))completionBlock;



/*
 Checks if we have enabled the push notifications for this device
 */
+ (void)getFanAppsWithDeviceId:(NSString *)deviceId
               completionBlock:(void(^)(MDPAppModel *content, NSError *error))completionBlock;

/*
 Registers an app for a user. This method should be invoked when a user installs and execute an app in a device.
 */
+ (void)postAppsWithDeviceId:(NSString *)deviceId
     enablePushNotifications:(BOOL)enablePushNotifications
     pushNotificationHandler:(NSString *)pushNotificationHandler
                  deviceType:(MDPFanModelDeviceType)deviceType
             platformVersion:(NSString *)platformVersion
             completionBlock:(MDPFanHandlerResponseBlock)completionBlock;

/*
 Updates an app for a user. This method should be invoked each time the pushNotificationHandler of app for push notifications changes.
 */
+ (void)putAppsWithDeviceId:(NSString *)deviceId
    enablePushNotifications:(BOOL)enablePushNotifications
 pushNotificationHandler:(NSString *)pushNotificationHandler
              deviceType:(MDPFanModelDeviceType)deviceType
         platformVersion:(NSString *)platformVersion
         completionBlock:(MDPFanHandlerResponseBlock)completionBlock;


/**
 Upload user's image for profile. The image is loaded from request's body
 
 @warning Network: Says you load image from body but in HTML doc body has no parameters
 */
+ (void)putAvatarWithImage:(UIImage *)image completionBlock:(void (^)(NSError *error))completionBlock;

/**
 Gets current user virtual goods
 */
+ (void)getVirtualGoodsWithContinuationTokenForPagination:(NSString *)ct
                                                 language:(NSString *)language
                                          completionBlock:(void(^)(MDPPagedFanVirtualGoodsModel *content, NSError *error))completionBlock;

/**
 Gets current user points transactions
 */
+ (void)getPointsWithContinuationTokenForPagination:(NSString *)ct
                                           language:(NSString *)language
                                    completionBlock:(void(^)(MDPPagedPointsTransactionsModel *content, NSError *error))completionBlock;

/**
 Gets current user achievements
 */
+ (void)getAchivementsWithContinuationTokenForPagination:(NSString *)ct
                                                language:(NSString *)language
                                         completionBlock:(void(^)(MDPPagedAchievementsModel *content, NSError *error))completionBlock;

/*
 Activates logged user
 */
+ (void)putActivateWithCompletionBlock:(MDPFanHandlerResponseBlock)completionBlock;

/*
 Gets the profile avatar of the user that is doing the request.
 */
+ (void)getProfileAvatarWithIdUser:(NSString *)idUser
                   completionBlock:(void(^)(MDPProfileAvatarModel *content, NSError *error))completionBlock;

/*
 Creates a profile avatar for a user.
 */
+ (void)createProfileAvatarWithProfileAvatarUpdateable:(MDPProfileAvatarUpdateableModel *)profileAvatarUpdateable completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Updates the profile avatar of a user.
 */
+ (void)updateProfileAvatarWithProfileAvatarUpdateable:(MDPProfileAvatarUpdateableModel *)profileAvatarUpdateable completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Deletes the profile avatar of the user that is doing the request.
 */
+ (void)deleteProfileAvatarWithCompletionBlock:(void(^)(NSError *error))completionBlock;

/*
 Gets the virtual goodies of the user that is doing the request, filtering by type.
 */
+ (void)getFanVirtualGoodsByTypeWithType:(NSString *)type
                                      ct:(NSString *)ct
                                language:(NSString *)language
                         completionBlock:(void(^)(MDPPagedFanVirtualGoodsModel *content, NSError *error))completionBlock;

/*
 Gets the achievements of the user that is doing the request, filtered by type.
 */
+ (void)getFanAchievementsByTypeWithType:(NSString *)type
                                      ct:(NSString *)ct
                                language:(NSString *)language
                         completionBlock:(void(^)(MDPPagedAchievementsModel *content, NSError *error))completionBlock;

/*
 Upload user profile avatar image. The image is loaded from request's body
 */
+ (void)putProfileAvatarPictureWithImage:(UIImage *)image completionBlock:(void (^)(NSError *error))completionBlock;

/*
  Use a guest virtual good.
 */
+ (void)putBurnVirtualGoodWithIdVirtualGood:(NSString *)idVirtualGood
                            completionBlock:(void (^)(NSError *error))completionBlock;

/*
*/
+ (void)putConvertGuestWithIdGuest:(NSString *)idGuest
                    completionBlock:(void (^)(NSError *error))completionBlock;

/*
Search users by suggestion
*/
+ (void)searchUsersAsyncWithText:(NSString *)text
                             top:(NSInteger)top
                 completionBlock:(MDPFanHandlerResponseBlock)completionBlock;

/*
 Search users by email
 */
+ (void)searchUsersByEmailWithEmail:(NSString *)email
                    completionBlock:(MDPFanHandlerResponseBlock)completionBlock;

/*
 Gets a user virtual good by Id
 */
+ (void)getFanVirtualGoodByIdWithIdVirtualGood:(NSString *)idVirtualGood
                                      language:(NSString *)language
                               completionBlock:(void (^)(MDPFanVirtualGoodModel *content, NSError *error))completionBlock;

/*
 Gets the user information by his id.
 */
+ (void)getUserByIdWithIdUserToFind:(NSString *)userIdToFind
                    completionBlock:(void (^)(MDPFanContactModel *content, NSError *error))completionBlock;

/*
 */
+ (void)getOffersWithCt:(NSInteger)ct
        completionBlock:(void (^)(MDPPagedFanOffersModel *content, NSError *error))completionBlock;
/*
 */
+ (void)getOfferDetailsWithIdOfferType:(NSString *)idOfferType
                       completionBlock:(void (^)(MDPFanOfferModel *content, NSError *error))completionBlock;


/////////////////////////////////////////////////////////////////////////////

/*
 Updates the isActivePaidFan in BD
 */
+ (void)updateCacheFanWithIsActivePaidFan :(BOOL)isActivePaidFan;

/*
 Updates the language in BD
 */
+ (void)updateCacheFanWithLanguage:(NSString *)language;

/*
 Listens to MDPAchievementModel objects
 */
+ (NSFetchedResultsController *)achievementFetchedResultsControllerWithType:(NSString *)type
                                                                   delegate:(id <NSFetchedResultsControllerDelegate>)delegate;


/*
 Listens to MDPFanVirtualGoodModel objects
 */
+ (NSFetchedResultsController *)fanVirtualGoodFetchedResultsControllerWithDelegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)fanVirtualGoodFetchedResultsControllerWithId:(NSString *)idVirtualGood
                                                                      typeId:(NSString *)idType
                                                                    delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

/*
 Find Achievements
 */
+ (MDPAchievementModel *)achievementWithIdAchievement:(NSString *)idAchievement level:(uint)level;


/*
 Listens to GamificationStatusModel objects
 */
+ (NSFetchedResultsController *)gamificationStatusFetchedResultsControllerWithDelegate:(id <NSFetchedResultsControllerDelegate>)delegate;

/*
 Listens to FanModel object
 */
+ (NSFetchedResultsController *)fanFetchedResultsControllerWithDelegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)fanFetchedResultsControllerWithIdVirtualGood:(NSString *)idVirtualGood
                                                                        type:(NSString *)idType
                                                                    delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end

#endif















