//
//  MDPTimelineModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPTimelineModel.h"


#pragma mark - Interface
@interface MDPTimelineModel : _MDPTimelineModel

+ (MDPTimelineModel *)timelineWithIdMatch:(NSString *)idMatch language:(NSString *)language managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsTimeline:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
