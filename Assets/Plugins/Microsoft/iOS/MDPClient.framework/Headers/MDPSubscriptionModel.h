//
//  MDPSubscriptionModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPSubscriptionModel.h"


#pragma mark SubscriptionDisabledType
typedef NS_ENUM(NSInteger, MDPSubscriptionModelSubscriptionDisabledType ) {
    MDPSubscriptionModelSubscriptionDisabledTypeExpired             = 0,
    MDPSubscriptionModelSubscriptionDisabledTypeCanceledByUser      = 1,
    MDPSubscriptionModelSubscriptionDisabledTypeCanceledByDP        = 2,
};


#pragma mark - Interface
@interface MDPSubscriptionModel : _MDPSubscriptionModel

+ (NSArray *)subscriptionWithManagedObjectContext:(NSManagedObjectContext *)context;

+ (NSArray *)subscriptionsWithType:(NSString *)type managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)subscriptionWithIdSubscription:(NSString *)idSubscription managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsSubscriptionWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)subscriptionFetchedResultsControllerWithManagedObjectContext:(NSManagedObjectContext *)context
                                                                                    delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)subscriptionFetchedResultsControllerWithType:(NSString *)idType
                                                        managedObjectContext:(NSManagedObjectContext *)context
                                                                    delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
