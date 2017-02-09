//
//  MDPUserActionsHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 9/4/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPUserActionsHandlerProtocol_h
#define MDPClient_MDPUserActionsHandlerProtocol_h

#import "MDPPagedUserActionHistoryModel.h"


#pragma mark  - Response
typedef void (^MDPUserActionsHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPUserActionsHandlerProtocol
@protocol MDPUserActionsHandlerProtocol <NSObject>

/*Register in the platform an action performed by current user using a specific client. To get available actions for a client use
 */
+ (void)postUserActionWithActionId:(NSString *)actionId
                       contextData:(NSString *)contextData
                   completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Register in the platform an action performed by a client for an user. To get available actions for a client use
 */
+ (void)postUserActionByClientWithUserId:(NSString *)userId
                                actionId:(NSString *)actionId
                             contextData:(NSString *)contextData
                         completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Gets user timeline
 */
+ (void)getTimelineWithIdUser:(NSString *)idUser
                           ct:(NSString *)ct
                     language:(NSString *)language
                     idAction:(NSString *)idAction
              completionBlock:(void(^)(MDPPagedUserActionHistoryModel *response, NSError *error))completionBlock;

/*
 FetchResultsController
 */
+ (NSFetchedResultsController *)userActionHistoryFetchedResultsControllerWithIdUser:(NSString *)idUser
                                                                           delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

/*
 Deletes all MDPUserActionHistoryModel for a UserId
 */
+ (void)deleteAllUserActionsHistoryWithIdUser:(NSString *)idUser;

@end

#endif
