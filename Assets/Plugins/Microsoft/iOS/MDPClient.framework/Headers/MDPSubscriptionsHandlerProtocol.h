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
 Gets if the user can see the video with the device
 */
+ (void)getSubscriptionTokenAliveWithIdSubscription:(NSString *)idSubscription
                                           idDevice:(NSString *)idDevice
                                    completionBlock:(void (^)(BOOL isAvailable, NSError *error))completionBlock;

/*
 Gets the subscription configuration
 */
+ (void)getSubscriptionConfigurationBasicInfoWithIdSubscription:(NSString *)idSubscription
                                                       language:(NSString *)language
                                                completionBlock:(void (^)(MDPSubscriptionConfigurationBasicInfoModel *content, NSError *error))completionBlock;

/*
 Gets available highlight subscription configurations for a type.
 */
+ (void)getSubscriptionConfigurationsHighlightByTypeWithCt:(uint)ct
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
+ (void)getHighlightTypesWithCt:(uint)ct
                       language:(NSString *)language
                completionBlock:(void (^)(MDPPagedSubscriptionConfigurationTypeModel *content, NSError *error))completionBlock;

/*
 Gets a subscription configuration type by his id
 */
+ (void)getSubscriptionConfigurationTypeWithIdType:(NSString *)idType
                                          language:(NSString *)language
                                   completionBlock:(void (^)(MDPSubscriptionConfigurationTypeModel *content, NSError *error))completionBlock;

/*
 Gests the videos for a subscription.
 */
+ (void)getVideosBySubscriptionWithIdSubscription:(NSString *)idSubscription
                                              top:(NSInteger)top
                                             skip:(NSInteger)skip
                                  completionBlock:(MDPSubscriptionsHandlerResponseBlock)completionBlock;



/*
 FetchResultsController
 */
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

@end

#endif /* MDPSubscriptionsHandlerProtocol_h */





































































