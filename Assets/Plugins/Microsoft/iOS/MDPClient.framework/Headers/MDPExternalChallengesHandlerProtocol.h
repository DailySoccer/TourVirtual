//
//  MDPExternalChallengesHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 28/1/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPExternalChallengesHandlerProtocol_h
#define MDPClient_MDPExternalChallengesHandlerProtocol_h

#import "MDPExternalChallengeModel.h"
#import "MDPExternalChallengeTypeModel.h"
#import "MDPPagedExternalChallengeTypeModel.h"


#pragma mark  - Response
typedef void (^MDPExternalChallengesHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPExternalChallengesHandlerProtocol
@protocol MDPExternalChallengesHandlerProtocol <NSObject>

/*
 Sends to platform the participation of current user in a external challenge
 */
+ (void)postExternalChallengeParticipationWithIdExternalChallenge:(NSString *)idExternalChallenge
                                                  completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Gets an external challenge participationb by his idExternalChallenge
 */
+ (void)getExternalChallengeParticipationByIdWithIdExternalChallenge:(NSString *)idExternalChallenge
                                                     completionBlock:(void(^)(MDPExternalChallengeModel *content, NSError *error))completionBlock;
/*
 Get all the ExternalChallenges
 */
+ (void)getExternalChallengesWithCompletionBlock:(MDPExternalChallengesHandlerResponseBlock)completionBlock;

/*
 Gets an external challenge type of external challenges availables
 */
+ (void)getExternalChallengeTypeByIdWithIdExternalChallenge:(NSString *)idExternalChallenge
                                            completionBlock:(void(^)(MDPExternalChallengeTypeModel *content, NSError *error))completionBlock;

/*
 Gets a paginated list of all external challenge types
 */
+ (void)getExternalChallengeTypesWithCt:(int)ct
                        completionBlock:(void(^)(MDPPagedExternalChallengeTypeModel *content, NSError *error))completionBlock;

@end

#endif
