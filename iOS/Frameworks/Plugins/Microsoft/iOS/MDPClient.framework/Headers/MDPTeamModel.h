//
//  MDPTeamModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPTeamModel.h"


#pragma mark - TeamType
typedef NS_ENUM(NSInteger, MDPTeamModelTeamType ) {
    MDPTeamModelTeamTypeFootballFirstDivision        = 0,
    MDPTeamModelTeamTypeFootballSecondDivision       = 1,
    MDPTeamModelTeamTypeBasket                       = 2,
} ;

#pragma mark Sport Type
typedef NS_ENUM(NSInteger, MDPTeamModelSportType) {
    MDPTeamModelSportTypeFootball   = 1,
    MDPTeamModelSportTypeBasket     = 2
} ;


#pragma mark - Interface
@interface MDPTeamModel : _MDPTeamModel

+ (MDPTeamModel *)teamWithIdTeam:(NSString *)idTeam managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsTeamWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
