//
//  MDPFootballLiveMatchHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 11/3/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPFootballLiveMatchHandlerProtocol_h
#define MDPClient_MDPFootballLiveMatchHandlerProtocol_h

#import "MDPFootballLiveMatchModel.h"
#import "MDPFootballLiveMatchTeamStatisticsModel.h"
#import "MDPFootballLiveMatchPlayerStatisticsModel.h"
#import "MDPLiveFootBallSeasonCompetitionTeamStatModel.h"

#pragma mark  - Response
typedef void (^MDPFootballLiveMatchHandlerProtocol)(NSArray *response, NSError *error);

@protocol MDPFootballLiveMatchHandlerProtocol <NSObject>


/*
 Gets a player statistics in a specified match. A player statistic is identified by two fields: id of the player, and the id of the match.
 */
+ (void)getFootballLiveMatchPlayerStatisticsWithIdSeason:(NSString *)idSeason
                                           idCompetition:(NSString *)idCompetition
                                                 idMatch:(NSString *)idMatch
                                                idPlayer:(NSString *)idPlayer
                                                language:(NSString *)language
                                         completionBlock:(void (^)(MDPFootballLiveMatchPlayerStatisticsModel *content, NSError *error))completionBlock;

/*
 Gets a team statistics in a specified match. A team statistic is identified by two fields: id of the team, and the id of the match.
 */
+ (void)getFootballLiveMatchTeamStatisticsWithIdSeason:(NSString *)idSeason
                                         idCompetition:(NSString *)idCompetition
                                               idMatch:(NSString *)idMatch
                                                idTeam:(NSString *)idTeam
                                              language:(NSString *)language
                                       completionBlock:(void(^)(MDPFootballLiveMatchTeamStatisticsModel *content, NSError *error))completionBlock;


/*
 Gets a football match statistics. A match statistic is identified by three fields. Id of season, id of the competition and id of the match
*/
+ (void)getFootballLiveMatchStatisticsWithIdSeason:(NSString *)idSeason
                                     idCompetition:(NSString *)idCompetition
                                           idMatch:(NSString *)idMatch
                                          language:(NSString *)language
                                   completionBlock:(void(^)(MDPFootballLiveMatchModel *content, NSError *error))completionBlock;


/*
 Gets a collection of statisitics for a team by season and competition. A team statistic is identified by three fields. Id of season, id of the competition and id of the team.
 */
+ (void)getFootballLiveMatchSeasonCompetitionTeamStatisticsWithIdSeason:(NSString *)idSeason
                                                          idCompetition:(NSString *)idCompetition
                                                                 idTeam:(NSString *)idTeam
                                                               language:(NSString *)language
                                                        completionBlock:(MDPFootballLiveMatchHandlerProtocol)completionBlock;


/* Gets a collection of statisitics by season and competition. A team statistic is identified by two fields. Id of season and id of the competition.
 */
+ (void)getFootballLiveMatchSeasonCompetitionStatisticsWithIdSeason:(NSString *)idSeason
                                                      idCompetition:(NSString *)idCompetition
                                                           language:(NSString *)language
                                                    completionBlock:(MDPFootballLiveMatchHandlerProtocol)completionBlock;

/*
 Gets a collection of statisitics for a player by season and competition. A team statistic is identified by three fields. Id of the season, id of the competition and id of the player.
 */
+ (void)getFootballLiveMatchSeasonCompetitionPlayerStatisticsWithIdSeason:(NSString *)idSeason
                                                            idCompetition:(NSString *)idCompetition
                                                                 idPlayer:(NSString *)idPlayer
                                                                 language:(NSString *)language
                                                          completionBlock:(MDPFootballLiveMatchHandlerProtocol)completionBlock;

/*
 Gets a collection of statisitics for a player by season. A statistic is identified by two fields. Id of the season and id of the player.
 */
+ (void)getFootballLiveMatchSeasonPlayerStatisticsWithIdSeason:(NSString *)idSeason
                                                      idPlayer:(NSString *)idPlayer
                                                      language:(NSString *)language
                                               completionBlock:(MDPFootballLiveMatchHandlerProtocol)completionBlock;

/*
 Gets a collection of statisitics for all players of a team. A statistic is identified by three fields. Id of the season, id of the competition and id of the team.
 */
+ (void)getFootballLiveMatchPlayerStatisticsWithIdSeason:(NSString *)idSeason
                                           idCompetition:(NSString *)idCompetition
                                                  idTeam:(NSString *)idTeam
                                                language:(NSString *)language
                                         completionBlock:(MDPFootballLiveMatchHandlerProtocol)completionBlock;

+ (NSFetchedResultsController *)footballLiveMatchFetchedResultsControllerWithIdSeason:(NSString *)idSeason
                                                                        idCompetition:(NSString *)idCompetition
                                                                              idMatch:(NSString *)idMatch delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end

#endif






















