//
//  MDPLiveFootBallSeasonCompetitionPlayerStatModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPLiveFootBallSeasonCompetitionPlayerStatModel.h"


#pragma mark - Interface
@interface MDPLiveFootBallSeasonCompetitionPlayerStatModel : _MDPLiveFootBallSeasonCompetitionPlayerStatModel

+ (NSArray *)liveFootBallSeasonCompetitionPlayerStatWithIdSeason:idSeason idCompetition:idCompetition idPlayer:(NSString *)idPlayer managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsLiveFootBallSeasonCompetitionTeamStatWithIdSeason:(NSString *)idSeason
                                                                     idCompetition:(NSString *)idCompetition
                                                                          idPlayer:(NSString *)idPlayer
                                                                        dictionary:(NSDictionary *)dictionary
                                                              managedObjectContext:(NSManagedObjectContext *)context;

@end
