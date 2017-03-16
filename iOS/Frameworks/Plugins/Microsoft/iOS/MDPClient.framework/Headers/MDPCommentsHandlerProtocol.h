//
//  MDPCommentsHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 1/12/15.
//  Copyright © 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPCommentsHandlerProtocol_h
#define MDPClient_MDPCommentsHandlerProtocol_h

#import "MDPPagedAnswersModel.h"


#pragma mark Content VoteType
typedef NS_ENUM(NSUInteger, MDPCommentsHandlerVoteType) {
    MDPCommentsHandlerVoteTypePositive          = 0,
    MDPCommentsHandlerVoteTypeNegative          = 1,
};

#pragma mark - MDPCommentsHandlerProtocol
@protocol MDPCommentsHandlerProtocol <NSObject>

/*
 Write a new answer to a comment.
 */
+ (void)postAnswerWithIdGroup:(NSString *)idGroup
                     idThread:(NSString *)idThread
                   idComments:(NSString *)idComments
                         text:(NSString *)text
              completionBlock:(void(^)(NSError *error))completionBlock;


/*
 Reports an abusive message.
 */
+ (void)postReportAbuseWithIdGroup:(NSString *)idGroup
                          idThread:(NSString *)idThread
                         idMessage:(NSString *)idMessage
                   completionBlock:(void(^)(NSError *error))completionBlock;


/*
 Delete a comment.
 */
+ (void)deleteCommentWithIdGroup:(NSString *)idGroup
                        idThread:(NSString *)idThread
                       idMessage:(NSString *)idMessage
                 completionBlock:(void(^)(NSError *error))completionBlock;


/*
 Vote a comment.
 */
+ (void)putVoteCommentWithIdGroup:(NSString *)idGroup
                         idThread:(NSString *)idThread
                        idMessage:(NSString *)idMessage
                         voteType:(MDPCommentsHandlerVoteType)voteType
                  completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Gets all answers of a specific comment.
 */
+ (void)getCommentAnswersWithIdGroup:(NSString *)idGroup
                            idThread:(NSString *)idThread
                           idMessage:(NSString *)idMessage
                                  ct:(NSString *)ct
                     completionBlock:(void(^)(MDPPagedAnswersModel *content, NSError *error))completionBlock;

@end


#endif /* MDPCommentsHandlerProtocol_h */
