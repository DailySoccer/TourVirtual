//
//  MDPRankingHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 17/12/15.
//  Copyright © 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPRankingHandlerProtocol_h
#define MDPClient_MDPRankingHandlerProtocol_h


#import "MDPExperienceRankingModel.h"


#pragma mark - Response
typedef void (^MDPRankingHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPRankingHandlerProtocol
@protocol MDPRankingHandlerProtocol <NSObject>

/*
  Return top 10 and ranking for current user (with nearby) for specific client app
 */
+ (void)getCurrentUserRankingWithCompletionBlock:(MDPRankingHandlerResponseBlock)completionBlock;

/*
 Return ranking position for specific user for a specific client app
 */
+ (void)getUserRankingWithIdUser:(NSString *)idUser
                 completionBlock:(void(^)(MDPExperienceRankingModel *content, NSError *error))completionBlock;

@end

#endif /* MDPRankingHandlerProtocol_h */
