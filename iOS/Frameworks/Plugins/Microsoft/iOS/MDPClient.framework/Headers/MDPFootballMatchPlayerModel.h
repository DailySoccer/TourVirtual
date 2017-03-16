//
//  MDPFootballMatchPlayerModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPFootballMatchPlayerModel.h"


#pragma mark  - FootballMatchPlayerStatus
typedef NS_ENUM(NSInteger, MDPFootballMatchPlayerModelFootballMatchPlayerStatus) {
    MDPFootballMatchPlayerModelFootballMatchPlayerStatusUnknow     = 0,
    MDPFootballMatchPlayerModelFootballMatchPlayerStatusStart      = 1,
    MDPFootballMatchPlayerModelFootballMatchPlayerStatusSub        = 2,
};


#pragma mark - Interface
@interface MDPFootballMatchPlayerModel : _MDPFootballMatchPlayerModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
