//
//  MDPSubscriptionsHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 19/11/15.
//  Copyright © 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPSubscriptionsHandlerProtocol_h
#define MDPClient_MDPSubscriptionsHandlerProtocol_h

#import "MDPSubscriptionModel.h"
#import "MDPSubscriptionConfigurationModel.h"
#import "MDPPagedSubscriptionConfigurationModel.h"
#import "MDPPagedSubscriptionConfigurationTypeModel.h"
#import "MDPSubscriptionConfigurationBasicInfoModel.h"
#import "MDPPagedFavoriteSubscriptionModel.h"
#import "MDPSubscriptionTokenModel.h"
#import "MDPPagedVideosModel.h"
#import "MDPFavoriteModel.h"


#pragma mark - Response
typedef void (^MDPSubscriptionsHandlerResponseBlock)(NSArray *response, NSError *error);


@protocol MDPSubscriptionsHandlerProtocol <NSObject>

/*
 Gets the subscriptions for the logged user
 */
+ (void)getFanSubscriptionsWithCompletionBlock:(MDPSubscriptionsHandlerResponseBlock)completionBlock;

/*
 Gets the subscriptions for the logged user by his id
 */
+ (void)getFanSubscriptionByIdWithIdSubscription:(NSString *)idSubscription
                                 completionBlock:(void (^)(MDPSubscriptionModel *content, NSError *error))completionBlock;

/*
 Gets the subscriptions for a specified type for the logged user
 */
+ (void)getUserSubscriptionByTypeWithType:(NSString *)type
                          completionBlock:(MDPSubscriptionsHandlerResponseBlock)completionBlock;

/*
 Gets the subscription token if it is allowed
 */
+ (void)getSubscriptionTokenWithIdSubscription:(NSString *)idSubscription
                                      idDevice:(NSString *)idDevice
                               completionBlock:(void (^)(NSString *token, NSError *error))completionBlock;

/*
 Check if token is still avaliable for logged user and the specified device
 */
+ (void)getSubscriptionTokenAliveWithIdSubscription:(NSString *)idSubscription
                                           idDevice:(NSString *)idDevice
                                    completionBlock:(void (^)(BOOL isAvailable, NSError *error))completionBlock;

/*
 Gets the subscription configuration
 */
+ (void)getSubscriptionConfigurationWithIdSubscription:(NSString *)idSubscription
                                                       language:(NSString *)language
                                                completionBlock:(void (^)(MDPSubscriptionConfigurationBasicInfoModel *content, NSError *error))completionBlock;

/*
 Gets available highlight subscription configurations for a type.
 */
+ (void)getHighlightedSubscriptionConfigurationsByTypeWithCt:(uint)ct
                                                   country:(NSString *)country
                                                    idType:(NSString *)idType
                                                  language:(NSString *)language
                                           completionBlock:(void (^)(MDPPagedSubscriptionConfigurationModel *content, NSError *error))completionBlock;

/*
 Gets available subscription configurations for a type.
 */
+ (void)getSubscriptionConfigurationsByTypeWithIdType:(NSString *)idType
                                              country:(NSString *)country
                                                   ct:(uint)ct
                                             language:(NSString *)language
                                      completionBlock:(void (^)(MDPPagedSubscriptionConfigurationModel *content, NSError *error))completionBlock;

/*
 Gets the paginated list of availables subscription configuration types.
 */
+ (void)getSubscriptionConfigurationTypesWithCt:(uint)ct
                                       language:(NSString *)language
                                completionBlock:(void (^)(MDPPagedSubscriptionConfigurationTypeModel *content, NSError *error))completionBlock;

/*
 Gets the paginated list of availables highlight subscription configuration types.
 */
+ (void)getHighlightedSubscriptionConfigurationTypes:(uint)ct
                                            language:(NSString *)language
                                     completionBlock:(void (^)(MDPPagedSubscriptionConfigurationTypeModel *content, NSError *error))completionBlock;

/*
 Gets a subscription configuration type by his id
 */
+ (void)getSubscriptionConfigurationTypeWithIdType:(NSString *)idType
                                          language:(NSString *)language
                                   completionBlock:(void (^)(MDPSubscriptionConfigurationTypeModel *content, NSError *error))completionBlock;

/*
 Get the videos for a subscription.
 */
+ (void)getVideosBySubscriptionWithIdSubscription:(NSString *)idSubscription
                                              top:(NSInteger)top
                                             skip:(NSInteger)skip
                                  completionBlock:(MDPSubscriptionsHandlerResponseBlock)completionBlock;

