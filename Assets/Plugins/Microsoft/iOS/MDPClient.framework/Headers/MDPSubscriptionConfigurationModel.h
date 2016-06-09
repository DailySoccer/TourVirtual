//
//  MDPSubscriptionConfigurationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPSubscriptionConfigurationModel.h"


#pragma mark  - SubscriptionExpirationType
typedef NS_ENUM(NSInteger, MDPSubscriptionConfigurationModelSubscriptionExpirationType) {
    MDPSubscriptionConfigurationModelSubscriptionExpirationTypeFixed                = 0,
    MDPSubscriptionConfigurationModelSubscriptionExpirationTypeTimeRange            = 1,
};


#pragma mark - Interface
@interface MDPSubscriptionConfigurationModel : _MDPSubscriptionConfigurationModel

+ (instancetype)subscriptionConfigurationWithIdSubscription:(NSString *)idSubscription managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsSubscriptionConfigurationWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end




































































































































