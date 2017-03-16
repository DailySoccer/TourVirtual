//
//  MDPGoalModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPGoalModel.h"


#pragma mark  - GoalType
typedef NS_ENUM(NSInteger, MDPGoalModelGoalType) {
    MDPGoalModelGoalTypeUnknow   = 0,
    MDPGoalModelGoalTypePenalty  = 1,
    MDPGoalModelGoalTypeGoal     = 2,
    MDPGoalModelGoalTypeOwn      = 3,
};


#pragma mark - Interface
@interface MDPGoalModel : _MDPGoalModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
