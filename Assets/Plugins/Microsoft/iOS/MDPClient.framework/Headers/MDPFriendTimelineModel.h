//
//  MDPFriendTimelineModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPFriendTimelineModel.h"


#pragma mark - Interface
@interface MDPFriendTimelineModel : _MDPFriendTimelineModel

+ (instancetype)insertIfNotExistsFriendTimelineWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
