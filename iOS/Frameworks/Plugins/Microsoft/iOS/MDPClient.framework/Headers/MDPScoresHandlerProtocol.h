//
//  MDPScoresHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 18/2/16.
//  Copyright © 2016 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPScoresHandlerProtocol_h
#define MDPClient_MDPScoresHandlerProtocol_h

#import "MDPFanMaxScoreModel.h"


#pragma mark - Response
typedef void (^MDPScoresHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPScoresHandlerProtocol
@protocol MDPScoresHandlerProtocol <NSObject>

/*
 Store a score for a game
 */
+ (void)postScoreWithIdGame:(NSString *)idGame
                    idScore:(NSInteger)score
            completionBlock:(MDPScoresHandlerResponseBlock)completionBlock;

/*
 Gets top 50 best scores for a game
 */
+ (void)getTopScoresWithIdGame:(NSString *)idGame
               completionBlock:(MDPScoresHandlerResponseBlock)completionBlock;

/*
 Gets best fan score for a game
 */
+ (void)getFanMaxScoreWithIdGame:(NSString *)idGame
                 completionBlock:(void(^)(MDPFanMaxScoreModel *content, NSError *error))completionBlock;

@end

#endif /* MDPScoresHandlerProtocol_h */
