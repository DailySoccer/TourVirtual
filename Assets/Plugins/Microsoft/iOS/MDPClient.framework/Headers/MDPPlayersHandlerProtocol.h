//
//  MDPPlayersHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 16/1/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPPlayersHandlerProtocol_h
#define MDPClient_MDPPlayersHandlerProtocol_h

#pragma mark - Model
#import "MDPCareerDetailModel.h"
#import "MDPContentModel.h"
#import "MDPHonourModel.h"
#import "MDPLocaleDescriptionModel.h"
#import "MDPPlayerModel.h"
#import "MDPMediaContentModel.h"
#import "MDPPlayerStatisticModel.h"
#import "MDPPlayerStatisticValueModel.h"
#import "MDPPreferredPlayerModel.h"
#import "MDPPagedTweetModel.h"

#pragma mark  - Response
typedef void (^MDPPlayersHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPPlayerServiceHandlerProtocol
@protocol MDPPlayersHandlerProtocol <NSObject>

/* Get a player identified by two fields: id of the team and id of the player.
 */
+ (void)getPlayerWithIdTeam:(NSString *)idTeam
                   idPlayer:(NSString *)idPlayer
                   language:(NSString *)language
            completionBlock:(void(^)(MDPPlayerModel *content, NSError *error))completionBlock;

/* Get a player statidistics identified by three fields: id of the player, id of the season and id of the competition.
 */
+ (void)getPlayerStatisticsWithIdSeason:(NSString *)idSeason
                          idCompetition:(NSString *)idCompetition
                               idPlayer:(NSString *)idPlayer
                               language:(NSString *)language
                        completionBlock:(void(^)(MDPPlayerStatisticModel *content, NSError *error))completionBlock;

/*
  Send the preferred players by id, name, order and sport
 */
+ (void)postPreferredPlayerWithPlayerId:(NSString *)playerId
                             playerName:(NSString *)playerName
                                  order:(uint)order
                                  sport:(MDPPlayerModelSportType)sport
                        completionBlock:(void(^)(NSError *error))completionBlock;

/*
  Get the preferred players identified by a sport
 */
+ (void)getPreferredPlayersWithSport:(MDPPlayerModelSportType)sportType
                      completionBlock:(MDPPlayersHandlerResponseBlock)completionBlock;

/*
  Deletes a preferred player identified by his id
 */
+ (void)removePreferredPlayerWithIdPlayer:(NSString *)idPlayer
                          completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Get the paginated list of player tweets.
 */
+ (void)getPlayerTweetsWithIdTeam:(NSString *)idTem
                         idPlayer:(NSString *)idTeam
                               ct:(uint)ct
                         language:(NSString *)language
                  completionBlock:(void(^)(MDPPagedTweetModel *content, NSError *error))completionBlock;

@end

#endif
