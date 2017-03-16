//
//  MDPMatchEventModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPMatchEventModel.h"

#pragma mark - EventType
typedef NS_ENUM(NSInteger, MDPMatchEventModelEventtype) {
    MDPEventModelEventtypeText       = 0,
    MDPEventModelEventtypeChallenge  = 1,
    MDPEventModelEventtypeBanner     = 2,
    MDPEventModelEventtypeLink       = 3,
    MDPEventModelEventtypeStatistic  = 4,
};


#pragma mark - Interface
@interface MDPMatchEventModel : _MDPMatchEventModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