/*
 Add subscripiton as part of user's favorite subscripiton
 */
+ (void)postFavoriteSubscriptionWithIdSubscription:(NSString *)idSubscription
                                   completionBlock:(void (^)(NSError *error))completionBlock;

/*
 Remove subscripiton as part of user's favorite subscripiton
 */
+ (void)deleteFavoriteSubscriptionWithIdSubscription:(NSString *)idSubscription
                                     completionBlock:(void (^)(NSError *error))completionBlock;

/*
 Gets the list of paginated user's favorite subscriptions
 */
+ (void)getPagedFavoriteSubscriptionWithPageSize:(NSNumber *)pageSize
                                        language:(NSString *)language
                                              ct:(NSString *)ct
                                 completionBlock:(void (^)(MDPPagedFavoriteSubscriptionModel *content, NSError *error))completionBlock;

/*
 Gets the subscription token if it is allowed. If available, returns CDN and DRM tokens
 */
+ (void)getSubscriptionAuthTokenWithIdSubscription:(NSString *)idSubscription
                                          idDevice:(NSString *)idDevice
                                        contentKey:(NSString *)contentKey
                                   completionBlock:(void (^)(MDPSubscriptionTokenModel *content, NSError *error))completionBlock;

/*
 Get the subscriptions for the logged user that meet the search criteria
 */
+ (void)getFanSubscriptionsBySearchMetadataWithVideoPackSearch:(MDPVideoPackSearchModel *)videoPackSearch
                                               completionBlock:(MDPSubscriptionsHandlerResponseBlock)completionBlock;

/*
 Get the videos for a subscription.
 */
+ (void)getSubscriptionVideosWithSubscriptionId:(NSString *)subscriptionId
                                            top:(NSNumber *)top
                                           skip:(NSNumber *)skip
                                completionBlock:(void (^)(MDPPagedVideosModel *content, NSError *error))completionBlock;

/*
 Get user's favorite subscription by identifier
 */
+ (void)getFavoriteSubscriptionWithIdSubscription:(NSString *)idSubscription
                                  completionBlock:(void (^)(MDPFavoriteModel *content, NSError *error))completionBlock;


#pragma mark - Delete all Favorite Subscriptions
+ (void)deleteAllFavoriteSubscriptions;

+ (void)deleteFavoriteSubscriptionsWithSuscriptionId:(NSString *)subscriptionId;


#pragma mark - FetchResultsController
+ (NSFetchedResultsController *)subscriptionConfigurationBasicInfoFetchedResultsControllerWithDelegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)subscriptionConfigurationBasicInfoFetchedResultsControllerWithIdSubscription:(NSString *)idSubscription
                                                                                                    delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)subscriptionConfigurationBasicInfoFetchedResultsControllerWithHighLight:(BOOL)highLight
                                                                                    highLightInCategory:(BOOL)highLightInCategory
                                                                                               delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)subscriptionConfigurationBasicInfoFetchedResultsControllerWithType:(NSString *)idType
                                                                                         highLight:(BOOL)highLight
                                                                                highLighInCategory:(BOOL)highLightInCategory
                                                                                          delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)subscriptionConfigurationBasicInfoFetchedResultsControllerWithType:(NSString *)idType
                                                                                          delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)subscriptionConfigurationTypeFetchedResultsControllerWithLanguage:(NSString *)language
                                                                                         delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)subscriptionConfigurationTypeFetchedResultsControllerWithLanguage:(NSString *)language
                                                                                        highLight:(BOOL)highLight
                                                                                         delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)subscriptionFetchedResultsControllerWithDelegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)subscriptionFetchedResultsControllerWithType:(NSString *)idType
                                                                    delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)subscriptionVideoFetchedResultsControllerWithSubscriptionId:(NSString *)subscriptionId
                                                                                   delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)subscriptionVideoFetchedResultsControllerWithIdsSubscription:(NSArray *)idsSubscription
                                                                                    delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

/*
 Videos
 */
+ (NSFetchedResultsController *)videosFetchedResultsControllerWithIdSubscription:(NSString *)idSubscription
                                                                        delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)videosFetchedResultsControllerWithIdsSubscription:(NSArray *)idsSubscription
                                                                         delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

/*
 Favorite Subscriptions
 */
+ (NSFetchedResultsController *)favoriteSubscriptionsFetchedResultsControllerDelegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end

#endif /* MDPSubscriptionsHandlerProtocol_h */





































































