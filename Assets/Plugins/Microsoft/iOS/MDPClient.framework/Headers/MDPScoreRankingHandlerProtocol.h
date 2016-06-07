//
//  MDPScoreRankingHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 17/12/15.
//  Copyright © 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPScoreRankingHandlerProtocol_h
#define MDPClient_MDPScoreRankingHandlerProtocol_h


#pragma mark - Response
typedef void (^MDPScoreRankingHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPScoreRankingHandlerProtocol
@protocol MDPScoreRankingHandlerProtocol <NSObject>

/*
 Store a score for a game
 */
+ (void)postScoreWithIdGame:(NSString *)idGame
                    idScore:(NSInteger)score
            completionBlock:(MDPScoreRankingHandlerResponseBlock)completionBlock;

/*
  Gets top 50 best scores for a game
 */
+ (void)getTopScoresWithIdGame:(NSString *)idGame
               completionBlock:(MDPScoreRankingHandlerResponseBlock)completionBlock;

@end


#endif /* MDPScoreRankingHandlerProtocol_h */
