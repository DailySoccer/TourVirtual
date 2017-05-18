//
//  MDPLiveFootBallSeasonCompetitionStatModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPLiveFootBallSeasonCompetitionStatModel.h"


#pragma mark - Interface
@interface MDPLiveFootBallSeasonCompetitionStatModel : _MDPLiveFootBallSeasonCompetitionStatModel

+ (NSArray *)liveFootBallSeasonCompetitionStatWithIdSeason:idSeason idCompetition:idCompetition managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsLiveFootBallSeasonCompetitionTeamStatWithIdSeason:idSeason
                                                                     idCompetition:idCompetition
                                                                        dictionary:(NSDictionary *)dictionary
                                                              managedObjectContext:(NSManagedObjectContext *)context;

@end
