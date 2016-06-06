//
//  MDPLiveFootBallSeasonCompetitionTeamPlayersStatModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPLiveFootBallSeasonCompetitionTeamPlayersStatModel.h"


#pragma mark - Interface
@interface MDPLiveFootBallSeasonCompetitionTeamPlayersStatModel : _MDPLiveFootBallSeasonCompetitionTeamPlayersStatModel

+ (NSArray *)liveFootBallSeasonCompetitionTeamPlayersStatWithIdSeason:idSeason
                                                        idCompetition:(NSString *)idCompetition
                                                               idTeam:(NSString *)idTeam
                                                 managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsLiveFootBallSeasonPlayerStatWithIdSeason:idSeason
                                                            idCompetition:(NSString *)idCompetition
                                                                   idTeam:(NSString *)idTeam
                                                               dictionary:(NSDictionary *)dictionary
                                                     managedObjectContext:(NSManagedObjectContext *)context;

@end
