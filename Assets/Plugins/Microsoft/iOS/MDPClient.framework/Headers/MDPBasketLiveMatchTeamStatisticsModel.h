//
//  MDPBasketLiveMatchTeamStatisticsModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPBasketLiveMatchTeamStatisticsModel.h"


#pragma mark - Interface
@interface MDPBasketLiveMatchTeamStatisticsModel : _MDPBasketLiveMatchTeamStatisticsModel

+ (MDPBasketLiveMatchTeamStatisticsModel *)basketLiveMatchTeamStatisticsWithIdSeason:idSeason idCompetition:idCompetition
                                                                             idMatch:(NSString *)idMatch
                                                                              idTeam:(NSString *)idTeam
                                                                managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsBasketLiveMatchTeamStatisticsWithDictionary:(NSDictionary *)dictionary
                                                        managedObjectContext:(NSManagedObjectContext *)context;

@end
