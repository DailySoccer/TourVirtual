//
//  MDPFootballLiveMatchPlayerStatisticsModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPFootballLiveMatchPlayerStatisticsModel.h"


#pragma mark - Interface
@interface MDPFootballLiveMatchPlayerStatisticsModel : _MDPFootballLiveMatchPlayerStatisticsModel

+ (MDPFootballLiveMatchPlayerStatisticsModel *)footballLiveMatchPlayerStatisticsWithIdSeason:(NSString *)idSeason
                                                                               idCompetition:(NSString *)idCompetition
                                                                                     idMatch:(NSString *)idMatch
                                                                                    idPlayer:(NSString *)idPlayer
                                                                        managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsFootballLiveMatchPlayerStatisticsWithIdSeason:(NSString *)idSeason
                                                                 idCompetition:(NSString *)idCompetition
                                                                    dictionary:(NSDictionary *)dictionary
                                                          managedObjectContext:(NSManagedObjectContext *)context;

@end
