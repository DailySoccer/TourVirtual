//
//  MDPTeamHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 19/1/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPTeamHandlerProtocol_h
#define MDPClient_MDPTeamHandlerProtocol_h


#pragma mark - Model
#import "MDPPlayerBasicInfoModel.h"
#import "MDPTeamModel.h"
#import "MDPTeamStatisticModel.h"
#import "MDPPagedTweetModel.h"


#pragma mark - Response
typedef void (^MDPTeamHandlerResponseBlock)(NSArray *response, NSError *error);

@protocol MDPTeamHandlerProtocol <NSObject>

/*
 Gets a team entity identified by one field: id of the team.
 */
+ (void)getTeamWithUseCache:(BOOL)useCache idTeam:(NSString *)idTeam
                   language:(NSString *)language
            completionBlock:(void(^)(MDPTeamModel *content, NSError *error))completionBlock;

/*
 Gets a collection of team's players identified by one field: id of the team
 */
+ (void)getTeamPlayersWithUseCache:(BOOL)useCache idTeam:(NSString *)idTeam
                          language:(NSString *)language
                   completionBlock:(MDPTeamHandlerResponseBlock)completionBlock;

/*
 Gets a team statistics identified by one field: id of the team
 */
+ (void)getTeamStatisticsWithIdSeason:(NSString *)idSeason
                        idCompetition:(NSString *)idCompetition
                               idTeam:(NSString *)idTeam
                             language:(NSString *)language
                      completionBlock:(void(^)(MDPTeamStatisticModel *content, NSError *error))completionBlock;

+ (void)getTeamTweetsWithUseCache:(BOOL)useCache
                           idTeam:(NSString *)idTeam
                               ct:(uint)ct
                         language:(NSString *)language
                  completionBlock:(void(^)(MDPPagedTweetModel *content, NSError *error))completionBlock;

/*
 Search parameter text in teams name and return the matches
 */
+ (void)searchTeamsByNameWithText:(NSString *)text
                        sportType:(MDPTeamModelSportType)sportType
                              top:(NSInteger)top
                         language:(NSString *)language
                  completionBlock:(MDPTeamHandlerResponseBlock)completionBlock;

/*
 Gets a player identified by two fields: idplayer and idTeam
 */
+ (MDPPlayerBasicInfoModel *)playerBasicInfoWithTeam:(NSString *)idTeam
                                              player:(NSString *)idPlayer;

/*
 Filters
 */
+ (MDPPlayerBasicInfoModel *)playerWithIdPlayer:(NSString *)playerId inArray:(NSArray *)arrayOfPlayerBasicInfo;

@end
#endif
