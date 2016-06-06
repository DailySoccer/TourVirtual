//
//  MDPPlayerModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPPlayerModel.h"


#pragma mark PlayerPreferredFoot
typedef NS_ENUM(NSInteger, MDPPlayerPreferredFoot ) {
    MDPPlayerPreferredFootLeft   = 0,
    PlayerPreferredFootRight    = 1,
};


#pragma mark - SportType
typedef NS_ENUM(NSInteger, MDPPlayerModelSportType) {
    MDPPlayerModelSportTypeFootball  = 1,
    MDPPlayerModelSportTypeBasket    = 2,
};


#pragma mark - Interface
@interface MDPPlayerModel : _MDPPlayerModel

+ (MDPPlayerModel *)playerWithIdTeam:(NSString *)idTeam idPlayer:(NSString *)idPlayer managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsPlayerWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
