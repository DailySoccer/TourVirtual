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


#pragma mark - MDPScoresHandlerProtocol
@protocol MDPScoresHandlerProtocol <NSObject>

/*
 Gets best fan score for a game
 */
+ (void)getFanMaxScoreWithIdGame:(NSString *)idGame
                 completionBlock:(void(^)(MDPFanMaxScoreModel *content, NSError *error))completionBlock;

@end

#endif /* MDPScoresHandlerProtocol_h */
