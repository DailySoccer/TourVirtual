//
//  MDPPagedSubscriptionConfigurationBasicInfoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPPagedSubscriptionConfigurationBasicInfoModel.h"
#import "MDPSubscriptionConfigurationBasicInfoModel.h"


#pragma mark - Interface
@interface MDPPagedSubscriptionConfigurationBasicInfoModel : _MDPPagedSubscriptionConfigurationBasicInfoModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary callType:(MDPSubscriptionConfigBasicInfoModelCallType)callType managedObjectContext:(NSManagedObjectContext *)context;

+ (MDPPagedSubscriptionConfigurationBasicInfoModel *)pagedSubscriptionConfigurationBasicInfoWithCallType:(MDPSubscriptionConfigBasicInfoModelCallType)callType managedObjectContext:(NSManagedObjectContext *)context;

@end
