//
//  MDPLiveFootBallSeasonCompetitionTeamStatModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPLiveFootBallSeasonCompetitionTeamStatModel.h"


#pragma mark - Interface
@interface MDPLiveFootBallSeasonCompetitionTeamStatModel : _MDPLiveFootBallSeasonCompetitionTeamStatModel

+ (NSArray *)liveFootBallSeasonCompetitionTeamStatWithIdSeason:idSeason
                                                 idCompetition:idCompetition
                                                        idTeam:(NSString *)idTeam
                                          managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsLiveFootBallSeasonCompetitionTeamStatWithIdSeason:idSeason
                                                                     idCompetition:idCompetition
                                                                        dictionary:(NSDictionary *)dictionary
                                                              managedObjectContext:(NSManagedObjectContext *)context;

@end
