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
 Gets a player statistics in a specified match. A player statistic is identified by two fields: id of the player, and the id of the match.
 */
+ (void)getBasketLiveMatchPlayerStatisticsWithIdSeason:(NSString *)idSeason
                                         idCompetition:(NSString *)idCompetition
                                               idMatch:(NSString *)idMatch
                                              idPlayer:(NSString *)idPlayer
                                              language:(NSString *)language
                                       completionBlock:(void(^)(MDPBasketLiveMatchPlayerStatisticsModel *content, NSError *error))completionBlock;


/*
 Gets a team statistics in a specified match. A team statistic is identified by four fields: id of the season, competition, team, and the id of the match.
 */
+ (void)getBasketLiveMatchTeamStatisticsWithIdSeason:(NSString *)idSeason
                                           idCompetition:(NSString *)idCompetition
                                                 idMatch:(NSString *)idMatch
                                                  idTeam:(NSString *)idTeam
                                                language:(NSString *)language
                                          completionBlock:(void(^)(MDPBasketLiveMatchTeamStatisticsModel *content, NSError *error))completionBlock;

@end

#endif
