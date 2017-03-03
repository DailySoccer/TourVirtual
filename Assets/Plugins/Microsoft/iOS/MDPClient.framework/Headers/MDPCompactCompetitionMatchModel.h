//
//  MDPCompactCompetitionMatchModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPCompactCompetitionMatchModel.h"

#pragma mark - SportType
typedef NS_ENUM(NSInteger, MDPCompactCompetitionMatchModelSportType) {
    MDPCompactCompetitionMatchModelSportFootball        = 1,
    MDPCompactCompetitionMatchModelSportTypeBasket      = 2,
};


#pragma mark - Interface
@interface MDPCompactCompetitionMatchModel : _MDPCompactCompetitionMatchModel

+ (MDPCompactCompetitionMatchModel *)compactCompetitionMatchWithIdSeason:(NSString *)idSeason
                                                           idCompetition:(NSString *)idCompetition
                                                                 idMatch:(NSString *)idMatch
                                                    managedObjectContext:(NSManagedObjectContext *)context;

+ (MDPCompactCompetitionMatchModel *)compactCompetitionMatchWithIdSeason:(NSString *)idSeason
                                                           idCompetition:(NSString *)idCompetition
                                                                 idMatch:(NSString *)idMatch
                                                                language:(NSString *)language
                                                    managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsCompactCompetitionMatchWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;
+ (instancetype)insertIfNotExistsCompactCompetitionMatchWithDictionary:(NSDictionary *)dictionary language:(NSString *)language managedObjectContext:(NSManagedObjectContext *)context;

- (BOOL)isPreMatch;
- (BOOL)isStartedMatch;
- (BOOL)isFinishedMatchWithSport:(uint)sport;

@end
