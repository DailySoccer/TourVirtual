//
//  MDPMatchStatusModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPMatchStatusModel.h"


#pragma mark  - MatchStatusType
typedef NS_ENUM(NSInteger, MDPMatchStatusModelMatchStatusType) {
    MDPMatchStatusModelMatchStatusTypeNonGameDay     = 0,
    MDPMatchStatusModelMatchStatusTypeGameDay        = 1,
    MDPMatchStatusModelMatchStatusTypePreGame        = 2,
    MDPMatchStatusModelMatchStatusTypeDuringGame     = 3,
    MDPMatchStatusModelMatchStatusTypePostGame       = 4,
};


#pragma mark  - SportType
typedef NS_ENUM(NSInteger, MDPMatchStatusModelSportType) {
    MDPMatchStatusModelSportTypeFootball     = 1,
    MDPMatchStatusModelSportTypeBasket       = 2,
};


#pragma mark - Interface
@interface MDPMatchStatusModel : _MDPMatchStatusModel

+ (MDPMatchStatusModel *)matchStatusWithIdTeam:(NSString *)idTeam
                                     sportType:(MDPMatchStatusModelSportType)sportType
                          managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsMatchStatusWithIdTeam:(NSString *)idTeam
                                             sportType:(MDPMatchStatusModelSportType)sportType
                                            dictionary:(NSDictionary *)dictionary
                                  managedObjectContext:(NSManagedObjectContext *)context;

@end
