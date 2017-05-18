//
//  MDPMatchModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPMatchModel.h"

#pragma mark - MatchType
typedef NS_ENUM(NSInteger, MDPMatchModelMatchType) {
    MDPMatchModelMatchTypeFootballFirstDivision   = 0,
    MDPMatchModelMatchTypeFootballSecondDivision  = 1,
    MDPMatchModelMatchTypeBasket                  = 2,
};

#pragma mark - SportType
typedef NS_ENUM(NSInteger, MDPMatchModelSportType) {
    MDPMatchModelSportTypeFootball  = 1,
    MDPMatchModelSportTypeBasket    = 2,
};


#pragma mark - Interface
@interface MDPMatchModel : _MDPMatchModel

+ (MDPMatchModel *)matchWithIdSeason:(NSString *)idSeason
                       idCompetition:(NSString *)idCompetition
                             idMatch:(NSString *)idMatch
                             country:(NSString *)country
                managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsMatchWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsMatchWithCountry:(NSString *)country dictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
