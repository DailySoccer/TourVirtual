//
//  MDPMessagesHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 18/11/15.
//  Copyright © 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPMessagesHandlerProtocol_h
#define MDPClient_MDPMessagesHandlerProtocol_h

#import "MDPPagedMessagesModel.h"
#import "MDPMessageModel.h"


#pragma mark - Response
typedef void (^MDPMessagesHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPMessagesHandlerProtocol
@protocol MDPMessagesHandlerProtocol <NSObject>


/*
 Sends a message to a friend.
 */
+ (void)postMessageWithIdThread:(NSString *)idThread
                     idReceiver:(NSString *)idReceiver
                           text:(NSString *)text
                completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Reads a message from a thread.
 */
+ (void)getMessageWithIdThread:(NSString *)idThread
                     idMessage:(NSString *)idMessage
               completionBlock:(void(^)(MDPMessageModel *content, NSError *error))completionBlock;


/*
 Read the following messages from a user.
 */
+ (void)getMessagesFromUserWithIdThread:(NSString *)idThread
                                     ct:(NSString *)ct
                        completionBlock:(void(^)(MDPPagedMessagesModel *content, NSError *error))completionBlock;

@end

#endif
