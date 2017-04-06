//
//  MDPFootballLiveMatchTeamStatisticsModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPFootballLiveMatchTeamStatisticsModel.h"


#pragma mark - Interface
@interface MDPFootballLiveMatchTeamStatisticsModel : _MDPFootballLiveMatchTeamStatisticsModel

+ (MDPFootballLiveMatchTeamStatisticsModel *)footballLiveMatchTeamStatisticsWithIdSeason:(NSString *)idSeason
                                                                           idCompetition:(NSString *)idCompetition
                                                                                 idMatch:(NSString *)idMatch
                                                                                  idTeam:(NSString *)idTeam
                                                                    managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsFootballLiveMatchTeamStatisticsWithIdSeason:(NSString *)idSeason
                                                               idCompetition:(NSString *)idCompetition
                                                                  dictionary:(NSDictionary *)dictionary
                                                        managedObjectContext:(NSManagedObjectContext *)context;

@end
