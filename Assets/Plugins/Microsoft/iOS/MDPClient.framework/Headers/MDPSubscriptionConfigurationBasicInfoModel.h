//
//  MDPSubscriptionConfigurationBasicInfoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPSubscriptionConfigurationBasicInfoModel.h"


#pragma mark Call Type
typedef NS_ENUM(NSUInteger, MDPSubscriptionConfigBasicInfoModelCallType) {
    MDPSubscriptionConfigBasicInfoModelCallTypeSubscriptionsHandler                             = 1,
    MDPSubscriptionConfigBasicInfoModelCallTypeVirtualTicketsBySearchMetadata                   = 2,
    MDPSubscriptionConfigBasicInfoModelCallTypeSearchVideoPackByMetadata                        = 3,

};


#pragma mark - Interface
@interface MDPSubscriptionConfigurationBasicInfoModel : _MDPSubscriptionConfigurationBasicInfoModel

#pragma mark - General Insert
+ (instancetype)insertIfNotExistsSubscriptionConfigurationBasicInfoWithDictionary:(NSDictionary *)dictionary callType:(MDPSubscriptionConfigBasicInfoModelCallType)callType managedObjectContext:(NSManagedObjectContext *)context;

#pragma mark - Subscriptions Handler
+ (instancetype)subscriptionConfigurationBasicInfoWithIdSubscription:(NSString *)idSubscription managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)subscriptionConfigurationBasicInfoFetchedResultsControllerWithManagedObjectContext:(NSManagedObjectContext *)context
                                                                                                          delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)subscriptionConfigurationBasicInfoFetchedResultsControllerWithIdSubscription:(NSString *)idSubscription
                                                                                        managedObjectContext:(NSManagedObjectContext *)context
                                                                                                    delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)subscriptionConfigurationBasicInfoFetchedResultsControllerWithHighLight:(BOOL)highLight
                                                                                    highLightInCategory:(BOOL)highLightInCategory
                                                                                   managedObjectContext:(NSManagedObjectContext *)context delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)subscriptionConfigurationBasicInfoFetchedResultsControllerWithType:(NSString *)idType
                                                                                         highLight:(BOOL)highLight
                                                                               highLightInCategory:(BOOL)highLightInCategory
                                                                              managedObjectContext:(NSManagedObjectContext *)context
                                                                                          delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)subscriptionConfigurationBasicInfoFetchedResultsControllerWithType:(NSString *)idType
                                                                              managedObjectContext:(NSManagedObjectContext *)context
                                                                                          delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
