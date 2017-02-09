//
//  MDPBasketLiveMatchHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 11/3/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPBasketLiveMatchHandlerProtocol_h
#define MDPClient_MDPBasketLiveMatchHandlerProtocol_h

#import "MDPBasketLiveMatchModel.h"
#import "MDPBasketLiveMatchTeamStatisticsModel.h"
#import "MDPBasketLiveMatchPlayerStatisticsModel.h"
#import "MDPBasketSeasonCompetitionTeamStatisticsModel.h"
#import "MDPBasketSeasonPlayerStatisticsModel.h"


#pragma mark  - Response
typedef void (^MDPBasketLiveMatchHandlerResponseBlock)(NSArray *response, NSError *error);



#pragma mark - MDPBasketLiveMatchHandlerProtocol
@protocol MDPBasketLiveMatchHandlerProtocol <NSObject>

/*
 Gets a basket match statistics. A match statistic is identified by three fields. Id of season, id of the competition and id of the match
 */
+ (void)getBasketLiveMatchStatisticsWithIdSeason:(NSString *)idSeason
                                   idCompetition:(NSString *)idCompetition
                                         idMatch:(NSString *)idMatch
                                        language:(NSString *)language
                                 completionBlock:(void(^)(MDPBasketLiveMatchModel *content, NSError *error))completionBlock;

/*
 Gets a team statistics in a specified match. A team statistic is identified by four fields: id of the season, competition, team, and the id of the match.
 */
+ (void)getBasketLiveMatchTeamStatisticsWithIdSeason:(NSString *)idSeason
                                       idCompetition:(NSString *)idCompetition
                                             idMatch:(NSString *)idMatch
                                              idTeam:(NSString *)idTeam
                                            language:(NSString *)language
                                     completionBlock:(void(^)(MDPBasketLiveMatchTeamStatisticsModel *content, NSError *error))completionBlock;

/*
 Gets a player statistics in a specified match. A player statistic is identified by two fields: id of the player, and the id of the match.
 */
+ (void)getBasketLiveMatchPlayerStatisticsWithIdSeason:(NSString *)idSeason
                                         idCompetition:(NSString *)idCompetition
                                               idMatch:(NSString *)idMatch
                                              idPlayer:(NSString *)idPlayer
                                              language:(NSString *)language
                                       completionBlock:(void(^)(MDPBasketLiveMatchPlayerStatisticsModel *content, NSError *error))completionBlock;

/*
 Gets a collection of statisitics for a player by season. A statistic is identified by two fields. Id of the season and id of the player.
 */
+ (void)getLiveBasketSeasonPlayerStatWithIdSeason:(NSString *)idSeason
                                         idPlayer:(NSString *)idPlayer
                                  completionBlock:(void(^)(MDPBasketSeasonPlayerStatisticsModel *content, NSError *error))completionBlock;

/*
 Gets a collection of statisitics by season and competition. A team statistic is identified by two fields. Id of season and id of the competition.
 */
+ (void)getLiveBasketSeasonCompetitionStatWithIdSeason:(NSString *)idSeason
                                         idCompetition:(NSString *)idCompetition
                                       completionBlock:(MDPBasketLiveMatchHandlerResponseBlock)completionBlock;

/*
 Gets a player statistics in a specified season and competition.
 */
+ (void)getTeamPlayerStatsBySeasonAndCompetitionWithIdSeason:(NSString *)idSeason
                                               idCompetition:(NSString *)idCompetition
                                                      idTeam:(NSString *)idTeam
                                             completionBlock:(void(^)(NSArray *content, NSError *error))completionBlock;

/*
 Gets a team statistics in a specified season and competition.
 */
+ (void)getTeamStatsBySeasonAndCompetitionWithIdSeason:(NSString *)idSeason
                                         idCompetition:(NSString *)idCompetition
                                                idTeam:(NSString *)idTeam
                                       completionBlock:(void(^)(MDPBasketSeasonCompetitionTeamStatisticsModel *content, NSError *error))completionBlock;

@end

#endif
