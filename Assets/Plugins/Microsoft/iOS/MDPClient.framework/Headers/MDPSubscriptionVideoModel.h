//
//  MDPSubscriptionVideoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPSubscriptionVideoModel.h"


#pragma mark - Interface
@interface MDPSubscriptionVideoModel : _MDPSubscriptionVideoModel

+ (NSArray *)subscriptionVideosWithSubscriptionId:(NSString *)subscriptionId managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsSubscriptionVideoWithSubscriptionId:(NSString *)subscriptionId
                                                          dictionary:(NSDictionary *)dictionary
                                                managedObjectContext:(NSManagedObjectContext *)context;

@end
