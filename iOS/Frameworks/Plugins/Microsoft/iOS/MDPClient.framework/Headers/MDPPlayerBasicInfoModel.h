//
//  MDPPlayerBasicInfoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPPlayerBasicInfoModel.h"


#pragma mark - PlayerPosition
typedef NS_ENUM(NSInteger, MDPPlayerBasicInfoModelPlayerPosition ) {
    MDPPlayersBasicInfoModelPlayerPositionGoalkeeper                 = 1002,
    MDPPlayersBasicInfoModelPlayerPositionDefender                   = 1003,
    MDPPlayersBasicInfoModelPlayerPositionWingback                   = 1004,
    MDPPlayersBasicInfoModelPlayerPositionFullback                   = 1005,
    MDPPlayersBasicInfoModelPlayerPositionStriker                    = 1006,
    MDPPlayersBasicInfoModelPlayerPositionCentralDefender            = 1007,
    MDPPlayersBasicInfoModelPlayerPositionDefensiveMidfieldler       = 1008,
    MDPPlayersBasicInfoModelPlayerPositionAttackingMidfielder        = 1009,
    MDPPlayersBasicInfoModelPlayerPositionCentralMidfieldler         = 1010,
    MDPPlayersBasicInfoModelPlayerPositionWinger                     = 1011,
    MDPPlayersBasicInfoModelPlayerPositionSecondStriker              = 1012,
    MDPPlayersBasicInfoModelPlayerPositionMiddlefielder              = 1020,
    MDPPlayersBasicInfoModelPlayerPositionForward                    = 1021,
};


#pragma mark - PlayerSide
typedef NS_ENUM(NSInteger, MDPPlayerBasicInfoModelPlayerSide ) {
    MDPPlayersBasicInfoModelPlayerSideLeft                           = 1013,
    MDPPlayersBasicInfoModelPlayerSideRight                          = 1014,
    MDPPlayersBasicInfoModelPlayerSideCentre                         = 1015,
    MDPPlayersBasicInfoModelPlayerSideLeftCentre                     = 1016,
    MDPPlayersBasicInfoModelPlayerSideCentreRight                    = 1017,
    MDPPlayersBasicInfoModelPlayerSideLeftCentreRight                = 1018,
    MDPPlayersBasicInfoModelPlayerSideLeftRight                      = 1019,
};


#pragma mark - PlayerSide
typedef NS_ENUM(NSInteger, MDPPlayerBasicInfoModelPlayerBasket ) {
    MDPPlayerBasicInfoModelPlayerBasketBase                          = 2001,
    MDPPlayerBasicInfoModelPlayerBasketGuard                         = 2002,
    MDPPlayerBasicInfoModelPlayerBasketForward                       = 2003,
    MDPPlayerBasicInfoModelPlayerBasketCenterForward                 = 2004,
    MDPPlayerBasicInfoModelPlayerBasketPivot                         = 2005,
    MDPPlayerBasicInfoModelPlayerBasketBaseAlero                     = 2006,
};


#pragma mark - Interface
@interface MDPPlayerBasicInfoModel : _MDPPlayerBasicInfoModel

+ (NSArray *)teamPlayersWithIdTeam:(NSString *)idTeam managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)playerWithPlayer:(NSString *)idPlayer team:(NSString *)idTeam managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsPlayerBasicInfoWithDictionary:(NSDictionary *)dictionary order:(uint)order managedObjectContext:(NSManagedObjectContext *)context;

@end
