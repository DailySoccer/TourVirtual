//
//  MDPCompetitionMatchModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPCompetitionMatchModel.h"

#pragma mark Sport Type
typedef NS_ENUM(NSInteger, MDPCompetitionMatchModelSportType) {
    MDPCompetitionMatchModelSportTypeFootball   = 1,
    MDPCompetitionMatchModelSportTypeBasket   = 2
} ;


#pragma mark - Interface
@interface MDPCompetitionMatchModel : _MDPCompetitionMatchModel

+ (MDPCompetitionMatchModel *)previousCompetitionMatchWithIdTeam:(NSString *)idTeam
                                                       sportType:(MDPCompetitionMatchModelSportType)sportType
                                                   includeRecent:(BOOL)includeRecent
                                                         country:(NSString *)country
                                            managedObjectContext:(NSManagedObjectContext *)context;

+ (NSArray *)competitionMatchWithIdSeason:(NSString *)idSeason idCompetition:(NSString *)idCompetition
                                 language:(NSString *)language matchDay:(NSString *)matchDay
                                   idTeam:(NSString *)idTeam
                                  country:(NSString *)country
                     managedObjectContext:(NSManagedObjectContext *)context;

+ (NSArray *)competitionMatchWithIdSeason:(NSString *)idSeason
                            idCompetition:(NSString *)idCompetition
                                 language:(NSString *)language
                                    round:(NSString *)round
                                   idTeam:(NSString *)idTeam
                                  country:(NSString *)country
                     managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsCompetitionMatchWithIdTeam:(NSString *)idTeam
                                                 dictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsCompetitionMatchWithIdTeam:(NSString *)idTeam
                                              includeRecent:(BOOL)includeRecent
                                                    country:(NSString *)country
                                                 dictionary:(NSDictionary *)dictionary
                                       managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsCompetitionMatchWithIdSeason:(NSString *)idSeason
                                                idCompetition:(NSString *)idCompetition
                                                     language:(NSString *)language
                                                        round:(NSString *)round
                                                       idTeam:(NSString *)idTeam
                                                      country:(NSString *)country
                                                   dictionary:(NSDictionary *)dictionary
                                         managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsCompetitionMatchWithIdSeason:(NSString *)idSeason
                                                idCompetition:(NSString *)idCompetition
                                                     language:(NSString *)language
                                                     matchDay:(NSString *)matchDay
                                                       idTeam:(NSString *)idTeam
                                                      country:(NSString *)country
                                                   dictionary:(NSDictionary *)dictionary
                                         managedObjectContext:(NSManagedObjectContext *)context;

+ (NSArray *)fetchCompetitionMatchWithIdSeason:(NSString *)idSeason
                                 idCompetition:(NSString *)idCompetition
                                         month:(NSDate *)date
                          managedObjectContext:(NSManagedObjectContext *)context;

+ (NSArray *)fetchCompetitionMatchWithIdSeason:(NSString *)idSeason
                                 idCompetition:(NSString *)idCompetition
                                         month:(NSDate *)date
                                        idTeam:(NSString *)idTeam
                          managedObjectContext:(NSManagedObjectContext *)context;

+ (NSArray *)fetchCompetitionMatchWithIdSeason:(NSString *)idSeason
                                 idCompetition:(NSString *)idCompetition
                                        idTeam:(NSString *)idTeam
                          managedObjectContext:(NSManagedObjectContext *)context;

+ (NSArray *)fetchCompetitionMatchWithIdSeason:(NSString *)idSeason
                                 idCompetition:(NSString *)idCompetition
                                        idTeam:(NSString *)idTeam
                                oppositeIdTeam:(NSString *)oppositeIdTeam
                          managedObjectContext:(NSManagedObjectContext *)context;

- (BOOL)isStartedMatch;

- (BOOL)isPreMatch;

- (BOOL)isFinishedMatchWithSport:(uint)sport;

@end
